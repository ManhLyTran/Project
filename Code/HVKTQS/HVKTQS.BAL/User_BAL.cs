using HVKTQS.DAL;
using HVKTQS.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVKTQS.BAL
{
    public class User_BAL
    {
        private User_DAL objUser_DAL = new User_DAL();

        public int Update(User_DTO obj)
        {
            return objUser_DAL.Update(obj);
        }

        public int Insert(User_DTO obj)
        {
            return objUser_DAL.Insert(obj);
        }

        public int DeleteByID(int UserID)
        {
            return objUser_DAL.DeleteByID(UserID);
        }

        public DataTable GetAll()
        {
            return objUser_DAL.GetAll();
        }

        public bool IsExists(int UserID, string UserName)
        {
            return objUser_DAL.IsExists(UserID, UserName);
        }

        public User_DTO GetObject(int UserID)
        {
            return objUser_DAL.GetObject(UserID);
        }

        public UserExtension_DTO Login(string username, string password)
        {
            return objUser_DAL.Login(username, password);
        }

        public int UpdateLastIPAddress(int UserID, string LastIPAddress)
        {
            return objUser_DAL.UpdateLastIPAddress(UserID, LastIPAddress);
        }

        public int ChangePassword(int UserID, string Password)
        {
            return objUser_DAL.ChangePassword(UserID, Password);
        }

        public int UpdateLockUsser(int UserID, bool IsLock)
        {
            return objUser_DAL.UpdateLockUsser(UserID, IsLock);
        }

        public DataTable Search(string Keyword)
        {
            return objUser_DAL.Search(Keyword);
        }
    }
}