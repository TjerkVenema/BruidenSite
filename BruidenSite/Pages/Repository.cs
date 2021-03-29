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
                "Uid=root;Pwd=Umbrio-Lanka100;"
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
                "SELECT * FROM cadeau WHERE WensenlijstId = @WensenlijstId",
                new {WensenlijstId = wensenlijstId}
            );
            return listcadeau.ToList();
        }

        public static void AddCadeau(Cadeau newCadeau)
        {
            using var connection = Connect();
            var cadeau = connection.Execute(
                "INSERT INTO cadeau(Cadeaunaam, WensenlijstId) values (@Cadeaunaam, @WensenlijsId)",
                new
                {
                    Cadeaunaam = newCadeau.CadeauNaam,
                    WensenlijsId = newCadeau.WensenlijstId
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
    }
}