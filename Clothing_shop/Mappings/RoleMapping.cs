using Clothing_shop.Entities;
using Clothing_shop.VModel;

namespace Clothing_shop.Mappings
{
    public static class RoleMapping
    {
        public static RoleGetVModel EntityGetVModel(Role role)
        {
            return new RoleGetVModel
            {
                Id = role.Id,
                RoleName = role.RoleName
            };
        }
        public static Role VModelToEntity(RoleCreateVModel roleCreateVModel)
        {
            return new Role
            {
                RoleName = roleCreateVModel.RoleName
            };
        }
        public static Role VModelToEntity(RoleUpdateVModel roleUpdateVModel)
        {
            return new Role
            {
                Id = roleUpdateVModel.Id,
                RoleName = roleUpdateVModel.RoleName
            };
        }
    }
}
