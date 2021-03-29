using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        List<string> mijnLijst = new List<string>();
        List<string> mijnFilterLijst = new List<string>();
        List<Werknemer> werknemers = new List<Werknemer>();
        string[] opvulling = { "An", "Bart", "Cedric", "Dieter", "Evert", "Filip", "Gert", "Henk" };
        string[] voornamen = { "Kenny", "Tom", "Tim", "Arno", "Ken", "Nick", "Vincent", "Gewein","Claire","Katia" };
        string[] achternamen = { "Bruwier", "Dilen", "GeenIdee", "Field", "Janssens", "Verbist" };
        string[] straatnamen = { "Azalealei", "Weimanstraat", "Paleisstraat", "Bredabaan", "Schipperstraat" };
        User randomUser = new User();
        List<User> users = new List<User>();
        List<Bedrijf> bedrijven = new List<Bedrijf>();
        
        

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Hellow world");
            //txt.Text = "Hellow world";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }




        private void button1_Click_1(object sender, EventArgs e)
        {
            if (tbToevoegen.Text != null)
            {
                if (mijnLijst == null)
                    mijnLijst = new List<string>();
                mijnLijst.Add(tbToevoegen.Text);
                tbToevoegen.Text = null;
            }
            lbLijst.Items.Clear();
            foreach (string text in mijnLijst)
            {
                lbLijst.Items.Add(text);
            }
            tbToevoegen.Focus();
                
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnGevuld_Click(object sender, EventArgs e)
        {
            if (cbGevuld.Text.Length == 0)
                MessageBox.Show("Geen waarde gevonden");
            else
                MessageBox.Show(cbGevuld.Text.ToString());
            cbGevuld.Text = null;
        }

        private void btFilter_Click(object sender, EventArgs e)
        {
            lbLijst2.Items.Clear();
            foreach (string tekst in mijnFilterLijst)
            {
                if (tekst.Contains(tbToFilter.Text.ToString())) lbLijst2.Items.Add(tekst);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            byte iAantalBedrijven = 3;
            Bedrijf[] bedrijf = new Bedrijf[iAantalBedrijven];
            bedrijf[0] = new Bedrijf();
            bedrijf[0].Naam = "AB InBev";
            bedrijf[0].BTWnummer = "5465445665445";
            bedrijf[1] = new Bedrijf();
            bedrijf[1].Naam = "Heineken";
            bedrijf[1].BTWnummer = "9879876546487";
            bedrijf[2] = new Bedrijf();
            bedrijf[2].Naam = "Moortgat";
            bedrijf[2].BTWnummer = "8977897894454";
            //int temp = bedrijf.GetLength(1);
            int temp2 = bedrijf.GetLength(0);
            byte aantalWerkenemers = 0;
            int iBedrijf = 0;
            //tabCOefeningen.TabPages.
            mijnFilterLijst.AddRange(opvulling);
            users.Add(new User("Kenny", "Bruwier",true,39,"Rupelmonde","9150","Belgie","Nieuwstraat",57));
            users.Add(new User("Sven", "Allangweg",true,24,"Bredabaan","2180","Belgie","Merksem",20));
            users.Add(new User("Tom", "Dilen",true,42,"Deurne","2100","Belgie", "Jozefstraat",15));
            users.Add(new User("Ken", "Field",true,24,"Dendermonde","8000","Belgie","Stationstraat",10));
            users.Add(new User("Bart", "Juistweg",true,29,"Antwerpen","2100","Belgie","Kamenstraat",20));
            users.Add(new User("Clair", "Geenidee", false, 24,"Schoten","2011","Belgie","St jozefstraat",10));
            werknemers.Add(new Werknemer("Geert", 2440.55, "België", ContractType.Weekcontract));
            werknemers.Add(new Werknemer("Frank", 2200.00, "België"));
            werknemers.Add(new Werknemer("Daniel", 2440.55, "Nederland",ContractType.Weekcontract));
            werknemers.Add(new Werknemer("Sofia", 3110.00, "Nederland"));
            werknemers.Add(new Werknemer("Bart", 2600.55, "België", ContractType.Maandcontract));
            werknemers.Add(new Werknemer("Jef", 2500.00, "België"));
            werknemers.Add(new Werknemer("Katrien", 4110.00, "Nederland"));
            werknemers.Add(new Werknemer("Els", 2200.55, "België", ContractType.Maandcontract));
            werknemers.Add(new Werknemer("Nathalie", 2700.00, "Nederland", ContractType.Weekcontract));
            foreach (Werknemer werknemer in werknemers)
            {
                if (aantalWerkenemers == 3)
                {
                    aantalWerkenemers = 0;
                    if (iBedrijf < bedrijf.GetLength(0)-1) iBedrijf++;
                }
                cbNaamWerknemer.Items.Add(werknemer.Naam);
                if (bedrijf[iBedrijf].werknemers == null) bedrijf[iBedrijf].werknemers = new List<Werknemer>();
                bedrijf[iBedrijf].werknemers.Add(werknemer);
                aantalWerkenemers++;
            }
            foreach (User user in users)
            {
                cbVoornamen.Items.Add(user.Voornaam);
                cbVnaam.Items.Add(user.Voornaam);
            }
            //cbVoornamen.Text = cbVoornamen.Items[0].ToString();
            cbVnaam.Text = cbVnaam.Items[0].ToString();
            randomUser = users[rnd.Next(users.Count - 1)];
            if (tbNaam.Text == "")
            {
                tbNaam.Text = randomUser.Achternaam;
                tbVoornaam.Text = randomUser.Voornaam;
                numLeeftijd.Value = randomUser.Leeftijd;
                tbStr.Text = randomUser.StraatNaam;
                tbGemeente.Text = randomUser.Gemeente;
                tbNr.Text = randomUser.StraatNr.ToString();
                tbPostcode.Text = randomUser.Postcode;
                rbMan.Checked = randomUser.Man;
                rbVr.Checked = !randomUser.Man;
            }
            foreach (string tekst in opvulling)
            {
                lbLijst2.Items.Add(tekst);
            }
            tbAdd.Text = opvulling[0];

            bedrijven = new List<Bedrijf>();
            for (int i = 0; i < bedrijf.GetLength(0); i++)
            {
                bedrijven.Add(bedrijf[i]);
                cbBedrijf.Items.Add(bedrijf[i].Naam);
            }
        }

        private void lbLijst2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbVoornamen_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show(users[cbVoornamen.SelectedIndex].Achternaam);
        }

        private void cbVoornamen_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            if (tbAdd.Text != null)
                lbLinks.Items.Add(tbAdd.Text);
            tbAdd.Text = null;
            tbAdd.Text = opvulling[rnd.Next(opvulling.GetLength(0) - 1)];
        }

        private void btRechts_Click(object sender, EventArgs e)
        {

            if (lbLinks.Text != "")
            {
                lbRechts.Items.Add(lbLinks.SelectedItem.ToString());
                lbLinks.Items.Remove(lbLinks.SelectedItem.ToString());
            }
        }

        private void btLinks_Click(object sender, EventArgs e)
        {
            if (lbRechts.Text != "")
            {
                lbLinks.Items.Add(lbRechts.SelectedItem);
                lbRechts.Items.Remove(lbRechts.SelectedItem);
            }
        }

        private void tbAdd_VisibleChanged(object sender, EventArgs e)
        {
            if (tbAdd.Text == "") tbAdd.Text = opvulling[rnd.Next(opvulling.GetLength(0) - 1)];
        }

        private void tbToFilter_MouseHover(object sender, EventArgs e)
        {
            if (tbToFilter.Text.ToLower() == "filteren op?") tbToFilter.Text = "";
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void tbIndienen_Click(object sender, EventArgs e)
        {
            MessageBox.Show(    $"{(rbMan.Checked?"De heer":"Mevr.")} {tbVoornaam.Text} {tbNaam.Text} is {numLeeftijd.Value} jaar oud en " +
                                $"woont in {tbPostcode.Text} {tbGemeente.Text} {tbStr.Text} {tbNr.Text}");

            randomUser = users[rnd.Next(users.Count)];
            tbNaam.Text = randomUser.Achternaam;
            tbVoornaam.Text = randomUser.Voornaam;
            numLeeftijd.Value = randomUser.Leeftijd;
            tbStr.Text = randomUser.StraatNaam;
            tbGemeente.Text = randomUser.Gemeente;
            tbNr.Text = randomUser.StraatNr.ToString();
            tbPostcode.Text = randomUser.Postcode;
            rbMan.Checked = randomUser.Man;
            rbVr.Checked = !randomUser.Man;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            MessageBox.Show(dateTimePicker1.Value.ToString("dddd dd, MMM yyyy - H:mm:ss"));
        }

        private void tbToFilter_TextChanged(object sender, EventArgs e)
        {
            lbLijst2.Items.Clear();
            foreach (string tekst in mijnFilterLijst)
            {
                if (tekst.Contains(tbToFilter.Text.ToString())) lbLijst2.Items.Add(tekst);
            }
        }

        private void cbVnaam_SelectedIndexChanged(object sender, EventArgs e)
        {
            User userToChange = new User();
            if (cbVnaam.Text.Length > 0)
            {
                userToChange = users.Find(item => item.Voornaam == cbVnaam.Text);
            }
            if (userToChange != null)
            {
                tbVnaam.Text = userToChange.Voornaam;
                tbANaam.Text = userToChange.Achternaam;
            }
        }

        private void btnBewaar_Click(object sender, EventArgs e)
        {
            int iUsers;
            if (cbVnaam.Text.Length > 0)
            {
                iUsers = users.FindIndex(item => item.Voornaam == cbVnaam.Text);
                if (iUsers != -1)
                {
                    users[iUsers].Voornaam = tbVnaam.Text;
                    users[iUsers].Achternaam = tbANaam.Text;
                    cbVoornamen.Items.Clear();
                    cbVnaam.Items.Clear();
                    foreach (User user in users)
                    {
                        cbVoornamen.Items.Add(user.Voornaam);
                        cbVnaam.Items.Add(user.Voornaam);
                    }
                }
            }
            
        }

        private void cbNaamWerknemer_SelectedIndexChanged(object sender, EventArgs e)
        {
            Werknemer gevondenWerknemer = new Werknemer();
            int iWerknemer = -1;
            int iBedrijf = -1;
            foreach (Bedrijf bedrijf in bedrijven)
            {
                iWerknemer = bedrijf.werknemers.FindIndex(item => item.Naam == cbNaamWerknemer.Text);
                if (iWerknemer != -1)
                {
                    iBedrijf = bedrijven.IndexOf(bedrijf);
                    break;
                }
            }
            //int iWerknemer = bedrijven[iBedrijf].werknemers.FindIndex(item => item.Naam == cbNaamWerknemer.Text);

            //int iWerknemer = werknemers.FindIndex(item => item.Naam == cbNaamWerknemer.Text);
            if (iWerknemer != -1)
            {
                tbSalaris.Text = bedrijven[iBedrijf].werknemers[iWerknemer].Salaris.BrutoBedrag.ToString();
                tbLand.Text = bedrijven[iBedrijf].werknemers[iWerknemer].LandVanHerkomst;
                if ((ContractType)bedrijven[iBedrijf].werknemers[iWerknemer].Salaris.TypeContract == ContractType.Maandcontract)
                    rbMaand.Checked = true;
                else
                    rbWeek.Checked = true;
                tbNet.Text = bedrijven[iBedrijf].werknemers[iWerknemer].Salaris.BerekenNetto().ToString("0.0");
                tbToString.Text = bedrijven[iBedrijf].werknemers[iWerknemer].Salaris.ToString();
            }
            //else
            //    MessageBox.Show(cbNaamWerknemer.Text + " niet gevonden");
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbBedrijf_SelectedIndexChanged(object sender, EventArgs e)
        {
            int iBedrijf = bedrijven.FindIndex(Item => Item.Naam == cbBedrijf.Text);
            if (iBedrijf != -1)
            {
                cbWerknemers.DataSource = null;
                cbWerknemers.DataSource = bedrijven[iBedrijf].werknemers;
                cbWerknemers.DisplayMember = nameof(Werknemer.Naam);
                cbNaamWerknemer.DataSource = null;
                cbNaamWerknemer.DataSource = bedrijven[iBedrijf].werknemers;
                cbNaamWerknemer.DisplayMember = nameof(Werknemer.Naam);
                cbBTWnr.Text = bedrijven[iBedrijf].BTWnummer;
            }
        }

        private void cbWerknemers_SelectedIndexChanged(object sender, EventArgs e)
        {
            int iBedrijf = -1;
            int iWerknemer = -1;
            foreach (Bedrijf bedrijf in bedrijven)
            {
                iWerknemer = bedrijf.werknemers.FindIndex(item => item.Naam == cbWerknemers.Text);
                if (iWerknemer != -1)
                {
                    iBedrijf = bedrijven.IndexOf(bedrijf);
                    break;
                }
            }
            if (iWerknemer != -1)
            {
                //cbNaamWerknemer.Items.Clear();
                cbNaamWerknemer.DataSource = bedrijven[iBedrijf].werknemers;
                cbNaamWerknemer.DisplayMember = nameof(Werknemer.Naam);
                   
                //foreach (Werknemer werknemer in bedrijven[iBedrijf].werknemers)
                //{
                //    cbNaamWerknemer.Items.Add(werknemer.Naam);
                //}
            }
            //int iWerknemer = bedrijven[iBedrijf].werknemers.FindIndex(item => item.Naam == cbWerknemers.Text);

        }

        private void btSave_Click(object sender, EventArgs e)
        {
            //cbNaamWerknemer
            
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            int iWerknemer = -1;
            int iBedrijf = -1;

            foreach (Bedrijf bedrijf in bedrijven)
            {
                iWerknemer = bedrijf.werknemers.FindIndex(item => item.Naam == cbNaamWerknemer.Text);
                if (iWerknemer != -1)
                {
                    iBedrijf = bedrijven.IndexOf(bedrijf);
                    break;
                }
            }
            if (iWerknemer != -1)
                bedrijven[iBedrijf].werknemers.RemoveAt(iWerknemer);
        }

        private void btToevoegen_Click(object sender, EventArgs e)
        {
            cbNaamWerknemer.Text = null;
            tbLand.Text = null;
            tbSalaris.Text = null;
            rbMaand.Checked = false;
            rbWeek.Checked = false;
            cbBedrijf.Text = "";
            cbBTWnr.Text = "";
            tbSalaris.Text = "";
            tbNet.Text = "";
            tbToString.Text = "";
            btnBewaren.Enabled = true;
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void btnBewaren_Click(object sender, EventArgs e)
        {
            Werknemer nieuwWerknemer = new Werknemer();
            Bedrijf nieuwBedrijf = new Bedrijf();
            nieuwWerknemer.Naam = cbNaamWerknemer.Text;
            nieuwWerknemer.LandVanHerkomst = tbLand.Text;
            nieuwWerknemer.Salaris = new Salaris(Convert.ToDouble(tbSalaris.Text));
            nieuwWerknemer.Salaris.TypeContract = rbMaand.Checked == true ? ContractType.Maandcontract : ContractType.Weekcontract;
            nieuwWerknemer.Salaris.BTWprocent = 21;
            int iBedrijf = bedrijven.FindIndex(item => item.Naam == cbBedrijf.Text);
            if (iBedrijf != -1)
                bedrijven[iBedrijf].werknemers.Add(nieuwWerknemer);
            else
            {
                nieuwBedrijf = new Bedrijf(cbBedrijf.Text, cbBTWnr.Text);
                nieuwBedrijf.werknemers = new List<Werknemer>();
                nieuwBedrijf.werknemers.Add(nieuwWerknemer);
                bedrijven.Add(nieuwBedrijf);
            }
            btnBewaren.Enabled = false;
        }
    }
}
