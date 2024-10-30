using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Enums;

namespace backend.Models
{
    public class CreateCouresModel
    {
        public  string? courseName
        {
            get;
            set;
        }

        public  string? courseDescription
        {
            get;
            set;
        }

        public  string? courseCode
        {
            get;
            set;
        }

        public int maxCapacity
        {
            get;
            set;
        }

        public  int credits
        {
            get;
            set;
        }

        public  Department departmentId
        {
            get;
            set;
        }

    }

}