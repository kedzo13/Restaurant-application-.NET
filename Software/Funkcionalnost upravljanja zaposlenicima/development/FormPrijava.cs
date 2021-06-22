﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Funkcionalnost_prijave
{
    public partial class FormPrijava : Form
    {
        public User LogiraniKorisnik { get; set; }
        public List<User> ListaKorisnika { get; set; }
        public FormPrijava()
        {
            InitializeComponent();
        }

        private void ButtonPrijava_Click(object sender, EventArgs e)
        {
            ListaKorisnika = DohvatiKorisnike();

            foreach (var obj in ListaKorisnika)
            {
                if (obj.Username == textBoxKorisnickoIme.Text && obj.Password == textBoxLozinka.Text)
                {
                    LogiraniKorisnik = obj;
                }
            }
            if (LogiraniKorisnik == null)
            {
                MessageBox.Show("Neispravno uneseni podaci");
            }
            else
            {
                if (LogiraniKorisnik.Type == "zaposlenik")
                {
                    FormPrijavljenZaposlenik form = new FormPrijavljenZaposlenik(LogiraniKorisnik);
                    this.Hide();
                    form.ShowDialog();
                }
                else if (LogiraniKorisnik.Type == "admin")
                {
                    FormPrijavljenAdmin form = new FormPrijavljenAdmin(LogiraniKorisnik);
                    this.Hide();
                    form.ShowDialog();
                }
                else if (LogiraniKorisnik.Type == "superadmin")
                {
                    FormPrijavljenSuperadmin form = new FormPrijavljenSuperadmin();
                    this.Hide();
                    form.ShowDialog();

                }
            }
        }

        private List<User> DohvatiKorisnike()
        {
            using (var context = new PI21_54_DBEntities ())
            {
                return context.Users.ToList();
            }
        }
    }
}