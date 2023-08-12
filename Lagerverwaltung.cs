using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lagerverwaltungssystem
{
    internal class Lagerverwaltung
    {
        public string neuerBenutzername;
        public string neuesPasswort;
        public string eingabeLagerplatz;
        public int eingabeMengeBestand;
        public string eingabeArtikelnummer;
        string eingabeArtikelname;
        public int eingabeMengeBestandZubuchen;
        public int eingabeMengeBestandAbbuchen;

        bool ifrei1 = false;
        bool ifrei2 = false;
        bool jfrei1 = false;
        bool jfrei2 = false;
        bool hfrei1 = false;
        bool hfrei2 = false;
        bool pfrei1 = false;
        bool pfrei2 = false;

        public int e;
        public int i;
        public int v;
        public int j;
        public int u;


        string[] benutzer = { "Sezgin", "Fabian", "Max", "Jan", "", "", "", "", "", "" }; //array für Benutzernamen
        string[] passwoerter = { "111", "222", "333", "444", "", "", "", "", "", "" }; //array für passwörter
        string[] artikelnummern = { "", "", "", "", "", "", "", "", "", "" }; //array für Artikelnummern
        string[] artikelnamen = { "", "", "", "", "", "", "", "", "", "" }; //array für Artikelnamen
        string[] lagerplaetze = { "", "", "", "", "", "", "", "", "", "" }; //array für Lagerplätze
        static int[] bestaende = new int[10]; //array für Bestände



        public Lagerverwaltung(string _neuerBenutzername, string _neuesPasswort, string _eingabeLagerplatz, string _eingabeArtikelnummer)
        {
            neuerBenutzername = _neuerBenutzername;
            neuesPasswort = _neuesPasswort;
            eingabeLagerplatz = _eingabeLagerplatz;
            eingabeArtikelnummer = _eingabeArtikelnummer;
        }


        bool bestandAbbuchen = false;
        public void BestandAbbuchen()
        {
            Console.Clear();
            while (bestandAbbuchen == false)
            {
                Console.WriteLine("Geben Sie bitte die Artikelnummer ein");
                string eingabeArtikelNummerBestandAbbuchen = Console.ReadLine();
                for (int k = 0; k < artikelnummern.Length; k++)
                {

                    if (eingabeArtikelNummerBestandAbbuchen == artikelnummern[k])
                    {
                        bool mengenEingabeSchleife = false;
                        while (mengenEingabeSchleife == false)
                        {
                            Console.WriteLine("Geben Sie bitte die Menge ein, die sie abbuchen möchten");
                            bool eingabe_Menge_Ist_Integer = int.TryParse(Console.ReadLine(), out eingabeMengeBestandAbbuchen);
                            if (eingabe_Menge_Ist_Integer == true)
                            {
                                bestaende[k] = bestaende[k] - eingabeMengeBestandAbbuchen;
                                Console.WriteLine($"Die Menge wurde bei array bestaende auf Index{k} abgebucht.");
                                Console.WriteLine("Menü: Eingabetaste");
                                Console.ReadKey();
                                Menue();
                                menue = true;
                                bestandAbbuchen = true;
                                mengenEingabeSchleife = true;
                            }
                            else if (eingabe_Menge_Ist_Integer != true)
                            {
                                Console.WriteLine("Bitte nur Zahlen eingeben.");
                            }
                        }
                    }
                }
                if (artikelnummern.All(element => !element.Equals(eingabeArtikelNummerBestandAbbuchen)))

                {
                    Console.WriteLine("Artikelnummer ist nicht vorhanden");
                }
            }
        }



        bool bestandZubuchen = false;
        public void BestandZubuchen()
        {
            Console.Clear();
            while (bestandZubuchen == false)
            {
                Console.WriteLine("Geben Sie bitte die Artikelnummer ein");
                string eingabeArtikelNummerBestandZubuchen = Console.ReadLine();
                for (int k = 0; k < artikelnummern.Length; k++)
                {

                    if (eingabeArtikelNummerBestandZubuchen == artikelnummern[k])
                    {
                        bool mengenEingabeSchleife = false;
                        while (mengenEingabeSchleife == false)
                        {
                            Console.WriteLine("Geben Sie bitte die Menge ein, die sie zubuchen möchten");
                            bool eingabe_Menge_Ist_Integer = int.TryParse(Console.ReadLine(), out eingabeMengeBestandZubuchen);
                            if (eingabe_Menge_Ist_Integer == true)
                            {
                                bestaende[k] = bestaende[k] + eingabeMengeBestandZubuchen;
                                Console.WriteLine($"Die Menge wurde bei array bestaende auf Index{k} zugebucht.");
                                Console.WriteLine("Menü: Eingabetaste");
                                Console.ReadKey();
                                Menue();
                                menue = true;
                                bestandZubuchen = true;
                                mengenEingabeSchleife = true;
                            }
                            else if (eingabe_Menge_Ist_Integer != true)
                            {
                                Console.WriteLine("Bitte nur Zahlen eingeben.");
                            }
                        }
                    }
                }
                if (artikelnummern.All(element => !element.Equals(eingabeArtikelNummerBestandZubuchen)))

                {
                    Console.WriteLine("Artikelnummer ist nicht vorhanden");
                }
            }
        }











        bool artikelSuchenSchleife1;
        bool artikelSuchen;
        bool artikelGefunden;
        bool artikelNichtGefunden;
        bool ungültigeEingabe = false;
        bool forSchleifeBeenden = false;

        public void ArtikelSuchen()
        {
            artikelSuchen = false;
            while (artikelSuchen == false)
            {
                artikelSuchenSchleife1 = false;
                while (artikelSuchenSchleife1 == false)
                {

                    Console.Clear();
                    Console.WriteLine("  ___ _   _  ___ _  _ ___ \r\n / __| | | |/ __| || | __|\r\n \\__ \\ |_| | (__| __ | _| \r\n |___/\\___/ \\___|_||_|___|\r\n                          \r\n\r\n");
                    Console.WriteLine("Geben Sie bitte eine Artikelnummer ein");
                    string eingabeArtikelSuche = Console.ReadLine();
                    for (int i = 0; i < artikelnummern.Length; i++)
                        if (eingabeArtikelSuche == artikelnummern[i])
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine($"\n Pos.{i}  | Artikelnummer:      {artikelnummern[i]}\n        | Artikelbezeichnung: {artikelnamen[i]}\n        | Lagerplatz:         {lagerplaetze[i]}\n        | Bestand:            {bestaende[i]}  Stk.");
                            Thread.Sleep(100);
                            Console.Write("--");
                            Console.Write("--");
                            Console.Write("--");
                            Console.Write("--");
                            Console.Write("--");
                            Console.Write("--");
                            Console.Write("--");
                            Console.Write("--");
                            Console.Write("--");
                            Console.Write("--");
                            Console.Write("--");
                            Console.Write("--");
                            Console.Write("--");
                            Console.Write("--");
                            Console.Write("--");
                            Console.Write("--");
                            Console.Write("--");
                            Console.Write("--");
                            Console.Write("--");
                            Console.Write("--");
                            Console.Write("--");
                            Console.Write("--");
                            Console.Write("--\n");
                            Console.ForegroundColor = ConsoleColor.White;
                            artikelGefunden = true;
                            artikelNichtGefunden = false;
                            while (ungültigeEingabe == false)
                            {
                                Console.WriteLine("Möchten Sie einen weiteren Artikel suchen? (j)a / (n)ein");
                                string eingabeWeitereSuche = Console.ReadLine().ToLower();
                                if (eingabeWeitereSuche == "j" || eingabeWeitereSuche == "ja")
                                {
                                    //artikelSuchenSchleife1 = true;
                                    break;

                                }
                                else if (eingabeWeitereSuche == "n" || eingabeWeitereSuche == "nein")
                                {
                                    Menue();
                                    menue = true;
                                    artikelSuchen = true;
                                    artikelSuchenSchleife1 = true;
                                    ungültigeEingabe = true;
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Ungültige Eingabe.");
                                    Thread.Sleep(500);
                                }
                            }
                        }
                        else if (artikelnummern.All(element => !element.Equals(eingabeArtikelSuche)))
                        {
                            artikelGefunden = !true;
                            artikelNichtGefunden = true;
                        }


                    bool schleife6b = false;
                    if (artikelGefunden != true)
                    {
                        Console.WriteLine("Eingegebene Artikelnummer ist nicht vorhanden");
                        while (schleife6b == false)
                        {
                            Console.WriteLine("Möchten Sie einen weiteren Artikel suchen? (j)a / (n)ein");
                            string eingabeWeitereSuche2 = Console.ReadLine().ToLower();
                            if (eingabeWeitereSuche2 == "j" || eingabeWeitereSuche2 == "ja")
                            {
                                break;
                            }
                            else if (eingabeWeitereSuche2 == "n" || eingabeWeitereSuche2 == "nein")
                            {
                                Menue();
                                artikelSuchen = true;
                                menue = true;
                                artikelSuchenSchleife1 = true;
                                login = true;
                                schleife6b = true;
                            }
                            else
                            {
                                Console.WriteLine("Ungültige Eingabe.");
                                Thread.Sleep(500);
                            }

                        }
                    }
                }
            }
        }








        bool neuenBenutzerAnlegen;
        public void NeuenBenutzerAnlegen()
        {
            Console.Clear();
            neuenBenutzerAnlegen = false;
            while (neuenBenutzerAnlegen == false)
            {

                bool schleifeNeuenBenutzerAnlegen1 = false;
                Console.WriteLine("Legen Sie bitte den Benutzernamen fest.");
                Console.Write("Benutzername: ");
                neuerBenutzername = Console.ReadLine();
                for (int m = 0; m < benutzer.Length; m++)
                    if (neuerBenutzername == benutzer[m])
                    {
                        Console.WriteLine("Der eingegebene Benutzername ist bereits vorhanden.");
                        Thread.Sleep(2000);
                        NeuenBenutzerAnlegen();
                        neuenArtikelAnlegen = true;
                    }
                while (schleifeNeuenBenutzerAnlegen1 == false)
                {
                    Console.WriteLine("Legen Sie bitte das Passwort fest.");
                    Console.Write("Passwort: ");
                    string neuesPasswort1 = Console.ReadLine();
                    Console.WriteLine("Bitte bestätigen Sie das Passwort");
                    Console.Write("Passwort: ");
                    string neuesPasswort2 = Console.ReadLine();

                    if (neuesPasswort1 != neuesPasswort2)
                    {
                        Console.WriteLine("Ihre Eingabe stimmt mit der vorherigen Eingabe nicht überein."); //schleife startet neu
                    }
                    else if (neuesPasswort1 == neuesPasswort2)
                    {
                        neuesPasswort = neuesPasswort2;
                        schleifeNeuenBenutzerAnlegen1 = true; //beendet die Schleife, wenn die zweite Passworteingabe mit der vorherigen übereinstimmt
                    }
                    else
                    {
                        Console.WriteLine("Fehler");
                    }
                }
                int i = 0;
                bool schleife1 = false;
                //try //hier wird vorerst geprüft, ob array benutzer freie felder hat. Angelegt wird der Benutzername allerdings erst in der nächsten Schleife.
                //{
                while (i < benutzer.Length - 1 && schleife1 == false)
                {
                    i++;
                    if (benutzer[i].Length >= 1 && benutzer[i + 1].Length < 1) //wenn aktuelles Arrayfeld größer oder gleich 1 ist UND das nächste Arrayfeld leer ist, wird der Benutzer bei letzterem abgespeichert.  
                    {
                        //Console.WriteLine($"Das Benutzerkonto mit dem Namen {neuerBenutzername} wurde angelegt.");
                        schleife1 = true;
                    }
                    else if (benutzer[i].Length < 1)
                    {
                        //Console.WriteLine($"Das Benutzerkonto mit dem Namen {neuerBenutzername} wurde angelegt.");
                        schleife1 = true;
                    }
                    else
                    {
                        // Console.WriteLine("Das Benutzerkonto konnte nicht angelegt werden. Der Speicherplatz ist voll"); ist auskommentiert, damit es nicht mehrmals in der Konsole erscheint.
                        // i++ führt dazu, dass bei jedem Schleifendurchlauf das nächste Arrayfeld angesteuert wird, wenn array mit eckigen Klammern und dem i darin verwendet wird
                    }
                }
                //} catch {/*Console.WriteLine("Das Benutzerkonto konnte nicht angelegt werden. Der Speicherplatz ist voll");*/ } //durch try catch wird ein programmabsturtz verhindert und es wird die Meldung ausgegeben, dass alle Arrayfelder voll sind.


                int j = 0;
                bool schleife2 = false;
                bool konnteAngelegtWerden1 = false;
                bool konnteAngelegtWerden2 = false;
                //try //Da mit dieser Prüfung ersichtlich wird, ob beide arrays freie Felder haben, wird hier sowohl der Name als auch das Passwort angelegt.
                //{
                while (j < passwoerter.Length - 1 && schleife2 == false)
                {
                    j++;
                    if (passwoerter[j].Length >= 1 && passwoerter[j + 1].Length < 1) //wenn aktuelles Arrayfeld größer oder gleich 1 ist UND das nächste Arrayfeld leer ist, wird der Benutzer bei letzterem abgespeichert.  
                    {
                        passwoerter[j + 1] = neuesPasswort;
                        benutzer[i + 1] = neuerBenutzername;
                        Console.WriteLine($"Das Benutzerkonto mit dem Namen {neuerBenutzername} wurde angelegt.\n");
                        schleife2 = true;
                        menue = true;
                        konnteAngelegtWerden1 = true;
                        Login();
                    }
                    else if (passwoerter[j].Length < 1)
                    {
                        passwoerter[j] = neuesPasswort;
                        benutzer[i] = neuerBenutzername;
                        Console.WriteLine($"Das Benutzerkonto mit dem Namen {neuerBenutzername} wurde angelegt.\n");
                        schleife2 = true;
                        menue = true;
                        konnteAngelegtWerden2 = true;
                        Login();
                    }
                    else
                    {
                        //Console.WriteLine("Ihr Benutzerkonto konnte nicht angelegt werden. Der Speicherplatz ist voll");
                        konnteAngelegtWerden1 = false;
                        konnteAngelegtWerden2 = false;
                    }
                }
                if (konnteAngelegtWerden1 != true && konnteAngelegtWerden2 != true)
                {
                    Console.WriteLine("Das Benutzerkonto konnte nicht angelegt werden. Der Speicherplatz ist voll");
                    Console.Write("Menü: Eingabetaste");
                    Console.ReadKey();
                    Menue();
                }

                //}
                //catch (IndexOutOfRangeException)
                //    { Console.WriteLine("Das Benutzerkonto konnte nicht angelegt werden. Der Speicherplatz ist voll"); } //durch try catch wird ein programmabsturtz verhindert und es wird die Meldung ausgegeben, dass alle Arrayfelder voll sind.
            }
        }


        bool listeBenutzerUndPasswörter;
        public void ListeBenutzerUndPasswörter()
        {
            Console.Clear();
            listeBenutzerUndPasswörter = false;
            while (listeBenutzerUndPasswörter == false)
            {

                for (int i = 0; i < benutzer.Length; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"\n Pos.{i}  | Benutzername: {benutzer[i]}\n        | Passwort:     {passwoerter[i]}");
                    Console.Write("--");
                    //Thread.Sleep(1);
                    Console.Write("--");
                    Thread.Sleep(1);
                    Console.Write("--");
                    //Thread.Sleep(1);
                    Console.Write("--");
                    Thread.Sleep(1);
                    Console.Write("--");
                    //Thread.Sleep(1);
                    Console.Write("--");
                    Thread.Sleep(1);
                    Console.Write("--");
                    //Thread.Sleep(1);
                    Console.Write("--");
                    Thread.Sleep(1);
                    Console.Write("--");
                    //Thread.Sleep(1);
                    Console.Write("--");
                    Thread.Sleep(1);
                    Console.Write("--");
                    //Thread.Sleep(1);
                    Console.Write("--");
                    Thread.Sleep(1);
                    Console.Write("--");
                    //Thread.Sleep(1);
                    Console.Write("--");
                    Thread.Sleep(1);
                    Console.Write("--");
                    //Thread.Sleep(1);
                    Console.Write("--");
                    Thread.Sleep(1);
                    Console.Write("--");
                    //Thread.Sleep(1);
                    Console.Write("--");
                    Thread.Sleep(1);
                    Console.Write("--");
                    //Thread.Sleep(1);
                    Console.Write("--");
                    Thread.Sleep(1);
                    Console.Write("--");
                    //Thread.Sleep(1);
                    Console.Write("--");
                    Thread.Sleep(1);
                    Console.Write("--\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine("Menü: Eingabetaste");
                Console.ReadKey();
                menue = true;
                Menue();
                listeBenutzerUndPasswörter = true;
            }
        }

        bool listeArtikelLagerplatzBestand = false;
        public void ListeArtikelLagerplatzBestand()
        {
            Console.Clear();
            while (listeArtikelLagerplatzBestand == false)
            {

                for (int i = 0; i < artikelnummern.Length; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"\n Pos.{i}  | Artikelnummer:      {artikelnummern[i]}\n        | Artikelbezeichnung: {artikelnamen[i]}\n        | Lagerplatz:         {lagerplaetze[i]}\n        | Bestand:            {bestaende[i]}  Stk.");
                    Thread.Sleep(500);
                    Console.Write("--");
                    //Thread.Sleep(1);
                    Console.Write("--");
                    //Thread.Sleep(1);
                    Console.Write("--");
                    //Thread.Sleep(1);
                    Console.Write("--");
                    //Thread.Sleep(1);
                    Console.Write("--");
                    //Thread.Sleep(1);
                    Console.Write("--");
                    //Thread.Sleep(1);
                    Console.Write("--");
                    //Thread.Sleep(1);
                    Console.Write("--");
                    //Thread.Sleep(1);
                    Console.Write("--");
                    //Thread.Sleep(1);
                    Console.Write("--");
                    //Thread.Sleep(1);
                    Console.Write("--");
                    //Thread.Sleep(1);
                    Console.Write("--");
                    //Thread.Sleep(1);
                    Console.Write("--");
                    //Thread.Sleep(1);
                    Console.Write("--");
                    //Thread.Sleep(1);
                    Console.Write("--");
                    //Thread.Sleep(1);
                    Console.Write("--");
                    //Thread.Sleep(1);
                    Console.Write("--");
                    //Thread.Sleep(1);
                    Console.Write("--");
                    //Thread.Sleep(1);
                    Console.Write("--");
                    //Thread.Sleep(1);
                    Console.Write("--");
                    //Thread.Sleep(1);
                    Console.Write("--");
                    //Thread.Sleep(1);
                    Console.Write("--");
                    //Thread.Sleep(1);
                    Console.Write("--\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine(" Menü: Eingabetaste");
                Console.ReadKey();
                menue = true;
                Menue();
                listeArtikelLagerplatzBestand = true;
            }
        }


        bool menue;
        public void Menue()
        {
            Console.Clear();
            menue = false;
            while (menue == false)
            {
                Console.WriteLine("   _____  _____                        \r\n  / ____|/ ____|   /\\    \r\n | (___ | |       /  \\   \r\n  \\___ \\| |      / /\\ \\  \r\n  ____) | |____ / ____ \\ \r\n |_____/ \\_____/_/    \\_\\\r\n                         \r\n                         \r\n\r");
                //Console.WriteLine(" _ __ ___   ___ _ __  _   _ \r\n| '_ ` _ \\ / _ \\ '_ \\| | | |\r\n| | | | | |  __/ | | | |_| |\r\n|_| |_| |_|\\___|_| |_|\\__,_|\n");
                Console.WriteLine(" [1]Artikel | Lagerplatz | Bestand (Gesamtübersicht)\n [2]Artikel suchen\n [3]Neuen Artikel anlegen\n [4]Bestand zubuchen\n [5]Bestand abbuchen\n [6]Neuen Benutzer anlegen\n [7]Registrierte Benutzer | Passwörter \n [8]Beenden");
                //try
                //{

                string eingabe1 = Console.ReadLine();
                if (eingabe1 == "1")
                {
                    menue = true;
                    ListeArtikelLagerplatzBestand();
                }

                else if (eingabe1 == "2")
                {
                    menue = true;
                    ArtikelSuchen();
                }


                else if (eingabe1 == "3")
                {
                    menue = true;
                    NeuenArtikelAnlegen();
                }

                else if (eingabe1 == "4")
                {
                    menue = true;
                    BestandZubuchen();
                }

                else if (eingabe1 == "5")
                {
                    menue = true;
                    BestandAbbuchen();
                }


                else if (eingabe1 == "6")
                {
                    menue = true;
                    NeuenBenutzerAnlegen();
                }

                else if (eingabe1 == "7")
                {
                    menue = true;
                    ListeBenutzerUndPasswörter();
                }

                else if (eingabe1 == "8")
                {
                    menue = true;
                    login = true;
                    listeBenutzerUndPasswörter = true;
                    neuenBenutzerAnlegen = true;
                    artikelSuchen = true;
                    listeArtikelLagerplatzBestand = true;
                    neuenArtikelAnlegen = true;
                    bestandZubuchen = true;
                    bestandAbbuchen = true;
                }

                else
                {
                    Console.WriteLine("\nUngültige Eingabe!");
                    Thread.Sleep(800);
                    Console.Clear();
                }
                //}
                //catch { Console.WriteLine("Ungültige Eingabe!"); }
            }

        }

        bool login = false;
        public void Login()
        {
            while (login == false)
            {
                Console.Clear();
                Console.WriteLine("  _    ___   ___ ___ _  _ \r\n | |  / _ \\ / __|_ _| \\| |\r\n | |_| (_) | (_ || || .` |\r\n |____\\___/ \\___|___|_|\\_|\r\n                          \r\n\r");
                Console.WriteLine("Bitte Benutzername und Passwort eingeben.");
                Console.Write("Benutzername: ");
                string eingabeBenutzername = Console.ReadLine();
                Console.Write("Passwort: ");
                string eingabePasswort = Console.ReadLine();

                for (int i = 0; i < benutzer.Length; i++)
                {

                    if (eingabeBenutzername == benutzer[i] && eingabePasswort == passwoerter[i])
                    {
                        Console.WriteLine($"Sie sind nun eingeloggt.");
                        Thread.Sleep(1000);
                        Menue();
                        login = true;
                    }
                }
                if (login == false)
                {
                    Console.WriteLine("Falsche Anmeldedaten");
                    Thread.Sleep(1000);
                }
            }
        }
        bool falschesformat = false;
        bool speichervoll = false;
        bool lagerplatzbereitsvorhanden = false;
        bool lagerplatzspeichervoll = false;
        bool neuenArtikelAnlegen = false;
        public void NeuenArtikelAnlegen()
        {
            Console.Clear();
            while (neuenArtikelAnlegen == false)
            {
                Console.WriteLine("Geben Sie bitte eine neue Artikelnummer ein.");
                eingabeArtikelnummer = Console.ReadLine();

                for (u = 0; u < artikelnummern.Length - 1; u++)
                    if (artikelnummern[u].Length >= 1 && artikelnummern[u + 1].Length < 1 /*&& pfrei1 == true || pfrei2 == true*/)
                    {
                        //artikelnummern[i + 1] = eingabeArtikelnummer; fertig
                        ifrei1 = true;
                        break;
                    }
                    else if (artikelnummern[u].Length < 1 /*&& pfrei1 == true || pfrei2 == true*/)
                    {
                        //artikelnummern[i] = eingabeArtikelnummer; fertig
                        ifrei2 = true;
                        break;
                    }
                    else
                    {
                        ifrei1 = false;
                        ifrei2 = false;
                    }





                if (ifrei1 == true || ifrei2 == true)
                {

                    Console.WriteLine("Geben Sie bitte einen Artikelnamen ein.");
                    eingabeArtikelname = Console.ReadLine();
                    for (j = 0; j < artikelnamen.Length - 1; j++)
                        if (artikelnamen[j].Length >= 1 && artikelnamen[j + 1].Length < 1 /*&& pfrei1 == true || pfrei2 == true*/)
                        {
                            //artikelnamen[j + 1] = eingabeArtikelname; fertig
                            jfrei1 = true;
                            break;
                        }
                        else if (artikelnamen[j].Length < 1 /*&& pfrei1 == true || pfrei2 == true*/)
                        {
                            //artikelnamen[j] = eingabeArtikelname; fertig
                            jfrei2 = true;
                            break;
                        }
                        else
                        {
                            jfrei1 = false;
                            jfrei2 = false;
                        }
                }
                else if (ifrei1 != true && ifrei2 != true)
                {
                    Console.WriteLine("Der Artikel kann nicht angelegt werden. Der Speicherplatz (artikelnummern) ist voll.");
                    Console.WriteLine("Menü: Eingabetaste");
                    Console.ReadKey();
                    Menue();
                    neuenArtikelAnlegen = true;
                }






                bool schleife1 = false;
                while (schleife1 == false)
                {

                    if (jfrei1 == true || jfrei2 == true)
                    {
                        Console.WriteLine("Geben Sie bitte einen Lagerplatz ein.");
                        eingabeLagerplatz = Console.ReadLine();
                        for (e = 0; e < lagerplaetze.Length - 1; e++)
                            if (lagerplaetze[e].Length >= 1 && lagerplaetze[e + 1].Length < 1 /*&& pfrei1 == true || pfrei2 == true*/)
                            {
                                //lagerplaetze[e + 1] = eingabeLagerplatz; fertig
                                hfrei1 = true;
                                schleife1 = true;
                                break;

                            }
                            else if (lagerplaetze[e].Length < 1 /*&& pfrei1 == true || pfrei2 == true*/)
                            {
                                //lagerplaetze[e] = eingabeLagerplatz; fertig
                                hfrei2 = true;
                                schleife1 = true;
                                break;
                            }
                            else
                            {
                                schleife1 = true;
                                hfrei1 = false;
                                hfrei2 = false;
                            }
                    }
                    else if (jfrei1 != true && jfrei2 != true)
                    {
                        Console.WriteLine("Der Artikel kann nicht angelegt werden. Der Speicherplatz (artikelnamen) ist voll.");
                        Console.WriteLine("Menü: Eingabetaste");
                        Console.ReadKey();
                        Menue();
                        neuenArtikelAnlegen = true;
                        schleife1 = true;
                    }







                    if (hfrei1 == true || hfrei2 == true)
                    {
                        for (v = 0; v < lagerplaetze.Length; v++) //überprüft, ob der lagerplatz bereits vorhanden ist
                            if (lagerplaetze[v] == eingabeLagerplatz && lagerplaetze[v].Length >= 1 /*&& lagerplaetze[v + 1] != eingabeLagerplatz*/)
                            {
                                // lagerplaetze[v +1] = eingabeLagerplatz;
                                Console.WriteLine($"Lagerplatz {eingabeLagerplatz} ist auf Index {v} bereits vorhanden.");
                                lagerplatzbereitsvorhanden = true;
                                schleife1 = false;

                            }
                            else if (lagerplaetze[v] != eingabeLagerplatz)

                            {
                                lagerplatzbereitsvorhanden = false;
                                // lagerplaetze[v] = eingabeLagerplatz;
                                //Console.WriteLine($"nicht vorhanden {v}");
                            }
                    }
                }







                if (hfrei1 != true && hfrei2 != true)
                {                                       //Wird ausgeführt, wenn array lagerplaetze voll ist
                    lagerplatzspeichervoll = true;
                    Console.WriteLine("Der Artikel kann nicht angelegt werden. Der Speicherplatz (lagerplaetze) ist voll.");
                    Console.WriteLine("Menü: Eingabetaste");
                    Console.ReadKey();
                    Menue();
                    neuenArtikelAnlegen = true;
                }





                bool integer = false;
                if (lagerplatzspeichervoll != true && lagerplatzbereitsvorhanden != true)
                {
                    while (integer == false)
                    {
                        Console.WriteLine("Geben Sie bitte die Menge ein. Falls noch kein Bestand vorhanden ist, können Sie keinen Artikel anlegen");
                        bool eingabe_ist_Integer = Int32.TryParse(Console.ReadLine(), out eingabeMengeBestand);
                        if (!eingabe_ist_Integer)
                        {
                            Console.WriteLine("Bitte nur Zahlen eingeben.");
                            integer = false;
                        }
                        else if (eingabe_ist_Integer)
                        {
                            integer = true;
                        }
                    }
                    for (i = 0; i < bestaende.Length - 1; i++)
                    {
                        if (bestaende[i] >= 1 && bestaende[i + 1] < 1 /*&& pfrei1 == true || pfrei2 == true*/)
                        {
                            bestaende[i + 1] = eingabeMengeBestand;
                            lagerplaetze[e + 1] = eingabeLagerplatz;
                            artikelnamen[j + 1] = eingabeArtikelname;
                            artikelnummern[i + 1] = eingabeArtikelnummer;
                            pfrei1 = true;
                            break;
                        }
                        else if (bestaende[i] < 1 /*&& pfrei1 == true || pfrei2 == true */)
                        {
                            lagerplaetze[e] = eingabeLagerplatz;
                            bestaende[i] = eingabeMengeBestand;
                            artikelnamen[j] = eingabeArtikelname;
                            artikelnummern[i] = eingabeArtikelnummer;
                            pfrei2 = true;
                            break;
                        }
                        else
                        {
                            pfrei1 = false;
                            pfrei2 = false;
                        }
                    }


                }



                if (pfrei1 == true || pfrei2 == true)
                {

                    Console.WriteLine("Der Artikel wurde angelegt.");
                    Console.WriteLine("Menü: Eingabetaste");
                    Console.ReadKey();
                    Menue();
                    neuenArtikelAnlegen = true;
                }

                if (pfrei1 != true && pfrei2 != true)
                {
                    speichervoll = true;
                    lagerplatzspeichervoll = true;
                    Console.WriteLine("Der Artikel kann nicht angelegt werden. Der Speicherplatz (bestaende) ist voll.");
                    Console.WriteLine("Menü: Eingabetaste");
                    Console.ReadKey();
                    Menue();
                    neuenArtikelAnlegen = true;

                }
            }
        }
    }
}
