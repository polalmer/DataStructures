namespace CustomTypes;

public class Time
{
    public uint hour;
    public uint minute;
    public uint second;

    /// <summary>
    ///  Null if unable to get Tiem
    /// </summary>
    public static Time? GetTime(string input)
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