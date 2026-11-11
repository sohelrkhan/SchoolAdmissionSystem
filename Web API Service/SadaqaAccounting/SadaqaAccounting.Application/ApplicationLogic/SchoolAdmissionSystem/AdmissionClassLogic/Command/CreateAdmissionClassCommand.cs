using SadaqaAccounting.Application.ApplicationLogic.SchoolAdmissionSystem.AdmissionClassLogic.Model;
using SadaqaAccounting.Repository.Contracts.SchoolAdmissionSystem;

namespace SadaqaAccounting.Application.ApplicationLogic.SchoolAdmissionSystem.AdmissionClassLogic.Command
{
    public class CreateAdmissionClassCommand : AdmissionClassCreateModel, IRequest<AdmissionClassCreateModel>
    {
        public class Handler : IRequestHandler<CreateAdmissionClassCommand, AdmissionClassCreateModel>
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

            public async Task<AdmissionClassCreateModel> Handle(CreateAdmissionClassCommand request, CancellationToken cancellationToken)
            {
                // Retrieve the user's Id from the current HTTP context
                var userId = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Name)?.Value;

                // Check if the user Id is null or not
                if (string.IsNullOrEmpty(userId))
                    throw new UnauthorizedAccessException(ProvideErrorMessage.UserNotAuthenticated);

                var createdAdmissionClass = _mapper.Map<SadaqaAccounting.Model.Models.SchoolAdmissionSystem.AdmissionClass>(request);
                createdAdmissionClass.CreatedById = userId;
                createdAdmissionClass.CreatedDateTime = DateTime.UtcNow;
                createdAdmissionClass.StatusId = GlobalStatus.Active;
                createdAdmissionClass = await _admissionClassRepository.CreateAsync(createdAdmissionClass);
                return _mapper.Map<AdmissionClassCreateModel>(createdAdmissionClass);
            }
        }
    }    
}
