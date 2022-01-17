using System;
using System.Collections.Generic;

namespace TestTask.Creatio.Data.Entities
{
    public class SysModuleVisa : BaseEntity
    {
        public bool UseCustomNotificationProvider { get; set; }

        public Guid? VisaSchemaUId { get; set; }

        public Guid? MasterColumnUId { get; set; }
    }
}
