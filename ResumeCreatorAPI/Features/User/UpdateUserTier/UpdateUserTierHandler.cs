using MediatR;

namespace ResumeCreatorAPI.Features.User.UpdateUserTier
{
    public class UpdateUserTierHandler : IRequestHandler<UpdateUserTierCommand, bool>
    {
        private readonly IUpdateUserTierRepository _updateUserTierRepository;
        public UpdateUserTierHandler(IUpdateUserTierRepository updateUserTierRepository)
        {
            _updateUserTierRepository = updateUserTierRepository;
        }
        public async Task<bool> Handle(UpdateUserTierCommand request, CancellationToken cancellationToken)
        {
            return await _updateUserTierRepository.UpdateUserTierAsync(request.Email, request.NewTier);
        }
    }
}