using SadaqaAccounting.Application.ApplicationLogic.SchoolAdmissionSystem.AdmissionClassLogic.Model;
using SadaqaAccounting.Repository.Contracts.SchoolAdmissionSystem;

namespace SadaqaAccounting.Application.ApplicationLogic.SchoolAdmissionSystem.AdmissionClassLogic.Queries
{
    public class GetAllAdmissionClassQuery : IRequest<ICollection<AdmissionClassGridModel>>
    {
        public class Handler : IRequestHandler<GetAllAdmissionClassQuery, ICollection<AdmissionClassGridModel>>
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

            public async Task<ICollection<AdmissionClassGridModel>> Handle(GetAllAdmissionClassQuery request, CancellationToken cancellationToken)
            {
                // Retrieve the user's Id from the current HTTP context
                var userId = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Name)?.Value;

                // Check if the user Id is null or not
                if (string.IsNullOrEmpty(userId))
                    throw new UnauthorizedAccessException(ProvideErrorMessage.UserNotAuthenticated);

                var getAdmissionClasses = await _admissionClassRepository.GetAllAsync();
                var mapGetAdmissionClasses = _mapper.Map<ICollection<AdmissionClassGridModel>>(getAdmissionClasses);

                return mapGetAdmissionClasses;
            }
        }
    }
}
