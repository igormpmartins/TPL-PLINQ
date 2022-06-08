using System;
using System.Threading.Tasks;

namespace _7_2_PigLatin
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static string[] Map(string s) => s.Split();

        public static string Piggify(string s)
        {
            if (string.IsNullOrEmpty(s))
                throw new ArgumentNullException(nameof(s));

            var temp = s.ToLower();
            temp = temp.Substring(1, temp.Length - 1) + temp[0].ToString() + "ay";

            return temp;
        }

        public static string[] Process(string[] words)
        {
            for (var i = 0; i < words.Length; i++)
            {
                int index = i;

                Task.Factory.StartNew(
                    () => words[index] = Piggify(words[index]),
                    TaskCreationOptions.AttachedToParent | TaskCreationOptions.LongRunning);
            }

            return words;
        }

        public static string Reduce(string[] words) => string.Join(" ", words);

        public static string PigLatin(string sentence)
        {

            if (string.IsNullOrEmpty(sentence))
                throw new ArgumentNullException(nameof(sentence));

            var task =
                Task<string[]>.Factory
                    .StartNew(() => Map(sentence))
                    .ContinueWith<string[]>(t => Process(t.Result))
                    .ContinueWith<string>(t => Reduce(t.Result));

            return task.Result;
        }
    }
}
