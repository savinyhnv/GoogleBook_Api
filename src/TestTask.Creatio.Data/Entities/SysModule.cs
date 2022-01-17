using System;
using System.Collections.Generic;

namespace TestTask.Creatio.Data.Entities
{
    public class SysModule : BaseEntity
    {
        public string Caption { get; set; }

        public Guid? SysModuleEntityId { get; set; }

        public SysModuleEntity SysModuleEntity { get; set; }

        public byte[] Image16 { get; set; }

        public byte[] Image20 { get; set; }

        public Guid? FolderModeId { get; set; }

        public SysModuleFolderMode FolderMode { get; set; }

        public bool GlobalSearchAvailable { get; set; }

        public bool HasAnalytics { get; set; }

        public bool HasActions { get; set; }

        public bool HasRecent { get; set; }

        public string Code { get; set; }

        public string HelpContextId { get; set; }

        public string ModuleHeader { get; set; }

        public string Attribute { get; set; }

        public Guid? SysPageSchemaUId { get; set; }

        public Guid? CardSchemaUId { get; set; }

        public Guid? SectionModuleSchemaUId { get; set; }

        public Guid? SectionSchemaUId { get; set; }

        public Guid? CardModuleUId { get; set; }

        public Guid? TypeColumnValue { get; set; }

        public Guid? Image32Id { get; set; }

        public SysImage Image32 { get; set; }

        public Guid? LogoId { get; set; }

        public SysImage Logo { get; set; }

        public Guid? SysModuleVisaId { get; set; }

        public SysModuleVisa SysModuleVisa { get; set; }

        public bool IsSystem { get; set; }

        public int Type { get; set; }
    }
}
