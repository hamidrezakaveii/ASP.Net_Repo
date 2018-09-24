using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Jour3_HtmlHelper.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [DisplayName("Student Name: ")]
        public string StudentName { get; set; }
        public int Age { get; set; }
        public string Description { get; set; }

        public bool IsNewlyEnrolled { get; set; }

        public string StudentGender { get; set; }
        public DateTime DoB { get; set; }


        public override string ToString()
        {
            return "Name: "+ StudentName + " Description: "+ Description+ " Enrolled: "+ IsNewlyEnrolled + " Gender: "+StudentGender;
        }


    }
}