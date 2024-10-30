using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Enums;

namespace backend.Models
{
    public class UserModel
    {

        public string? userName
        {
            get;
            set;
        }
        public string? firstName
        {
            get;
            set;
        }
        public string? lastName
        {
            get;
            set;
        }

        public int? userId
        {
            get;
            set;
        }

        public string? emailId
        {
            get;
            set;
        }

        public UserType userType
        {
            get;
            set;
        }

        public string password
        {
            get;
            set;
        }

        public string? contact
        {
            get;
            set;
        }

    }
}