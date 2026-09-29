using System;

namespace GeneratorHasełdesktop2026
{
    /***********************************************************************
    * nazwa klasy: PasswordGenerator
    * opis klasy: Klasa odpowiedzialna za generowanie losowych haseł oraz ocenę ich siły.
    * pola: length - długość wygenerowanego hasła (int)
    * includeSpecialChars - czy uwzględniać znaki specjalne (bool)
    * autor: 12345678901
    ***********************************************************************/

    public class PasswordGenerator
    {
        private int length;
        private bool includeSpecialChars;
        private bool includeUppercase;
        private bool includeDigits;

        public PasswordGenerator(int length, bool includeSpecialChars)
        {
            this.length = length;
            this.includeSpecialChars = includeSpecialChars;
            includeUppercase = true;
            includeDigits = true;
        }

        public PasswordGenerator(int length, bool includeSpecialChars, bool includeUppercase, bool includeDigits)
        {
            this.length = length;
            this.includeSpecialChars = includeSpecialChars;
            this.includeUppercase = includeUppercase;
            this.includeDigits = includeDigits;
        }

        public string GenerujHaslo()
        {
            string maleLitery = "abcdefghijklmnopqrstuvwxyz";
            string wielkieLitery = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string cyfry = "0123456789";
            string znakiSpecjalne = "!@#$%^&*";

            string dostepneZnaki = maleLitery;

            if (includeUppercase)
                dostepneZnaki += wielkieLitery;

            if (includeDigits)
                dostepneZnaki += cyfry;

            if (includeSpecialChars)
                dostepneZnaki += znakiSpecjalne;

            Random losowanie = new Random();
            string haslo = "";

            for (int i = 0; i < length; i++)
            {
                int indeks = losowanie.Next(dostepneZnaki.Length);
                haslo += dostepneZnaki[indeks];
            }

            return haslo;
        }

        public static string OcenSileHasla(string password)
        {
            bool maZnakSpecjalny = false;
            string znakiSpecjalne = "!@#$%^&*";

            foreach (char znak in password)
            {
                if (znakiSpecjalne.Contains(znak.ToString()))
                {
                    maZnakSpecjalny = true;
                    break;
                }
            }

            if (password.Length < 8)
                return "Słabe";

            if (password.Length >= 12 && maZnakSpecjalny)
                return "Mocne";

            return "Średnie";
        }
    }
}