var syncObj = new object();

int value1 = 1;
int value2 = 1;

Thread t1 = new Thread(DoWork);
Thread t2 = new Thread(DoWork);
t1.Start();
t2.Start();

void DoWork()
{
    lock (syncObj)
    {
        if (value2 > 0)
        {
            Console.WriteLine(value1/value2);
            value2 = 0;
        }
    }
}


