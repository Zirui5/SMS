using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class UserSignUpModel
    {
        public required string firstName
        {
            get;
            set;
        }

        public required string lastName
        {
            get;
            set;
        }

        public required string userName 
        {
            get;
            set;
        }

        public required string emailId
        {
            get;
            set;
        }

        public required string password
        {
            get;
            set;
        }

        public required string contact
        {
            get;
            set;
        }

    }
}