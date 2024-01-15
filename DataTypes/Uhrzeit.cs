using System.Runtime.ExceptionServices;

namespace CustomTypes;

public class Uhrzeit
{
    public static void Function()
    {
        Time div = CalcDiv(GetUhrzeitFromUser(), GetUhrzeitFromUser());
        Console.WriteLine($"Diffrerenz:{div.hour} {div.minute} {div.second}");
    }

    private static Time CalcDiv(Time time1, Time time2)
    {
        Time div = new();
        if (time1.second < time2.second)
        {
            time2.second -= time1.second;
            time1.second = 60;
            time2.minute++;
        }
        div.second = time1.second - time2.second;

        if (time1.minute < time2.minute)
        {
            time2.minute -= time1.minute;
            time1.minute = 60;
            time2.hour++;
        }
        div.minute = time1.minute - time2.minute;
        if (time1.hour < time2.hour)
        {
            div.hour = time2.hour - time1.hour;
        }
        else
        {
            div.hour = time1.hour - time2.hour;
        }
        return div;
    }

    private static Time GetUhrzeitFromUser()
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

    private static Time? GetTime(string input)
    {
        input = input.Replace(" ", string.Empty);
        string h = input[0..2];
        string m = input[2..4];
        string s = input[4..6];
        if (int.TryParse(h, out _) is false) return null;
        if (int.TryParse(m, out _) is false) return null;
        if (int.TryParse(s, out _) is false) return null;
        Time time = new()
        {
            hour = uint.Parse(h),
            minute = uint.Parse(m),
            second = uint.Parse(s)
        };
        if (time.second > 59) return null;
        if (time.minute > 59) return null;
        if (time.hour > 23) return null;
        return time;
    }
}


class Time
{
    public uint hour;
    public uint minute;
    public uint second;
}
