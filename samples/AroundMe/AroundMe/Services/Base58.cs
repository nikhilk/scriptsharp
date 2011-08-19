// Base58.cs
//

using System;

namespace AroundMe.Services {

    internal static class Base58 {

        private static string Alphabet = "123456789abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNPQRSTUVWXYZ";

        public static string Decode(string id) {
            int converted = 0;
            int multiplier = 1;

            while (id.Length > 0) {
                string currentChar = id.Substr(id.Length - 1);
                converted += multiplier * Alphabet.IndexOf(currentChar);
                multiplier = multiplier * Alphabet.Length;

                id = id.Substr(0, id.Length - 1);
            }

            return converted.ToString();
        }

        public static string Encode(string id) {
            int number = Int32.Parse(id);

            string encoded = "";
            while (number > 0) {
                int remainder = number % Alphabet.Length;
                number = (int)(number / Alphabet.Length);
                encoded = Alphabet.CharAt(remainder) + encoded;
            }

            return encoded;
        }
    }
}
