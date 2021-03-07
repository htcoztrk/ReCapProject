using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constant
{
    public class Messages
    {
        public static string Added = "Added Successfully.";
        public static string Deleted = "Deleted Successfully.";
        public static string Updated = "Updated Successfully.";
        public static string NameInvalid = "Invalid Name !!!";
        public static string Listed = "Listed";
        public static string DailyPrice = "Daily Price must be bigger than 0";
        public static string MaintenanceTime = "Sisem bakımda";
        public static string CarInRental = "Car is in rental, select another Car.";
        public static string ImageLimitExceded = "Bir arabanın en fazla 5 resmi olabilir.";
        internal static string AuthorizationDenied;
        internal static string AddedColor;
        internal static string DeletedColor;
        internal static string UpdatedColor;
        internal static string UserAlreadyExists;
        internal static string AccessTokenCreated;
        internal static string SuccessfulLogin;
        internal static User PasswordError;
        internal static User UserNotFound;
        internal static string UserRegistered;
    }
}
