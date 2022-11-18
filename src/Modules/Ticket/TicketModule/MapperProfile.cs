using AutoMapper;
using TicketModule.Core.DTOs.Tickets;
using TicketModule.Data.Entities;

namespace TicketModule;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<CreateTicketCommand, Ticket>().ReverseMap();
        CreateMap<TicketDto, Ticket>().ReverseMap();
        CreateMap<TicketMessageDto, TicketMessage>().ReverseMap();
    }
}