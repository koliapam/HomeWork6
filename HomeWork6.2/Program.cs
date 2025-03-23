using System;


enum StoreType
{
    Продовольчий,
    Господарський,
    Одяг,
    Взуття
}


class Store : IDisposable
{
   
    public string Name { get; set; }
    public string Address { get; set; }
    public StoreType Type { get; set; }
    private bool disposed = false;

   
    public Store(string name, string address, StoreType type)
    {
        Name = name;
        Address = address;
        Type = type;
        Console.WriteLine("Створено магазин: " + Name);
    }

    
    public void DisplayInfo()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine($"Назва магазину: {Name}\nАдреса: {Address}\nТип: {Type}\n");
    }

    
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                
                Console.WriteLine("Звільняємо ресурси магазину: " + Name);
            }

            disposed = true;
        }
    }

    // Деструктор
    ~Store()
    {
        Dispose(false);
        Console.WriteLine("Знищено магазин: " + Name);
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        using (Store store1 = new Store("АТБ", "вул. Люстдорфська, 162", StoreType.Продовольчий))
        {
            store1.DisplayInfo();
        } 

        Console.WriteLine("Магазин видалено");
    }
}
