using AirOpsTest.DtoS;
using AirOpsTest.Entities;
using AutoMapper;

namespace AirOpsTest.MappingProfiles
{
    public class StatusMessageMappings: Profile
    {
        public StatusMessageMappings()
        {
            CreateMap<StatusMessageEntity, StatusMessageModel>().ReverseMap();
        }
    }
}