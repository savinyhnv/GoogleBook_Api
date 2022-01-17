using EdenLab.Core.Entities.Mapping;
using TestTask.Creatio.Data.Entities;

namespace TestTask.Creatio.Data.Mappings
{
    public class SysImageProfile : EntityProfile
    {
        public SysImageProfile()
        {
            CreateMap<SysImage>()
                .ForProp("Id", x => x.Id)
                .ForProp("CreatedOn", x => x.CreatedOn)
                .ForProp("CreatedById", x => x.CreatedById)
                .ForProp("CreatedBy", x => x.CreatedBy)
                .ForProp("ModifiedOn", x => x.ModifiedOn)
                .ForProp("ModifiedById", x => x.ModifiedById)
                .ForProp("ModifiedBy", x => x.ModifiedBy)
                .ForProp("ProcessListeners", x => x.ProcessListeners)
                .ForProp("UploadedOn", x => x.UploadedOn)
                .ForProp("Name", x => x.Name)
                .ForProp("Data", x => x.Data)
                .ForProp("MimeType", x => x.MimeType)
                .ForProp("HasRef", x => x.HasRef)
                .ForProp("PreviewData", x => x.PreviewData);
        }
    }
}
