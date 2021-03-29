using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Werknemer
    {
        public string Naam { get; set; }
        //public double Salaris { get; set; }
        public Salaris Salaris { get; set; }
        public string LandVanHerkomst { get; set; }
        public Werknemer(string naam, double salaris, string land, ContractType contractType)
        {
            Naam = naam;
            Salaris = new Salaris(contractType, salaris);
            LandVanHerkomst = land;
        }
        public Werknemer(string naam, double salaris, string land)
        {
            Naam = naam;
            Salaris = new Salaris(salaris);
            LandVanHerkomst = land;
        }
        public Werknemer(string naam)
        {
            Naam = naam;
            Salaris = new Salaris(2440.55);
            LandVanHerkomst = "België";
        }
        public Werknemer()
        {

        }
    }
    public enum ContractType
    {
        Weekcontract,
        Maandcontract
    }
    public class Salaris
    {
        public ContractType TypeContract { get; set; }
        public double BrutoBedrag { get; set; }
        public double BTWprocent { get; set; }

        public Salaris(ContractType typeContract, double brutoBedrag, double bTWprocent)
        {
            TypeContract = typeContract;
            BrutoBedrag = brutoBedrag;
            BTWprocent = bTWprocent;
        }
        public Salaris(ContractType typeContract, double brutoBedrag)
        {
            TypeContract = typeContract;
            BrutoBedrag = brutoBedrag;
            BTWprocent = 21;
        }

        public Salaris(double bruto)
        {
            BrutoBedrag = bruto;
            BTWprocent = 21;
            TypeContract = ContractType.Maandcontract;
        }
        public double BerekenNetto()
        {
            return BrutoBedrag * (1 - BTWprocent / 100);
        }
        public override string ToString()
        {
            return string.Format("Netto bedrag: {0,5:0.0} ({1,5:0.0})", BerekenNetto(), BrutoBedrag);
        }
    }
    public class Bedrijf
    {
        public string Naam { get; set; }
        public List<Werknemer> werknemers { get; set; }
        public string BTWnummer { get; set; }
        public Bedrijf(string naam, List<Werknemer> werknemers, string bTWnummer)
        {
            Naam = naam;
            this.werknemers = werknemers;
            BTWnummer = bTWnummer;
        }

        public Bedrijf(string naam, string bTWnummer)
        {
            Naam = naam;
            BTWnummer = bTWnummer;
        }
        public Bedrijf()
        {

        }
        public void WerknemerToevoegen(Werknemer werknemer)
        {
            if (werknemers == null) werknemers = new List<Werknemer>();
            werknemers.Add(werknemer);
        }
        public void WerknemerVerwijderen(Werknemer werknemer)
        {
            int iTeVerwijderen = werknemers.IndexOf(werknemer);
            if (iTeVerwijderen != -1) werknemers.RemoveAt(iTeVerwijderen);
        }
    }

}
