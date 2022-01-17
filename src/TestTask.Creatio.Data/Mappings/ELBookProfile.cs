using EdenLab.Core.Entities.Mapping;
using TestTask.Creatio.Data.Entities;

namespace TestTask.Creatio.Data.Mappings
{
    public class ELBookProfile : EntityProfile
    {
        public ELBookProfile()
        {
            CreateMap<ELBook>()
                .ForProp("Id", x => x.Id)
                .ForProp("CreatedOn", x => x.CreatedOn)
                .ForProp("CreatedById", x => x.CreatedById)
                .ForProp("CreatedBy", x => x.CreatedBy)
                .ForProp("ModifiedOn", x => x.ModifiedOn)
                .ForProp("ModifiedById", x => x.ModifiedById)
                .ForProp("ModifiedBy", x => x.ModifiedBy)
                .ForProp("ProcessListeners", x => x.ProcessListeners)
                .ForProp("ELIsFreeBook", x => x.ELIsFreeBook)
                .ForProp("ELBookPageCount", x => x.ELBookPageCount)
                .ForProp("ELBookPublisherId", x => x.ELBookPublisherId)
                .ForProp("ELBookPublisher", x => x.ELBookPublisher)
                .ForProp("ELBookSubtitle", x => x.ELBookSubtitle)
                .ForProp("ELBookTitle", x => x.ELBookTitle)
                .ForProp("ELGoogleIdentifyer", x => x.ELGoogleIdentifyer)
                .ForProp("ELNotes", x => x.ELNotes);
        }
    }
}
