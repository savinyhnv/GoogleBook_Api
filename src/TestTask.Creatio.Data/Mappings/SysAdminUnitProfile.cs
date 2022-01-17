using EdenLab.Core.Entities.Mapping;
using TestTask.Creatio.Data.Entities;

namespace TestTask.Creatio.Data.Mappings
{
    public class SysAdminUnitProfile : EntityProfile
    {
        public SysAdminUnitProfile()
        {
            CreateMap<SysAdminUnit>()
                .ForProp("Id", x => x.Id)
                .ForProp("CreatedOn", x => x.CreatedOn)
                .ForProp("CreatedById", x => x.CreatedById)
                .ForProp("CreatedBy", x => x.CreatedBy)
                .ForProp("ModifiedOn", x => x.ModifiedOn)
                .ForProp("ModifiedById", x => x.ModifiedById)
                .ForProp("ModifiedBy", x => x.ModifiedBy)
                .ForProp("Name", x => x.Name)
                .ForProp("Description", x => x.Description)
                .ForProp("SysAdminUnitTypeValue", x => x.SysAdminUnitTypeValue)
                .ForProp("ParentRoleId", x => x.ParentRoleId)
                .ForProp("ParentRole", x => x.ParentRole)
                .ForProp("ContactId", x => x.ContactId)
                .ForProp("Contact", x => x.Contact)
                .ForProp("AccountId", x => x.AccountId)
                .ForProp("Account", x => x.Account)
                .ForProp("IsDirectoryEntry", x => x.IsDirectoryEntry)
                .ForProp("TimeZoneId", x => x.TimeZoneId)
                .ForProp("UserPassword", x => x.UserPassword)
                .ForProp("Active", x => x.Active)
                .ForProp("SynchronizeWithLDAP", x => x.SynchronizeWithLDAP)
                .ForProp("LDAPEntry", x => x.LDAPEntry)
                .ForProp("LDAPEntryId", x => x.LDAPEntryId)
                .ForProp("LDAPEntryDN", x => x.LDAPEntryDN)
                .ForProp("LoggedIn", x => x.LoggedIn)
                .ForProp("ProcessListeners", x => x.ProcessListeners)
                .ForProp("SysCultureId", x => x.SysCultureId)
                .ForProp("SysCulture", x => x.SysCulture)
                .ForProp("LoginAttemptCount", x => x.LoginAttemptCount)
                .ForProp("SourceControlLogin", x => x.SourceControlLogin)
                .ForProp("SourceControlPassword", x => x.SourceControlPassword)
                .ForProp("PasswordExpireDate", x => x.PasswordExpireDate)
                .ForProp("HomePageId", x => x.HomePageId)
                .ForProp("HomePage", x => x.HomePage)
                .ForProp("ConnectionType", x => x.ConnectionType)
                .ForProp("UnblockTime", x => x.UnblockTime)
                .ForProp("ForceChangePassword", x => x.ForceChangePassword)
                .ForProp("DateTimeFormatId", x => x.DateTimeFormatId)
                .ForProp("DateTimeFormat", x => x.DateTimeFormat)
                .ForProp("SessionTimeout", x => x.SessionTimeout)
                .ForProp("Email", x => x.Email)
                .ForProp("OpenIDSub", x => x.OpenIDSub);
        }
    }
}
