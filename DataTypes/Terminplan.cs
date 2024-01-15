namespace CustomTypes;

public static class Terminplan
{
    private static List<Termin> Termine = [];

    public static void Funtion()
    {
        Console.WriteLine("Willkommmen im Terminkalender");
        while (true)
        {
            Console.WriteLine("add, list, exit");
            string? input = Console.ReadLine();
            if (input is null) continue;

        }
    }
}


public class Termin(Time time, Date dateOnly)
{
    public Date Date { get; private set; } = dateOnly;
    public Time Time { get; private set; } = time;
}