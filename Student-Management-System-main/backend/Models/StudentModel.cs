using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class StudentModel : UserModel
    {
        public int grade
        {
            get;
            set;
        }

    }
}