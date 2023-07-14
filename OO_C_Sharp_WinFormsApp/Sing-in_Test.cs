using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OO_C_Sharp_WinFormsApp
{
    public partial class Sing_in_Test : Form
    {
        //private Class1 class1 = new Class1();
        private PersonPanel personPanel;

        public Sing_in_Test(PersonPanel personPanel)
        {
            InitializeComponent();

            this.personPanel = personPanel;
        }

        public void addPersonPanel(PersonPanel personPanel)
        {
            this.personPanel = personPanel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (personPanel == null) return;

            //if (パスワードとIDが一致してれば、非表示)   
            {
                Hide();
            }
        }
    }
}
