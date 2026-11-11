using SadaqaAccounting.Model.Models.SchoolAdmissionSystem;

namespace SadaqaAccounting.Application.ApplicationLogic.SchoolAdmissionSystem.AdmissionClassLogic.Model
{
    public class AdmissionClassViewModel
    {
        public AdmissionClassCreateModel CreateModel { get; set; }
        public AdmissionClassUpdateModel UpdateModel { get; set; }
        public AdmissionClassGridModel GridModel { get; set; }
        public dynamic OptionsDataSources { get; set; } = new ExpandoObject();
    }

    public class AdmissionClassCreateModel : IMapFrom<AdmissionClass>
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Shift { get; set; } = string.Empty;

        public int TotalSeats { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AdmissionClass, AdmissionClassCreateModel>();
            profile.CreateMap<AdmissionClassCreateModel, AdmissionClass>();
        }
    }

    public class AdmissionClassUpdateModel : IMapFrom<AdmissionClass>
    {
        public int Id { get; set; }
        public string? EncryptedId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Shift { get; set; } = string.Empty;

        public int TotalSeats { get; set; }
        public int StatusId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AdmissionClass, AdmissionClassUpdateModel>()
                .ForMember(d => d.EncryptedId, s => s.MapFrom(m => EncryptionService.Encrypt(m.Id.ToString())));
            profile.CreateMap<AdmissionClassUpdateModel, AdmissionClass>();
        }
    }

    public class AdmissionClassGridModel : IMapFrom<AdmissionClass>
    {
        public int Id { get; set; }
        public string? EncryptedId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Shift { get; set; } = string.Empty;

        public int TotalSeats { get; set; }
        public int StatusId { get; set; }
        public string StatusName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AdmissionClass, AdmissionClassGridModel>()
                .ForMember(d => d.EncryptedId, s => s.MapFrom(m => EncryptionService.Encrypt(m.Id.ToString())))
                .ForMember(d => d.StatusName, s => s.MapFrom(m => m.Status.Name));
        }
    }
}
