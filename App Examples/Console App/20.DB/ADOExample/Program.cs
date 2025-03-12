using System;
using AutoMapper;
using System.Collections;
using static System.Console;
using BoscComa.ADO;
using BoscComa.Helper;
using BoscComa.DTO;

namespace BoscComa.AppERP
{
    public class Program 
    {
        public static void Main() 
        {
            Connection connection=ConnectToDB();
            IMapper mapper = ConfigMapper();

            bool errorCreateingUser = CreateUser(connection);
            List<UserDTO> usersDTO = GetViewUsers(connection, mapper);
            ViewData(usersDTO);
            bool errorUpdatingUser = UpdateUser(usersDTO[0],connection,mapper);
            usersDTO = GetViewUsers(connection, mapper);
            ViewData(usersDTO);
            bool errorCreatingItem = CreateItem(connection,usersDTO[0].Uuid);
        }
        private static IMapper ConfigMapper()
        {
            MapperConfiguration configMapper = new MapperConfiguration(config =>
                {
                    config.CreateMap<User,UserDTO>();
                    config.CreateMap<UserDTO,User>();
                }
            );
            return configMapper.CreateMapper();
        }
        private static Connection ConnectToDB() 
        {
            string path=@"/home/projecteinf/Projectes/2025/EF/App Examples/Console App/20.DB/ADOExample/Config";
            string fileName=@"connction.enc";
            Connection.Inicialitzar(path, fileName);
            return Connection.ConnectionDB;
        }
        private static bool CreateUser(Connection connection)
        {
            User user = new User
                {
                    Uuid = Utils.CreateUUID(),
                    Name = "Joan", 
                    Email = "joan@gmail.com", 
                    DateOfBirth = Utils.ConvertToDate("18/12/2000","ca-ES")
                };
            user.SetPassword("Patata1234");
            UserADO userADO = new UserADO(connection);
            return userADO.Create(user);
        }
        private static List<UserDTO> GetViewUsers(Connection connection, IMapper mapper)
        {
            UserADO userADO = new UserADO(connection);
            List<User> users = userADO.GetAllUsers();
            return mapper.Map<List<UserDTO>>(users);
        }
        private static void ViewData(List<UserDTO> usersDTO)
        {
            WriteLine("Dades de vista");
            foreach (UserDTO user in usersDTO)
            {
                WriteLine($"User: {user.Uuid} - {user.Name} - {user.Email}");
            }
        }
        private static bool UpdateUser(UserDTO userDTO, Connection connection, IMapper mapper)
        {
            User user = mapper.Map<User>(userDTO);
            user.Email="joan@boscdelacoma.cat";
            UserADO userADO = new UserADO(connection);
            return userADO.Update(user);
        }
        private static bool CreateItem(Connection connection, string userOwner)
        {
            Item item = new Item
                {
                    Uuid = Utils.CreateUUID(),
                    Name = "Gasoil", 
                    Price = 1.45m,          // m per a indicar que és decimal!
                    UserOwner = userOwner
                };
            
            ItemADO itemADO = new ItemADO(connection);
            return itemADO.Create(item);
        }
    }
}