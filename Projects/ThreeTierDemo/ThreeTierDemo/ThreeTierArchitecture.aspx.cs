using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Student.Entity;
using ThreeTier.BusinessLayer;

namespace ThreeTierDemo
{
    public partial class ThreeTierArchitecture : System.Web.UI.Page
    {
        private StudentBusiness _stu = new StudentBusiness();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            StudentDetails student = new StudentDetails()
            {
                StudentName = UsernameId.Text,
                EmailId = EmailId.Text,
                ContactID = ContactId.Text
            };


            Label1.Text = _stu.InsertStudentDetails(student);

            var studentDetails = _stu.GetStudentDetails();

            Label2.Text = "User Name"; Label5.Text = studentDetails[0];
            Label3.Text = "Email ID"; Label6.Text = studentDetails[1];
            Label4.Text = "Contact"; Label7.Text = studentDetails[2];

        }
    }
}