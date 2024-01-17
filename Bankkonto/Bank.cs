namespace Bankkonto;
public class Bank(List<Konto> konten)
{
    private readonly List<Konto> bankKonten = konten;

    private Konto? logInKonto = null;

    public void BankApp()
    {
        Console.WriteLine("Willkommen beim offline banking:");
        while (true)
        {
            if (logInKonto is null)
            {
                Console.WriteLine("[create] Konto erstellen\n[list] Konten anzeigen\n[login] einloggen\n[exit]");
                string? input = Console.ReadLine();
                if (input is null) continue;
                if (input == "create") CreateKonto();
                if (input == "list") ListKonten();
                if (input == "login") Login();
                if (input == "exit") return;
            }
            else
            {
                Console.WriteLine("Eingelogged als:");
                logInKonto.Auszug();
                Console.WriteLine("[setDispo]\n[auszug]\n[einzahlen]\n[abheben]\n[überweisung]\n[logout]");
                string? input = Console.ReadLine();
                if (input is null) continue;
                if (input == "auszug") logInKonto.Auszug();
                if (input == "setDispo") SetDispo();
                if (input == "einzahlen") Einzahlen();
                if (input == "abheben") Abheben();
                if (input == "überweisung") ÜberweisungsScreen();
                if (input == "logout") logInKonto = null;
            }
        }
    }

    public void Überweisen(Konto von, Konto nach, float betrag)
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

    private void ÜberweisungsScreen()
    {
        Console.WriteLine("\nÜberweisungsterminal ([list] to show Konten, [exit])");
    repeatEmpfänger:
        Console.Write("An welches Konto wird überwiesen:");
        string? input = Console.ReadLine();
        if (input is null || input == "exit") return;
        if (input == "list")
        {
            ListKonten();
            goto repeatEmpfänger;
        }
        if (int.TryParse(input, out int empfängerNr) is false)
        {
            Console.WriteLine("Invalid input");
            goto repeatEmpfänger;
        }
        try
        {
            Konto empfänger = bankKonten[empfängerNr];
        repeatGeld:
            Console.Write("Wie viel soll überwiesen werden?");
            string? amountString = Console.ReadLine();
            if (float.TryParse(amountString, out float amount) is false)
            {
                Console.WriteLine("Invalid number");
                goto repeatGeld;
            }
            Überweisen(logInKonto!, empfänger, amount);
        }
        catch
        {
            Console.WriteLine("Empfänger not found");
            goto repeatEmpfänger;
        }
    }

    private void Abheben()
    {
    repeatAbheben:
        Console.Write("Einzuzahlender Betrag?");
        string? input = Console.ReadLine();
        if (input == "exit") return;
        if (float.TryParse(input, out float subAmmount) is false)
        {
            Console.WriteLine("Invalide Eingabe");
            goto repeatAbheben;
        }
        Console.WriteLine(logInKonto?.Auszahlung(subAmmount));
    }

    private void Einzahlen()
    {
    repeatEinzahlen:
        Console.Write("Einzuzahlender Betrag?");
        string? input = Console.ReadLine();
        if (input == "exit") return;
        if (float.TryParse(input, out float addedAmmount) is false)
        {
            Console.WriteLine("Invalide Eingabe");
            goto repeatEinzahlen;
        }
        logInKonto?.Einzahlung(addedAmmount);
        logInKonto?.Auszug();
    }

    private void SetDispo()
    {
    repeatSetDispo:
        Console.Write("neue Dispogrenze?");
        string? input = Console.ReadLine();
        if (input == "exit") return;
        if (float.TryParse(input, out float neueGrenze) is false)
        {
            Console.WriteLine("Invalide Eingabe");
            goto repeatSetDispo;
        }
        logInKonto?.Set_Dispo(neueGrenze);
    }

    private void Login()
    {
    repeatLogin:
        Console.Write("Kontonummer?");
        string? input = Console.ReadLine();
        if (input is null) return;
        if (input == "exit") return;
        if (int.TryParse(input, out int number) is false)
        {
            Console.WriteLine("Keine Konto nummer");
            goto repeatLogin;
        }
        try
        {
            logInKonto = bankKonten[number];
        }
        catch
        {
            Console.WriteLine("Konto not found");
            return;
        }
    }

    private void CreateKonto()
    {
        Console.Write("Inhaber?");
        string? inhaber = Console.ReadLine();
        if (inhaber is null) return;
        Konto konto = new(bankKonten.Count, bankKonten.Count, inhaber);
        konto.Auszug();
        bankKonten.Add(konto);
    }

    private void ListKonten()
    {
        int count = 0;
        if (bankKonten.Count == count)
        {
            Console.WriteLine("Keine konten \n");
            return;
        }
        foreach (Konto konto in bankKonten)
        {
            Console.WriteLine($"Konto {count++}:");
            konto.Auszug();
            Console.WriteLine();
        }
    }
}