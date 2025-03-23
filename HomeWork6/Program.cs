using System;

class Play : IDisposable
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public int Year { get; set; }
    private bool disposed = false;

    public Play(string title, string author, string genre, int year)
    {
        Title = title;
        Author = author;
        Genre = genre;
        Year = year;
        Console.WriteLine("Створено п'єсу: " + Title);
    }

    public void DisplayInfo()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine($"Назва: {Title}\nАвтор: {Author}\nЖанр: {Genre}\nРік: {Year}\n");
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
                Console.WriteLine("Звільняємо ресурси п'єси: " + Title);
            }

            disposed = true;
        }
    }

    ~Play()
    {
        Dispose(false);
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        using (Play play1 = new Play("Річард III", "Вільям Шекспір", "Історічна Хроніка", 1594))
        {
            play1.DisplayInfo();
        }

        Console.WriteLine("П'єса видалена");
    }
}
