namespace DesignSetup.Application.SysMenuPermissiones.OutPuts
{
    public class TreePermissions
    {
        public Guid id { get; set; }
        public string label { get; set; }
        public List<TreePermissions> children { get; set; }
    }

    public class TreePermissionsOutPut
    {
        public List<Guid> roleMenIdList { get; set; }
        public List<TreePermissions> menuTreeList { get; set; }
    }
}
