using SadaqaAccounting.Application.ApplicationLogic.SchoolAdmissionSystem.AdmissionClassLogic.Model;
using SadaqaAccounting.Repository.Contracts.SchoolAdmissionSystem;

namespace SadaqaAccounting.Application.ApplicationLogic.SchoolAdmissionSystem.AdmissionClassLogic.Queries
{
    public class GetAdmissionClassDetailsQuery : IRequest<AdmissionClassUpdateModel>
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<GetAdmissionClassDetailsQuery, AdmissionClassUpdateModel>
        {
            private readonly IAdmissionClassRepository _admissionClassRepository;
            private readonly IMapper _mapper;
            private readonly IHttpContextAccessor _httpContextAccessor;

            public Handler(IAdmissionClassRepository admissionClassRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
            {
                _admissionClassRepository = admissionClassRepository;
                _mapper = mapper;
                _httpContextAccessor = httpContextAccessor;
            }

            public async Task<AdmissionClassUpdateModel> Handle(GetAdmissionClassDetailsQuery request, CancellationToken cancellationToken)
            {
                // Retrieve the user's ID from the current HTTP context
                var userId = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Name)?.Value;

                // Check if the user ID is null or not
                if (string.IsNullOrEmpty(userId))
                    throw new UnauthorizedAccessException(ProvideErrorMessage.UserNotAuthenticated);

                var getExistAdmissionClass = await _admissionClassRepository.GetByIdAsync(request.Id);

                if (getExistAdmissionClass is null)
                    return null!;

                var mapExistAdmissionClass = _mapper.Map<AdmissionClassUpdateModel>(getExistAdmissionClass);

                return mapExistAdmissionClass;
            }
        }
    }
}
