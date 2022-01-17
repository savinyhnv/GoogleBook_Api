using EdenLab.Core.Entities.Mapping;
using TestTask.Creatio.Data.Entities;

namespace TestTask.Creatio.Data.Mappings
{
    public class SysModuleEntityProfile : EntityProfile
    {
        public SysModuleEntityProfile()
        {
            CreateMap<SysModuleEntity>()
                .ForProp("Id", x => x.Id)
                .ForProp("CreatedOn", x => x.CreatedOn)
                .ForProp("CreatedById", x => x.CreatedById)
                .ForProp("CreatedBy", x => x.CreatedBy)
                .ForProp("ModifiedOn", x => x.ModifiedOn)
                .ForProp("ModifiedById", x => x.ModifiedById)
                .ForProp("ModifiedBy", x => x.ModifiedBy)
                .ForProp("TypeColumnUId", x => x.TypeColumnUId)
                .ForProp("ProcessListeners", x => x.ProcessListeners)
                .ForProp("SysEntitySchemaUId", x => x.SysEntitySchemaUId);
        }
    }
}
