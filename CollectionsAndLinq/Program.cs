using System;
using System.Collections.Generic;

namespace CollectionsAndLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            //anything with angle brackets afer the type name is called a generic type
            //List<T> is pronounced list of T. angle brackets mean "of" basically.
            // string in this case closes the generic type <STRING>
            // between brackets tells it what it will contain
            var e13 = new List<string>(); // list of string
            var teachers = new List<string> { "Jameka", "Dylan", "Nathan" };
            // string Jordan
            e13.Add("Jordan");
            e13.Add("Ryan");
            e13.Add("Bailey");

            /*foreach (var teacher in teachers)
            {
                e13.Add(teacher);
            }*/
            // the same as
            e13.AddRange(teachers);

            /*this will not work. once you pull the iterator for e13 you cannot change the collection
             * foreach (var student in e13)
            {
                e13.Add("wsdfsdf"); //unsuported operation exception
            }*/

            //Dictionary<TKey,TValue> //maybe similar to JSON?
            //Arity (`2) -> how many generic type parameters a type has. Dictionary`2
            // very fast info retrieval
            // slower info storage speeds
            // good for infrequently updated but often read data
            // good for loading info at startup or in the background and fast retrieval on demand (caching)

            // the first param is the type for the key, the second param is the type for the value
            var words = new Dictionary<string,string>();

            /*can also be writen like this
            var words = new Dictionary<string, string>
            {
                { "soup", "a thing i dont have right now" },
            }*/


            words.Add("Arity","how many generic type parameters a type has");
            words["Arity"] = "A thing Nathan made up?";

            //words.Add("Arity", "another definition"); //argument exception
            if(!words.TryAdd("Arity", "another definition"))
            {
                words["Arity"] = "another definition";
            }

            foreach (var word in words)
            {
                Console.WriteLine($"{word.Key} means {word.Value}");
            }
            //destructuring
            foreach (var (word, definition) in words)
            {
                Console.WriteLine($"{word} means... {definition}");
            }

            var complicatedDictionary = new Dictionary<string, List<string>>();

            complicatedDictionary.Add("Soup", new List<string>());
            complicatedDictionary["Soup"].Add("This is the definition of soup");
            var soupDefinitions = complicatedDictionary["Soup"];
            soupDefinitions.Add("This is another def");
            complicatedDictionary.Add("Arity", new List<string> { "A def of soup" });

            foreach (var (word,definitions) in complicatedDictionary)
            {
                Console.WriteLine(word);
                foreach (var definition in definitions)
                {
                    Console.WriteLine($"\t{definition}");
                }

            }

            //Hashset<T>
            //Really fast retrieval, no keys
            // good for retrieving
            //enforces uniqueness, but doesnt cause errors for things not unique
            // good for looping, deduplication - no duplicates, not allowed
            // good for when you only want at most one copy of a thing

            var unique = new HashSet<string>(e13); // if you pass a param it will eliminate duplicates

            unique.Add("something");

            //Queue<T>
            //FIFO
            var queue = new Queue<int>();
            //enqueue adds to end of line
            queue.Enqueue(5);
            queue.Enqueue(6);
            queue.Enqueue(7);
            queue.Enqueue(8);
            queue.Enqueue(9);

            while (queue.Count > 0)
            {
                Console.WriteLine($"currently dequeueing : {queue.Dequeue()}");
            }

            //Stack<T>
            //LIFO
            var stack = new Stack<int>();
            // push adds and pop removes
            stack.Push(5);
            stack.Push(6);
            stack.Push(7);
            stack.Push(8);
            stack.Push(9);

            while (queue.Count > 0)
            {
                Console.WriteLine($"currently dequeueing : {stack.Pop()}");
            }


        }
    }
}
