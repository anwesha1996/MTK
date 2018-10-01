using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DatabaseAccessLayer;
using System.Security.Cryptography;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.IO;
using System.Data.Entity;

namespace BusinessLayer
{
    public class UserDetailsManager
    {
        /// <summary>
        /// saveUserDetails is the object for the class UserDetailsSave in DataAccessLayer 
        /// </summary>
        /// 
        private readonly UserDetailsSave saveUserDetails = new UserDetailsSave();

        /// <summary>
        /// Method is converting username and password as HashCode for security purpose
        /// </summary>
        /// <param name="userDetails"></param>
        /// <returns> integer "result"</returns>
        public bool SaveUserDetails(UserDetails userDetails)
        {
            //Password is converting to Hashcode and updating the same in the object by calling ComputeSha256Hash method

            userDetails.password = ComputeSha256Hash(userDetails.password);

            //Username is converting to Hashcode and updating the same in the object  by calling ComputeSha256Hash method

            userDetails.userName = ComputeSha256Hash(userDetails.userName);

            //Calling SaveUserDetails method which is in DataAccessLayer

            bool result = saveUserDetails.SaveUserDetails(userDetails);
            return result;
        }

        /// <summary>
        /// Method will calls CheckValidation in DataAccess Layer by passing an object "logindetails"
        /// </summary>
        /// <param name="logindetails"></param>
        /// <returns> Bool</returns>
         
        public bool CheckValidation(UserDetails logindetails)
        {
            
            //Password is converting to Hashcode and updating the same in the object by calling ComputeSha256Hash method

            logindetails.password = ComputeSha256Hash(logindetails.password);

            //Username is converting to Hashcode and updating the same in the object by calling ComputeSha256Hash method

            logindetails.userName = ComputeSha256Hash(logindetails.userName);
            bool res;
            //CAlling CheckVAlidation method in DataAccessLayer by passing parameter "logindetails"

            res = saveUserDetails.CheckValidation(logindetails);
           
            return res;
        }

        public bool AdminValidation(UserDetails admindetails)
        {

            //Password is converting to Hashcode and updating the same in the object by calling ComputeSha256Hash method

            // admindetails.password = ComputeSha256Hash(admindetails.password);

            bool res;
            //CAlling CheckVAlidation method in DataAccessLayer by passing parameter "logindetails"

            res = saveUserDetails.AdminValidation(admindetails);

            return res;
        }

        /// <summary>
        /// Converting the string raw data to Hash Code
        /// </summary>
        /// <param name="unhasheddata"></param>
        /// <returns> string in Hashcode</returns>
        /// 
        static string ComputeSha256Hash(string unhasheddata)
        {
            // Create a SHA256 
            
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  

                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(unhasheddata));

                // Convert byte array to a string   

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        /// <summary>
        /// To find LoggedUser details using Login Credentials 
        /// The Credentials are in HashCode so converting the data to HashCode by calling ComputeSha256Hash method 
        /// After converting calling LoggedUserFetch method in DataAccessLayer by passing "loggeddetails" parameter
        /// </summary>
        /// <param name="loggeddetails"></param>
        /// <returns> string</returns>

        public UserDetails LoggedUser(UserDetails loggeddetails)
        {
            //Password is converting to Hashcode and updating the same in the object by calling ComputeSha256Hash method

            loggeddetails.password = ComputeSha256Hash(loggeddetails.password);

            //Password is converting to Hashcode and updating the same in the object by calling ComputeSha256Hash method

            loggeddetails.userName = ComputeSha256Hash(loggeddetails.userName);

            //returns UserDetails Object which contains Logged User Data by calling LoggedUser method in DataAccessLayer

            return saveUserDetails.LoggedUser(loggeddetails);
        }
       
        /// <summary>
        /// Calling UpdateRewards Method in DataAccessLayer by passing "rewardsupdate" parameter
        /// </summary>
        /// <param name="rewardsupdate"></param>
        /// <returns>int</returns>
        public bool UpdateRewards(UserDetails rewardsupdate)
        {
            if (rewardsupdate == null)
            {
                //If the rewardsupdate is null ArgumentNullException will be thrown
                throw new ArgumentNullException("NullValues");
            }
            //calling UpdateRewards methods in DataAccessLayer by passing parameter "rewardsupdate" which returns int

           return saveUserDetails.UpdateRewards(rewardsupdate); 
            
        }
        //------------User Profile Starts from here-----------------
        public bool UserProfileName(UserProfileName user)
        {
            bool result = saveUserDetails.UserProfileName(user);
            if (result)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UserProfilePhone(UserProfilePhone user)
        {
            bool result = saveUserDetails.UserProfilePhone(user);
            if (result)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool UserProfilePasssword(UserProfilePasssword user)
        {
            user.oldPass = ComputeSha256Hash(user.oldPass);
            user.newPass = ComputeSha256Hash(user.newPass);
            bool result = saveUserDetails.UserProfilePasssword(user);
            if (result)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public UserDetails SocialUser(UserDetails user)
        {
            return saveUserDetails.Save_Social_User(user);
        }

        //FORGOT PASSWORD!

        string otp;
        /// <summary>
        /// Verifying Email Id for forgor password  by passing mail through BAL
        /// </summary>
        /// <param name="mail"></param>
        /// <returns></returns>
        public UserDetails VerifyMailBAL(string mail)
        {
            return saveUserDetails.verifyMailDAL(mail);
        }

        public string generateOTPBAL(string mail)
        {
            string num = "123456789";
            int len = num.Length;
            otp = string.Empty;
            int otpdigit = 4;
            string finalotp;
            int getindex;

            for (int i = 0; i < otpdigit; i++)
            {
                do
                {
                    getindex = new Random().Next(0, len);
                    finalotp = num.ToCharArray()[getindex].ToString();
                }
                while (otp.IndexOf(finalotp) != -1);
                otp += finalotp;
            }
            SendMail(mail);
            return otp;
        }

        public void SendMail(string mail)
        {
            try
            {
                string FromAddress = "bookmyroom10@gmail.com";
                string Password = "Mindtree";
                string ToAddress = mail;
                MailMessage message = new MailMessage();
                message.Subject = "ONE TIME PASSWORD!";
                message.From = new MailAddress(FromAddress);
                message.Body = "*This is a system generated Email, Please do not reply to this Email* \n\n\n\n"+"Hello,\n\n" + "Please verify the OTP provided below to change your password: \n\n\n" + "OTP: " + otp + "\n\n\n Thanks and Regards, \n\n" + "-BookMyRoom";
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
            }
        }

        public bool UpdatePasswordByOTP(UserDetails updatePassword)
        {
            if (updatePassword == null)
            {
                //If the rewardsupdate is null ArgumentNullException will be thrown
                throw new ArgumentNullException("NullValues");
            }
            //calling UpdatePassword methods in DataAccessLayer by passing parameter "rewardsupdate" which returns int

            updatePassword.password = ComputeSha256Hash(updatePassword.password);
            return saveUserDetails.UpdatePasswordDAL(updatePassword);

        }
        public void SaveImage(HttpRequest httpRequest)
        {
           
            int count = 0;
            int id = 0;
           
            id = Convert.ToInt32(httpRequest.Files[0].FileName);

            foreach (var file in httpRequest.Files)
            {
                var postedFile = httpRequest.Files[count];

                using (var binaryReader = new BinaryReader(postedFile.InputStream))
                {
                    byte[] imageContent = binaryReader.ReadBytes(postedFile.ContentLength);
                    string imageURL = "data:image/jpg;base64," + Convert.ToBase64String(imageContent);


                    saveUserDetails.Save_User_Image(id, imageURL);

                    count++;

                }
            }
            

                }

            
        

    }
}
