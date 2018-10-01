using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLayer
{
    public class StudentBusiness
    {
        Student student = new Student();
        int status = student.InsertDetails(UsernameId.Text, EmailId.Text, ContactId.Text);
        var studentDetails = student.GetStudentDetail();
    }
}
