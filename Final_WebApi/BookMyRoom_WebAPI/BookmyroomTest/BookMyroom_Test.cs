using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Hosting;
using Entities;
using Entities.MVC.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLayer;


namespace BookMyRoom.Controllers  //Add this this selected part
{
    [TestClass]
    public class UnitTest1
    {
        readonly UserDetailsController controller = new UserDetailsController()
        {
            Request = new HttpRequestMessage()
            {
                Properties = { { HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration() } }
            }
        };
       readonly UserDetailsManager _userDetailsManager = new UserDetailsManager();
        [TestMethod]
        public void BookMyRoom_LoginValidation_WrongCredentials()
        {
           

            // Arrange
             UserDetails user = new UserDetails();
            

           
            user.userName = "RittikBasu123";
            user.password = "Anwesh@6";
            // Act       
            var response = controller.LoginValidation(user);
            Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
           


        }
        [TestMethod]
        public void BookMyroom_LoginValidation_CorrectCredentials()
        {

            // Arrange
            UserDetails user = new UserDetails();
          
          
            user.userName = "RittikBasu123";
            user.password = "Anwesh@96";
           
            // Act       
            var response = controller.LoginValidation(user);
          

            //Assert
            
             Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            
           

        }
        [TestMethod]
        public void BookMyRoom_RoomSearch_WrongDetails()
        {
            //Arrange
            BookMyRoomManager booking = new BookMyRoomManager();
            SearchCriteria search = new SearchCriteria();
            search.hotelCity = "Kolkata";
            search.hotelFromDate = Convert.ToDateTime("05/09/2018");
            search.hotelToDate = Convert.ToDateTime("09/10/ 2018");
            search.hotelRoomType = "Single";

            //Act
            List<Output> response = booking.GetHotelDetails(search);

            //Assert
            Assert.AreEqual(0, response.Count);
            

        }
        [TestMethod]
        public void BookMyRoom_RoomSearch_CorrectDetails()
        {
            //Arrange
            BookMyRoomManager booking = new BookMyRoomManager();
            SearchCriteria search = new SearchCriteria();
            search.hotelCity = "Kolkata";
            search.hotelFromDate = DateTime.Now;
            search.hotelToDate = Convert.ToDateTime("09/09/ 2018");
            search.hotelRoomType = "Single";

            //Act
            List<Output> response = booking.GetHotelDetails(search);

           //Assert
            Assert.AreEqual(0, response.Count);


        }

        [TestMethod]
        public void BookMyRoom_LogedUser_CorrectDetails()
        {
            //Arrange
            UserDetailsManager userDetailsManager = new UserDetailsManager();
            UserDetails loggeduser = new UserDetails();
            loggeduser.userName = "RittikBasu123";
            loggeduser.password = "Anwesh@96";

            //Act
            UserDetails userDetails = userDetailsManager.LoggedUser(loggeduser);

            //Assert
            Assert.AreNotEqual(null, userDetails);


        }
        [TestMethod]
        public void BookMyRoom_LogedUser_WrongDetails()
        {
            //Arrange
            UserDetailsManager userDetailsManager = new UserDetailsManager();
            UserDetails loggeduser = new UserDetails();
            loggeduser.userName = "RittikBasu";
            loggeduser.password = "Anwesh@9";

            //Act
            UserDetails userDetails = userDetailsManager.LoggedUser(loggeduser);

            //Assert
            Assert.AreEqual(null, userDetails);

        }

        [TestMethod]
        public void BookMyRoom_SavenewUser_WrongDetails()
        {
            //Arrange
           
            UserDetails newuser = new UserDetails();
           
            newuser.email = "gokul@gmail.com";
            newuser.gender = "male";
            newuser.mobileNo="9492055568";
            newuser.name = "Gokul123";
            newuser.password = "12345678";
            newuser.userName = "Gokul1";
            newuser.rewardPoints = 5;
           
            //Act
            var result=  controller.PostUserDetail(newuser);
           
            //Assert
          
            
            Assert.AreEqual(HttpStatusCode.Conflict, result.StatusCode);

        }

        [TestMethod]
        public void BookMyRoom_SavenewUser_CorrectDetails()
        {
            //Arrange
          
           
            UserDetails newuser = new UserDetails();
            newuser.age = 25;
            newuser.email = "gokul18111@gmail.com";
            newuser.gender = "male";
            newuser.mobileNo = "9492055568";
            newuser.name = "Gokul123";
            newuser.password = "12345678";
            newuser.userName = "Gokul11745";
            newuser.rewardPoints = 5;
            //Act
          
            var result = controller.PostUserDetail(newuser);

            //Asser
            
             Assert.AreEqual(HttpStatusCode.Created, result.StatusCode);
            
          

        }
        [TestMethod]

        public void BookMyRoom_UpdateRewardPoints_CorrectDetails()
        {
            //Arrange
            UserDetailsManager userDetailsManager = new UserDetailsManager();
            UserDetails loggeduser = new UserDetails();
            loggeduser.userName = "RittikBasu123";
            loggeduser.password = "Anwesh@96";

            //Act

            UserDetails userDetails = userDetailsManager.LoggedUser(loggeduser);

            userDetails.rewardPoints = 100;
            bool result = userDetailsManager.UpdateRewards(userDetails);

            //Assert
            Assert.AreEqual(true, result);
        }

       [TestMethod]
       public void BookMyRoom_ConfirmBooking_CorrectDetails()
        {
            //Arrange
            BookMyRoomManager booking = new BookMyRoomManager();
            BookingTransfer bookingTransfer = new BookingTransfer();
            bookingTransfer.bookingAmount=10000;
            bookingTransfer.bookingDate = DateTime.Today;
            bookingTransfer.checkInDate = DateTime.Today;
            bookingTransfer.checkOutDate = DateTime.Today.AddDays(8);
            bookingTransfer.discountAmount = 100;
            bookingTransfer.roomId = 1;
            bookingTransfer.userId = 5;
            //Act
            var confirmbooking = booking.Confirm_Booking(bookingTransfer);
            //Assert
            Assert.AreEqual(true, confirmbooking);

        }
        [TestMethod]
        public void BookMyRoom_ConfirmBooking_WrongDetails()
        {
            //Arrange
            BookMyRoomManager booking = new BookMyRoomManager();
            BookingTransfer bookingTransfer = new BookingTransfer();
            bookingTransfer.bookingAmount = 10000;
            bookingTransfer.bookingDate = DateTime.Today;
            bookingTransfer.checkInDate = DateTime.Today;
            bookingTransfer.checkOutDate = DateTime.Today.AddDays(8);
            bookingTransfer.discountAmount = 100;
            bookingTransfer.roomId = 1;
            
            var confirmbooking = booking.Confirm_Booking(bookingTransfer);
            //Assert
            Assert.AreEqual(false, confirmbooking);

        }
    }
}
