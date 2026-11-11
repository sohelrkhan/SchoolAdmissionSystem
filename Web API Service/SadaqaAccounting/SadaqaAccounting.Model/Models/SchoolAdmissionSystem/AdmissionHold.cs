using static SadaqaAccounting.Shared.EnumConfiguration.BaseEnumCollection;

namespace SadaqaAccounting.Model.Models.SchoolAdmissionSystem
{
    public class AdmissionHold
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public Student Student { get; set; } = null!;

        public int AdmissionClassId { get; set; }

        public AdmissionClass AdmissionClass { get; set; } = null!;

        public AdmissionHoldStatus Status { get; set; }
            = AdmissionHoldStatus.Held;

        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;

        public DateTime ExpiresAtUtc { get; set; }

        public DateTime? ConfirmedAtUtc { get; set; }

        public DateTime? CancelledAtUtc { get; set; }
    }
}
