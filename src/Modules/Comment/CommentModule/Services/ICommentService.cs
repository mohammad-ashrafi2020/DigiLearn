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
        comment.Id = Guid.NewGuid();
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
            .Include(c => c.Replies).ThenInclude(c => c.User).FirstOrDefaultAsync(f => f.Id == id);


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
        var query = _context.Comments
            .Include(c => c.Replies)
            .ThenInclude(c => c.User)
            .Include(c => c.User)
            .Where(r => r.ParentId == null)
            .OrderByDescending(d => d.CreationDate).AsQueryable();

        if (filterParams.CommentType != null)
        {
            query = query.Where(r => r.CommentType == filterParams.CommentType);
        }

        if (filterParams.EntityId != null)
        {
            query = query.Where(r => r.EntityId == filterParams.EntityId);
        }
        if (filterParams.StartDate != null)
        {
            query = query.Where(r => r.CreationDate.Date >= filterParams.StartDate.Value.Date);
        }
        if (filterParams.EndDate != null)
        {
            query = query.Where(r => r.CreationDate.Date <= filterParams.EndDate.Value.Date);
        }
        if (filterParams.Name != null)
        {
            query = query.Where(r => r.User.Name.Contains(filterParams.Name));
        }
        if (filterParams.Family != null)
        {
            query = query.Where(r => r.User.Family.Contains(filterParams.Family));
        }

        var skip = (filterParams.PageId - 1) * filterParams.Take;
        var model = new CommentFilterResult()
        {
            Data = await query.Skip(skip).Take(filterParams.Take)
                .Select(c => new CommentDto()
                {
                    Id = c.Id,
                    CreationDate = c.CreationDate,
                    UserId = c.UserId,
                    EntityId = c.EntityId,
                    Text = c.Text,
                    FullName = $"{c.User.Name} {c.User.Family}",
                    IsActive = c.IsActive,
                    Email = c.User.Email.SetUnReadableEmail(),
                    CommentType = c.CommentType,
                    Replies = c.Replies.Select(s => new CommentReplyDto
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
                }).ToListAsync(),
            FilterParams = filterParams
        };
        model.GeneratePaging(query, filterParams.Take, filterParams.PageId);
        return model;
    }

    public async Task<AllCommentFilterResult> GetAllComments(CommentFilterParams filterParams)
    {
        var query = _context.Comments
            .Include(c => c.Replies)
            .ThenInclude(c => c.User)
            .Include(c => c.User)
            .OrderByDescending(d => d.CreationDate).AsQueryable();

        if (filterParams.CommentType != null)
        {
            query = query.Where(r => r.CommentType == filterParams.CommentType);
        }

        if (filterParams.EntityId != null)
        {
            query = query.Where(r => r.EntityId == filterParams.EntityId);
        }
        if (filterParams.StartDate != null)
        {
            query = query.Where(r => r.CreationDate.Date >= filterParams.StartDate.Value.Date);
        }
        if (filterParams.EndDate != null)
        {
            query = query.Where(r => r.CreationDate.Date <= filterParams.EndDate.Value.Date);
        }
        if (filterParams.Name != null)
        {
            query = query.Where(r => r.User.Name.Contains(filterParams.Name));
        }
        if (filterParams.Family != null)
        {
            query = query.Where(r => r.User.Family.Contains(filterParams.Family));
        }

        var skip = (filterParams.PageId - 1) * filterParams.Take;
        var model = new AllCommentFilterResult()
        {
            Data = await query.Skip(skip).Take(filterParams.Take)
                .Select(s => new CommentReplyDto
                {
                    Id = s.Id,
                    CreationDate = s.CreationDate,
                    UserId = s.UserId,
                    EntityId = s.EntityId,
                    Text = s.Text,
                    FullName = $"{s.User.Name} {s.User.Family}",
                    IsActive = s.IsActive,
                    ParentId = s.ParentId,
                    Email = s.User.Email,
                    CommentType = s.CommentType
                }).ToListAsync()
        };
        model.GeneratePaging(query, filterParams.Take, filterParams.PageId);
        return model;
    }
}