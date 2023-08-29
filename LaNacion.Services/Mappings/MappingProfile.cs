using AutoMapper;
using LaNacion.Model.Entities;
using LaNacion.Services.Services;
using LaNacion.Services.Services.Contacts.DTOs;

namespace LaNacion.Services.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //#region Commands
            CreateMap<Contact, ContactDTO>();
            CreateMap<ContactDTO, Contact>();

            //#endregion

            //#region DTO's
            //CreateMap<UpdateContactRequestModel, ContactDTO>().ReverseMap();

            //#endregion
        }
    }
}
