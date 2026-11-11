using SadaqaAccounting.Repository.Contracts.SchoolAdmissionSystem;

namespace SadaqaAccounting.Application.ApplicationLogic.SchoolAdmissionSystem.AdmissionClassLogic.Queries
{
    public class SelectListAdmissionClassQuery : IRequest<List<SelectModel>>
    {
        public class Handler : IRequestHandler<SelectListAdmissionClassQuery, List<SelectModel>>
        {
            private readonly IAdmissionClassRepository _admissionClassRepository;

            public Handler(IAdmissionClassRepository admissionClassRepository)
            {
                _admissionClassRepository = admissionClassRepository;
            }

            public async Task<List<SelectModel>> Handle(SelectListAdmissionClassQuery request, CancellationToken cancellationToken)
            {
                var getAdmissionClass = await _admissionClassRepository.GetAllAsync();

                var admissionClassSelectList = getAdmissionClass
                    .Select(s => new SelectModel()
                    {
                        Id = s.Id,
                        Name = s.Name
                    }).ToList();

                return admissionClassSelectList;
            }
        }
    }
}
