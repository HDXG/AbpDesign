namespace DesignSetup.Application.SysMenuPermissiones.OutPuts
{
    public class TreePermissionsOutPut
    {
        public Guid id { get; set; }
        public string label { get; set; }
        public List<TreePermissionsOutPut> children { get; set; }
    }
}
