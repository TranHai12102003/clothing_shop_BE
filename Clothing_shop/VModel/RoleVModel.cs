namespace Clothing_shop.VModel
{
    public class RoleCreateVModel
    {
        public string RoleName { get; set; }
    }
    public class RoleUpdateVModel : RoleCreateVModel
    {
        public int Id { get; set; }
    }
    public class RoleGetVModel : RoleUpdateVModel
    {
    }
}
