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
    
    /// <summary>
    /// 利用者登録
    /// </summary>
    public partial class RegisterBook : Form, ActionListener
    {

        private Place place = NullPlace.get();
        private Book book = NullBook.get();
        private Role role = Role.None;
        private PlaceRegister placeRegister = NullBookPlaceRegister.get();
        private Status status = new Status();

        public RegisterBook(Place place)
        {

            Debug.Assert(place != null);

            this.place = place;

            Debug.Assert(this.place != null);

            InitializeComponent();

            initialize();

        }

        public RegisterBook(Place place, Role role)
        {

            Debug.Assert(place != null);
            Debug.Assert(role != null);

            this.place = place;
            this.role = role;

            Debug.Assert(this.place != null);
            Debug.Assert(this.role != null);

            InitializeComponent();

            initialize();
            initializeDragDrop();
        }

        private void initialize()
        {
            
            Controls.Add(new BookPanel(new BookModel(1,"name",100,"format","abc")).addActionListener(this));

            Text = "本登録";

            setSize(500, 350);
            setLocation(0, 0);

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
            if (obj is BookPanel)
            {

                BookPanel bookPanelMock = (obj as BookPanel);

                if (!Controls.Contains(bookPanelMock))
                {

                    Controls.Add(bookPanelMock);
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

        /// <summary>
        ///  Makes the control display by setting the visible property to true
        /// </summary>
        public virtual RegisterBook show()
        {

            if (placeRegister is NullObject)
            {

                // データ登録用のオブジェクトを生成する
                placeRegister = new BookPlaceRegister(place, book).setStatus(status.addValue(SaveStatus.Temporary));

            }

            // 表示する
            Show();

            return this;

        }

        /// <summary>
        ///  Brings this control to the front of the zorder.
        /// </summary>
        public virtual RegisterBook bringToFront()
        {

            // 最前面に配置する
            BringToFront();

            return this;

        }

        /// <summary>
        /// 一時保存
        /// </summary>
        /// <returns></returns>
        public virtual RegisterBook save()
        {

            place.add(placeRegister);

            return this;

        }

        /// <summary>
        /// 登録
        /// </summary>
        /// <returns></returns>
        public virtual RegisterBook register()
        {

            place.add(placeRegister.setStatus(status.addValue(SaveStatus.Complete)));

            return this;

        }

        /// <summary>
        /// 登録終了
        /// </summary>
        /// <returns></returns>
        public virtual RegisterBook finish()
        {

            Controls.RemoveAt(0);

            book = NullBook.get();

            return hide();

        }

        /// <summary>
        ///  Hides the control by setting the visible property to false;
        /// </summary>
        public virtual RegisterBook hide()
        {

            // 非表示にする
            Hide();

            return this;

        }

        public void listen(object sender)
        {

            // TODO 「一時保存」の実装
            register().finish();

        }

        private Application application = NullApplication.get();

        public RegisterBook addApplication(Application application)
        {

            Debug.Assert(application != null);

            this.application = application;

            Debug.Assert(this.application != null);

            if (application is Observer)
            {

                foreach (Control control in Controls)
                {

                    if (control is BookPanel)
                    {

                        (control as BookPanel).addObserver(application as Observer);

                    }

                }

            }

            return this;

        }

        public RegisterBook setLocation(int x, int y)
        {
            this.Location = new Point(x, y);

            return this;
        }

        public RegisterBook setSize(int width, int height)
        {
            this.Size = new Size(width, height);

            return this;
        }

        private void RegisterBook_Load(object sender, EventArgs e)
        {

        }
    }

    public class NullRegisterBook : RegisterBook, NullObject
    {

        private static RegisterBook registerBook = new NullRegisterBook();

        private NullRegisterBook() : base(NullPlace.get())
        {

        }

        public static RegisterBook get()
        {

            return registerBook;

        }

        public override RegisterBook show()
        {

            return this;

        }

        public override RegisterBook bringToFront()
        {

            return this;

        }

        public override RegisterBook register()
        {

            return this;

        }

        public override RegisterBook finish()
        {

            return this;

        }

        public override RegisterBook hide()
        {

            return this;

        }

    }

}