namespace DesignSetup.Application.SysUsers.Dtos
{
    public class GetLogInUserInfoDto
    {
        public string UserName { get; set; }
        public Guid Id { get; set; }

        public GetLogInUserInfoDto(string userName, Guid id)
        {
            UserName = userName;
            Id = id;
        }
    }
}
