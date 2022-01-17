using System;
using System.Collections.Generic;

namespace TestTask.Creatio.Data.Entities
{
    public class AddressType : BaseLookup
    {
        public bool ForContact { get; set; }

        public bool ForAccount { get; set; }
    }
}
