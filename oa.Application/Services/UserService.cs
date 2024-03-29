using oa.Application.Models.Requests;
using oa.Application.Models.Responses;
using oa.Domain.Specifications;
using oa.Domain.Entities;
using oa.Domain.Enums;
using oa.Domain.Exceptions;
using oa.Application.Models.DTOs;
using oa.Application.Interfaces;
using oa.Application.Core.Services;
using oa.Domain.Core.Repositories;

namespace oa.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerService _loggerService;

        public UserService(IUnitOfWork unitOfWork, ILoggerService loggerService)
        {
            _unitOfWork = unitOfWork;
            _loggerService = loggerService;
        }

        public async Task<CreateUserRes> CreateUser(CreateUserReq req)
        {
            var user = await _unitOfWork.Repository<User>().AddAsync(new User
            {
                FirstName = req.FirstName,
                LastName = req.LastName,
                EmailId = req.EmailId,
                Password = req.Password,
                Status = req.Status
            });

            await _unitOfWork.SaveChangesAsync();

            _loggerService.LogInfo("New user created");

            return new CreateUserRes() { Data = new UserDTO(user) };
        }

        public async Task<ValidateUserRes> ValidateUser(ValidateUserReq req)
        {
            var validateUserSpec = UserSpecifications.GetUserByEmailAndPasswordSpec(req.EmailId, req.Password);

            var user = await _unitOfWork.Repository<User>().FirstOrDefaultAsync(validateUserSpec);

            if (user == null)
            {
                _loggerService.LogInfo("User not found");

                throw new UserNotFoundException();
            }

            if (user.Status != UserStatus.Active)
            {
                _loggerService.LogInfo("User not active");

                throw new UserIsNotActiveException();
            }

            return new ValidateUserRes()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }

        public async Task<GetAllActiveUsersRes> GetAllActiveUsers()
        {
            var activeUsersSpec = UserSpecifications.GetAllActiveUsersSpec();

            var users = await _unitOfWork.Repository<User>().ListAsync(activeUsersSpec);

            return new GetAllActiveUsersRes()
            {
                Data = users.Select(x => new UserDTO(x)).ToList()
            };
        }
    }
}