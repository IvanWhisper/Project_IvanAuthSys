using System;

namespace DbEntities
{
    public class User
    {
        public string UserID { get; set; }
        public string UserGuid { get; set; }
        public string GroupID { get; set; }

        public string UserName { get; set; }
        public string NickName { get; set; }
        public string Password { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

    }
}
