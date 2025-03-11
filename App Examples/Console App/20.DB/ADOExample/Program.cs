﻿using System;
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
            WriteLine("Dades de vista");
            foreach (UserDTO user in usersDTO)
            {
                WriteLine($"User: {user.Uuid} - {user.Name} - {user.Email}");
            }
        }

        private static IMapper ConfigMapper()
        {
            MapperConfiguration configMapper = new MapperConfiguration(config =>
                {
                    config.CreateMap<User,UserDTO>();
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
        
    }
}