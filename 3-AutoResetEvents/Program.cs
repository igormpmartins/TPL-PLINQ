var result = 0;
var lockHandle = new object();

var readyForResult = new AutoResetEvent(false);
var setResult = new AutoResetEvent(false);

var t = new Thread(DoWork);
t.Start();

for (var i = 0; i < 100; i++)
{
    //tell thread we're ready for the result
    readyForResult.Set();

    //wait until result is ready
    setResult.WaitOne();

    lock (lockHandle)
    {
        Console.WriteLine(result);
    }

    Thread.Sleep(10);
}

t.Abort();

void DoWork()
{
    while (true)
    {
        var i = result;
        Thread.Sleep(1);

        //wait until main loop is ready to receive the result
        readyForResult.WaitOne();

        lock (lockHandle)
        {
            result = i + 1;
        }
        setResult.Set();
    }
}
