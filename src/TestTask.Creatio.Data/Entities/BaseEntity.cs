using System;
using System.Collections.Generic;

namespace TestTask.Creatio.Data.Entities
{
    public class BaseEntity : EdenLab.Core.Entities.Entries.BaseEntity
    {
        public Guid? CreatedById { get; set; }

        public Contact CreatedBy { get; set; }

        public Guid? ModifiedById { get; set; }

        public Contact ModifiedBy { get; set; }

        public int ProcessListeners { get; set; }
    }
}
