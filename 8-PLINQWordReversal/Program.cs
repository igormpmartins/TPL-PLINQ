var sentence = "the quick fat cat jumped over the crazy dev";

var words = sentence.Split()
                .AsParallel()
                //.AsSequential()
                .AsOrdered()
                .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                //.AsUnordered()
                .Select(w => new string(w.Reverse().ToArray()));

Console.WriteLine(string.Join(" ", words));
