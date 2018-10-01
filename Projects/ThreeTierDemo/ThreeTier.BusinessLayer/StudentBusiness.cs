using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Student.Entity;

namespace ThreeTier.BusinessLayer
{
    public class StudentBusiness
    {
        DataAccessLayer.Student stu = new DataAccessLayer.Student();
        public List<string> GetStudentDetails()
        {
            
           var details = stu.GetStudentDetail();
            

            if(details[2].Length > 5)
            {
               // throw new InvalidLengthException()
            }

            if (details[0].Contains('a'))
            {
                details[0].Replace('r', 'a');
            }

            return details;
        }

        public string InsertStudentDetails(StudentDetails stuDet)
        {
            
            int status = stu.InsertDetails(stuDet);

            if (status > 0)
            {
                return "Your record has been saved with the following details!";
            }
            else
            {
                return "something went wrong";
            }
        }
    }
}
