using ApiRest.Models.Dto;

namespace ApiRest.Data
{
    public static class UserStore
    {
        public static List<UserDto> userList = new List<UserDto>
        {
            new UserDto{ Id = 1, Name="Pol Hernan Camino", Age=18, Money=1800},
            new UserDto{ Id = 2, Name="Veronica Lainez Liso", Age=18, Money=500},
            new UserDto{ Id = 3, Name="Jaime Hernan Diaz", Age=47, Money=0}
        };
    }
}
