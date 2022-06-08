var syncObj = new object();

int value1 = 1;
int value2 = 1;

Thread t1 = new Thread(DoWork);
Thread t2 = new Thread(DoWork);
t1.Start();
t2.Start();

void DoWork()
{
    var lockTaken = false;
    try
    {
        Monitor.Enter(syncObj, ref lockTaken);
        //Monitor.TryEnter(syncObj, TimeSpan.FromMilliseconds(50), ref lockTaken);

        if (value2 > 0)
        {
            Calculate(value1, value2);
            value2 = 0;
        }
    } 
    finally
    {
        if (lockTaken)
            Monitor.Exit(syncObj);
    }
}


void Calculate(int value1, int value2)
{
    lock (syncObj)
    {
        Console.WriteLine(value1 / value2);
    }
}