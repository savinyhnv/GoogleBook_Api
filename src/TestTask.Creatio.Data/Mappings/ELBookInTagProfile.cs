using EdenLab.Core.Entities.Mapping;
using TestTask.Creatio.Data.Entities;

namespace TestTask.Creatio.Data.Mappings
{
    public class ELBookInTagProfile : EntityProfile
    {
        public ELBookInTagProfile()
        {
            CreateMap<ELBookInTag>()
                .ForProp("Id", x => x.Id)
                .ForProp("CreatedOn", x => x.CreatedOn)
                .ForProp("CreatedById", x => x.CreatedById)
                .ForProp("CreatedBy", x => x.CreatedBy)
                .ForProp("ModifiedOn", x => x.ModifiedOn)
                .ForProp("ModifiedById", x => x.ModifiedById)
                .ForProp("ModifiedBy", x => x.ModifiedBy)
                .ForProp("ProcessListeners", x => x.ProcessListeners)
                .ForProp("TagId", x => x.TagId)
                .ForProp("Tag", x => x.Tag)
                .ForProp("EntityId", x => x.EntityId)
                .ForProp("Entity", x => x.Entity);
        }
    }
}
