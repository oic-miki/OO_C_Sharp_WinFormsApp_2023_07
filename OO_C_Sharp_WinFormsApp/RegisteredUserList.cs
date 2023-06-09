using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace OO_C_Sharp_WinFormsApp
{

    /// <summary>
    /// �o�^�ςݗ��p��
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
             * �t�H�[��
             */
            Text = "�o�^�ςݗ��p��";

            // �h���b�O���h���b�v�����s�\�ɂ���
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

        // ���p�ҏ��̃r���[���[�𐶐�����
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

                    // ���p�ҏ��̃p�l���𐶐�����
                    PersonPanel personPanel = new PersonPanel(user);

                    /*
                     * �ŏ��ɁA�r���[���[�p�̗��p�ҏ��̃p�l���𐶐����A�r���[���[�֒ǉ�����B
                     * ���ɁA���p�ҏ��̃r���[���[�Ƃ��ēo�^����B
                     * ���̎��ɁA�������̃n���h���[�Ƃ��ēo�^����B
                     * �Ō�ɁA���p�ҏ��̃p�l����ǉ�����B
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

            // �\���ʒu���w�肷��
            Location = new Point(x, y);

            return this;

        }
        /// <summary>
        ///  Brings this control to the front of the zorder.
        /// </summary>
        public RegisteredUserList bringToFront()
        {

            // �őO�ʂɔz�u����
            BringToFront();

            return this;

        }

        /// <summary>
        /// ���X�g�̌�����Ԃ��܂��B
        /// </summary>
        /// <returns></returns>
        public int count()
        {

            return getUserDB().count();

        }

        /// <summary>
        /// ���X�g���󂩂ǂ�����Ԃ��܂��B
        /// </summary>
        /// <returns>��̏ꍇ true</returns>
        public bool isEmpty()
        {

            return count() == 0;

        }

        /// <summary>
        /// ���ׂẴf�[�^��j�����܂��B
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

            // �\������
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

                // ���p�ҏ��̃r���[���[��\������
                personPanelViewer.show();

            }
            else
            {

                // ���p�ҏ��̃r���[���[���\���ɂ���
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

            // ���ꎞ�ۑ��͖�����

            return this;

        }

    }

}