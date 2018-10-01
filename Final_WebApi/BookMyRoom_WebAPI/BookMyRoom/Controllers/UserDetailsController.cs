using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessLayer;
using Entities;
using System.Web.Http.Description;
using System.Web.Http.Cors;
using System.Web;
using System.IO;

namespace BookMyRoom.Controllers
{
    [CustomExceptionFilter]
    public class UserDetailsController : ApiController
    {
        /// <summary>
        /// userDetailsManager is the object of the class UserDetailsManager in BusinessLayer
        /// </summary>
        /// 
        readonly UserDetailsManager userDetailsManager = new UserDetailsManager();

        // POST: api/UserDetails
        /// <summary>
        /// Method to store Signup Userdetails in database by using UserDetails object "userDetails"
        /// </summary>
        /// <param name="userDetails"></param>
        /// <returns> bool</returns>
        
        [HttpPost]
        [ResponseType(typeof(UserDetails))]
        
        public HttpResponseMessage PostUserDetail(UserDetails userDetails)
        {
            
            //Checking whether the object userdetail is null
            if(userDetails==null)
            {
                //If the userDetails is null ArgumentNullException will be thrown

                throw new ArgumentNullException("userDetails cannot be null");
            }
            
            //passing the object to DataAccesslayer by calling "SaveUserDetails" method in Businesslayer
            //which returns integer and is storing in variable  "result"

            bool result = userDetailsManager.SaveUserDetails(userDetails);
            
                if (result)
                {
                //If the result is true StatusCode "201" will be returned

                return Request.CreateErrorResponse(HttpStatusCode.Created, "Account Created Sucessfully");
               
                }
                else
                {
                
                   //If the result is false StatusCode "409" will be returned
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, "Details Already Exists");
                   
                }
            
            
        }

        /// <summary>
        /// //Method used for Login Validation by using UserDetails object "loginparameters"
        /// </summary>
        /// <param name="loginparameters"></param>
        /// <returns> bool </returns>
        
            [Route("api/UserDetails/Validate")]
        public HttpResponseMessage LoginValidation(UserDetails loginparameters)
        {
            //Checking whether the object loginparameters is null
            if (loginparameters == null)
            {
                //If the loginparameters is null ArgumentNullException will be thrown

                throw new ArgumentNullException("NullValues");
            }

            //Passing the method <<CheckValidation>> in Business Layer and passing loginparameter which returns a bool value
            //The bool value is stored in res based upon which HttpResponseMessage will be returned

            bool res = userDetailsManager.CheckValidation(loginparameters);
            

                if (res)
                {

                //If the logincredentials are Valid, Statuscode"200" will be returned

                return Request.CreateErrorResponse(HttpStatusCode.OK, "Logged in Sucessfully"); //using HttpError
                }
                else
                {
                  //If the logincredentials are Invalid, Statuscode"401" will be returned

                    return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Incorrect Credentials");
                }
            
          
        }

        [Route("api/UserDetails/CheckAdmin")]
        public HttpResponseMessage AdminValidation(UserDetails adminparameters)
        {
            //Checking whether the object adminparameters is null
            if (adminparameters == null)
            {
                //If the adminparameters is null ArgumentNullException will be thrown

                throw new ArgumentNullException("NullValues");
            }

            //Passing the method <<AdminValidation>> in Business Layer and passing adminparameter which returns a bool value
            //The bool value is stored in res based upon which HttpResponseMessage will be returned

            bool res = userDetailsManager.AdminValidation(adminparameters);


            if (res)
            {

                //If the admincredentials are Valid, Statuscode"200" will be returned

                return Request.CreateErrorResponse(HttpStatusCode.OK, "Admin Logged in Sucessfully"); //using HttpError
            }
            else
            {
                //If the admincredentials are Invalid, Statuscode"401" will be returned

                return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Incorrect Credentials");
            }


        }


        /// <summary>
        ///  //Method to retrive the details of Loggeduser by using "finduser" object
        /// </summary>
        /// <param name="finduser"></param>
        /// <returns> UserDetails Object</returns>

        [Route("api/UserDetails/LoggedUser")]
        public IHttpActionResult LoggedUser(UserDetails finduser)
        {
            //Checking whether the object finduser is null

            if (finduser == null)
            {
                //If the finduser is null ArgumentNullException will be thrown
                throw new ArgumentNullException("NullValues");
            }

            // Calling LoggedUser method in Business Layer by passing parameter "finduser"
            UserDetails userDetails= userDetailsManager.LoggedUser(finduser);

            //checking whether the userDetails is null

            if (userDetails == null)
            {
                //Using HttpResponseException one can use the HttpResponseException class to return specific HTTP status code and messages from your controller methods in Web API. 

                // If userDetails is null notfound will be thrown
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)   //using HttpResponseMessage
                {
                    Content = new StringContent(string.Format("No User found with UserName = {0}", finduser.userName)),
                    ReasonPhrase = "UserDetails Not Found"
                };

                throw new HttpResponseException(response);
            }
            else
            {
                //userdetails will be returned with Status"Ok"
                return Ok(userDetails);
            }
        }

        /// <summary>
        /// Method to update the reward points based on purchase. 
        /// </summary>
        /// <param name="updaterewards"></param>
        /// <returns></returns>

           
        [Route("api/UserDetails/UpdateRewards")]
        public IHttpActionResult UpdateRewards(UserDetails updaterewards)
        {
            if (updaterewards == null)
            {
                //If the updaterewards is null ArgumentNullException will be thrown
                throw new ArgumentNullException("NullValues");
            }

            // Calling UpdateRewards Method in BusinessLayer by passing "updaterewards" parameter
            bool result= userDetailsManager.UpdateRewards(updaterewards); 
            if(result)
            {
                //true will be returned with Status"Ok"
                return Ok(result);
            }
            else
            {
                // If updaterewards object details is not present in database notfound will be thrown
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)   //using HttpResponseMessage
                {
                    Content = new StringContent(string.Format("No user found with UserId = {0}", updaterewards.userId)),
                    ReasonPhrase = "UserDetails Not Found"
                };

                throw new HttpResponseException(response);
            }
        }
        //----------User Profile Changing Name Starts--------------------
        [Route("api/UserDetails/UserProfileName")]
        [HttpPut]
        public HttpResponseMessage UserProfileName(UserProfileName user)
        {
            bool res = userDetailsManager.UserProfileName(user);
            try
            {

                if (res)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.Accepted, "Updated Sucessfully");
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.Conflict, "Error Occured");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        //----------User Profile Changing PhoneNumber Starts--------------------
        [Route("api/UserDetails/UserProfilePhone")]
        [HttpPut]
        public HttpResponseMessage UserProfilePhone(UserProfilePhone user)
        {
            bool res = userDetailsManager.UserProfilePhone(user);
            try
            {

                if (res)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.Accepted, "Updated Sucessfully");
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.Conflict, "Error Occured");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }



        //----------User Profile Changing password Starts--------------------
        [Route("api/UserDetails/UserProfilePasssword")]
        [HttpPut]
        public HttpResponseMessage UserProfilePasssword(UserProfilePasssword user)
        {
            bool res = userDetailsManager.UserProfilePasssword(user);
            try
            {

                if (res)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.Accepted, "Updated Sucessfully");
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.Conflict, "Error Occured");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
     

        [Route("api/UserDetails/PostSocialuser")]
        [HttpPost]
       
        public UserDetails PostSocialuser(UserDetails user)
        {
            //Checking whether the object userdetail is null
            if (user == null)
            {
                //If the userDetails is null ArgumentNullException will be thrown

                throw new ArgumentNullException("userDetails cannot be null");
            }
            UserDetails result = userDetailsManager.SocialUser(user);
            return result;
        }

        [HttpGet]
        [Route("api/UserDetails/verifyMail")]
        public IHttpActionResult verifyMail(string mail)
        {
            if (mail == null)
            {
                //If email recieved from angular is null, then the following exeption will be thrown.
                throw new ArgumentNullException("NullValues");
            }
            UserDetails result = userDetailsManager.VerifyMailBAL(mail);
            try
            {
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();

            }
        }

        [HttpGet]
        [Route("api/UserDetails/GenerateOTP")]
        public IHttpActionResult GenerateOTP(string mail)
        {
            if (mail == null || mail=="")
            {
                throw new ArgumentNullException("NullValues");
            }

            try
            {
                return Ok(userDetailsManager.generateOTPBAL(mail));
            }
            catch (Exception)
            {
                string message = "Email not sent!";
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, message));
            }
        }





        [HttpPost]
        [Route("api/UserDetails/UpdatePassword")]
        public IHttpActionResult UpdatePassword(UserDetails updatePass)
        {
            if (updatePass == null)
            {

                throw new ArgumentNullException("NullValues");
            }

            bool result = userDetailsManager.UpdatePasswordByOTP(updatePass);
            if (result)
            {
                //true will be returned with Status"Ok"
                return Ok(result);
            }
            else
            {
                throw new DivideByZeroException("Null values");
            }
        }
        [Route("api/UserDetails/SaveImage")]
        [HttpPost]
        public bool SaveIamge()
        {
            var httpRequest = HttpContext.Current.Request;
            try
            {

                userDetailsManager.SaveImage(httpRequest);
            }

            catch
            {
                return false;
            }
            return true;
        }

    }
}