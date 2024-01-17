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

        long time1InSeconds = time1.hour * 3600 + time1.minute * 60 + time1.second;
        long time2InSeconds = time2.hour * 3600 + time2.minute * 60 + time2.second;

        long diffInSeconds = Math.Abs(time1InSeconds - time2InSeconds);

        div.hour = (uint)diffInSeconds / 3600;
        div.minute = (uint)(diffInSeconds % 3600) / 60;
        div.second = (uint)diffInSeconds % 60;

        return div;
    }
}

