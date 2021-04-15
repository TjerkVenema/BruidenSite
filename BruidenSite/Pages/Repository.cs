using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using MySql.Data.MySqlClient;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace BruidenSite.Pages
{
    public class Repository
    {
        public static IDbConnection Connect()
        {
            return new MySqlConnection(
                "Server=127.0.0.1;Port=3306;" +
                ";Database=bruidensite;" +
                "Uid=root;Pwd=Test12345;"
            );
        }

        public static List<User> Get()
        {
            using var connection = Connect();
            var users = connection.Query<User>("SELECT * FROM user");
            return users.ToList();
        }
        
        public static User GetById(int _userId)
        {
            using var connection = Connect();
            var userId = connection.QuerySingleOrDefault<User>(
                "SELECT * FROM user WHERE UserId = @UserId",
                new {UserId = _userId});
            return userId;
        }

        public static void AddUser(User newUser)
        {
            using var connection = Connect();
            var user = connection.Execute(
                "INSERT INTO user(UserName, PassWord, EMailadres, WensenlijstId) VALUES (@UserName, @PassWord, @E_mailadres, @WensenlijstId)",
                new
                {
                    UserName = newUser.UserName,
                    PassWord = newUser.PassWord,
                    E_Mailadres = newUser.EMailadres,
                    WensenlijstId = newUser.WensenlijstId
                });
        }

        public static void AddDl(User DLUser)
        {
            using var connection = Connect();
            var updatedUser = connection.Execute(
                "UPDATE User SET TrouwDatum = @TrouwDatum, TrouwLocatie = @TrouwLocatie WHERE UserId = @UserId;",
                new
                {
                    TrouwDatum = DLUser.TrouwDatum,
                    TrouwLocatie = DLUser.TrouwLocatie,
                    UserId = DLUser.UserId
                });
        }

        public static User GetDL(int _userId)
        {
            using var connection = Connect();
            var Dl = connection.QuerySingleOrDefault<User>(
                "SELECT TrouwDatum, TrouwLocatie FROM user WHERE UserId = @userId",
                new {userId = _userId});
            return Dl;
        }

        public static User Login(string username, string password)
        {
            using var connection = Connect();
            var user = connection.QuerySingleOrDefault<User>(
                "SELECT * FROM user WHERE PassWord = @Password1 AND UserName = @UserName",
                new 
                {
                    password1 = password,
                    UserName = username
                });
            return user;
        }

        public static void AddList(WensenLijst wensenLijst)
        {
            using var connection = Connect();
            var list = connection.Execute(
                "INSERT INTO wensenlijst(UniqueId) values (@UniqueId)",
                new
                {
                    UniqueId = wensenLijst.UniqueId
                });
        }

        public static WensenLijst GetListIdcode(string uniqueId)
        {
            using var connection = Connect();
            var listId = connection.QuerySingleOrDefault<WensenLijst>(
                "SELECT WensenlijstId FROM wensenlijst WHERE UniqueId = @UniqueId",
                new {UniqueId = uniqueId});
            return listId;
        }
        
        public static WensenLijst GetListIduser(int userId)
        {
            using var connection = Connect();
            var listId = connection.QuerySingleOrDefault<WensenLijst>(
                "SELECT WensenlijstId FROM user WHERE UserId = @UserId",
                new {UserId = userId});
            return listId;
        }

        public static List<Cadeau> GetCadeausByListId(int wensenlijstId)
        {
            using var connection = Connect(); 
            var listcadeau = connection.Query<Cadeau>(
                "SELECT * FROM cadeau WHERE WensenlijstId = @WensenlijstId ORDER BY Prioriteit desc",
                new {WensenlijstId = wensenlijstId}
            );
            return listcadeau.ToList();
        }

        public static void AddCadeau(Cadeau newCadeau)
        {
            using var connection = Connect();
            var cadeau = connection.Execute(
                "INSERT INTO cadeau(Cadeaunaam, WensenlijstId, Prioriteit, Done) values (@Cadeaunaam, @WensenlijsId, @Prioriteit, @Done)",
                new
                {
                    Cadeaunaam = newCadeau.CadeauNaam,
                    WensenlijsId = newCadeau.WensenlijstId,
                    Prioriteit = newCadeau.Prioriteit,
                    Done = 0
                });
        }

        public static WensenLijst GetListIdByCode(string uniquecode)
        {
            using var connection = Connect();
            var listId = connection.QuerySingleOrDefault<WensenLijst>(
                "SELECT WensenlijstId FROM wensenlijst WHERE UniqueId = @UniqueId",
                new {UniqueId = uniquecode});
            return listId;
        }

        public static void RemoveListItem(int cadeauId, int wensenlijstId)
        {
            using var connection = Connect();

            var prio = GetPrioByCadeauId(cadeauId);
            
            connection.Execute(
                "DELETE FROM cadeau WHERE CadeauId = @CadeauId",
                new
                {
                    CadeauId = cadeauId
                });
            
            var list = GetCadeausByListId(wensenlijstId);
            foreach (var a in list)
            {
                if (a.Prioriteit < prio)
                {
                    connection.Execute(
                        "UPDATE cadeau SET Prioriteit = @Prioriteit WHERE CadeauId = @CadeauId",
                        new 
                        {
                            Prioriteit = a.Prioriteit + 1,
                            CadeauId = a.CadeauId
                        });
                }
            }
        }

        public static int GetPrioByCadeauId(int cadeauId)
        {
            using var connetion = Connect();
            int prio = connetion.QuerySingleOrDefault<int>(
                "SELECT Prioriteit FROM cadeau WHERE CadeauId = @CadeauId",
                new
                {
                    CadeauId = cadeauId
                });
            return prio;
        }

        public static void UpdatePrioUp(int cadeauId, int wensenlijstId)
        {
            using var connection = Connect();
            var list = GetCadeausByListId(wensenlijstId);
            int index = list.FindIndex(a => a.CadeauId == cadeauId);
            if (index != 0)
            {
                connection.Execute(
                    "UPDATE cadeau SET Prioriteit = @Prioriteit WHERE CadeauId = @CadeauId",
                    new {
                        Prioriteit = GetPrioByCadeauId(cadeauId) + 1,
                        CadeauId = cadeauId
                    });
                
                connection.Execute(
                    "UPDATE cadeau SET Prioriteit = @Prioriteit WHERE CadeauId = @CadeauId",
                    new
                    {
                        Prioriteit = list[index - 1].Prioriteit - 1,
                        CadeauId = list[index - 1].CadeauId 
                    });
            }
        }

        public static void UpdatePrioDown(int cadeauId, int wensenlijstId)
        {
            using var connection = Connect();
            var list = GetCadeausByListId(wensenlijstId);
            int index = list.FindIndex(a => a.CadeauId == cadeauId);
            int total = list.Count -1;
            if (index != total)
            {
                connection.Execute(
                    "UPDATE cadeau SET Prioriteit = @Prioriteit WHERE CadeauId = @CadeauId",
                    new {
                        Prioriteit = GetPrioByCadeauId(cadeauId) - 1,
                        CadeauId = cadeauId
                    });
                
                connection.Execute(
                    "UPDATE cadeau SET Prioriteit = @Prioriteit WHERE CadeauId = @CadeauId",
                    new
                    {
                        Prioriteit = list[index + 1].Prioriteit + 1,
                        CadeauId = list[index + 1].CadeauId 
                    });
            }
        }

        public static void UpdateDoneAndBuyer(List<int> cadeauId, string Buyername)
        {
            using var connection = Connect();
            foreach (var Id in cadeauId)
            {
                connection.Execute(
                    "UPDATE cadeau SET Done = @Done, Koper = @Koper WHERE CadeauId = @CadeauId",
                    new
                    {
                        Done = 1,
                        Koper = Buyername, 
                        CadeauId = Id
                    });
            }
        }

        public static User GetUserByListId(int listId)
        {
            using var connection = Connect();
            var user = connection.QuerySingleOrDefault<User>(
                "SELECT TrouwDatum, TrouwLocatie FROM user WHERE WensenlijstId = @ListId",
                new
                {
                    ListId = listId
                });
            return user;
        }
        public static string GetListCodeById(int listId)
        {
            using var connection = Connect();
            var uniqueId = connection.QuerySingleOrDefault<string>(
                "SELECT UniqueId FROM wensenlijst WHERE WensenlijstId = @WensenlijstId",
                new {WensenlijstId = listId});
            return uniqueId;
        }
    }
}