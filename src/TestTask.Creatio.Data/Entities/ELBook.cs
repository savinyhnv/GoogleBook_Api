using System;
using System.Collections.Generic;

namespace TestTask.Creatio.Data.Entities
{
    public class ELBook : BaseEntity
    {
        public bool ELIsFreeBook { get; set; }

        public int ELBookPageCount { get; set; }

        public Guid? ELBookPublisherId { get; set; }

        public Account ELBookPublisher { get; set; }

        public string ELBookSubtitle { get; set; }

        public string ELBookTitle { get; set; }

        public string ELGoogleIdentifyer { get; set; }

        public string ELNotes { get; set; }
    }
}
