using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to HashTable Program");
            string paragraph = "Paranoids are not paranoid because they are paranoid but because they keep putting themselves deliberately into paranoid avoidable situations";
            CountWords(paragraph);
            Console.ReadLine();
        }
        /// <summary>
        /// Counts the words.
        /// </summary>
        /// <param name="paragraph">The paragraph.</param>
        public static void CountWords(string paragraph)
        {
            MyMapNode<string, int> myMapNode = new MyMapNode<string, int>(6);
            string[] words = paragraph.Split(' ');
            foreach (string word in words)
            {
                if(myMapNode.Exists(word))
                    myMapNode.Add(word.ToLower(), myMapNode.Get(word) + 1);
                else
                    myMapNode.Add(word.ToLower(), 1);
            }
            Console.WriteLine("Display after Add operation");
            myMapNode.Display();
        }
    }
}
