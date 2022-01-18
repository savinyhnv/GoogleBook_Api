using System;
using System.Collections.Generic;

namespace TestTask.Creatio.Data.Entities
{
    public class ELBookFile : File
    {
        public Guid? ELBookId { get; set; }

        public ELBook ELBook { get; set; }
    }
}
