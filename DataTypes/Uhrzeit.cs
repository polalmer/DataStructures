using System.Runtime.ExceptionServices;

namespace CustomTypes;

public class Uhrzeit
{
    public static void Function()
    {
        Time div = CalcDiv(Time.GetUhrzeitFromUser(), Time.GetUhrzeitFromUser());
        Console.WriteLine($"Diffrerenz:{div.hour} {div.minute} {div.second}");
    }

    private static Time CalcDiv(Time time1, Time time2)
    {
        Time div = new();
        if (time1.second < time2.second)
        {
            time1.second += 60;
            time1.minute--;
        }
        div.second = time1.second - time2.second;

        if (time1.minute < time2.minute)
        {
            time1.minute += 60;
            time1.hour--;
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
}

