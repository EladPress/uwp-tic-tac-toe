using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Classes
{
    public class Users
    {
        private int _ID, _score;
        private string _userName, _firstName, _lastName, _password;
        private Boolean _isAdmin;

        public Users() { }

        public int ID { get => _ID; set => _ID = value; }
        public int Score { get => _score; set => _score = value; }
        public string UserName { get => _userName; set => _userName = value; }
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public string Password { get => _password; set => _password = value; }
        public Boolean IsAdmin { get => _isAdmin; set => _isAdmin = value; }
    }
}
