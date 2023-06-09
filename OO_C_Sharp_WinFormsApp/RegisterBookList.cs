﻿using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OO_C_Sharp_WinFormsApp
{
    public partial class RegisterBookList : Form, Viewer, Observer
    {
        private BookDataBase bookDB = BookDataBase.get();

        public RegisterBookList()
        {
            InitializeComponent();
            SuspendLayout();

            initialize();

            /*
             * フォーム
             */
            Text = "登録済み本リスト";

            // ドラッグ＆ドロップを実行可能にする
            initializeDragDrop();

            ResumeLayout(false);

            PerformLayout();

        }

        private void initializeDragDrop()
        {

            DragOver += event_DragOver;
            DragDrop += event_DragDrop;
            DragEnter += event_DragEnter;
            AllowDrop = true;

        }

        private void event_DragOver(object sender, DragEventArgs e)
        {

            e.Effect = DragDropEffects.Move;

        }

        private void event_DragDrop(object sender, DragEventArgs e)
        {

            object obj = e.Data.GetData(DataFormats.Serializable);
            if (obj is PersonPanel)
            {

                PersonPanel personPanel = (obj as PersonPanel);

                if (!Controls.Contains(personPanel))
                {

                    Controls.Add(personPanel);

                }

                e.Effect = DragDropEffects.Move;

            }

        }

        private void event_DragEnter(object sender, DragEventArgs e)
        {

            if (e.Data.GetDataPresent(DataFormats.Serializable))
            {

                e.Effect = DragDropEffects.Move;

            }
            else
            {

                e.Effect = DragDropEffects.None;

            }

        }

        // 利用者情報のビューワーを生成する
        BookPanelViewer bookPanelViewer = new BookPanelViewer();

        private void initialize()
        {

            initializeDisplay();

        }

        private void initializeDisplay()
        {

            bookPanelViewer.removeControlAll();

            removeControlAll();

            int bookCount = getBookDB().count();

            if (bookCount > 0)
            {

                int x = 20;
                int y = 20;
                int incrementalValueOfX = 800 / bookCount - 100;
                int incrementalValueOfY = 450 / bookCount - 50;
                var list = getBookDB().list();
                foreach (Book book in list)
                {

                    // 利用者情報のパネルを生成する
                    BookPanel bookPanel = new BookPanel(book);

                    /*
                     * 最初に、ビューワー用の利用者情報のパネルを生成し、ビューワーへ追加する。
                     * 次に、利用者情報のビューワーとして登録する。
                     * その次に、活性化のハンドラーとして登録する。
                     * 最後に、利用者情報のパネルを追加する。
                     */
                    add(bookPanel.addViewer(bookPanelViewer.add(new BookPanel(book))).addActivationHandler(bookPanelViewer).setLocation(x, y));

                    x += incrementalValueOfX;
                    y += incrementalValueOfY;

                    if (application is Observer)
                    {

                        bookPanel.addObserver(application as Observer);

                    }

                }
            }
        }

        protected BookDataBase getBookDB()
        {

            return bookDB;

        }

        public Viewer setSize(int width, int height)
        {
            Size = new Size(width, height);
            return this;
        }

        public RegisterBookList setLocation(int x, int y)
        {

            // 表示位置を指定する
            Location = new Point(x, y);

            return this;

        }
        /// <summary>
        ///  Brings this control to the front of the zorder.
        /// </summary>
        public RegisterBookList bringToFront()
        {

            // 最前面に配置する
            BringToFront();

            return this;

        }

        /// <summary>
        /// リストの件数を返します。
        /// </summary>
        /// <returns></returns>
        public int count()
        {

            return getBookDB().count();

        }

        /// <summary>
        /// リストが空かどうかを返します。
        /// </summary>
        /// <returns>空の場合 true</returns>
        public bool isEmpty()
        {

            return count() == 0;

        }

        /// <summary>
        /// すべてのデータを破棄します。
        /// </summary>
        /// <returns></returns>
        public RegisterBookList removeAll()
        {

            removeControlAll();

            getBookDB().removeAll();

            return this;

        }

        public Viewer add(Control control)
        {

            Controls.Add(control);

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

            initializeDisplay();

            // 表示する
            Show();

            return this;

        }

        private Application application = NullApplication.get();

        public RegisterBookList addApplication(Application application)
        {

            Debug.Assert(application != null);

            this.application = application;

            Debug.Assert(this.application != null);

            if (this.application is Observer)
            {

                foreach (Control control in Controls)
                {

                    if (control is PersonPanel)
                    {

                        (control as PersonPanel).addObserver(application as Observer);

                    }

                }

            }

            return this;

        }

        public void update()
        {

            if (!isEmpty() && application.isDebugMode())
            {

                // 利用者情報のビューワーを表示する
                bookPanelViewer.show();

            }
            else
            {

                // 利用者情報のビューワーを非表示にする
                bookPanelViewer.Hide();

            }

        }

    }

    public class PlaceRegisterBookList : RegisterBookList
    {

        public RegisterBookList save(BookPlaceRegister BookPlaceRegister)
        {

            Debug.Assert(BookPlaceRegister != null);

            getBookDB().save(BookPlaceRegister.getBook());

            return this;

        }

        public RegisterBookList saveTemporary(BookPlaceRegister BookPlaceRegister)
        {

            Debug.Assert(BookPlaceRegister != null);

            // ※一時保存は未実装

            return this;

        }

    }

}