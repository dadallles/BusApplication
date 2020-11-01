using System;
using System.Collections.Generic;
using System.Text;

namespace BusApplication.Utility
{
    public class StaticData
    {
        public const string PaymentStatusNew = "New";
        public const string PaymentStatusConfirmed = "Confirmed";
        public const string PaymentStatusCanceled = "Canceled";

        public const float ExtraBaggagePrice = 5;

        public const string AdminRole = "Admin";
        public const string EmployeeRole = "Employee";
        public const string UserRole = "User";

        public const string EmployeeAndAdminRoleString = "Admin, Employee";
    }
}
