using System.Diagnostics;

var tasks = new List<Task<string>>();

var sentence = "the quick fat cat jumped over the crazy dev";

var sw = new Stopwatch();
sw.Start();
Task.Factory.StartNew(() => ProcessSentence(sentence)).Wait();
sw.Stop();
Console.WriteLine($"Total: {sw.ElapsedMilliseconds} ms");

Console.WriteLine("Result: ");


foreach (var item in tasks)
{
    Console.WriteLine($"Task {item.Id} Completed? " + item.IsCompleted);
}

foreach (var item in tasks)
{
    Console.Write(item.Result);
}

string ReverseString(string s)
{
    Thread.Sleep(1000);
    return String.Join("", s.ToArray().Reverse());
}

void ProcessSentence(string sentence)
{
    foreach (var word in sentence.Split())
    {
        tasks.Add(
            Task<string>.Factory.StartNew(
                () => ReverseString(word) + " ",
                TaskCreationOptions.AttachedToParent | TaskCreationOptions.LongRunning)
        );
    }
}