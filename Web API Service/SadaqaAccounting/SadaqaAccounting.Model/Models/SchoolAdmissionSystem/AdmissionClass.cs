namespace SadaqaAccounting.Model.Models.SchoolAdmissionSystem
{
    public class AdmissionClass
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Shift { get; set; } = string.Empty;

        public int TotalSeats { get; set; }

        [Required(ErrorMessage = "Please, select status.")]
        public int StatusId { get; set; }
        public string CreatedById { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string? UpdatedById { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDateTime { get; set; }

        public ICollection<AdmissionHold> Holds { get; set; }
            = new List<AdmissionHold>();
        public EnumTypeCollection Status { get; set; }
    }
}
