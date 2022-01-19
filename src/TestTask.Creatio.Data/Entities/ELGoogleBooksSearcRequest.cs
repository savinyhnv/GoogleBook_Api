using System;
using System.Collections.Generic;

namespace TestTask.Creatio.Data.Entities
{
    public class ELGoogleBooksSearcRequest : BaseEntity
    {
        public bool ELIsSuccessful { get; set; }

        public string ELSearchKeyword { get; set; }

        public string ELNotes { get; set; }
    }
}
