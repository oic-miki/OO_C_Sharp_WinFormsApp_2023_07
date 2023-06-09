using Microsoft.VisualBasic.Devices;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OO_C_Sharp_WinFormsApp
{

    public partial class Library : Form, Place, Observer
    {

        /// <summary>
        /// 利用者登録
        /// </summary>
        private RegisterUser registerUser = NullRegisterUser.get();
        /// <summary>
        /// 登録済み利用者
        /// </summary>
        private PlaceRegisteredUserList registeredUserList;
        private int id;
        private String name;

        public Library(int id, String name)
        {

            InitializeComponent();

            SuspendLayout();

            // ドラッグ＆ドロップを実行可能にする
            initializeDragDrop();

            addId(id);
            Text = addName(name).getName();

            initializeDisplay();

            ResumeLayout(false);

            PerformLayout();

            setLocation(0,0).setSize(1000, 1000);
        }

        private void initializeDisplay()
        {

            if (getRegisteredUserList().isEmpty())
            {

                // 利用者登録画面を表示する
                getRegisterUser().bringToFront().show();

            }
            else
            {

                // 登録済み利用者の一覧を表示する
                getRegisteredUserList().bringToFront().show();

            }

        }

        private RegisterUser getRegisterUser()
        {

            if (registerUser is NullObject)
            {

                // 管理者を作成するように設定して利用者登録を生成する
                registerUser = new RegisterUser(this, Role.Administrator);

            }

            return registerUser;

        }

        private PlaceRegisteredUserList getRegisteredUserList()
        {

            if (registeredUserList is null)
            {

                // 登録済み利用者の一覧を生成する
                registeredUserList = new PlaceRegisteredUserList();

            }

            return registeredUserList;

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

        public int getId()
        {

            return id;

        }

        public Place addId(int id)
        {

            Debug.Assert(id >= 0);

            this.id = id;

            Debug.Assert(this.id >= 0);

            return this;

        }

        public String getName()
        {

            return name;

        }

        public Place addName(String name)
        {

            Debug.Assert(name != null);

            this.name = name;

            Debug.Assert(this.name != null);

            return this;

        }

        public Place add(PlaceRegister placeRegister)
        {

            Debug.Assert(placeRegister != null);

            // この場所にふさわしいかどうかを決めることができる
            if (placeRegister.getPlace() is Library)
            {

                if (placeRegister is UserPlaceRegister)
                {

                    register(placeRegister as UserPlaceRegister);

                }

            }

            return this;

        }

        private void register(UserPlaceRegister? userPlaceRegister)
        {

            if (userPlaceRegister.getStatus().getValue().Equals(SaveStatus.Complete))
            {

                // DBに永続化する
                getRegisteredUserList().save(userPlaceRegister);

            }
            else
            {

                // 一時保存用のDBに永続化する
                getRegisteredUserList().saveTemporary(userPlaceRegister);

            }

            initializeDisplay();

        }

        public Library show()
        {

            Show();

            return this;

        }

        private Application application = NullApplication.get();

        public Library addApplication(Application application)
        {

            Debug.Assert(application != null);

            this.application = application;

            Debug.Assert(this.application != null);

            getRegisterUser().addApplication(this.application);

            getRegisteredUserList().addApplication(this.application);

            return this;

        }

        public void update()
        {

            if (application.isDebugMode())
            {
                setLocation(0,0).setSize(1000, 500);
                // ここにデバッグモードの処理を記述できます
            }
            else
            {
                setLocation(100, 0).setSize(500, 500);

                // ここに通常モードの処理を記述できます

            }

            getRegisteredUserList().update();

        }

        public Library setLocation(int x,int y)
        {
            this.Location = new Point(x,y);
            return this;
        }

        public Library setSize(int width,int height)
        {
            this.Size = new Size(width,height);
            return this;
        }

    }

}