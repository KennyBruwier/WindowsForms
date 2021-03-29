using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class User : Gemeenten
    {
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public bool Man { get; set; }
        public byte Leeftijd { get; set; }
        public User(string voornaam, string achternaam, bool man, byte leeftijd, string gemeente,string postcode, string land,string straat,int straatNr) : base (gemeente,postcode,land,straat,straatNr)
        {
            Voornaam = voornaam;
            Achternaam = achternaam;
            Man = man;
            Leeftijd = leeftijd;
            Gemeente = gemeente;
            Postcode = postcode;
            StraatNaam = straat;
        }
        public User(string voornaam, string achternaam)
        {

        }
        public User()
        {

        }
    }
    class Straat
    {
        public string StraatNaam { get; set; }
        public int StraatNr  { get; set; }
        public Straat(string straat, int straatNr)
        {
            StraatNaam = straat;
            StraatNr = straatNr;
        }
        public Straat()
        {

        }
    }
    class Gemeenten: Straat
    {
        public string Postcode { get; set; }
        public string Gemeente { get; set; }
        public string Land { get; set; }

        public Gemeenten(string gemeente, string postcode, string land, string straat, int straatNr) : base (straat, straatNr)
        {
            Postcode = postcode;
            Gemeente = gemeente;
            Land = land;
        }
        public Gemeenten() 
        {

        }
    }
}
