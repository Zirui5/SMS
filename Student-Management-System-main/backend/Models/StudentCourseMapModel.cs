using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class StudentCourseMapModel
    {
        public int studentId
        {
            get;
            set;
        }

        public int courseId
        {
            get;
            set;
        }
    }
}