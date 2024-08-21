using System;
using System.Linq;
using System.Text.RegularExpressions;


namespace PigLatinLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isLoopActive = true;

            do
            {
                string word = GetUseruserInput();
                string[] strings = word.Split(' ');

                foreach (string s in strings)
                {
                    Console.Write($"{TranslateToPigLatin(s)}");
                }

                isLoopActive = GetUserChoice();

            } while (isLoopActive);
            Console.ReadLine();
        }

        static string TranslateToPigLatin(string userInput) 
        {
            

            if (IsVowel(userInput[0]))
            {
                return userInput += "way";
            }

            else
            {
                return ConsonantStringWork(userInput);
            }
        }
        static bool GetUserChoice()
        {
            string userInput = "";
            bool isActiveLoop = false;

            do
            {
                Console.Write("Would you like to continue? (Y/N)");
                userInput = Console.ReadLine().ToUpper();

                if (userInput == "Y")
                {
                    isActiveLoop = true;
                }
                if (userInput == "N")
                {
                    isActiveLoop = false;
                }

            } while (userInput != "Y" && userInput != "N");

            return isActiveLoop;
        }
        static string ConsonantStringWork(string userInput)
        {
            string specialCharacters = "!@#$%^&*()_+-=~`[]{}|;:',.<>?/";
            int vowelLocation = -1;

            for (int i = 0; i < userInput.Length; i++)
            {
                if (IsVowel(userInput[i]))
                {
                    vowelLocation = i;
                    break;
                }
            }
            if (userInput.Any(character => specialCharacters.Contains(character)) || userInput.Any(char.IsDigit))
            {
                return userInput;
            }
            else if (vowelLocation == -1)
            {
                return userInput += "ay";
            }

            string preVowel = userInput.Substring(0, vowelLocation);
            string postVowel = userInput.Substring(vowelLocation);

            return postVowel + preVowel + "ay";
        }
        static string GetUseruserInput()
        {
            string text = "";
            do
            {
                Console.Write("Enter a line to be translated: ");
                text = Console.ReadLine();

            } while (string.IsNullOrEmpty(text));

            return text;
        }

        static bool IsVowel(char character)
        {
            return "aeiouAEIOU".IndexOf(character) >= 0; //this will return true if it finds an index of the vowel
        }
    }
}
