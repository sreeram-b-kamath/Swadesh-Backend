using System.Text.RegularExpressions;

namespace Helpers;


public static class ValidatePassword
{
    public static bool CheckPassWord(string passWord)
    {
        if (string.IsNullOrEmpty(passWord))
            return false;

        if (passWord.Length < 8 || passWord.Length > 12) return false;
        Regex regex = new(@"^(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).+$");
        return regex.IsMatch(passWord);
    }
}