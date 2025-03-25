///
///     ATENCIO: EXECUTAR AMB sudo per poder operar amb els contenidors
/// 
///         sudo dotnet run 
/// 
///  Instal·lació del paquet Docker.DotNet per a parar el docker quan la connexió ja està establerta
///     
///         dotnet add package Docker.DotNet
/// 
using System;
using AutoMapper;
using System.Collections;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using static System.Console;
using BoscComa.ADO;
using BoscComa.Helper;
using BoscComa.DTO;
using BoscComa.GestioErrors;

namespace BoscComa.AppERP
{
    public class Program 
    {
        public static async Task Main() 
        {
            // await Utils.StopDocker("sqlserver");
            IMapper mapper = ConfigMapper();

            Connection connection=ConnectToDB();    // Sembla que la connexió no pot fallar. Amb DOCKER aturat no dóna error!
           
            try 
            {
                bool errorCreateingUser = CreateUser(connection);
            }
            catch (DBException dbex)
            {
                WriteLine(dbex);
            }
            catch (SqlException sqlex)
            {
                WriteLine(sqlex);
            }
            catch (Exception ex)
            {
                WriteLine(ex);
            }
            
            WriteLine($"Usuari loginejat: {Login(connection,"Patata1234").AccessToken}");
            WriteLine($"Usuari loginejat error: {Login(connection,"Patata12345")?.AccessToken}");

            // await Utils.StartDocker("sqlserver");   
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
        private static TokenResponse? Login(Connection connection, string password)
        {
            UserADO userADO = new UserADO(connection);
            User user = userADO.GetByEmail("joan@gmail.com");
            if (user.Login(password)) 
            {
                return (TokenResponse)Token.GenerateJwtToken(user, new TokenResponse());
            }
            return null;
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
            try 
            {
                return userADO.Create(user);
            }
            catch (DBException dbex)
            {
                throw dbex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;
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