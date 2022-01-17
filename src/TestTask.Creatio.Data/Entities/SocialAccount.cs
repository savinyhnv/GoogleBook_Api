using System;
using System.Collections.Generic;

namespace TestTask.Creatio.Data.Entities
{
    public class SocialAccount : BaseEntityNotes
    {
        public string Login { get; set; }

        public bool Public { get; set; }

        public string AccessToken { get; set; }

        public string AccessSecretToken { get; set; }

        public string ConsumerKey { get; set; }

        public Guid? TypeId { get; set; }

        public CommunicationType Type { get; set; }

        public Guid? UserId { get; set; }

        public SysAdminUnit User { get; set; }

        public string SocialId { get; set; }

        public bool IsExpired { get; set; }

        public string Name { get; set; }
    }
}
