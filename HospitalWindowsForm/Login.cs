using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TableDrivenAdmin;

namespace HospitalWindowsForm
{
    public partial class Login : Form
    {
        Automata.automata.State state = Automata.automata.State.LOGIN, nextPosisi;
        string email, pass, role;
        public Login()
        {
            InitializeComponent();
        }

        private void cB_Role_SelectedIndexChanged(object sender, EventArgs e)
        {
            role = (string)cB_Role.SelectedItem;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void cB_password_CheckedChanged(object sender, EventArgs e)
        {
            tB_Password.PasswordChar = cB_password.Checked ? '\0' : '*';
        }

        private void btn_simpanLogin_Click(object sender, EventArgs e)
        {
            Enum name =  TableDrivenAdmin.TableDrivenAdmin.getUsername(tB_Email.Text);
            email = name.ToString();
            pass = TableDrivenAdmin.TableDrivenAdmin.getPassword(tB_Password.Text);
            role = (string)cB_Role.SelectedItem;

            if(role.Equals("Admin") && tB_Email.Text == email && tB_Password.Text == pass)
            {
                
                MessageBox.Show("Welcome " + tB_Email.Text);
                nextPosisi = Automata.automata.State.DASHBOARD;
                Automata.automata.nextPosisi = nextPosisi;
                HalamanAdmin halamanAdmin = new HalamanAdmin();
                halamanAdmin.Show();
                this.Hide();
            } else
            {
                MessageBox.Show("nama dan password salah");
            }
        }
    }
}
