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
using System.Linq;
using AutoMapper;
using System.Collections;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using static System.Console;
using BoscComa.ADO;
using BoscComa.Helper;
using BoscComa.DTO;
using BoscComa.GestioErrors;
using NRedisStack;
using NRedisStack.RedisStackCommands;
using StackExchange.Redis;

namespace BoscComa.AppERP
{
    public class Program 
    {
        public static async Task Main() 
        {
            // await Utils.StopDocker("sqlserver");
            IMapper mapper = ConfigMapper();

            MSSQLConnection connection=ConnectToDB();    // Sembla que la connexió no pot fallar. Amb DOCKER aturat no dóna error!
           
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
            
            TokenResponse tokenResponse = Login(connection,"Patata1234");
            ConnectionRedis.Inicialitzar("localhost");
            TokenResponseADO tokenResponseADO = new TokenResponseADO(ConnectionRedis.ConnectionDB);
            tokenResponseADO.Save(tokenResponse);
            EscriureTokenRefresh(tokenResponse);
            WriteLine($"Usuari loginejat error: {Login(connection,"Patata12345")?.AccessToken}");

            // await Utils.StartDocker("sqlserver");   
            List<UserDTO> usersDTO = GetViewUsers(connection, mapper);

            ViewData(usersDTO.Where((Selected)).ToList());
            bool errorUpdatingUser = UpdateUser(usersDTO[0],connection,mapper);
            usersDTO = GetViewUsers(connection, mapper);
            ViewData(usersDTO.Where(userDTO => userDTO.Uuid.Contains("d4")).ToList());
            bool errorCreatingItem = CreateItem(connection,usersDTO[0].Uuid);
        }
        private static bool Selected(UserDTO userDTO) {
            return userDTO.Uuid.Contains("d4");
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
        private static MSSQLConnection ConnectToDB() 
        {
            string path=@"/home/projecteinf/Projectes/2025/EF/App Examples/Console App/20.DB/ADOExample/Config";
            string fileName=@"connction.enc";
            MSSQLConnection.Inicialitzar(path, fileName);
            return MSSQLConnection.ConnectionDB;
        }
        private static TokenResponse? Login(MSSQLConnection connection, string password)
        {
            UserADO userADO = new UserADO(connection);
            User user = userADO.GetByEmail("joan@gmail.com");
            if (user.Login(password)) 
            {
                return (TokenResponse)Token.GenerateJwtToken(user, new TokenResponse());
            }
            return null;
        }
        private static bool CreateUser(MSSQLConnection connection)
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
        private static List<UserDTO> GetViewUsers(MSSQLConnection connection, IMapper mapper)
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
        private static bool UpdateUser(UserDTO userDTO, MSSQLConnection connection, IMapper mapper)
        {
            User user = mapper.Map<User>(userDTO);
            user.Email="joan@boscdelacoma.cat";
            UserADO userADO = new UserADO(connection);
            return userADO.Update(user);
        }
        private static bool CreateItem(MSSQLConnection connection, string userOwner)
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
        private static async Task EscriureTokenRefresh(TokenResponse token)
        {
            string key = $"refresh:{token.RefreshToken}";
            HashEntry[] allFields = ConnectionRedis.ConnectionDB.GetConnection().HashGetAll(key);
            foreach (var field in allFields)
            {
                WriteLine($"{field.Name}: {field.Value}");
            }
        }
    }
}