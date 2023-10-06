using AutoMapper;
using CommentModule.Context;
using CommentModule.Domain;
using CommentModule.Services.DTOs;
using Common.Application;
using Common.Application.SecurityUtil;
using Common.Domain.Utils;
using Microsoft.EntityFrameworkCore;

namespace CommentModule.Services;

public interface ICommentService
{
    Task<OperationResult> CreateComment(CreateCommentCommand command);
    Task<OperationResult> DeleteComment(Guid id);

    Task<CommentDto?> GetCommentById(Guid id);
    Task<CommentFilterResult> GetCommentByFilter(CommentFilterParams filterParams);
    Task<AllCommentFilterResult> GetAllComments(CommentFilterParams filterParams);
}
class CommentService : ICommentService
{
    private CommentContext _context;
    private IMapper _mapper;
    public CommentService(CommentContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<OperationResult> CreateComment(CreateCommentCommand command)
    {
        var comment = _mapper.Map<Comment>(command);

        comment.Text = comment.Text.SanitizeText();
        comment.IsActive = true;
        _context.Comments.Add(comment);
        await _context.SaveChangesAsync();
        return OperationResult.Success();
    }

    public async Task<OperationResult> DeleteComment(Guid id)
    {
        var comment = await _context.Comments.FirstOrDefaultAsync(f => f.Id == id);
        if (comment == null)
        {
            return OperationResult.NotFound();
        }

        _context.Comments.Remove(comment);
        await _context.SaveChangesAsync();
        return OperationResult.Success();
    }

    public async Task<CommentDto?> GetCommentById(Guid id)
    {
        var comment = await _context.Comments.Include(c => c.User)
            .Include(c => c.Replies).FirstOrDefaultAsync(f => f.Id == id);


        if (comment == null)
        {
            return null;
        }

        return new CommentDto
        {
            Id = comment.Id,
            CreationDate = comment.CreationDate,
            UserId = comment.UserId,
            EntityId = comment.EntityId,
            Text = comment.Text,
            FullName = $"{comment.User.Name} {comment.User.Family}",
            IsActive = comment.IsActive,
            Email = comment.User.Email.SetUnReadableEmail(),
            CommentType = comment.CommentType,
            Replies = comment.Replies.Select(s => new CommentReplyDto
            {
                Id = s.Id,
                CreationDate = s.CreationDate,
                UserId = s.UserId,
                EntityId = s.EntityId,
                Text = s.Text,
                FullName = $"{s.User.Name} {s.User.Family}",
                IsActive = s.IsActive,
                ParentId = s.ParentId,
                Email = s.User.Email.SetUnReadableEmail(),
                CommentType = s.CommentType
            }).ToList()
        };
    }

    public async Task<CommentFilterResult> GetCommentByFilter(CommentFilterParams filterParams)
    {
        throw new NotImplementedException();
    }

    public async Task<AllCommentFilterResult> GetAllComments(CommentFilterParams filterParams)
    {
        throw new NotImplementedException();
    }
}