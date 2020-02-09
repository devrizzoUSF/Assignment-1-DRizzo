using System;
using System.Collections.Generic;

namespace Assignment_1_DRizzo
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5;
            PrintPattern(n);

            int n2 = 6;
            PrintSeries(n2);

            string s = "09:15:35PM";
            string t = UsfTime(s);
            Console.WriteLine(t);

            int n3 = 110;
            int k = 11;
            UsfNumbers(n3, k);

            string[] words = new string[] { "abcd", "dcba", "lls", "s", "sssll" };
            PalindromePairs(words);

            int n4 = 5;
            Stones(n4);
        }

        //QUESTION 1: 
        private static void PrintPattern(int n)
        {
            Console.WriteLine("QUESTION 1 ANSWER:");

            try
            {
                //Outer loop decrements n by 1 each iteration.
                //That way, each new row will begin with n-1 until n reaches 1
                for (int i = n; i >= 1; i--)
                {
                    //Inner loop creates a new int variable s in which n can be stored in as it's decremented
                    //This loop is responsible for printing the numbers in decending order to the console
                    for (int s = i; s >= 1; s--)
                    {
                        Console.Write(s);
                    }

                    //Self reflection: is there a better way to break to a new line without an empty writeline method?
                    Console.WriteLine();
                }
            }
            catch
            {
                Console.WriteLine("Exception Occured while computing printPattern");
            }
        }

        //QUESTION 2:
        private static void PrintSeries(int n2)
        {
            Console.WriteLine();
            Console.WriteLine("QUESTION 2 ANSWER:");

            try
            {
                //Create an array and store the n2 values in decending order
                int size = n2;
                int[] initArray = new int[size];

                for (int index = 0; index < size; index++)
                {
                    initArray[index] = n2;
                    //Console.WriteLine(initArray[index]);
                    n2 -= 1;
                }

                //Reverse the values in the array so the elements are in ascending order
                Array.Reverse(initArray);

                //Starting at index 6, add all values in the array together and store in new array. 
                int maxLength = initArray.Length;
                List<string> newList = new List<string>();

                for (int i = maxLength; i >= 1; i--)
                {
                    int total = 0;
                    for (int index2 = 0; index2 < maxLength; index2++)
                    {
                        total += initArray[index2];
                        
                    }
                    //Console.WriteLine(total);

                    //Add value for 'total' to new list (would probably be better if adding directly to array instead of converting below)
                    newList.Add(Convert.ToString(total)); 
                    maxLength = maxLength - 1;
                }

                //Convert list to array, reverse order, display on console
                string[] finalArray = newList.ToArray();
                Array.Reverse(finalArray);
                Console.WriteLine(string.Join(", ", finalArray));

            }
            catch
            {
                Console.WriteLine("Exception Occured while computing printSeries");
            }
        }

        //QUESTION 3:
        public static string UsfTime(string s)
        {
            Console.WriteLine();
            Console.WriteLine("QUESTION 3 ANSWER:");

            try
            {
                double hours = Convert.ToDouble(s.Substring(0, 2));
                double minutes = Convert.ToDouble(s.Substring(3, 2));
                double seconds = Convert.ToDouble(s.Substring(6, 2));
                string meridian = s.Substring(8, 2);

                //Add 12 hours if meridian is PM
                if (meridian == "PM")
                {
                    hours += 12;
                }

                //Calculate how many seconds total are in the earth time
                double totalEarthSeconds = (hours * 3600) + (minutes * 60) + seconds;
                //Console.WriteLine(totalEarthSeconds);

                //Calculate USF time
                int uHours = Convert.ToInt32(totalEarthSeconds / 2700);
                int uMinutes = Convert.ToInt32(totalEarthSeconds % 2700) / 45;
                double uSeconds = ((Convert.ToDouble(totalEarthSeconds % 2700) / 45) - uMinutes) * 45;
                int uSeconds2 = Convert.ToInt32(uSeconds);

                string t = uHours.ToString("d2") + ":" + uMinutes.ToString("d2") + ":" + uSeconds2.ToString("d2");

                return t;
            }
            catch
            {
                Console.WriteLine("Exception Occured while computing UsfTime");
            }
            return null;
        }

        //QUESTION 4:
        public static void UsfNumbers(int n3, int k)
        {
            Console.WriteLine();
            Console.WriteLine("QUESTION 4 ANSWER:");
            
            try
            {
                //Let's start out by putting all numbers into an array. Will need to be string to accomodate letters.
                int size = n3;
                string[] strArray = new string[size];

                int val = 1;
                for (int index = 0; index < size; index++)
                {
                    strArray[index] = Convert.ToString(val);
                    val += 1;
                }

                //Scan the array and if any numbers meet the criteria, replace them with the letter
                for (int s = 0; s < strArray.Length; s++)
                {
                    int currentVal = Convert.ToInt32(strArray[s]);

                    //Can also use a switch statement here
                    if (currentVal % 3 == 0 && currentVal % 5 == 0 && currentVal % 7 == 0)
                    {
                        //Replace multiples of 3,5,7 w/ "USF"
                        strArray[Array.IndexOf(strArray, (Convert.ToString(currentVal)))] = "USF";
                    }
                    else if (currentVal % 5 == 0 && currentVal % 7 == 0)
                    {
                        //Replace multiples of 5,7 w/ "SF"
                        strArray[Array.IndexOf(strArray, (Convert.ToString(currentVal)))] = "SF";
                    }
                    else if (currentVal % 3 == 0 && currentVal % 5 == 0)
                    {
                        //Replace multiples of 3,5 w/ "US"
                        strArray[Array.IndexOf(strArray, (Convert.ToString(currentVal)))] = "US";
                    }
                    else if (currentVal % 7 == 0)
                    {
                        //Replace multiples of 7 w/ "F"
                        strArray[Array.IndexOf(strArray, (Convert.ToString(currentVal)))] = "F";
                    }
                    else if (currentVal % 5 == 0)
                    {
                        //Replace multiples of 5 w/ "S"
                        strArray[Array.IndexOf(strArray, (Convert.ToString(currentVal)))] = "S";
                    }
                    else if (currentVal % 3 == 0)
                        //Replace multiples of 3 w/ "U"
                        strArray[Array.IndexOf(strArray, (Convert.ToString(currentVal)))] = "U";
                }

                //Console.WriteLine(string.Join(" ", strArray));
                
                //Write k numbers/letters per line
                int numPerLine = k;
                for (int i = 0; i < strArray.Length; i++)
                {
                    Console.Write("{0:X2} ", strArray[i]);
                    if ((i + 1) % numPerLine == 0)
                    {
                        Console.WriteLine();
                    }
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing UsfNumbers()");
            }
        }

        //QUESTION 5:
        public static void PalindromePairs(string[] words)
        {
            Console.WriteLine();
            Console.WriteLine("QUESTION 5 ANSWER:");
            
            try
            {
                List<string> concatenations = new List<string>();
                
                //Scan the string of arrays            
                for (int index = 0; index < words.Length; index++)
                {
                    string currentIndex = words[index];

                    for (int index2 = 0; index2 < words.Length; index2++)
                    {
                        if (currentIndex != words[index2])
                        {
                            //Concatenate current string with next string in the array and add to list
                            string concat = Convert.ToString(words[index] + words[index2]);

                            concatenations.Add(concat);
                        }   
                    }                   
                }

                //cycle through the list of concatenations and save the palindromes in a new list
                List<string> palindromes = new List<string>();

                foreach (string item in concatenations)
                {
                    //Reverse the string and store in a new variable
                    char[] copyItem = item.ToCharArray();
                    Array.Reverse(copyItem);
                    string reverseItem = new string(copyItem);

                    //If the two strings are the same, they are palindromes
                    if (string.Equals(item, reverseItem))
                    {
                        palindromes.Add(item);
                    }
                }

                //Write palindromes to console
                Console.Write("The palindromes are: ");
                Console.Write(string.Join(", ", palindromes));


            }
            catch
            {
                Console.WriteLine("Exception occured while computing PalindromePairs()");
            }
        }


        //QUESTION 6:
        /*
         This program is incomplete. My goal and thinking behind it was to create a while loop that tested 3 different scenarios.
         In each scenario, 1, 2, and 3 stones would be removed from the total, and the number of iterations would increment by 1 (representing
         each player's turn). If at any point the number of stones reaches 0, the loop would end and the number of iterations (turns)
         would be counted. If the iterations were odd, player 1 who went first wins. If even, player 2 wins.

         I've spent a few hours trying this different ways and can't seem to articulate it via a program. However, I'm hoping that at 
         least my 'plan of action' might earn at least a point or two. 
        */
        public static void Stones(int n4)
        {
            Console.WriteLine();
            Console.WriteLine("QUESTION 6 ANSWER:");

            try
            {
                int numOfStones = n4;
                int iterations = 1;

                while (numOfStones > 0)
                {
                    //The way the program is current written, it removes one stone, then two stones, then three and begins the 
                    //while loop again. Need another loop? I also considered using multidimensional arrays. Perhaps I'm just 
                    //overcomplicating this in my head. 
                    if ((numOfStones - 1) != 0)  
                    {
                        numOfStones -= 1;
                        iterations += 1;
                    }
                    else
                    {
                        break;
                    }

                    if ((numOfStones - 2) != 0)
                    {
                        numOfStones -= 2;
                        iterations += 1;
                    }
                    else
                    {
                        break;
                    }

                    if ((numOfStones - 3) != 0)
                    {
                        numOfStones -= 3;
                        iterations += 1;
                    }
                    else
                    {
                        break;
                    }
                }

                //If number of iterations are odd, player 1 wins. If even, player 2 wins. 
                Console.WriteLine(iterations);

            }
            catch
            {
                Console.WriteLine("Exception occured while computing Stones()");
            }
        }

    }

}
