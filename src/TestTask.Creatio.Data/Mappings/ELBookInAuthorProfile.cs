using EdenLab.Core.Entities.Mapping;
using TestTask.Creatio.Data.Entities;

namespace TestTask.Creatio.Data.Mappings
{
    public class ELBookInAuthorProfile : EntityProfile
    {
        public ELBookInAuthorProfile()
        {
            CreateMap<ELBookInAuthor>()
                .ForProp("Id", x => x.Id)
                .ForProp("CreatedOn", x => x.CreatedOn)
                .ForProp("CreatedById", x => x.CreatedById)
                .ForProp("CreatedBy", x => x.CreatedBy)
                .ForProp("ModifiedOn", x => x.ModifiedOn)
                .ForProp("ModifiedById", x => x.ModifiedById)
                .ForProp("ModifiedBy", x => x.ModifiedBy)
                .ForProp("ProcessListeners", x => x.ProcessListeners)
                .ForProp("ELBookId", x => x.ELBookId)
                .ForProp("ELBook", x => x.ELBook)
                .ForProp("ELBaseAuthorId", x => x.ELBaseAuthorId)
                .ForProp("ELBaseAuthor", x => x.ELBaseAuthor);
        }
    }
}
