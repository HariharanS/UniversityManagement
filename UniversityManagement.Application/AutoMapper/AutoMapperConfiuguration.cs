using AutoMapper;
namespace UniversityManagement.Application.AutoMapper
{
    public class AutoMapperConfiuguration
    {
        private static MapperConfiguration _mapperConfiguration;
        public AutoMapperConfiuguration()
        {
            
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ApplicationToDomainProfile>();
            });

            _mapperConfiguration = mapperConfig;
            /*Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<ApplicationToDomainProfile>();
            });*/
        }

        public IMapper CreateMapper()
        {
            return _mapperConfiguration.CreateMapper();
        }
    }
}