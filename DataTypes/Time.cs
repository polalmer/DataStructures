namespace CustomTypes;

public class Time
{
    public uint hour;
    public uint minute;
    public uint second;

    /// <summary>
    ///  Null if unable to get Tiem
    /// </summary>
    private static Time? GetTime(string input)
    {
        input = input.Replace(" ", string.Empty);
        string h = input[0..2];
        string m = input[2..4];
        string s = input[4..6];
        Time time = new();
        if (uint.TryParse(h, out time.hour) is false) return null;
        if (uint.TryParse(m, out time.minute) is false) return null;
        if (uint.TryParse(s, out time.second) is false) return null;
        if (time.second > 59) return null;
        if (time.minute > 59) return null;
        if (time.hour > 23) return null;
        return time;
    }

    public static Time GetUhrzeitFromUser()
    {
        Time? time;
        while (true)
        {
            Console.WriteLine("Enter Uhrzeit (HH MM SS):");
            string? input = Console.ReadLine();
            if (input is null) continue;
            if (input == "exit") continue;
            time = GetTime(input);
            if (time is not null) return time;
            Console.WriteLine("Fehler:");
        }
    }

    /// <summary>
    /// Null if same
    /// </summary>
    public static Time? GetLarger(Time one, Time two)
    {
        if (one.hour > two.hour) return one;
        if (two.hour > one.hour) return two;
        if (one.minute > two.minute) return one;
        if (two.minute > one.minute) return two;
        if (one.second > two.second) return one;
        if (two.second > one.second) return two;
        return null;
    }
}