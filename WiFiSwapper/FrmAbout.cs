using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WiFiSwapper
{
    public partial class FrmAbout : Form, IMessageFilter
    {
        private const int WM_LBUTTONDOWN = 0x0201; // Kod wiadomości dla lewego przycisku myszy

        public FrmAbout()
        {
            InitializeComponent();
            Application.AddMessageFilter(this); // Dodajemy filtr wiadomości
        }

        private void FrmAbout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmAbout_Load(object sender, EventArgs e)
        {
            var assembly = Assembly.GetExecutingAssembly();
            string company = assembly.GetCustomAttribute<AssemblyCompanyAttribute>()?.Company ?? "APPIT";
            string product = assembly.GetCustomAttribute<AssemblyProductAttribute>()?.Product ?? "WiFi Swapper";
            string copyright = assembly.GetCustomAttribute<AssemblyCopyrightAttribute>()?.Copyright ?? "Copyright (c) 2026 APPIT. All rights reserved.";

            lProduct.Text = product;
            lCompany.Text = company;
            lCopyright.Text = copyright;
            lVersion.Text = assembly.GetName().Version.ToString();
        }

        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == WM_LBUTTONDOWN)
            {
                this.Close(); // Zamknij okno, gdy wykryto kliknięcie lewym przyciskiem myszy
                return true; // Zwróć true, aby zatrzymać dalsze przetwarzanie tej wiadomości
            }
            return false; // Zwróć false, aby pozwolić na dalsze przetwarzanie innych wiadomości
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            Application.RemoveMessageFilter(this); // Usuwamy filtr wiadomości, gdy okno jest zamykane
            base.OnFormClosed(e);
        }
    }
}
