using SadaqaAccounting.Model.Models.SchoolAdmissionSystem;
using SadaqaAccounting.Repository.Contracts.SchoolAdmissionSystem;

namespace SadaqaAccounting.Repository.Repository.SchoolAdmissionSystem
{
    public class AdmissionClassRepository : BaseRepository<AdmissionClass>, IAdmissionClassRepository
    {
        public AdmissionClassRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public override async Task<ICollection<AdmissionClass>> GetAllAsync()
        {
            var getAdmissionClasses = await dbContext.AdmissionClasses
                .Where(c => !c.IsDeleted)
            .ToListAsync();

            return getAdmissionClasses.OrderByDescending(o => o.Id).ToList();
        }

        public override async Task<AdmissionClass> GetByIdAsync(int id)
        {
            var getAdmissionById = await dbContext.AdmissionClasses
                .Where(c => c.Id == id && !c.IsDeleted)
                .FirstOrDefaultAsync();

            return getAdmissionById!;
        }
    }
}
