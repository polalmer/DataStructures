namespace CustomTypes;

public static class Terminplan
{
    private static List<Termin> Termine = [];

    public static void Function()
    {
        Console.WriteLine("Willkommmen im Terminkalender");
        while (true)
        {
            Console.WriteLine("enter: add, list, remove, sort, exit");
            string? input = Console.ReadLine();
            if (input is null) continue;
            if (input == "exit") return;
            if (input == "list") ListTermine();
            if (input == "add") AddTermin();
            if (input == "remove") Remove();
            if (input == "sort") Sort();
        }
    }

    private static void Sort()
    {
        for (int start = 0; start < Termine.Count - 2; start++)
        {
            for (int i = start + 1; i < Termine.Count - 1; i++)
            {
                Termin later = GetLater(Termine[i], Termine[i + 1]);
                if (later == Termine[i])
                {
                    (Termine[i], Termine[i + 1]) = (Termine[i + 1], Termine[i]);
                }
            }
        }
        ListTermine();
    }

    private static Termin GetLater(Termin one, Termin two)
    {
        Date? date = Date.GetLarger(one.Date, two.Date);
        if (date is null)
        {
            Time? time = Time.GetLarger(one.Time, two.Time);
            if (time is null) return one;
            if (one.Time == time)
            {
                return one;
            }
            else
            {
                return two;
            }
        }
        if (one.Date == date)
        {
            return one;
        }
        else
        {
            return two;
        }
    }

    private static void Remove()
    {
        ListTermine();
        while (true)
        {
            Console.WriteLine("Enter number to delete:");
            string? input = Console.ReadLine();
            if (input is null) continue;
            if (input is "exit") return;
            if (int.TryParse(input, out _) is false) continue;
            int toDelete = int.Parse(input);
            try
            {
                Termine.Remove(Termine[toDelete - 1]);
                return;
            }
            catch
            {
                Console.WriteLine("Termin not found");
            }
        }
    }

    private static void AddTermin()
    {
        Time time = Time.GetUhrzeitFromUser();
        Date date = Date.GetUhrzeitFromUser();
        Termine.Add(new Termin(time, date));
        Console.WriteLine("Termin hinzugefügt");
    }

    private static void ListTermine()
    {
        int count = 1;
        if (Termine.Count == 0)
        {
            Console.WriteLine("Noch keine Termine vorhanden");
            return;

        }
        foreach (Termin termin in Termine)
        {
            Console.WriteLine($"Termin {count}: AM {termin.Date.Day}/{termin.Date.month}/{termin.Date.year}"
            + $" um {termin.Time.hour} {termin.Time.minute} {termin.Time.second}");
            count++;
        }
    }
}


public class Termin(Time time, Date dateOnly)
{
    public Date Date { get; private set; } = dateOnly;
    public Time Time { get; private set; } = time;
}