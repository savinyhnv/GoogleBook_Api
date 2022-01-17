using System;
using System.Collections.Generic;

namespace TestTask.Creatio.Data.Entities
{
    public class SysAdminUnit : BaseLookup
    {
        public int SysAdminUnitTypeValue { get; set; }

        public Guid? ParentRoleId { get; set; }

        public SysAdminUnit ParentRole { get; set; }

        public Guid? ContactId { get; set; }

        public Contact Contact { get; set; }

        public Guid? AccountId { get; set; }

        public Account Account { get; set; }

        public bool IsDirectoryEntry { get; set; }

        public string TimeZoneId { get; set; }

        public string UserPassword { get; set; }

        public bool Active { get; set; }

        public bool SynchronizeWithLDAP { get; set; }

        public string LDAPEntry { get; set; }

        public string LDAPEntryId { get; set; }

        public string LDAPEntryDN { get; set; }

        public bool LoggedIn { get; set; }

        public Guid? SysCultureId { get; set; }

        public SysCulture SysCulture { get; set; }

        public int LoginAttemptCount { get; set; }

        public string SourceControlLogin { get; set; }

        public string SourceControlPassword { get; set; }

        public DateTime? PasswordExpireDate { get; set; }

        public Guid? HomePageId { get; set; }

        public SysModule HomePage { get; set; }

        public int ConnectionType { get; set; }

        public DateTime? UnblockTime { get; set; }

        public bool ForceChangePassword { get; set; }

        public Guid? DateTimeFormatId { get; set; }

        public SysLanguage DateTimeFormat { get; set; }

        public int SessionTimeout { get; set; }

        public string Email { get; set; }

        public string OpenIDSub { get; set; }

    }
}
