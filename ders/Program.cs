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
// Birden fazla thread ın aynı kaynağa aynı anda ulaşma isteğini kontrol etmek için
// Aynı anda sadece tek bir threadın belirli bir kod bloğuna erişimini sağlamakta ve böylece paylaşılan kaynakların birden fazla thread in müdahalesini engelleyerek Race conditions durumlarına engel olmakta.

object _locking = new();
int i = 1;
Thread lock1 = new(() =>
{
    lock (_locking)
    {
        while(i < 10)
        {
            i++;
            Console.WriteLine($"Thread 1: {i}");
           
        }
    }
});

Thread lock2 = new(() =>
{
    lock(_locking)
    {
        while (i >0)
        {
            i--;
            Console.WriteLine($"Thread 2: {i}");
            
        }
    }
});

lock1.Start();
lock2.Start();

#endregion

#region Thread.Sleep 
// Belirli saniye uyutmak için
Thread threadSleep = new(() =>
{
    for(int i = 0; i < 10; i++)
    {
        Console.WriteLine(i);
        Thread.Sleep(1000);
    }
});

threadSleep.Start();
#endregion