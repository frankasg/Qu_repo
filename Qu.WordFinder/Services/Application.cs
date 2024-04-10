using Qu.WordFinder.Constants;
using Qu.WordFinder.Interfaces;

namespace Qu.WordFinder.Services
{
    internal class Application : IApplication
    {
        private List<string> _matrix;
        private List<string> _words;
        private IWordFinder _wordFinder;

        public Application() 
        {
            _matrix = new List<string>();
            _words = new List<string>(); 
        }


        public void Run()
        {
            PrintMenu();
        }

        private void PrintMenu()
        {
            Console.WriteLine(ApplicationConstants.Welcome_Message);

            while (true)
            {
                Console.WriteLine(ApplicationConstants.Menu_Title);
                Console.WriteLine(ApplicationConstants.Menu_Option1);
                Console.WriteLine(ApplicationConstants.Menu_Option2);
                Console.WriteLine(ApplicationConstants.Menu_Option3);
                Console.WriteLine(ApplicationConstants.Menu_Option4);

                Console.Write(ApplicationConstants.Menu_Select_Option_Message);
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        EnterMatrix();
                        break;
                    case "2":
                        EnterWords();
                        break;
                    case "3":
                        FindWords();
                        break;
                    case "4":
                        Console.WriteLine(ApplicationConstants.Menu_Thanks_Message);
                        return;
                    default:
                        Console.WriteLine(ApplicationConstants.Menu_Default_Option_Message);
                        break;
                }
            }
        }       

        private void EnterMatrix()
        {
            Console.WriteLine(ApplicationConstants.Enter_Matrix_Message);
            _matrix.Clear();
            string input = Console.ReadLine().ToLower();
            string[] rows = input.Split(',');

            foreach (string row in rows)
            {
                if (row.All(char.IsLetter))
                {
                    _matrix.Add(row);
                }
                else
                {
                    Console.WriteLine(ApplicationConstants.Letters_Only_Message);
                    return;
                }
            }
        }

        private void EnterWords()
        {
            Console.WriteLine(ApplicationConstants.Enter_Words_To_Search_Message);
            _words.Clear();
            string input = Console.ReadLine().ToLower();
            string[] wordArray = input.Split(',');

            foreach (string word in wordArray)
            {
                if (word.All(char.IsLetter))
                {
                    _words.Add(word);
                }
                else
                {
                    Console.WriteLine(ApplicationConstants.Letters_Only_Message);
                    return;
                }
            }
        }

        private void FindWords()
        {
            if (_wordFinder == null)
            {
                if (_matrix.Count == 0)
                {
                    Console.WriteLine(ApplicationConstants.Matrix_Empty_Message);
                    return;
                }
                _wordFinder = new WordFinder(_matrix);
            }

            if (_words.Count == 0)
            {
                Console.WriteLine(ApplicationConstants.Word_List_Empty_Message);
                return;
            }

            var result = _wordFinder.Find(_words);
            if (result.Any())
            {
                Console.WriteLine(ApplicationConstants.Find_Result_Message);
                foreach (var word in result)
                {
                    Console.WriteLine(word);
                }
            }
            else
            {
                Console.WriteLine(ApplicationConstants.Words_Not_Found_Message);
            }
        }
    }
}
