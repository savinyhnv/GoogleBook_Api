using EdenLab.Core.Entities.Mapping;
using TestTask.Creatio.Data.Entities;

namespace TestTask.Creatio.Data.Mappings
{
    public class ELWebServiceInfoProfile : EntityProfile
    {
        public ELWebServiceInfoProfile()
        {
            CreateMap<ELWebServiceInfo>()
                .ForProp("Id", x => x.Id)
                .ForProp("CreatedOn", x => x.CreatedOn)
                .ForProp("CreatedById", x => x.CreatedById)
                .ForProp("CreatedBy", x => x.CreatedBy)
                .ForProp("ModifiedOn", x => x.ModifiedOn)
                .ForProp("ModifiedById", x => x.ModifiedById)
                .ForProp("ModifiedBy", x => x.ModifiedBy)
                .ForProp("ProcessListeners", x => x.ProcessListeners)
                .ForProp("ELName", x => x.ELName)
                .ForProp("ELUri", x => x.ELUri);
        }
    }
}
