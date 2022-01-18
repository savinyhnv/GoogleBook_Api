using EdenLab.Core.Entities.Mapping;
using TestTask.Creatio.Data.Entities;

namespace TestTask.Creatio.Data.Mappings
{
    public class ELBookInFolderProfile : EntityProfile
    {
        public ELBookInFolderProfile()
        {
            CreateMap<ELBookInFolder>()
                .ForProp("Id", x => x.Id)
                .ForProp("CreatedOn", x => x.CreatedOn)
                .ForProp("CreatedById", x => x.CreatedById)
                .ForProp("CreatedBy", x => x.CreatedBy)
                .ForProp("ModifiedOn", x => x.ModifiedOn)
                .ForProp("ModifiedById", x => x.ModifiedById)
                .ForProp("ModifiedBy", x => x.ModifiedBy)
                .ForProp("FolderId", x => x.FolderId)
                .ForProp("Folder", x => x.Folder)
                .ForProp("ProcessListeners", x => x.ProcessListeners)
                .ForProp("ELBookId", x => x.ELBookId)
                .ForProp("ELBook", x => x.ELBook);
        }
    }
}
