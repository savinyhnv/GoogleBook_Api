using EdenLab.Core.Entities.Mapping;
using TestTask.Creatio.Data.Entities;

namespace TestTask.Creatio.Data.Mappings
{
    public class SysModuleProfile : EntityProfile
    {
        public SysModuleProfile()
        {
            CreateMap<SysModule>()
                .ForProp("Id", x => x.Id)
                .ForProp("CreatedOn", x => x.CreatedOn)
                .ForProp("CreatedById", x => x.CreatedById)
                .ForProp("CreatedBy", x => x.CreatedBy)
                .ForProp("ModifiedOn", x => x.ModifiedOn)
                .ForProp("ModifiedById", x => x.ModifiedById)
                .ForProp("ModifiedBy", x => x.ModifiedBy)
                .ForProp("Caption", x => x.Caption)
                .ForProp("SysModuleEntityId", x => x.SysModuleEntityId)
                .ForProp("SysModuleEntity", x => x.SysModuleEntity)
                .ForProp("Image16", x => x.Image16)
                .ForProp("Image20", x => x.Image20)
                .ForProp("FolderModeId", x => x.FolderModeId)
                .ForProp("FolderMode", x => x.FolderMode)
                .ForProp("GlobalSearchAvailable", x => x.GlobalSearchAvailable)
                .ForProp("HasAnalytics", x => x.HasAnalytics)
                .ForProp("HasActions", x => x.HasActions)
                .ForProp("HasRecent", x => x.HasRecent)
                .ForProp("Code", x => x.Code)
                .ForProp("HelpContextId", x => x.HelpContextId)
                .ForProp("ProcessListeners", x => x.ProcessListeners)
                .ForProp("ModuleHeader", x => x.ModuleHeader)
                .ForProp("Attribute", x => x.Attribute)
                .ForProp("SysPageSchemaUId", x => x.SysPageSchemaUId)
                .ForProp("CardSchemaUId", x => x.CardSchemaUId)
                .ForProp("SectionModuleSchemaUId", x => x.SectionModuleSchemaUId)
                .ForProp("SectionSchemaUId", x => x.SectionSchemaUId)
                .ForProp("CardModuleUId", x => x.CardModuleUId)
                .ForProp("TypeColumnValue", x => x.TypeColumnValue)
                .ForProp("Image32Id", x => x.Image32Id)
                .ForProp("Image32", x => x.Image32)
                .ForProp("LogoId", x => x.LogoId)
                .ForProp("Logo", x => x.Logo)
                .ForProp("SysModuleVisaId", x => x.SysModuleVisaId)
                .ForProp("SysModuleVisa", x => x.SysModuleVisa)
                .ForProp("IsSystem", x => x.IsSystem)
                .ForProp("Type", x => x.Type);
        }
    }
}
