using System;
using System.Collections.Generic;

namespace TestTask.Creatio.Data.Entities
{
    public class SysModuleEntity : BaseEntity
    {
        public Guid? TypeColumnUId { get; set; }

        public Guid? SysEntitySchemaUId { get; set; }
    }
}
