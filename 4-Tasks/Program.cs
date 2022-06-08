/*
var cts = new CancellationTokenSource();
var token = cts.Token;

cts.Cancel();
cts.CancelAfter(1000);
token.ThrowIfCancellationRequested();
*/


void DoTaskWork(object message)
{
    Console.WriteLine(message);
}

static void LongRunningTask()
{
    var task = Task.Factory.StartNew(() =>
    {
        Thread.Sleep(2000);
        Console.WriteLine("yo");

        Console.WriteLine($"Is background thread? {Thread.CurrentThread.IsBackground}");
        Console.WriteLine($"Is threadpool thread? {Thread.CurrentThread.IsThreadPoolThread}");

        //throw new Exception("ya");

    }, TaskCreationOptions.LongRunning);

    task.Wait();
}

static void GetTaskUsingResult()
{
    var task = Task<string>.Factory.StartNew(() =>
    {
        Thread.Sleep(2000);
        return "Yo";
    });

    Console.Write("Your name is ");
    Console.Write(task.Result);
}

void SendParameterTask()
{
    var theOneMessage = "Yo man";
    var task = Task.Factory.StartNew(DoTaskWork, theOneMessage);
    Console.ReadLine();
}

static void SupplyTaskState()
{
    string myMessage = "Yo dude";

    Task.Factory.StartNew((state) =>
    {
        Console.WriteLine(myMessage);
    }, "MyTaskHere");

    Thread.Sleep(1000);
    Console.ReadLine();
    Console.ReadLine();
}