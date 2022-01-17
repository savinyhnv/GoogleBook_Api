using System;
using System.Collections.Generic;

namespace TestTask.Creatio.Data.Entities
{
    public class CommunicationType : BaseImageLookup
    {
        public string HyperlinkTemplate { get; set; }

        public bool UseforAccounts { get; set; }

        public bool UseforContacts { get; set; }
    }
}
