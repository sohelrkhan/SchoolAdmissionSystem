namespace SadaqaAccounting.Model.Models.SchoolAdmissionSystem
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(17)]
        public string BirthRegistrationNumber { get; set; } = string.Empty;

        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;

        public ICollection<AdmissionHold> Holds { get; set; }
            = new List<AdmissionHold>();
    }
}
