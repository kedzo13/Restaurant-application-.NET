﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace Funkcionalnost_prijave
{
    public partial class FormDodajRezervaciju : Form
    {
        public User LogiranKorisnik { get; set; }
        public FormDodajRezervaciju(User korisnik)
        {
            InitializeComponent();
            LogiranKorisnik = korisnik;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void buttonOdustani_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonDodaj_Click(object sender, EventArgs e)
        {
            using(var context = new EntitiesReservations())
            {
                int brRezervacije = 0;
                foreach (var item in context.Reservations)
                {
                    if (item.BrojRezervacije > brRezervacije)
                    {
                        brRezervacije = item.BrojRezervacije;
                    }
                }

                string gost = textBoxIme.Text;
                string mail = textBoxEmail.Text;
                string osobe = textBoxBrOsoba.Text;
                string stol = textBoxBrStola.Text;
                DateTime date =TimePickerVrijeme.Value;
                int restoran =(int)LogiranKorisnik.Restaurant;
               
                

                Reservation novaRezervacija = new Reservation
                {
                    BrojRezervacije = brRezervacije+1,
                    ImeGosta = gost,
                    EmailGosta = mail,
                    BrojOsoba = osobe,
                    BrojStola = stol,
                    DatumVrijeme = date,
                    Restoran = restoran
                   
                };
                context.Reservations.Add(novaRezervacija);
                context.SaveChanges();
                PosaljiMail();
                Close ();
            }


            
        }

        private void PosaljiMail()
        {
            using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
            {
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("piprojektmail@gmail.com", "piprojekttest123");
                MailMessage msg = new MailMessage();
                msg.To.Add(textBoxEmail.Text);
                msg.From = new MailAddress("piprojekttest123@gmail.com");
                msg.Subject = "Podsjetnik na rezervaciju";
                msg.Body = "Poštovani, ovim putem Vas podsjećamo na Vašu rezervaciju u " + TimePickerVrijeme.Value + ". Veselimo se Vašem dolasku!";
                client.Send(msg);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
