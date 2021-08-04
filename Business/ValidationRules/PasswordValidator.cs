namespace Business.ValidationRules
{
    internal static class PasswordValidator
    {
        internal static bool MustContainsUpperChar(string arg)
        {
            char[] upperCaseCharacters =
            {
                'Q', 'W', 'E', 'R', 'T', 'Y', 'U', 'I',
                'O', 'P', 'Ğ', 'Ü', 'A', 'S', 'D', 'F',
                'G', 'H', 'J', 'K', 'L', 'Ş', 'İ', 'Z',
                'X', 'C', 'V', 'B', 'N', 'M', 'Ö', 'Ç'
            };

            return ForController(arg, upperCaseCharacters);
        }

        internal static bool MustContainsLowerChar(string arg)
        {
            char[] lowerCaseCharacters =
            {
                'q', 'w', 'e', 'r', 't', 'y', 'u', 'ı',
                'o', 'p', 'ğ', 'ü', 'a', 's', 'd', 'f',
                'g', 'h', 'j', 'k', 'l', 'ş', 'i', 'z',
                'x', 'c', 'v', 'b', 'n', 'm', 'ö', 'ç'
            };

            return ForController(arg, lowerCaseCharacters);
        }

        internal static bool MustContainsNumberChar(string arg)
        {
            char[] numberCharacters =
            {
                '0', '1', '2', '3', '4',
                '5', '6', '7', '8', '9'
            };

            return ForController(arg, numberCharacters);
        }


        internal static bool MustContainsSpecialChar(string arg)
        {
            char[] specialCharacters =
            {
                '@', '/', '\\', '_', '-', '!', '^',
                '+', '$', '%', '½', '&', '{', '}',
                '[', ']', '(', ')', '=', '?', '*',
                '€', ';', ':', ',', '.', '<', '>',
                '"', '\'', '#'
            };

            return ForController(arg, specialCharacters);
        }


        private static bool ForController(string arg, char[] chars)
        {
            foreach (var i in arg)
                foreach (var j in chars)
                    if (i == j)
                        return true;

            return false;
        }
    }
}