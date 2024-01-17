namespace Bankkonto;
public class Bank(List<Konto> konten)
{
    private readonly List<Konto> bankKonten = konten;

    public void Überweisung(Konto von, Konto nach, float betrag)
    {
        if (bankKonten.Contains(von) is false)
        {
            Console.WriteLine("Falsche Bank");
            return;
        }

        float geldVon = von.Auszahlung(betrag);
        if (geldVon == betrag)
        {
            nach.Einzahlung(geldVon);
            Console.WriteLine("Überweisung erflogreich");
            return;
        }
        Console.WriteLine("Unzureichende Kontodeckung");
    }
}