using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] splitWords;
            string userInput, response;
            int length;

            Console.WriteLine("Welcome to the Pig Latin Translator!");

            do
            {
                //prompts user to enter a sentence, and converts input to separated, lower case words
                Console.WriteLine("Please enter a line to translate: ");
                userInput = Console.ReadLine().ToLower();
                splitWords = userInput.Split(' ');
                length = splitWords.Length;

                //loops through each word in the sentence and translates to pig latin, then displays
                    for (int i= 0; i < splitWords.Length; i++)
                    {
                        string newWords = translateToPigLatin(splitWords[i]);
                        Console.Write(newWords + " ");
                    }
                //prompts user to continue
                Console.WriteLine(" ");
                Console.Write("Would you like to enter a new line? (y/n): ");
                response = Console.ReadLine().ToLower();
            }
            while (YesOrNo(response));
        }
        //checks to see if a letter is a vowel
        public static bool IsVowel(string letter)
        {
            switch (letter)
            {
                case "a": case "e": case "i": case "o": case "u":
                    return true;
                default:
                    return false;
            }
        }
        //output of method is the index for the first vowel present in the word
        public static int getIndex(string wordArray)
        {
            for (int i = 0; i <= wordArray.Length; i++)
            {
                while (wordArray[i] == 'a' || wordArray[i]== 'e' || wordArray[i] == 'i'|| wordArray[i] == 'o' || wordArray[i] == 'u')
                {
                    return i;
                }
                 
            }
            return 0;
        }
        
        //processes whether user wants to continue or end program
        public static bool YesOrNo(string response)
        {
            while (response == "y")
            {
                return true;
            }
            if (response == "n")
            {
                Console.WriteLine("Exiting program...");
                Console.ReadLine();
                return false;
            }
            else
            {
                Console.WriteLine("Invalid input, try again later."); //i could not figure out how to loop this back to the top of method
                Console.ReadLine();
                return false;
            }
        }
        //translates single words into pig latin and returns word
        public static string translateToPigLatin(string input)
        {
            
            string firstLetter = input.Substring(0, 1);
            string restOfWord = input.Substring(1);
            string word;
            //if first letter isnt a vowel, it sets the first letter to be a vowel, then adds rest of word and "ay"
            if (!IsVowel(firstLetter))
            {
                    int firstVowelIndex = getIndex(input);
                    string firstLetters = input.Substring(0, firstVowelIndex);
                    restOfWord = input.Substring(firstVowelIndex);
                    word = restOfWord + firstLetters + "ay ";
                    return word;

            }
            else
            {
                word = input + "way ";
                return word;
            }

        }
    }
}

