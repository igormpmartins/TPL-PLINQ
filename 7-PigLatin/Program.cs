//var sentence = Piggify("Mark Farragher");
var sentence = "Mark Farragher";

var task =
    Task<string[]>.Factory
        .StartNew(() => Map(sentence))
        .ContinueWith<string[]>(t => Process(t.Result))
        .ContinueWith<string>(t => Reduce(t.Result));

Console.WriteLine(task.Result);


string[] Map(string s) => s.Split();

string Piggify(string s)
{
    if (string.IsNullOrEmpty(s))
        throw new ArgumentNullException(nameof(s));

    var temp = s.ToLower();
    temp = temp.Substring(1, temp.Length - 1) + temp[0] + "ay";

    return temp;
}

string[] Process(string[] words)
{
    for (var i = 0; i < words.Length; i++)
    {
        int index = i;
        //words[index] = Piggify(words[index]);

        Task.Factory.StartNew(
            () => words[index] = Piggify(words[index]),
            TaskCreationOptions.AttachedToParent | TaskCreationOptions.LongRunning);
    }

    return words;
}

string Reduce(string[] words) => string.Join(' ', words);
