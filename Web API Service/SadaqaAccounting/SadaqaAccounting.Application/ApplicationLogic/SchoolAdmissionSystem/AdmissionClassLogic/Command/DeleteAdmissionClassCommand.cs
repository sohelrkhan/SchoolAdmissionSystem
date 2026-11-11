using SadaqaAccounting.Repository.Contracts.SchoolAdmissionSystem;

namespace SadaqaAccounting.Application.ApplicationLogic.SchoolAdmissionSystem.AdmissionClassLogic.Command
{
    public class DeleteProductCategoryCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<DeleteProductCategoryCommand, bool>
        {
            private readonly IAdmissionClassRepository _admissionClassRepository;
            private readonly IHttpContextAccessor _httpContextAccessor;

            public Handler(IAdmissionClassRepository admissionClassRepository, IHttpContextAccessor httpContextAccessor)
            {
                _admissionClassRepository = admissionClassRepository;
                _httpContextAccessor = httpContextAccessor;
            }

            public async Task<bool> Handle(DeleteProductCategoryCommand request, CancellationToken cancellationToken)
            {
                // Retrieve the user's Id from the current HTTP context
                var userId = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Name)?.Value;

                // Check if the user Id is null or not
                if (string.IsNullOrEmpty(userId))
                    throw new UnauthorizedAccessException(ProvideErrorMessage.UserNotAuthenticated);

                var isAdmissionClassDelete = false;
                var existAdmissionClass = await _admissionClassRepository.GetByIdAsync(request.Id);

                if (existAdmissionClass is null)
                    throw new BadRequestException(ProvideErrorMessage.AdmissionClassIdNotFound);

                if (existAdmissionClass is not null)
                {
                    existAdmissionClass.IsDeleted = true;
                    existAdmissionClass.DeletedDateTime = DateTime.UtcNow;

                    var updatedAdmissionClass = await _admissionClassRepository.UpdateAsync(existAdmissionClass);
                    isAdmissionClassDelete = true;
                }

                return isAdmissionClassDelete;
            }
        }
    }
}
