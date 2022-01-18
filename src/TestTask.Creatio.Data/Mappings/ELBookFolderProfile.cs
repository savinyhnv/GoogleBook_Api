using EdenLab.Core.Entities.Mapping;
using TestTask.Creatio.Data.Entities;

namespace TestTask.Creatio.Data.Mappings
{
    public class ELBookFolderProfile : EntityProfile
    {
        public ELBookFolderProfile()
        {
            CreateMap<ELBookFolder>()
                .ForProp("Id", x => x.Id)
                .ForProp("CreatedOn", x => x.CreatedOn)
                .ForProp("CreatedById", x => x.CreatedById)
                .ForProp("CreatedBy", x => x.CreatedBy)
                .ForProp("ModifiedOn", x => x.ModifiedOn)
                .ForProp("ModifiedById", x => x.ModifiedById)
                .ForProp("ModifiedBy", x => x.ModifiedBy)
                .ForProp("Name", x => x.Name)
                .ForProp("Description", x => x.Description)
                .ForProp("ParentId", x => x.ParentId)
                .ForProp("Parent", x => x.Parent)
                .ForProp("FolderTypeId", x => x.FolderTypeId)
                .ForProp("FolderType", x => x.FolderType)
                .ForProp("SearchData", x => x.SearchData)
                .ForProp("ProcessListeners", x => x.ProcessListeners)
                .ForProp("OptimizationType", x => x.OptimizationType);
        }
    }
}
