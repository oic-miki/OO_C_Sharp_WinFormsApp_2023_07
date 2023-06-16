using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace OO_C_Sharp_WinFormsApp
{

    /// <summary>
    /// 登録済み利用者
    /// </summary>
    public abstract partial class RegisteredUserList : Form, Viewer, Observer
    {

        private UserDataBase userDB = UserDataBase.get();

        public RegisteredUserList()
        {

            InitializeComponent();

            SuspendLayout();

            initialize();

            /*
             * フォーム
             */
            Text = "登録済み利用者";

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
        PersonPanelViewer personPanelViewer = new PersonPanelViewer();

        private void initialize()
        {

            initializeDisplay();

        }

        private void initializeDisplay()
        {

            personPanelViewer.removeControlAll();

            removeControlAll();

            int userCount = getUserDB().count();

            if (userCount > 0)
            {

                int x = 20;
                int y = 20;
                int incrementalValueOfX = 800 / userCount - 100;
                int incrementalValueOfY = 450 / userCount - 50;

                foreach (Person user in getUserDB().list())
                {

                    // 利用者情報のパネルを生成する
                    PersonPanel personPanel = new PersonPanel(user);

                    /*
                     * 最初に、ビューワー用の利用者情報のパネルを生成し、ビューワーへ追加する。
                     * 次に、利用者情報のビューワーとして登録する。
                     * その次に、活性化のハンドラーとして登録する。
                     * 最後に、利用者情報のパネルを追加する。
                     */
                    add(personPanel.addViewer(personPanelViewer.add(new PersonPanel(user))).addActivationHandler(personPanelViewer).setLocation(x, y));

                    x += incrementalValueOfX;
                    y += incrementalValueOfY;

                    if (application is Observer)
                    {

                        personPanel.addObserver(application as Observer);

                    }

                }

            }

        }

        protected UserDataBase getUserDB()
        {

            return userDB;

        }

        public RegisteredUserList setSize(int width, int height)
        {
            Size = new Size(width, height);

            return this;
        }

        public RegisteredUserList setLocation(int x, int y)
        {

            // 表示位置を指定する
            Location = new Point(x, y);

            return this;

        }
        /// <summary>
        ///  Brings this control to the front of the zorder.
        /// </summary>
        public RegisteredUserList bringToFront()
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

            return getUserDB().count();

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
        public RegisteredUserList removeAll()
        {

            removeControlAll();

            getUserDB().removeAll();

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

        public RegisteredUserList addApplication(Application application)
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
                personPanelViewer.show();

            }
            else
            {

                // 利用者情報のビューワーを非表示にする
                personPanelViewer.Hide();

            }

        }

    }

    public class PlaceRegisteredUserList : RegisteredUserList
    {

        public RegisteredUserList save(UserPlaceRegister userPlaceRegister)
        {

            Debug.Assert(userPlaceRegister != null);

            getUserDB().save(userPlaceRegister.getUser());

            return this;

        }

        public RegisteredUserList saveTemporary(UserPlaceRegister userPlaceRegister)
        {

            Debug.Assert(userPlaceRegister != null);

            // ※一時保存は未実装

            return this;

        }

    }

}