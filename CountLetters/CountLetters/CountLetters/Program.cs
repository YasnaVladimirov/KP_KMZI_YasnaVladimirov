using System.Text;

namespace CountLetters
{
    class Program
    {
        public static void Main()
        {
            const string path = "EncryptedMessage2.txt";
            char[] letters = "АБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЬЮЯ".ToArray();
            Dictionary<char, int> lettersCount = new Dictionary<char, int>();

            using (var f = new StreamReader(path))
            {
                while (!f.EndOfStream)
                {
                    char c = (char)f.Read();
                    if (letters.Contains(c))
                    {
                        if (lettersCount.ContainsKey(c))
                        {
                            lettersCount[c]++;
                        }
                        else
                        {
                            lettersCount.Add(c, 1);
                        }
                    }
                }
            }

            lettersCount = lettersCount
                .OrderByDescending(x => x.Value)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var letter in lettersCount)
            {
                Console.WriteLine($"{letter.Key}: {letter.Value}");
            }

            string text = File.ReadAllText(path);

            while(true)
            {
                Console.WriteLine(Environment.NewLine + text + Environment.NewLine);

                Console.Write("Заместване на: ");
                string letter = Console.ReadLine();

                Console.Write("Нова буква: ");
                string replaceWith = Console.ReadLine();

                text = text.Replace(letter, replaceWith);
            }
        }
    }
}
