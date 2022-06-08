var sentence = "the quick fat cat jumped over the crazy dev";

var task =
    Task<string[]>.Factory
        .StartNew(() => Map(sentence))
        .ContinueWith<string[]>(t => Process(t.Result))
        .ContinueWith<string>(t => Reduce(t.Result));

Console.WriteLine("Result: " + task.Result);

string ReverseString(string s)
{
    Thread.Sleep(1000);
    return string.Join("", s.Reverse());
}

string[] Map(string s) => s.Split();

string[] Process(string[] words)
{
    for (var i = 0; i < words.Length; i++)
    {
        int index = i;
        Task.Factory.StartNew(
            () => words[index] = ReverseString(words[index]),
            TaskCreationOptions.AttachedToParent | TaskCreationOptions.LongRunning);
    }
    return words;
}

string Reduce(string[] words) => string.Join(' ', words);
