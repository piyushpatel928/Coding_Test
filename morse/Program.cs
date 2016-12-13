using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace morse
{
    class Program
    {
        static Dictionary<string, char> translator;
        public List<string> listOfInput;
        static void Main(string[] args)
        {
            InitialiseDictionary();
            getUserInput();
        }


        private static void InitialiseDictionary()
        {
            char dot = '.';
            char dash = '−';

            translator = new Dictionary<string, char>()
            {
                {".-", 'a'},
                {"-...", 'b'},
                {"-.-.", 'c'},
                {"-..", 'd'},
                {".", 'e'},
                {"..-.",'f'},
                {"--.",'g'},
                {"....",'h'},
                {"..",'i'},
                {".---",'j'},
                {"-.-",'k'},
                {".-..",'l'},
                {"--",'m'},
                {"-.",'n'},
                {"---",'o'},
                {".--.",'p'},
                {"--.-",'q'},
                {".-.",'r'},
                {"...",'s'},
                {"-",'t'},
                {"..-",'u'},
                {"...-",'v'},
                {".--",'w'},
                {"-..-",'x'},
                {"-.--",'y'},
                {"--..",'z'},
                {"-----",'0'},
                {".----",'1'},
                {"..---",'2'},
                {"...--",'3'},
                {"....-",'4'},
                {".....",'5'},
                {"-....",'6'},
                {"--...",'7'},
                {"---..",'8'},
                {"----.",'9'}
            };
        }

        public static void getUserInput()
        {
            string inputA = "-..||---||--.";
            Console.WriteLine("1. Your input: "+ inputA);
            Console.WriteLine("Your output is: " + translate(inputA));

            string inputB = "....||.||.-..||.-..||---||||.--||---||.-.||.-..||-..";
            Console.WriteLine("2. Your input: " + inputB);
            Console.WriteLine("Your output is: " + translate(inputB));
            Console.ReadLine();         
        }

        private static string translate(string input)
        {

            System.Text.StringBuilder finalOutput = new System.Text.StringBuilder();
            System.Text.StringBuilder inputWord = new System.Text.StringBuilder();                  //Stringbuilder for holding current character of morse code
            List<string> listOfInput = new List<string>();                                          //collection of morse code entered by user
            bool boolcheck = false;                                                                 // used to count '|'
            int pipeCount = 0;                                                                      // counter which count '|' for spacing
            for (int i = 0; i < input.Length; i++)                                                  // for iterating input
            {
                if (input[i] == '|' )                                                               //checking first pipe
                {
                    pipeCount++;
                    if (boolcheck == false)
                    {
                        listOfInput.Add(inputWord.ToString());                                      //creats a collection of separeated morse code
                        inputWord.Clear();                                                          //flush out previous values after each break
                        boolcheck = true;
                        pipeCount = 0;                                                              // to start scanning input again after break

                    }
                    if (pipeCount >= 3)                                                             // to allocate space between two words
                    {
                        listOfInput.Add(inputWord.ToString());
                        inputWord.Append(" ");                                                      // adding space
                        inputWord.Clear();
                        listOfInput.Add(inputWord.ToString());
                        boolcheck = true;
                        pipeCount = 0;                                                              // to start scanning input again after break
                    } 

                }
                else
                {
                    inputWord.Append(input[i]);
                    if (i+1 == input.Length)                                                        //condition to check whether its last morse character or not?
                    {
                        listOfInput.Add(inputWord.ToString());
                        inputWord.Clear();
                    }
                    boolcheck = false;
                }
                

            }
            foreach (string item in listOfInput)                                                    //iteration to get single morse word separated by break
            {
                if (translator.ContainsKey(item))                                                   //verify with dictionary
                {
                    finalOutput.Append(translator[item] + "");                                      //Stringbuilder for holding decrypted character of morse code
                }
                else
                {
                    finalOutput.Append(" ");
                }
            }
            return answer.ToString();
        }
    }
}
