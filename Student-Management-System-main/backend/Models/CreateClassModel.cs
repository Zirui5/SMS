using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class CreateClassModel
    {

        public string className
        { 
            get; 
            set; 
        } 

        public string classTerm
        { 
            get; 
            set; 
        } 

        public int teacherId
        { 
            get; 
            set; 
        } 

        public string location
        { 
            get; 
            set; 
        } 

        public string classDescription
        {
            get;
            set;
        }
    
        public DateTime startTime
        { 
            get; 
            set; 
        } 

        public DateTime endTime
        { 
            get; 
            set; 
        } 
    }
}