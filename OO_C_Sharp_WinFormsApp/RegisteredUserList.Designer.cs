using System.ComponentModel;

namespace OO_C_Sharp_WinFormsApp
{

    partial class RegisteredUserList
    {

        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {

            if (disposing && (components != null))
            {

                components.Dispose();

            }

            base.Dispose(disposing);

        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {

            SuspendLayout();

            /*
             * フォーム
             */
            // 
            // registeredUserList
            // 
            components = new Container();
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);

            Name = "registeredUserList";
            Text = "registeredUserList";

            ResumeLayout(false);

            PerformLayout();

        }

        #endregion

    }

}