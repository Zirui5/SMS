using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;

namespace backend.Interface
{
    public interface ICourseHelper
    {
        public interface ICourseHelper
        {
            Task CreateCourse(CreateCouresModel course);
            Task UpdateCourse(CourseModel course);
            Task DeleteCourse(int courseId);
            Task<CourseModel> GetCourse(int courseId);
        }
    }
}