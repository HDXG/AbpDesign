using Design.Application.Contracts.Services;

namespace DesignSetup.Application.SysMenuPermissiones.InPuts
{
    public class PagedResultInPut : PagingBase
    {
        public string menuName { get; set; }
    }
}
