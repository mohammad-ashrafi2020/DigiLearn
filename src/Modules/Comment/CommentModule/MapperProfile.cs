using AutoMapper;
using CommentModule.Domain;
using CommentModule.Services.DTOs;

namespace CommentModule;

class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Comment, CreateCommentCommand>().ReverseMap();
    }
}