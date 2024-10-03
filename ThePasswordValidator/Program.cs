
PasswordValidator passwordValidator = new PasswordValidator();

while (true)
{
    Console.Write("Please enter your password: ");
    string? password = Console.ReadLine();
    Console.WriteLine(passwordValidator.ValidatePassword(password)
        ? "Your password is valid"
        : "Your password is not valid");
}

class PasswordValidator
{
    /// <summary>
    /// This method is used to validate passwords and make sure they have a given size, don't have specified illegal characters and have minimum number of various char types.
    /// </summary>
    /// <param name="password"></param>
    /// <returns>a boolean value representing if password is valid or not.</returns>
    public bool ValidatePassword(string? password)
    {
        if (password == null)
        {
            return false;
        }

        return (ValidatePasswordLength(password, 6, 20)
                && ValidateLetterTypes(password, 1, 1, 1, 0)
                && CheckForIllegalCharacters(password, new string[] { "T", "&" }));

    }
    


    private bool ValidatePasswordLength(string password, int minLength, int maxLength) =>  (password).Length >= minLength && (password).Length <= maxLength;

    private bool ValidateLetterTypes(string password, int minLowercaseLetterCount, int minUppercaseLetterCount,
        int minDigitCount, int minSymbolCount)
    {

        int lowercaseLetterCount = 0, uppercaseLetterCount = 0, digitCount = 0, symbolCount = 0;
        foreach (char c in password)
        {
            if (char.IsLower(c))
            {
                lowercaseLetterCount++;
            }
            else if (char.IsUpper(c))
            {
                uppercaseLetterCount++;
            }
            else if (char.IsDigit(c))
            {
                digitCount++;
            }
            else if (char.IsSymbol(c))
            {
                symbolCount++;
            }
        }

        return (lowercaseLetterCount >= minLowercaseLetterCount && uppercaseLetterCount >= minUppercaseLetterCount &&
                digitCount >= minDigitCount && symbolCount >= minSymbolCount);
    }

    private bool CheckForIllegalCharacters(string password, string[] illegalCharacters)
    {
        foreach (char c in password)
        {
            if (illegalCharacters.Contains(c.ToString()))
            {
                return false;
            }
        }

        return true;
    }
    
}