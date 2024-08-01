using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    class validation
    {
        public static bool IsHebrewLetter(char c)
        {
            string letters = "אבגדהוזחטיכלמנסעפצקרשתםןץף ";
            if (letters.IndexOf(c) == -1)
                return false;
            return true;
        }
        public static bool IsNumber(char c)//בדיקה האם התו הוא מספר
        {
            string numbers = " 1234567890";
            return (numbers.IndexOf(c) != -1);
        }
        public static bool IsValidName(string names)
        {
            for (int i = 0; i < names.Length; i++)
                if (!IsHebrewLetter(names[i]))
                    return false;
            return true;
        }
        public static bool IsValidAge(DateTime d)
        {
            return (DateTime.Now.Year - 120 <= d.Year && d.Year <= DateTime.Now.Year);
        }
        public static bool IsValidId(string id)
        {
            if (id.Length == 9)
            {
                int sum = 0;
                for (int i = 0; i < 8; i++)
                {
                    int num = id[i] - 48;
                    if (i % 2 == 0)
                        sum += num;
                    else
                        if ((num * 2) > 9)
                        sum += (num * 2) % 10 + (num * 2) / 10;
                    else
                        sum += num * 2;
                }
                if (sum % 10 + id[8] - 48 == 10)
                    return true;

            }
            return false;


        }
        public static bool IsValidPhone(string phone)
        {
            if (phone[0] != '0')
                return false;
            if (phone.Length != 11)
                return false;
            if (phone[3] != '-')
                return false;
            return true;
        }
        public static bool IsValidAddress(string address)
        {
            for (int i = 0; i < address.Length; i++)
                if (IsHebrewLetter(address[i]) == false && IsNumber(address[i]) == false)
                    return false;
            return true;
        }
        public static bool IsUserPassword(string c)
        {
            for (int i = 0; i < c.Length; i++)
                if (IsNumber(c[i]) == false)
                    return false;
            return true;
        }
        public static bool IsFullNumber(string c)
        {
            for (int i = 0; i < c.Length; i++)
                if (IsNumber(c[i]) == false)
                    return false;
            return true;
        }
        public static bool IsDayInMonth(int c)
        {
            int count = 0;
            for (int i = 1; i <= 28; i++)
            {
                if (i == c)
                    count++;

            }
            if (count == 0)
                return false;
            return true;
        }


    }
}
