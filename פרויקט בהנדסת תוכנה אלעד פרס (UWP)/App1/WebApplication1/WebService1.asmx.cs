using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public void Insert(String userName, String firstName, String lastName, String password)
        {
            Connection connection = new Connection();
            string sql = "Insert into Users(userName, firstName, lastName, password) values('" + userName + "', '" + firstName + "', '" + lastName + "', '" + password + "')";
            connection.GetDataSet(sql, "Users");
        }
        [WebMethod]
        public bool IsUserExist(string userName)
        {
            Connection connection = new Connection();
            return connection.IsExist("select * from Users where UserName = '" + userName + "'");
        }
        [WebMethod]
        public DataTable GetTable()
        {
            Connection connection = new Connection();
            string sql = "select * from Users";
            DataSet dataSet = connection.GetDataSet(sql, "Users");
            DataTable dataTable = dataSet.Tables[0];
            return dataTable;
        }
        [WebMethod]
        public void Update(int ID, String userName, String firstName, String lastName, String password)
        {
            Connection connection = new Connection();
            string sql = "update Users set firstName = '" + firstName + "', lastName = '" + lastName + "', password = '" + password + "',  userName = '" + userName + "' where ID =" + ID;
            connection.GetDataSet(sql, "Users");
        }
        [WebMethod]
        public bool isIDExist(int ID)
        {
            Connection connection = new Connection();
            return connection.IsExist("select * from Users where ID =" + ID);
        }
    }
}
