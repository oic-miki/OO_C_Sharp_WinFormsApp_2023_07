using Microsoft.VisualBasic.ApplicationServices;
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

    public partial class UserDataViewer : Form, Viewer, Observer
    {

        public UserDataViewer()
        {

            InitializeComponent();

            initialize();

            update();

        }

        private void initialize()
        {

            userDataGridView.AutoSize = true;
            userDataGridView.Location = new Point(20, 20);

            /*
             * ID/役割/姓/名/誕生日
             */
            userDataGridView.ColumnCount = 5;

            int index = 0;

            userDataGridView.Columns[index++].Name = "ID";
            userDataGridView.Columns[index++].Name = "役割";
            userDataGridView.Columns[index++].Name = "姓";
            userDataGridView.Columns[index++].Name = "名";
            userDataGridView.Columns[index++].Name = "誕生日";

            Size = new Size(userDataGridView.Size.Width, 300);

        }

        private void displayUserData()
        {

            userDataGridView.Rows.Clear();

            foreach (User user in UserDataBase.get().list())
            {

                userDataGridView.Rows.Add(new String[] {

                    // ID
                    user.getId().ToString(),
                    // 役割
                    user.isAdministrator().ToString(),
                    // 姓
                    user.getFamilyName(),
                    // 名
                    user.getName(),
                    // 誕生日
                    user.getBirthday().ToString(),

                });

            }

        }

        public Viewer add(Control control)
        {

            // NOP

            return this;

        }

        public Viewer removeControlAll()
        {

            foreach (Control control in Controls)
            {

                Controls.Remove(control);

            }

            return this;

        }

        public Viewer show()
        {

            Show();

            return this;

        }

        public void update()
        {

            displayUserData();

        }

    }

}
