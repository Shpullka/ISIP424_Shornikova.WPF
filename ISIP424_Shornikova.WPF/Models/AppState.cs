using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ISIP424_Shornikova.WPF.Models
{
    public static class AppState
    {
        public static string ModelName { get; set; }
        public static decimal BasePrice { get; set; }
        public static string EngineType { get; set; }
        public static decimal EnginePrice { get; set; }
        public static string ColorName { get; set; }
        public static decimal ColorPrice { get; set; }
        public static string OptionsList { get; set; }
        public static decimal OptionsPrice { get; set; }
        public static decimal DownPaymentPercent { get; set; } 
        public static int LoanTermMonths { get; set; } 
        public static decimal LoanAmount { get; set; }
        public static decimal MonthlyPayment { get; set; }
        public static string ClientName { get; set; }
        public static string ClientPhone { get; set; }
        public static string ClientEmail { get; set; }

        public static decimal GetTotalCarPrice()
        {
            return BasePrice + EnginePrice + ColorPrice + OptionsPrice;
        }

        public static void CalculateCredit()
        {
            decimal totalPrice = GetTotalCarPrice();
            if (totalPrice <= 0) return;

            decimal downPaymentSum = totalPrice * (DownPaymentPercent / 100m);
            LoanAmount = totalPrice - downPaymentSum;

            if (LoanTermMonths > 0)
            {
                decimal interest = LoanAmount * 0.10m;
                MonthlyPayment = (LoanAmount + interest) / LoanTermMonths;
            }
        }

        public static void Reset()
        {
            ModelName = "";
            BasePrice = 0;
            EngineType = "";
            EnginePrice = 0;
            ColorName = "";
            ColorPrice = 0;
            OptionsList = "";
            OptionsPrice = 0;
            DownPaymentPercent = 20m;
            LoanTermMonths = 96;
            LoanAmount = 0;
            MonthlyPayment = 0;
            ClientName = "";
            ClientPhone = "";
            ClientEmail = "";
        }
    }
}