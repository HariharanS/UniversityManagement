using AutoMapper;
namespace UniversityManagement.Application.AutoMapper
{
    public class AutoMapperConfiuguration
    {
        public AutoMapperConfiuguration()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<ApplicationToDomainProfile>();
            });
        }
    }
}