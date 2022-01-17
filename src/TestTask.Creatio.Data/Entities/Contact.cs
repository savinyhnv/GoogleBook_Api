using System;
using System.Collections.Generic;

namespace TestTask.Creatio.Data.Entities
{
    public class Contact : BaseEntity
    {
        public string Name { get; set; }

        public Guid? OwnerId { get; set; }

        public Contact Owner { get; set; }

        public string Dear { get; set; }

        public Guid? SalutationTypeId { get; set; }

        public ContactSalutationType SalutationType { get; set; }

        public Guid? GenderId { get; set; }

        public Gender Gender { get; set; }

        public Guid? AccountId { get; set; }

        public Account Account { get; set; }

        public Guid? DecisionRoleId { get; set; }

        public ContactDecisionRole DecisionRole { get; set; }

        public Guid? TypeId { get; set; }

        public ContactType Type { get; set; }

        public Guid? JobId { get; set; }

        public Job Job { get; set; }

        public string JobTitle { get; set; }

        public Guid? DepartmentId { get; set; }

        public Department Department { get; set; }

        public DateTime? BirthDate { get; set; }

        public string Phone { get; set; }

        public string MobilePhone { get; set; }

        public string HomePhone { get; set; }

        public string Skype { get; set; }

        public string Email { get; set; }

        public Guid? AddressTypeId { get; set; }

        public AddressType AddressType { get; set; }

        public string Address { get; set; }

        public Guid? CityId { get; set; }

        public City City { get; set; }

        public Guid? RegionId { get; set; }

        public Region Region { get; set; }

        public string Zip { get; set; }

        public Guid? CountryId { get; set; }

        public Country Country { get; set; }

        public bool DoNotUseEmail { get; set; }

        public bool DoNotUseCall { get; set; }

        public bool DoNotUseFax { get; set; }

        public bool DoNotUseSms { get; set; }

        public bool DoNotUseMail { get; set; }

        public string Notes { get; set; }

        public string Facebook { get; set; }

        public string LinkedIn { get; set; }

        public string Twitter { get; set; }

        public string FacebookId { get; set; }

        public string LinkedInId { get; set; }

        public string TwitterId { get; set; }

        public byte[] ContactPhoto { get; set; }

        public Guid? TwitterAFDAId { get; set; }

        public SocialAccount TwitterAFDA { get; set; }

        public Guid? FacebookAFDAId { get; set; }

        public SocialAccount FacebookAFDA { get; set; }

        public Guid? LinkedInAFDAId { get; set; }

        public SocialAccount LinkedInAFDA { get; set; }

        public Guid? PhotoId { get; set; }

        public SysImage Photo { get; set; }

        public string GPSN { get; set; }

        public string GPSE { get; set; }

        public string Surname { get; set; }

        public string GivenName { get; set; }

        public string MiddleName { get; set; }

        public bool Confirmed { get; set; }

        public Guid? LanguageId { get; set; }

        public SysLanguage Language { get; set; }

        public int Age { get; set; }

        public bool IsEmailConfirmed { get; set; }
    }
}
