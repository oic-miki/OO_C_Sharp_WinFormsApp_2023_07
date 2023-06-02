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

    public partial class LibraryApplication : Form, Application, Observer
    {

        Library library;
        // デバッグモード
        private bool debugMode = false;
        // DBのユーザー全データ表示
        private UserDataViewer userDataViewer = new UserDataViewer();

        public LibraryApplication()
        {

            InitializeComponent();

            library = new Library(1, "バーチャル図書館").addApplication(this).show();

        }

        /// <summary>
        /// 通常モード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {

            debugMode = false;

            update();

        }

        /// <summary>
        /// デバッグモード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {

            debugMode = true;

            update();

        }

        public UserDataViewer getUserDataViewer()
        {

            return userDataViewer;

        }

        public bool isDebugMode()
        {

            return debugMode;

        }

        public void update()
        {

            library.update();

            if (isDebugMode())
            {

                userDataViewer.update();
                userDataViewer.show();

            }
            else
            {

                userDataViewer.Hide();

            }

        }

    }

}
