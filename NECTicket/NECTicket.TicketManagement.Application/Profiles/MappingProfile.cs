using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using NECTicket.TicketManagement.Domain;
using NECTicket.TicketManagement.Application.Features.Events;
using NECTicket.TicketManagement.Domain.Entities;
using NECTicket.TicketManagement.Application.Features.Events.Queries.GetEventList;
using NECTicket.TicketManagement.Application.Features.Events.Queries.GetEventDetail;
using NECTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;
using NECTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvents;

namespace NECTicket.TicketManagement.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        { 
            CreateMap<Event, EventListVm>().ReverseMap();
            CreateMap<Event, EventDetailVm>().ReverseMap();
            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryListVm>();
            CreateMap<Category, CategoryEventListVm>();
        }
    }
}
