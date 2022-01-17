using System;
using System.Collections.Generic;

namespace TestTask.Creatio.Data.Entities
{
    public class ELBookInAuthor : BaseEntity
    {
        public Guid? ELBookId { get; set; }

        public ELBook ELBook { get; set; }

        public Guid? ELBaseAuthorId { get; set; }

        public ELBaseAuthor ELBaseAuthor { get; set; }
    }
}
