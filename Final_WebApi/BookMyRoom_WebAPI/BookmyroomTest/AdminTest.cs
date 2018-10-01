using BookMyRoom.Controllers;
using BusinessLayer;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Hosting;

namespace BookmyroomTest
{
    
    [TestClass]
    public class AdminTest
    {
        private readonly AdminManager adminManager = new AdminManager();
        //NumberOfUsers Function
        [TestMethod]
        public void Admin_NumberOfUsers()
        {
            //Arrange
            AdminController adminController = new AdminController()
            {
                Request = new HttpRequestMessage()
                {
                    Properties = { { HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration() } }
                }
            };

        //Act
        int result = adminController.NumberOfUsers();

            //Assert
            Assert.AreEqual(42, result);
        }
        /*------------------------------------------------END OF NumberOfUsers------------------------------------------------*/
        //NumberOfHotels Function
        [TestMethod]
        public void Admin_NumberOfHotels()
        {
            //Arrange
            AdminController adminController = new AdminController()
            {
                Request = new HttpRequestMessage()
                {
                    Properties = { { HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration() } }
                }
            };

            //Act
            int result = adminController.NumberOfHotels();

            //Assert
            Assert.AreEqual(19, result);
        }
        /*------------------------------------------------END OF NumberOfHotels------------------------------------------------*/
        //NumberOfHotels Function
        [TestMethod]
        public void Admin_NumberOfBookings()
        {
            //Arrange
            AdminController adminController = new AdminController()
            {
                Request = new HttpRequestMessage()
                {
                    Properties = { { HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration() } }
                }
            };

            //Act
            int result = adminController.NumberOfBookings();

            //Assert
            Assert.AreEqual(40  , result);
        }
        /*------------------------------------------------END OF NumberOfBookings------------------------------------------------*/
        //AddCity Function three test cases
        [TestMethod]
        public void Admin_AddCity_CorrectDetails()
        {
            //Arrange

            CityDetails city = new CityDetails();
            AdminController adminController = new AdminController()
            {
                Request = new HttpRequestMessage()
                {
                    Properties = { { HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration() } }
                }
            };
            city.cityName = "Nasik";
            
            //Act
            var response = adminController.AddCity(city);
                       
            //Assert
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }
        [TestMethod]
        public void Admin_AddCity_WrongDetails()
        {
            //Arrange
            AdminController adminController = new AdminController()
            {
                Request = new HttpRequestMessage()
                {
                    Properties = { { HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration() } }
                }
            };
            CityDetails city = new CityDetails();

            city.cityName = "Nasik"; //Same City that is already been added in the database

            //Act
            var response = adminController.AddCity(city);

            //Assert
            Assert.AreEqual(HttpStatusCode.Conflict, response.StatusCode);
        }
        [TestMethod]
        public void Admin_AddCity_NullValuePassing()
        {
            //Arrange
            AdminController adminController = new AdminController()
            {
                Request = new HttpRequestMessage()
                {
                    Properties = { { HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration() } }
                }
            };
            CityDetails city = new CityDetails();

            //Act
            var response = adminController.AddCity(city);

            //Assert
            Assert.AreEqual(HttpStatusCode.Conflict, response.StatusCode);
        }
        /*------------------------------------------------END OF AddCity------------------------------------------------*/
        //ListOfCities Function
        [TestMethod]
        public void Admin_ListOfCities()
        {
            //Arrange
            AdminController adminController = new AdminController()
            {
                Request = new HttpRequestMessage()
                {
                    Properties = { { HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration() } }
                }
            };

            //Act
            var result = adminController.ListOfCities();

            //Assert
            Assert.AreEqual(result, result);
        }
        /*------------------------------------------------END OF ListOfCities------------------------------------------------*/
        //DeleteCity Function three test cases
        [TestMethod]
        public void Admin_DeleteCity_CorrectDetails()
        {
            //Arrange
            AdminController adminController = new AdminController()
            {
                Request = new HttpRequestMessage()
                {
                    Properties = { { HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration() } }
                }
            };
            int id = 35;

            //Act
            var response = adminController.DeleteCity(id);

            //Assert
            Assert.AreEqual(HttpStatusCode.Accepted, response.StatusCode);
        }
        [TestMethod]
        public void Admin_DeleteCity_WrongDetails()
        {
            //Arrange
            AdminController adminController = new AdminController()
            {
                Request = new HttpRequestMessage()
                {
                    Properties = { { HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration() } }
                }
            };
            int id = 49;

            //Act
            var response = adminController.DeleteCity(id);

            //Assert
            Assert.AreEqual(HttpStatusCode.Conflict, response.StatusCode);
        }
        public void Admin_DeleteCity_NullValues()
        {
            //Arrange
            AdminController adminController = new AdminController()
            {
                Request = new HttpRequestMessage()
                {
                    Properties = { { HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration() } }
                }
            };
            int id = - 5;

            //Act
            var response = adminController.DeleteCity(id);

            //Assert
            Assert.AreEqual(HttpStatusCode.Conflict, response.StatusCode);
        }
        /*------------------------------------------------END OF DeleteCity------------------------------------------------*/
        //AddHotel Function three test cases
        [TestMethod]
        public void Admin_AddHotel_CorrectDetails()
        {
            //Arrange

            CityHotelDetailsFromAdmin hotel = new CityHotelDetailsFromAdmin();
            AdminController adminController = new AdminController()
            {
                Request = new HttpRequestMessage()
                {
                    Properties = { { HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration() } }
                }
            };
            hotel.cityId = 34;
            hotel.hotelName = "Izzy Cozy Hotel";
            hotel.hotelAddress = "143, Patia Road, Near Big Baazar";
            hotel.totalRooms = 5;

            //Act
            var response = adminController.AddHotel(hotel);

            //Assert
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }
        [TestMethod]
        public void Admin_AddHotel_WrongDetails()
        {
            //Arrange
            AdminController adminController = new AdminController()
            {
                Request = new HttpRequestMessage()
                {
                    Properties = { { HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration() } }
                }
            };
            CityHotelDetailsFromAdmin hotel = new CityHotelDetailsFromAdmin();
            hotel.cityId = 34;
            hotel.hotelName = "Izzy Cozy Hotel";
            hotel.hotelAddress = "143, Patia Road, Near Big Baazar";
            hotel.totalRooms = 5;


            //Act
            var response = adminController.AddHotel(hotel);

            //Assert
            Assert.AreEqual(HttpStatusCode.Conflict, response.StatusCode);
        }
        [TestMethod]
        public void Admin_AddHotel_NullValuePassing()
        {
            //Arrange
            AdminController adminController = new AdminController()
            {
                Request = new HttpRequestMessage()
                {
                    Properties = { { HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration() } }
                }
            };
            CityHotelDetailsFromAdmin hotel = new CityHotelDetailsFromAdmin();

            //Act
            var response = adminController.AddHotel(hotel);

            //Assert
            Assert.AreEqual(HttpStatusCode.Conflict, response.StatusCode);
        }
        /*------------------------------------------------END OF AddHotel------------------------------------------------*/
        //ListOfCities Function
        [TestMethod]
        public void Admin_ListOfHotels()
        {
            //Arrange
            AdminController adminController = new AdminController()
            {
                Request = new HttpRequestMessage()
                {
                    Properties = { { HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration() } }
                }
            };

            //Act
            var result = adminController.ListOfHotels().Count;

            //Assert
            Assert.AreEqual(result, result);
        }
        /*------------------------------------------------END OF Admin_ListOfHotels------------------------------------------------*/
        //DeleteCity Function three test cases
        [TestMethod]
        public void Admin_DeleteHotel_CorrectDetails()
        {
            //Arrange
            AdminController adminController = new AdminController()
            {
                Request = new HttpRequestMessage()
                {
                    Properties = { { HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration() } }
                }
            };
            int id = 20;

            //Act
            var response = adminController.DeleteHotel(id);

            //Assert
            Assert.AreEqual(HttpStatusCode.Accepted, response.StatusCode);
        }
        [TestMethod]
        public void Admin_DeleteHotel_WrongDetails()
        {
            //Arrange
            AdminController adminController = new AdminController()
            {
                Request = new HttpRequestMessage()
                {
                    Properties = { { HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration() } }
                }
            };
            int id = 49;

            //Act
            var response = adminController.DeleteHotel(id);

            //Assert
            Assert.AreEqual(HttpStatusCode.Conflict, response.StatusCode);
        }
        public void Admin_DeleteHotel_NullValues()
        {
            //Arrange
            AdminController adminController = new AdminController()
            {
                Request = new HttpRequestMessage()
                {
                    Properties = { { HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration() } }
                }
            };
            int id = -5;

            //Act
            var response = adminController.DeleteHotel(id);

            //Assert
            Assert.AreEqual(HttpStatusCode.Conflict, response.StatusCode);
        }
        /*------------------------------------------------END OF DeleteCity------------------------------------------------*/
        //AddHotel Function three test cases
        [TestMethod]
        public void Admin_AddRoom_CorrectDetails()
        {
            //Arrange

            RoomDetails room = new RoomDetails();
            AdminController adminController = new AdminController()
            {
                Request = new HttpRequestMessage()
                {
                    Properties = { { HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration() } }
                }
            };
            room.roomNumber = 101;
            room.starRating = 5;
            room.price = 2000;
            room.roomType = "Single";
            room.hotelId = 13;
            room.imageUrl = "/assets/HotelPic/Hotel1.jpg";
            //Act
            var response = adminController.AddRoom(room);

            //Assert
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }
        [TestMethod]
        public void Admin_AddRoom_WrongDetails()
        {
            //Arrange
            RoomDetails room = new RoomDetails();
            AdminController adminController = new AdminController()
            {
                Request = new HttpRequestMessage()
                {
                    Properties = { { HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration() } }
                }
            };
            room.roomNumber = 101;
            room.starRating = 5;
            room.price = 2000;
            room.roomType = "Single";
            room.hotelId = 13;
            room.imageUrl = "/assets/HotelPic/Hotel1.jpg";
            //Act
            var response = adminController.AddRoom(room);

            //Assert
            Assert.AreEqual(HttpStatusCode.Conflict, response.StatusCode);
        }
        [TestMethod]
        public void Admin_AddRoom_NullValuePassing()
        {
            //Arrange
            RoomDetails room = new RoomDetails();
            AdminController adminController = new AdminController()
            {
                Request = new HttpRequestMessage()
                {
                    Properties = { { HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration() } }
                }
            };
            

            //Act
            var response = adminController.AddRoom(room);

            //Assert
            Assert.AreEqual(HttpStatusCode.Conflict, response.StatusCode);
        }
        /*------------------------------------------------END OF AddHotel------------------------------------------------*/
        //ListOfCities Function
        [TestMethod]
        public void Admin_ListOfRooms()
        {
            //Arrange
            AdminController adminController = new AdminController()
            {
                Request = new HttpRequestMessage()
                {
                    Properties = { { HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration() } }
                }
            };

            //Act
            var result = adminController.ListOfRooms(13).Count;

            //Assert
            Assert.AreEqual(result, result);
        }
        /*------------------------------------------------END OF Admin_ListOfRooms------------------------------------------------*/
        //DeleteCity Function three test cases
        [TestMethod]
        public void Admin_DeleteRoom_CorrectDetails()
        {
            //Arrange
            AdminController adminController = new AdminController()
            {
                Request = new HttpRequestMessage()
                {
                    Properties = { { HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration() } }
                }
            };
            int id = 21;

            //Act
            var response = adminController.DeleteRoom(id);

            //Assert
            Assert.AreEqual(HttpStatusCode.Accepted, response.StatusCode);
        }
        [TestMethod]
        public void Admin_DeleteRoom_WrongDetails()
        {
            //Arrange
            AdminController adminController = new AdminController()
            {
                Request = new HttpRequestMessage()
                {
                    Properties = { { HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration() } }
                }
            };
            int id = 49;

            //Act
            var response = adminController.DeleteRoom(id);

            //Assert
            Assert.AreEqual(HttpStatusCode.Conflict, response.StatusCode);
        }
        [TestMethod]
        public void Admin_DeleteRoom_NullValues()
        {
            //Arrange
            AdminController adminController = new AdminController()
            {
                Request = new HttpRequestMessage()
                {
                    Properties = { { HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration() } }
                }
            };
            int id = -5;

            //Act
            var response = adminController.DeleteRoom(id);

            //Assert
            Assert.AreEqual(HttpStatusCode.Conflict, response.StatusCode);
        }
        /*------------------------------------------------END OF DeleteCity------------------------------------------------*/
    }
}
