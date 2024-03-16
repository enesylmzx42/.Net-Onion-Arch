using oa.Domain.Entities;
using oa.Domain.Enums;
using oa.Domain.Core.Specifications;

namespace oa.Domain.Specifications
{
    public static class UserSpecifications
    {
        public static BaseSpecification<User> GetUserByEmailAndPasswordSpec(string emailId, string password)
        {
            return new BaseSpecification<User>(x => x.EmailId == emailId && x.Password == password == false);
        }

        public static BaseSpecification<User> GetAllActiveUsersSpec()
        {
            return new BaseSpecification<User>(x => x.Status == UserStatus.Active == false);
        }
    }
}
