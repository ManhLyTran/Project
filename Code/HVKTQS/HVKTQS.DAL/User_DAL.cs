using HVKTQS.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVKTQS.DAL
{
    public class User_DAL
    {
        public int Update(User_DTO obj)
        {
            return SqlHelper.ExecuteNonQueryOfT("User_Update", obj);
        }

        public int Insert(User_DTO obj)
        {
            return Convert.ToInt32(SqlHelper.ExecuteScalarOfT("User_Insert", obj));
        }

        public int DeleteByID(int UserID)
        {
            return SqlHelper.ExecuteNoneQuery("User_DeleteByID", UserID);
        }

        public bool IsExists(int UserID, string UserName)
        {
            return (Convert.ToInt32(SqlHelper.ExecuteScalar("User_IsExists", UserID, UserName)) == 1 ? true : false);
        }

        public DataTable GetAll()
        {
            return SqlHelper.ExecuteReader("User_GetAll");
        }

        public User_DTO GetObject(int UserID)
        {
            return (User_DTO)CBO.FillObject(SqlHelper.ExecuteReader("User_GetObject", UserID), typeof(User_DTO));
        }

        public UserExtension_DTO Login(string username, string password)
        {
            return (UserExtension_DTO)CBO.FillObject(SqlHelper.ExecuteReader("User_Login", username, password), typeof(UserExtension_DTO));
        }

        public int UpdateLastIPAddress(int UserID, string LastIPAddress)
        {
            return SqlHelper.ExecuteNoneQuery("User_UpdateLastIPAddress", UserID, LastIPAddress);
        }

        public int ChangePassword(int UserID, string Password)
        {
            return SqlHelper.ExecuteNoneQuery("User_ChangePassword", UserID, Password);
        }

        public DataTable Search(string Keyword)
        {
            return SqlHelper.ExecuteReader("User_Search", Keyword);
        }

        public int UpdateLockUsser(int UserID, bool IsLock)
        {
            return SqlHelper.ExecuteNoneQuery("User_UpdateLockUsser", UserID, IsLock);
        }
    }
}