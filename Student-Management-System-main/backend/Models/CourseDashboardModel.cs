using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class CourseDashboardModel : CourseModel
    {
        public int totalEnrollment
        {
            get;
            set;
        }

        public string teacherName
        {
            get;
            set;
        }

        public int teacherId
        {
            get;
            set;
        }


    }
}