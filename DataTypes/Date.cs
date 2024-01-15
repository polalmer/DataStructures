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
    public static Date? GetDate(string input)
    {
        input = input.Replace(" ", string.Empty);
        string d = input[0..2];
        string m = input[2..4];
        string y = input[4..8];
        if (int.TryParse(d, out _) is false) return null;
        if (int.TryParse(m, out _) is false) return null;
        if (int.TryParse(y, out _) is false) return null;
        Date date = new()
        {
            Day = uint.Parse(d),
            month = uint.Parse(m),
            year = uint.Parse(y)
        };
        if (date.year > 31) return null;
        if (date.month > 12) return null;
        if (date.year > 9999) return null;
        return date;
    }
}