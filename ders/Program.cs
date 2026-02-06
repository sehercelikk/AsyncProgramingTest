// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
#region Thread ID 
Console.WriteLine("Main Tread ID:");
Console.WriteLine(Environment.CurrentManagedThreadId);

Thread thread = new(() =>
{
    Console.WriteLine("New Tread ID:");
    Console.WriteLine(Environment.CurrentManagedThreadId);
});

thread.Start();
#endregion

#region Locking Mekanizması
object _locking = new();
int i = 1;
Thread lock1 = new(() =>
{
    lock (_locking)
    {
        while(i <= 10)
        {
            Console.WriteLine(i++);
           
        }
    }
});

Thread lock2 = new(() =>
{
    lock(_locking)
    {
        while (i >1)
        {
            Console.WriteLine(i--);
            
        }
    }
});

lock1.Start();
lock2.Start();

#endregion