using AutoMapper;
using LaNacion.Services.Mappings;

namespace LaNacion.Services.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<MappingProfile>();
            });
        }
    }
}
