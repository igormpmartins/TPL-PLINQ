const int REPS = 1000;

//Thread t1 = new Thread(new ThreadStart(DoWork));
//Thread t1 = new Thread(DoWork);
/*Thread t1 = new Thread(() => 
{
    global::System.Console.WriteLine("Ini...");
    DoWork(); 
});
*/

for (int i = 0; i < 9; i++)
{
    Thread t = new Thread(DoWork);
    t.Name = "Thread " + i.ToString();
    t.Start();
}

//t1.Start();
var dummy = 123;

for (int i = 0; i < REPS; i++)
{
    Console.Write("A");
}


static void DoWork()
{
    for (int i = 0; i < REPS; i++)
    {
        Console.Write("B");
    }
}