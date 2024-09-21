using DesignSetup.Application.SysUsers.Dtos;

namespace DesignSetup.Application.SysUsers.OutPuts
{
    public class GetLogInOutPut
    {
        public GetLogInUserInfoDto UserInfo { get; set; }

        public string rolePermission { get; set; }

        public string token { get; set; }

        public List<loginUserMenuOutPut> menuList { get; set; }
    }

    public class loginUserMenuOutPut
    {

        public string title { get; set; }

        /// <summary>
        /// 路由名称
        /// </summary>
        public string RouteName { get; set; }


        /// <summary>
        /// 组件地址
        /// </summary>
        public string ComponentPath { get; set; }

        /// <summary>
        /// 路由路径
        /// </summary>
        public string MenuUrl { get; set; }

        public string Icon { get; set; }

        public List<loginUserMenuOutPut> children { get; set; }
    }
}
