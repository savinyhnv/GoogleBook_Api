using EdenLab.Core.Entities.Mapping;
using TestTask.Creatio.Data.Entities;

namespace TestTask.Creatio.Data.Mappings
{
    public class CityProfile : EntityProfile
    {
        public CityProfile()
        {
            CreateMap<City>()
                .ForProp("Id", x => x.Id)
                .ForProp("CreatedOn", x => x.CreatedOn)
                .ForProp("CreatedById", x => x.CreatedById)
                .ForProp("CreatedBy", x => x.CreatedBy)
                .ForProp("ModifiedOn", x => x.ModifiedOn)
                .ForProp("ModifiedById", x => x.ModifiedById)
                .ForProp("ModifiedBy", x => x.ModifiedBy)
                .ForProp("Name", x => x.Name)
                .ForProp("Description", x => x.Description)
                .ForProp("CountryId", x => x.CountryId)
                .ForProp("Country", x => x.Country)
                .ForProp("RegionId", x => x.RegionId)
                .ForProp("Region", x => x.Region)
                .ForProp("TimeZoneId", x => x.TimeZoneId)
                .ForProp("TimeZone", x => x.TimeZone)
                .ForProp("ProcessListeners", x => x.ProcessListeners);
        }
    }
}
