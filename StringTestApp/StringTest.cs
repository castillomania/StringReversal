using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringTestApp
{
    public class StringTest
    {
        private Dictionary<string, long> _letterCount { get; set; }

        public StringTest()
        {
            // initialize the dictionary in the constructor
            _letterCount = new Dictionary<string, long>(); 
        }

        /// <summary>
        /// Notes;
        /// I used a dictionary to store the letter counts because C# doesn't have a native HashTable. Using Java, I would have used that instead
        /// </summary>
        /// <param name="input">The input string that needs to be reversed</param>
        /// <param name="reversed">The reversed form of the input string</param>
        /// <param name="letterCount">A dictionary containing each letter in the reversed string as well as the number of times the letter appears</param>
        public void StringParser(string input, out string reversedString, out Dictionary<string, long> letterCount)
        {
            reversedString = ReverseString(input); // this does the reversing and logging
            letterCount = _letterCount; // set the output variable to the member variable in which the character logging was stored
        }

        /// <summary>
        /// Reverses the provided string and counts the appearance of each character in the string
        /// </summary>
        /// <param name="input">The string to be reversed and logged</param>
        /// <returns></returns>
        public string ReverseString(string input)
        {
            char[] inputArray = input.ToCharArray(); // convert the string to a character array

            long j = 0; // output array incrementer
            long i = inputArray.LongLength; // input array incrementer
            char[] outputArray = new char[i]; // container for the output

            // loop through each character on the input string, backwards
            while (i > 0)
            {
                i--; // decrement the incrementer since C# uses 0-base array indexing
                outputArray[j] = inputArray[i]; // add the decrementing char to the incrementing output

                // only log the character if it is a letter (numbers and special characters aren't logged)
                if (Char.IsLetter(inputArray[i]))
                { 
                    countLetters(inputArray[i].ToString()); // ensure that the added letter is counted
                }

                j++; // increment the output array for the next letter
            }

            // return a new string created from the char array created above
            return new string(outputArray);
        }

        /// <summary>
        /// Logs the appearance of the letter
        /// 
        /// Assumptions:
        /// Upper case and lower case letters should be counted separately from one another
        /// Non-letter characters should not be counted
        /// </summary>
        /// <param name="letter">The letter to be logged</param>
        public void countLetters(string letter)
        {
            // checks the dictionary to see if the letter has already been added
            if (_letterCount.ContainsKey(letter))
            {
                // if so, increment the value 
                // ASSUMPTION: we don't have so many letters that we're not going to overflow a 64-bit integer
                _letterCount[letter]++;
            }
            else
            {
                // if the letter isn't already added, add the letter to the dictionary with a value of 1 to indicate a single instance of the letter
                _letterCount.Add(letter,1);
            }
        }
    }
}
