using EdenLab.Core.Entities.Mapping;
using TestTask.Creatio.Data.Entities;

namespace TestTask.Creatio.Data.Mappings
{
    public class AccountProfile : EntityProfile
    {
        public AccountProfile()
        {
            CreateMap<Account>()
                .ForProp("Id", x => x.Id)
                .ForProp("Name", x => x.Name)
                .ForProp("OwnerId", x => x.OwnerId)
                .ForProp("Owner", x => x.Owner)
                .ForProp("CreatedOn", x => x.CreatedOn)
                .ForProp("CreatedById", x => x.CreatedById)
                .ForProp("CreatedBy", x => x.CreatedBy)
                .ForProp("ModifiedOn", x => x.ModifiedOn)
                .ForProp("ModifiedById", x => x.ModifiedById)
                .ForProp("ModifiedBy", x => x.ModifiedBy)
                .ForProp("ProcessListeners", x => x.ProcessListeners)
                .ForProp("OwnershipId", x => x.OwnershipId)
                .ForProp("Ownership", x => x.Ownership)
                .ForProp("PrimaryContactId", x => x.PrimaryContactId)
                .ForProp("PrimaryContact", x => x.PrimaryContact)
                .ForProp("ParentId", x => x.ParentId)
                .ForProp("Parent", x => x.Parent)
                .ForProp("IndustryId", x => x.IndustryId)
                .ForProp("Industry", x => x.Industry)
                .ForProp("Code", x => x.Code)
                .ForProp("TypeId", x => x.TypeId)
                .ForProp("Type", x => x.Type)
                .ForProp("Phone", x => x.Phone)
                .ForProp("AdditionalPhone", x => x.AdditionalPhone)
                .ForProp("Fax", x => x.Fax)
                .ForProp("Web", x => x.Web)
                .ForProp("AddressTypeId", x => x.AddressTypeId)
                .ForProp("AddressType", x => x.AddressType)
                .ForProp("Address", x => x.Address)
                .ForProp("CityId", x => x.CityId)
                .ForProp("City", x => x.City)
                .ForProp("RegionId", x => x.RegionId)
                .ForProp("Region", x => x.Region)
                .ForProp("Zip", x => x.Zip)
                .ForProp("CountryId", x => x.CountryId)
                .ForProp("Country", x => x.Country)
                .ForProp("AccountCategoryId", x => x.AccountCategoryId)
                .ForProp("AccountCategory", x => x.AccountCategory)
                .ForProp("EmployeesNumberId", x => x.EmployeesNumberId)
                .ForProp("EmployeesNumber", x => x.EmployeesNumber)
                .ForProp("AnnualRevenueId", x => x.AnnualRevenueId)
                .ForProp("AnnualRevenue", x => x.AnnualRevenue)
                .ForProp("Notes", x => x.Notes)
                .ForProp("Logo", x => x.Logo)
                .ForProp("AlternativeName", x => x.AlternativeName)
                .ForProp("GPSN", x => x.GPSN)
                .ForProp("GPSE", x => x.GPSE)
                .ForProp("AccountLogoId", x => x.AccountLogoId);
        }
    }
}
