using EdenLab.Core.Entities.Mapping;
using TestTask.Creatio.Data.Entities;

namespace TestTask.Creatio.Data.Mappings
{
    public class SocialAccountProfile : EntityProfile
    {
        public SocialAccountProfile()
        {
            CreateMap<SocialAccount>()
                .ForProp("Id", x => x.Id)
                .ForProp("CreatedOn", x => x.CreatedOn)
                .ForProp("CreatedById", x => x.CreatedById)
                .ForProp("CreatedBy", x => x.CreatedBy)
                .ForProp("ModifiedOn", x => x.ModifiedOn)
                .ForProp("ModifiedById", x => x.ModifiedById)
                .ForProp("ModifiedBy", x => x.ModifiedBy)
                .ForProp("Notes", x => x.Notes)
                .ForProp("Login", x => x.Login)
                .ForProp("Public", x => x.Public)
                .ForProp("AccessToken", x => x.AccessToken)
                .ForProp("AccessSecretToken", x => x.AccessSecretToken)
                .ForProp("ConsumerKey", x => x.ConsumerKey)
                .ForProp("TypeId", x => x.TypeId)
                .ForProp("Type", x => x.Type)
                .ForProp("UserId", x => x.UserId)
                .ForProp("User", x => x.User)
                .ForProp("SocialId", x => x.SocialId)
                .ForProp("IsExpired", x => x.IsExpired)
                .ForProp("Name", x => x.Name)
                .ForProp("ProcessListeners", x => x.ProcessListeners);
        }
    }
}
