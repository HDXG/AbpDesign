namespace DesignSetup.Application.SysMenuPermissiones.OutPuts
{
    public class TreeSelectOutPut
    {
        public string label { get; set; }
        public Guid value { get; set; }
        public List<TreeSelectOutPut> children { get; set; }
    }
}
