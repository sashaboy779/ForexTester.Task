using Riok.Mapperly.Abstractions;
using UserAPI.Entities;
using UserAPI.Models;

namespace UserAPI.Mappers
{
    [Mapper]
    public partial class UserMapper
    {
        public partial UserModel UserEntityToModel(User entity);
        public partial User UserModelToEntity(UserModel model);
    }
}
