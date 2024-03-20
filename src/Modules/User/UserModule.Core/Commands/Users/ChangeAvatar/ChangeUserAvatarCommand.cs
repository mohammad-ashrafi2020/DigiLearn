using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Common.Application.SecurityUtil;
using Common.EventBus.Abstractions;
using Common.EventBus.Events;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using UserModule.Core.Services;
using UserModule.Data;

namespace UserModule.Core.Commands.Users.ChangeAvatar;

public class ChangeUserAvatarCommand : IBaseCommand
{
    public Guid UserId { get; set; }
    public IFormFile AvatarFile { get; set; }
}

public class ChangeUserAvatarCommandHandler : IBaseCommandHandler<ChangeUserAvatarCommand>
{
    private readonly UserContext _context;
    private readonly ILocalFileService _localFileService;
    private readonly IEventBus _eventBus;

    public ChangeUserAvatarCommandHandler(UserContext context, ILocalFileService localFileService, IEventBus eventBus)
    {
        _context = context;
        _localFileService = localFileService;
        _eventBus = eventBus;
    }

    public async Task<OperationResult> Handle(ChangeUserAvatarCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FirstOrDefaultAsync(f => f.Id == request.UserId, cancellationToken);
        if (user == null)
        {
            return OperationResult.NotFound();
        }

        if (request.AvatarFile.IsImage() == false)
        {
            return OperationResult.Error("عکس نانعتبر است");
        }

        var avatar =
            await _localFileService.SaveFileAndGenerateName(request.AvatarFile, UserModuleDirectories.UserAvatar);
        user.Avatar = avatar;
        _context.Users.Update(user);
        await _context.SaveChangesAsync(cancellationToken);

        _eventBus.Publish(new UserChangeAvatar()
        {
            UserId = user.Id,
            Avatar = avatar
        }, null, Exchanges.UserTopicExchange, ExchangeType.Topic, "user.changeAvatar");

        return OperationResult.Success();
    }
}