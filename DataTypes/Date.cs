namespace CustomTypes;

/// <summary>
/// DD, MM, JJJJ
/// </summary>
public class Date
{
    public uint Day;
    public uint month;
    public uint year;

    /// <summary>
    ///  Null if unable to get Tiem
    /// </summary>
    private static Date? GetDate(string input)
    {
        input = input.Replace(" ", string.Empty);
        string d = input[0..2];
        string m = input[2..4];
        string y = input[4..8];
        Date date = new();
        if (uint.TryParse(d, out date.Day) is false) return null;
        if (uint.TryParse(m, out date.month) is false) return null;
        if (uint.TryParse(y, out date.year) is false) return null;
        if (date.Day > 31) return null;
        if (date.month > 12) return null;
        if (date.year > 9999) return null;
        return date;
    }

    public static Date GetUhrzeitFromUser()
    {
        Date? date;
        while (true)
        {
            Console.WriteLine("Enter Datum (DD MM YYYY):");
            string? input = Console.ReadLine();
            if (input is null) continue;
            if (input == "exit") continue;
            date = GetDate(input);
            if (date is not null) return date;
            Console.WriteLine("Fehler:");
        }
    }

    /// <summary>
    /// Null if same
    /// </summary>
    public static Date? GetLarger(Date one, Date two)
    {
        if (one.year > two.year) return one;
        if (two.year > one.year) return two;
        if (one.month > two.month) return one;
        if (two.month > one.month) return two;
        if (one.Day > two.Day) return one;
        if (two.Day > one.Day) return two;
        return null;
    }
}