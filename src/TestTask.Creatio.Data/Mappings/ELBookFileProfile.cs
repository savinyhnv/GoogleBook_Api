using EdenLab.Core.Entities.Mapping;
using TestTask.Creatio.Data.Entities;

namespace TestTask.Creatio.Data.Mappings
{
    public class ELBookFileProfile : EntityProfile
    {
        public ELBookFileProfile()
        {
            CreateMap<ELBookFile>()
                .ForProp("Id", x => x.Id)
                .ForProp("CreatedOn", x => x.CreatedOn)
                .ForProp("CreatedById", x => x.CreatedById)
                .ForProp("CreatedBy", x => x.CreatedBy)
                .ForProp("ModifiedOn", x => x.ModifiedOn)
                .ForProp("ModifiedById", x => x.ModifiedById)
                .ForProp("ModifiedBy", x => x.ModifiedBy)
                .ForProp("ProcessListeners", x => x.ProcessListeners)
                .ForProp("Name", x => x.Name)
                .ForProp("Notes", x => x.Notes)
                .ForProp("LockedById", x => x.LockedById)
                .ForProp("LockedBy", x => x.LockedBy)
                .ForProp("LockedOn", x => x.LockedOn)
                .ForProp("Data", x => x.Data)
                .ForProp("TypeId", x => x.TypeId)
                .ForProp("Type", x => x.Type)
                .ForProp("Version", x => x.Version)
                .ForProp("Size", x => x.Size)
                .ForProp("SysFileStorageId", x => x.SysFileStorageId)
                .ForProp("SysFileStorage", x => x.SysFileStorage)
                .ForProp("ELBookId", x => x.ELBookId)
                .ForProp("ELBook", x => x.ELBook);
        }
    }
}
