using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace Trendyol.Services.Classes;

public class RegistrationService
{
    public bool ValidateUser(string t1, string t2, string t3, string t4, string t5)
    {
        string usernameRegex = @"^(?=[a-zA-Z0-9_]{3,16}$)(?![_0-9])[a-zA-Z0-9_]+$";
        string passwordRegex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()\-_=+\\|[\]{};:'"",.<>/?]).{8,20}$";
        string emailRegex = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

        if (string.IsNullOrWhiteSpace(t1) || !Regex.IsMatch(t1, usernameRegex))
        {
            MessageBox.Show("The username entered is incorrect! Length from 3 to 16 characters.\r\nCan only contain letters of the Latin alphabet (in any case), numbers and underscores.\r\nMust not begin with a number or underscore.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }

        if (string.IsNullOrWhiteSpace(t2) || !Regex.IsMatch(t2, emailRegex))
        {
            MessageBox.Show("", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }

        if (string.IsNullOrWhiteSpace(t3) || !Regex.IsMatch(t3, passwordRegex))
        {
            MessageBox.Show("The password entered is incorrect! Length from 8 to 20 characters.\r\nMust contain at least one uppercase and lowercase letter.\r\nMust contain at least one digit.\r\nSpecial characters are allowed.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }

        if (string.IsNullOrWhiteSpace(t4) || !Regex.IsMatch(t3, passwordRegex))
        {
            MessageBox.Show("The password entered is incorrect! Length from 8 to 20 characters.\r\nMust contain at least one uppercase and lowercase letter.\r\nMust contain at least one digit.\r\nSpecial characters are allowed.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }

        if (t3 != t4)
        {
            MessageBox.Show("Password and confirm password must match.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }

        return true;
    }
}
