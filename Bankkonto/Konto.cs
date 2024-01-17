namespace Bankkonto;

public class Konto(int kontonummer, int kundennummer, string inhaber)
{
    private readonly int Kontonummer = kontonummer;
    private readonly string Inhaber = inhaber;
    private readonly int Kundennummer = kundennummer;
    private float Betrag;

    /// <summary>
    /// maximale Überziehgrenze positiv -> 100 beduetet der Betrag kann bis -100 gehen
    /// </summary>
    private float Dispo;

    public void Set_Dispo(float dispo_betrag)
    {
        Dispo = dispo_betrag;
    }

    public float Get_Betrag()
    {
        return Betrag;
    }

    public float Einzahlung(float betrag)
    {
        return Betrag += betrag;
    }

    public float Auszahlung(float betrag)
    {
        if (Dispo + Betrag >= betrag)
        {
            Betrag -= betrag;
            return betrag;
        }
        Console.WriteLine("nicht genug Geld!");
        return 0;
    }

    public void Auszug()
    {
        Console.WriteLine($"Inhaber: {Inhaber}");
        Console.WriteLine($"Betrag:{Betrag}");
        Console.WriteLine($"Dispo: {Dispo}");
        Console.WriteLine("-----------------------------");
    }
}