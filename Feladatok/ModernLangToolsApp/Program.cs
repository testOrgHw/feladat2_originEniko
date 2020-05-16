using System;
using System.ComponentModel;
using System.IO;
using System.Xml.Serialization;

namespace ModernLangToolsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Feladat_2();
            Feladat_3();
            Feladat_4();


        

        Console.ReadKey();
            
        } ///MAIN VÉGE


        [Description("Feladat2")]
        public static void Feladat_2()
        {
            //egy Jedi objektum létrehozása, értékadás
            Jedi j = new Jedi();
            j.Name = "Anya";
            j.MidiChlorianCount = 15;

            //kiírás txt-be
            XmlSerializer serializer = new XmlSerializer(typeof(Jedi));
            FileStream stream = new FileStream("jedi.txt", FileMode.Create);
            serializer.Serialize(stream, j);
            stream.Close();

            //visszaolvasás az előbb létrehozott txt-ből. Klónozza az eddig meglévő j nevű Jedi objektumot.
            XmlSerializer ser = new XmlSerializer(typeof(Jedi));
            FileStream fs = new FileStream("jedi.txt", FileMode.Open);
            Jedi clone = (Jedi)ser.Deserialize(fs);
            fs.Close();
        }

        [Description("Feladat3")]
        public static void Feladat_3()
        {
            // Tanács létrehozása
            JediCouncil council = new JediCouncil();
            council.CouncilChanged += MessageReceived;

            //Jedi tanács feltöltése 2 jedivel
            Jedi jedi1 = new Jedi();
            jedi1.Name = "Jedi 1";
            jedi1.MidiChlorianCount = 5000;
            council.Add(jedi1);
            Jedi jedi2 = new Jedi();
            jedi2.Name = "Jedi 2";
            jedi2.MidiChlorianCount = 10000;
            council.Add(jedi2);

            //Tagok törlése
            council.Remove();
            council.Remove();
        }

        [Description("Feladat4")]
        public static void Feladat_4()
        {
            // Tanács létrehozása
            JediCouncil council = new JediCouncil();
            council.CouncilChanged += MessageReceived;

            //Kezdő jedik létrehozása és a tanácshoz adása
            Jedi beginner1 = new Jedi();
            beginner1.Name = "Kezdő Jedi 1";
            beginner1.MidiChlorianCount = 100;
            council.Add(beginner1);
            Jedi beginner2 = new Jedi();
            beginner2.Name = "Kezdő Jedi 2";
            beginner2.MidiChlorianCount = 200;
            council.Add(beginner2);

            //Kezdő jedik kikeresése és tulajdonságaik kiírása
            foreach (Jedi i in council.GetBeginners())
            {
                Console.WriteLine("{0}", i.Name);
            }
        }

        static void MessageReceived(string message)
        {
            Console.WriteLine(message);
        }
    }

}
