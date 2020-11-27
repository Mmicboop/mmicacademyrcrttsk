using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;


namespace hangmanmmic
{
    class Program
    {
        
        
        string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"\countries_and_capitals.txt");

        static void Main(string[] args)
        {
            string ourtxt = Directory.GetCurrentDirectory();
            Console.WriteLine(ourtxt);
            Console.WriteLine("Hello World!");
            string[] countriesandcapitals = System.IO.File.ReadAllLines(@"C:\Users\me\Desktop\hangmanno\countries_and_capitals.txt");
           
                
            char quitgame = 'f';
            while (quitgame != 'q')
            {
                
                int win = 5;
                int lives = 5;
                Random rand = new Random();
                int ranline = rand.Next(countriesandcapitals.Length);
                string the_words = countriesandcapitals[ranline];
                Console.WriteLine(the_words);
                string[] separatingStrings = { " | " };
                string[] countriessplitt = the_words.Split(separatingStrings,StringSplitOptions.RemoveEmptyEntries);
                Console.WriteLine(countriessplitt[1], countriessplitt[0]);
                string the_word = countriessplitt[1].ToUpper();
                char[] the_word_array = the_word.ToCharArray();
                char[] mystery = new char[the_word.Length];
                int guesscount = 0;
                
                for (int p = 0; p < the_word.Length; p++)
                {
                    mystery[p] = '_';
                }
                while (win != 1 && lives > 0)
                {
                    var badletters=new List<char>();
                    Console.WriteLine("Letters not in words");
                    badletters.ForEach(Console.Write);
                    Console.WriteLine("current lives: " + lives);
                        Console.WriteLine("would you like to guess a letter (1) or a whole word (2)?");
                        int guesstype = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("input your guess uppercase only");
                        char guess = 'l';
                        if (guesstype == 1)
                        {
                            guesscount++;
                            int hit = 0;
                            guess = char.Parse(Console.ReadLine());
                            for (int j = 0; j < mystery.Length; j++)
                            {
                                if (guess == the_word[j])
                                {
                                    mystery[j] = guess;
                                    hit = 1;
                                    
                                }
                            }
                            
                            Console.WriteLine(mystery);
                            if (hit == 0)
                            {
                                guesscount++;
                                lives = lives - 1;
                                badletters.Add(guess);
                                Console.WriteLine("try again!");
                                Console.WriteLine(mystery);
                            }
                            if (lives < 3)
                            {
                                Console.WriteLine("A Hint!!! Capital of "+countriessplitt[0]);
                            }
                        }
                        else if (guesstype == 2)
                        {
                            string guessword = Console.ReadLine();
                            bool result = guessword.Equals(the_word, StringComparison.OrdinalIgnoreCase);
                            if (result)
                            {
                                win = 1;
                                
                            }
                            else
                            {
                                lives = lives -= 2;
                                Console.WriteLine("didnt guess the word -2 lives");
                            }
                            if (lives < 3)
                            {
                                Console.WriteLine("A Hint!!! Capital of "+countriessplitt[0]);
                            }
                        }
                }
                if (win == 1)
                {
                    Console.WriteLine("Congratulations you've won after "+guesscount+" guesses and with "+lives+" lives left!");
                    Console.WriteLine("The answer was "+countriessplitt[1]+"the capital of "+countriessplitt[0]);
                    Console.WriteLine("Whats your name, brave noose-less person?:");
                    string username = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("oh no, you got hanged! better luck next time! the answer was "+countriessplitt[1]+"the capital of "+countriessplitt[0]);
                }
                Console.WriteLine("q to quit, any other key to restart the game");
                quitgame = char.Parse(Console.ReadLine());
            }

        }
    }
}
