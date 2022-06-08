Thread t = new Thread(() =>
{
    Console.WriteLine("Thread is starting, press ENTER lala ...");
    Console.ReadLine();
});

t.IsBackground = false;
t.Start();


