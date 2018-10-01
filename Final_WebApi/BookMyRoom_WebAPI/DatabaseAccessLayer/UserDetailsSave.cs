using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer
{
    public class UserDetailsSave
    {
        /// <summary>
        /// dbContext is the object for BookMyRoomDBContext class
        /// By using this Database can be accessed and Database updating is carried out
        /// </summary>
        private readonly DbContext.BookMyRoomDBContext dbContext = new DbContext.BookMyRoomDBContext();
        /// <summary>
        /// SaveUserDetails method will receive userDetails object and add it into database
        /// </summary>
        /// <param name="signupdetails"></param>
        /// <returns>int</returns>

        public bool SaveUserDetails(UserDetails signupdetails)
        {
            //RewardPoints is the property of UserDetails Class. Whenever A person Signup, he will get 5 points as rewards
            //RewardPoints is used for Discount purpose
            signupdetails.rewardPoints = 5;
            signupdetails.profilepic = "./assets/user.png";
            //try block will try to add the userdetails in Database.

            try
            {
                //Using BookMyRoomDBContext class object we are accessing the Userdetails table by using UserDetails table object userDetails
                //Add method is used to new data into table by passing an object

                dbContext.userDetails.Add(signupdetails);

                //SaveChanges method is to save changes after adding object to table in Database

                dbContext.SaveChanges();
            }

            //Catch block will hits when the SaveChanges Method fails
            //When we try to save already existed UserName, Email it will hits

            catch
            {
                //Catch block returns 0 when the details are not saved

                return false;
            }

            //If the details are added into DataBase successfully returns 1

            return true;
        }

        /// <summary>
        /// To Check whether the logindetails are there in Database or not
        /// </summary>
        /// <param name="logindetails"></param>
        /// <returns>bool</returns>

        public bool CheckValidation(UserDetails logindetails)
        {
            //q is var type vriable which holds the data obtained from Linq Statement
            //Retriving the logindetails when the username and password matches

            var q = from UserDetails in dbContext.userDetails
                    where UserDetails.userName == (logindetails.userName)
                    && UserDetails.password == (logindetails.password)
                    select UserDetails;
            //if q.Any() contains any data it will returns true

            if (q.Any())
            {

                return true;
            }
            else
            {
                // returns false if login credentials are not matched or those credentials does not exists

                return false;
            }
        }

        public bool AdminValidation(UserDetails admindetails)
        {
            //adminResult is var type vriable which holds the data obtained from Linq Statement
            //Retriving the admindetails when the username and password matches

            //var adminResult = from UserDetails in dbContext.userDetails
            //                  where UserDetails.email == (admindetails.email)
            //                  && UserDetails.password == (admindetails.password)
            //                  select UserDetails;
            ////if adminResult.Any() contains any data it will returns true

            //if (adminResult.Any())
            if ((admindetails.email == "bookmyroom10@gmail.com") && (admindetails.password == "Mindtree"))
            {

                return true;
            }
            else
            {
                // returns false if login credentials are not matched or those credentials does not exists

                return false;
            }
        }


        /// <summary>
        /// Retrieving the row of LoggedUSer details into UserDetails object <<user>> from parameter "user" 
        /// </summary>
        /// <param name="loggeduserdetails"></param>
        /// <returns></returns>
        public UserDetails LoggedUser(UserDetails loggeduserdetails)
        {
            //Retrieving the logindetails when the username and password matches and storing to parameter userdetails

            UserDetails userdetails = dbContext.userDetails.SingleOrDefault(x =>
               x.userName == loggeduserdetails.userName && x.password == loggeduserdetails.password);

            return userdetails;
        }

        /// <summary>
        /// Saving the changes to database by using UserDetails Object -- "user"
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool UpdateRewards(UserDetails user)
        {
            //Trying to change the rewards point of the logged user

            try
            {
                dbContext.Entry(user).State = EntityState.Modified;
                dbContext.SaveChanges();

                //After perfect changes this method returns 1

                return true;
            }

            catch
            {
                //if any error occurs catch block returns 0

                return false;
            }

        }
        //----------User Profile Starts--------------------
        public bool UserProfileName(UserProfileName user)
        {
           // string name = user.fName + " " + user.lName;
            UserDetails userDetails = dbContext.userDetails.SingleOrDefault(x =>
             x.userId == user.userId);
            if (userDetails != null)
            {
                userDetails.name = user.fName;
                dbContext.Entry(userDetails).State = EntityState.Modified;
                dbContext.SaveChanges();

                bool emailResult = SendMail(userDetails.name, userDetails.email, 1);//sending email
                if (emailResult)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }

        }

        public bool UserProfilePhone(UserProfilePhone user)
        {

            UserDetails userDetails = dbContext.userDetails.SingleOrDefault(x =>
             x.userId == user.userId);
            if (userDetails != null)
            {
                userDetails.mobileNo = user.mobileNo;
                dbContext.Entry(userDetails).State = EntityState.Modified;
                dbContext.SaveChanges();
                bool emailResult = SendMail(userDetails.name, userDetails.email, 2);//sending email
                if (emailResult)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }


        public bool UserProfilePasssword(UserProfilePasssword user)
        {
            UserDetails userDetails = dbContext.userDetails.SingleOrDefault(x =>
            x.userId == user.userId);
            if (userDetails != null && user.oldPass.Equals(userDetails.password))
            {
                userDetails.password = user.newPass;
                dbContext.Entry(userDetails).State = EntityState.Modified;
                dbContext.SaveChanges();
                bool emailResult = SendMail(userDetails.name, userDetails.email, 3);//sending email
                if (emailResult)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }
        public bool SendMail(string name, string email, int whatInfo)
        {
            string body;
            if (whatInfo == 1)
            {
                body = "Your name has been changed.";
            }
            else if (whatInfo == 2)
            {
                body = "Your phone number has been changed.";
            }
            else if (whatInfo == 3)
            {
                body = "Your password has been changed.";
            }
            else
            {
                return false;
            }

            try
            {

                string FromAddress = "bookmyroom10@gmail.com";
                string Password = "Mindtree";
                string ToAddress = email;
                MailMessage message = new MailMessage();
                message.Subject = "Dear user your profile was recently changed!";
                message.From = new MailAddress(FromAddress);
                message.Body = "Hello " + name + ",\n\n" + body + "\n\n\n Thanks and Regards, \n\n" + "Admin(BookMyRoom)";
                message.To.Add(new MailAddress(ToAddress));
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = true;
                NetworkCredential nc = new NetworkCredential(FromAddress, Password);
                smtp.Credentials = nc;
                smtp.Send(message);


            }
            catch (Exception ex)
            {
                Console.WriteLine("Email not sent: " + ex.Message);
                Console.ReadKey();
                return false;
            }
            return true;
        }

        public UserDetails Save_Social_User(UserDetails sociallogin)
        {


            bool res = dbContext.userDetails.Count(x => x.email == sociallogin.email) > 0;
            if(res)
            {
                UserDetails user = Social_sigin_user(sociallogin);
                return user;
            }
         
            else
            { 
               

                dbContext.userDetails.Add(sociallogin);

            

                dbContext.SaveChanges();
                return sociallogin;
            }

          

           
        }
        public UserDetails Social_sigin_user(UserDetails user)
        {
            UserDetails userDetails = dbContext.userDetails.SingleOrDefault(x =>
            x.email == user.email);
            return userDetails;
        }
        /// <summary>
        /// Checks the database for existing Email Address
        /// </summary>
        /// <param name="mail"></param>
        /// <returns></returns>
        public UserDetails verifyMailDAL(string mail)
        {
            UserDetails user = dbContext.userDetails.SingleOrDefault(x => x.email == mail);
            return user;

        }

        public bool UpdatePasswordDAL(UserDetails user)
        {
            //Trying to change the password of the logged user

            try
            {
                dbContext.Entry(user).State = EntityState.Modified;
                dbContext.SaveChanges();

                //After perfect changes this method returns 1

                return true;
            }

            catch
            {
                //if any error occurs catch block returns 0

                return false;
            }

        }
        public void Save_User_Image(int id,string image)
        {
            try
            {
                UserDetails user = dbContext.userDetails.Find(id);
                user.profilepic = image;
                dbContext.Entry(user).State = EntityState.Modified;
                dbContext.SaveChanges();
            }
            catch
            {
                throw new ArgumentNullException("Cannot find Details");
            }
           
        }
    }
}