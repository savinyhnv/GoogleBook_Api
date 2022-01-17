using System;
using System.Collections.Generic;

namespace TestTask.Creatio.Data.Entities
{
    public class Account : BaseEntity
    {
        public string Name { get; set; }

        public Guid? OwnerId { get; set; }

        public Contact Owner { get; set; }

        public Guid? OwnershipId { get; set; }

        public AccountOwnership Ownership { get; set; }

        public Guid? PrimaryContactId { get; set; }

        public Contact PrimaryContact { get; set; }

        public Guid? ParentId { get; set; }

        public Account Parent { get; set; }

        public Guid? IndustryId { get; set; }

        public AccountIndustry Industry { get; set; }

        public string Code { get; set; }

        public Guid? TypeId { get; set; }

        public AccountType Type { get; set; }

        public string Phone { get; set; }

        public string AdditionalPhone { get; set; }

        public string Fax { get; set; }

        public string Web { get; set; }

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

        public Guid? AccountCategoryId { get; set; }

        public AccountCategory AccountCategory { get; set; }

        public Guid? EmployeesNumberId { get; set; }

        public AccountEmployeesNumber EmployeesNumber { get; set; }

        public Guid? AnnualRevenueId { get; set; }

        public AccountAnnualRevenue AnnualRevenue { get; set; }

        public string Notes { get; set; }

        public byte[] Logo { get; set; }

        public string AlternativeName { get; set; }

        public string GPSN { get; set; }

        public string GPSE { get; set; }

        public Guid? AccountLogoId { get; set; }
    }
}
