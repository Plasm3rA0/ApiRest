using ApiRest.Models.Dto;

namespace ApiRest.Data
{
    public static class UserStore
    {
        public static List<UserDto> userList = new List<UserDto>
        {
            new UserDto{ Id = 1, name="Pol Hernan Camino", age=18},
            new UserDto{ Id = 2, name="Veronica Lainez Liso", age=18},
            new UserDto{ Id = 3, name="Jaime Hernan Diaz", age=47}
        };
    }
}
