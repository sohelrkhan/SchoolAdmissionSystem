using SadaqaAccounting.Application.ApplicationLogic.SchoolAdmissionSystem.AdmissionClassLogic.Model;
using SadaqaAccounting.Repository.Contracts.SchoolAdmissionSystem;

namespace SadaqaAccounting.Application.ApplicationLogic.SchoolAdmissionSystem.AdmissionClassLogic.Command
{
    public class UpdateAdmissionClassCommand : AdmissionClassUpdateModel, IRequest<AdmissionClassUpdateModel>
    {
        public class Handler : IRequestHandler<UpdateAdmissionClassCommand, AdmissionClassUpdateModel>
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

            public async Task<AdmissionClassUpdateModel> Handle(UpdateAdmissionClassCommand request, CancellationToken cancellationToken)
            {
                // Retrieve the user's Id from the current HTTP context
                var userId = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Name)?.Value;

                // Check if the user Id is null or not
                if (string.IsNullOrEmpty(userId))
                    throw new UnauthorizedAccessException(ProvideErrorMessage.UserNotAuthenticated);

                // Get exist admission class
                var getExistAdmissionClass = await _admissionClassRepository.GetByIdAsync(request.Id);

                if (getExistAdmissionClass is null)
                    throw new BadRequestException(ProvideErrorMessage.AdmissionClassNotFound);

                getExistAdmissionClass = _mapper.Map((AdmissionClassUpdateModel)request, getExistAdmissionClass);
                getExistAdmissionClass.UpdatedById = userId;
                getExistAdmissionClass.UpdatedDateTime = DateTime.UtcNow;

                getExistAdmissionClass = await _admissionClassRepository.UpdateAsync(getExistAdmissionClass);
                return request;
            }
        }
    }
}
