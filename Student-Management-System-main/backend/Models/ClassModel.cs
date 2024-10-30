using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class ClassModel : CreateClassModel
    {
        public int classId
        {
            get;
            set;
        }
        public List<CourseModel> courseList
        { 
            get; 
            set; 
        } 
    }
}