using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Emit;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;
using ComboBox = System.Windows.Forms.ComboBox;
using Label = System.Windows.Forms.Label;
using TextBox = System.Windows.Forms.TextBox;

namespace OO_C_Sharp_WinFormsApp
{

    public class PersonPanel : Panel, ISerializable
    {

        private int id;
        private Place place;
        private List<Viewer> viewers = new List<Viewer>();
        private List<Observer> observers = new List<Observer>();
        private List<ActionListener> actionListeners = new List<ActionListener>();
        private List<ActivationHandler> activationHandlers = new List<ActivationHandler>();
        private ContextMenuStrip context1= new ContextMenuStrip();
        private ContextMenuStrip context2= new ContextMenuStrip();

        //保存ボタンを押した際に変更できるか判断するフラグ
        private bool changeFlg = true;

        public PersonPanel(Person person)
        {

            Debug.Assert(person != null);

            id = person.getId();

            int tabIndex = 0;

            /*
             * ID
             */
            Controls.Add(createPersonIdTitle());
            Controls.Add(createPersonIdLabel(person));

            /*
             * 役割
             */
            Controls.Add(createUserRoleTitle());
            Controls.Add(createUserRoleLabel(person));
            Controls.Add(createUserRoleComboBox(person, tabIndex++));

            /*
             * 姓
             */
            Controls.Add(createFamilyNameTitle());
            Controls.Add(createFamilyNameLabel(person));
            Controls.Add(createFamilyNameTextBox(person, tabIndex++));

            /*
             * 名
             */
            Controls.Add(createPersonNameTitle());
            Controls.Add(createPersonNameLabel(person));
            Controls.Add(createPersonNameTextBox(person, tabIndex++));

            /*
             * 誕生日
             */
            Controls.Add(createPersonBirthdayDateTimePicker(person, tabIndex++));

            /*
             * 年齢
             */
            Controls.Add(createAgeTitle());
            Controls.Add(createAgeLabel(person));

            /*
             * イメージ
             */
            Controls.Add(createPersonImagePictureBox(person));

            /*
             * 保存ボタン
             */
            Controls.Add(createSaveButton(tabIndex++));

            /*
             * コンテキストメニュー
             */
            
            ContextMenuStrip = new SampleContextMenuStrip();

            /*
             * パネル
             */
            setLocation(20, 20);
            setClientSize(450, 250); 
            BorderStyle = BorderStyle.Fixed3D;
            Name = "personPanel";
            Text = person.fullName();

            // ドラッグ＆ドロップを実行可能にする
            initializeDragDrop();

           
            if (place is Library)   //ライブラリウィンドウにあるPersonPanelであるばあい
                addLibraryContextMenu();
            else  //新規登録ウィンドウにあるPersonPanelであるばあい
                addRegisterContextMenu();
        }

        private void initializeDragDrop()
        {

            MouseDown += event_MouseDown;

        }

        private void event_MouseDown(object sender, MouseEventArgs e)
        {

           
            if (e.Button == MouseButtons.Right)
            {

                if (ContextMenuStrip != null)
                {

                    // コンテキストメニューを表示する
                    ContextMenuStrip.Show(this, e.X, e.Y);

                }

            }
            else if (DoDragDrop(this, DragDropEffects.Move) == DragDropEffects.Move)
            {

                setLocation(e.X, e.Y);

            }
            foreach (ActivationHandler activationHandler in activationHandlers)
            {

                activationHandler.activate(getId());

            }

            bringToFront();

        }

        private void addRegisterContextMenu()
        {
            context1.Items.Clear();
            context1.Items.Add("入力クリア",null,textBoxClear);
            context1.Items.Add("保存", null, ContextSave);


            ContextMenuStrip = context1;
        }
        
         private void addLibraryContextMenu()
        {
            context2.Items.Clear();
            context2.Items.Add("ブック検索", null);
            context2.Items.Add("検索クリア", null);

            ContextMenuStrip= context2;
        }

        private void textBoxClear(object sender, EventArgs e)
        {
            var c = Controls.OfType<TextBox>();
            foreach(TextBox t in c) { t.Text = ""; }

            var comboBoxes = Controls.OfType<ComboBox>();
            foreach(ComboBox combo in comboBoxes) { combo.SelectedIndex = 0; }

            var dateTimePickers = Controls.OfType<DateTimePicker>();
            foreach(DateTimePicker dateTimePicker in dateTimePickers) { dateTimePicker.Value = DateTime.Today; }

            foreach(PersonImagePictureBox pictureBox in Controls.OfType<PersonImagePictureBox>()) { pictureBox.Image = Properties.Resources.noImage_60x80; }
        }

        private void ContextSave(object sender, EventArgs e)
        {
            saveButton_Click(sender, e);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref='System.Drawing.Point'/> class with the specified coordinates.
        /// </summary>
        public PersonPanel setLocation(int x, int y)
        {

            // 表示位置を指定する
            Location = new Point(x, y);

            return this;

        }

        /// <summary>
        ///  Brings this control to the front of the zorder.
        /// </summary>
        public PersonPanel bringToFront()
        {

            // 最前面に配置する
            BringToFront();

            return this;

        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {

            // NOP

        }

        /// <summary>
        /// ID
        /// </summary>
        /// <returns></returns>
        private Title createPersonIdTitle()
        {
            
            Title title = new Title("ID");

            title.setLocation(30, 30).Size = new Size(38, 15);

            return title;

        }

        /// <summary>
        /// personIdLabel
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        private PersonIdLabel createPersonIdLabel(Person person)
        {

            PersonIdLabel personIdLabel = new PersonIdLabel(person);

            personIdLabel.setLocation(100, 30).Size = new Size(38, 15);
           //personIdLabel.setLocation(100, 30).setSize(38,15);

            // オブザーバーとして登録する
            addObserver(personIdLabel);

            return personIdLabel;

        }

        private Title createUserRoleTitle()
        {

            Title title = new Title("役割");

            title.setLocation(30, 60).Size = new Size(38, 15);

            return title;

        }

        private UserRoleLabel createUserRoleLabel(Person person)
        {

            Debug.Assert(person is User);

            UserRoleLabel userRoleLabel = new UserRoleLabel(person as User);

            userRoleLabel.setLocation(100, 60).Size = new Size(38, 15);

            // オブザーバーとして登録する
            addObserver(userRoleLabel);

            return userRoleLabel;

        }

        /// <summary>
        /// userComboBox
        /// </summary>
        /// <param name="person"></param>
        /// <param name="tabIndex"></param>
        /// <returns></returns>
        private UserRoleComboBox createUserRoleComboBox(Person person, int tabIndex)
        {

            UserRoleComboBox userRoleComboBox;

            if (person is User)
            {

                userRoleComboBox = new UserRoleComboBox(person as User);

            }
            else
            {

                userRoleComboBox = new UserRoleComboBox();

                // ユーザーでない場合は役割を設定できないので非表示にする
                userRoleComboBox.Hide();

            }

            Debug.Assert(userRoleComboBox != null);

            userRoleComboBox.setLocation(220, 58).Size = new Size(100, 23);
            userRoleComboBox.TabIndex = tabIndex;

            // オブザーバーとして登録する
            addObserver(userRoleComboBox);

            // イベントリスナーとして登録する
            addActionListener(userRoleComboBox);

            return userRoleComboBox;

        }

        /// <summary>
        /// 姓
        /// </summary>
        /// <returns></returns>
        private Title createFamilyNameTitle()
        {

            Title title = new Title("姓");

            title.setLocation(30, 90).Size = new Size(38, 15);

            return title;

        }

        /// <summary>
        /// familyNameLabel
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        private FamilyNameLabel createFamilyNameLabel(Person person)
        {

            FamilyNameLabel familyNameLabel = new FamilyNameLabel(person);

            familyNameLabel.setLocation(100, 90).Size = new Size(38, 15);
            familyNameLabel.setFontSize(10);

            // オブザーバーとして登録する
            addObserver(familyNameLabel);

            return familyNameLabel;

        }

        /// <summary>
        /// familyNameTextBox
        /// </summary>
        /// <param name="person"></param>
        /// <param name="tabIndex"></param>
        /// <returns></returns>
        private FamilyNameTextBox createFamilyNameTextBox(Person person, int tabIndex)
        {

            FamilyNameTextBox familyNameTextBox = new FamilyNameTextBox(person);

            familyNameTextBox.setLocation(220, 88).setSize(100, 23);
            familyNameTextBox.TabIndex = tabIndex;

            // オブザーバーとして登録する
            addObserver(familyNameTextBox);

            // イベントリスナーとして登録する
            addActionListener(familyNameTextBox);

            return familyNameTextBox;

        }

        /// <summary>
        /// 名
        /// </summary>
        /// <returns></returns>
        private Title createPersonNameTitle()
        {

            Title title = new Title("名");

            title.setLocation(30, 120).Size = new Size(38, 15);

            return title;

        }

        /// <summary>
        /// personNameLabel
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        private PersonNameLabel createPersonNameLabel(Person person)
        {

            PersonNameLabel personNameLabel = new PersonNameLabel(person);

            personNameLabel.setLocation(100, 120);
            // オブザーバーとして登録する
            addObserver(personNameLabel);
            
            return personNameLabel;

        }

        /// <summary>
        /// personNameTextBox
        /// </summary>
        /// <param name="person"></param>
        /// <param name="tabIndex"></param>
        /// <returns></returns>
        private PersonNameTextBox createPersonNameTextBox(Person person, int tabIndex)
        {

            PersonNameTextBox personNameTextBox = new PersonNameTextBox(person);

            personNameTextBox.setLocation(220, 118).setSize(100, 23);
            personNameTextBox.TabIndex = tabIndex;

            // オブザーバーとして登録する
            addObserver(personNameTextBox);

            // イベントリスナーとして登録する
            addActionListener(personNameTextBox);

            return personNameTextBox;

        }

        /// <summary>
        /// personBirthdayDateTimePicker
        /// </summary>
        /// <param name="tabIndex"></param>
        /// <returns></returns>
        private PersonBirthdayDateTimePicker createPersonBirthdayDateTimePicker(Person person, int tabIndex)
        {

            PersonBirthdayDateTimePicker personBirthdayDateTimePicker = new PersonBirthdayDateTimePicker(person);

            personBirthdayDateTimePicker.setLocation(220, 148).setSize(200, 23);
            personBirthdayDateTimePicker.TabIndex = tabIndex;

            // オブザーバーとして登録する
            addObserver(personBirthdayDateTimePicker);

            // イベントリスナーとして登録する
            addActionListener(personBirthdayDateTimePicker);

            return personBirthdayDateTimePicker;

        }

        /// <summary>
        /// 年齢
        /// </summary>
        /// <returns></returns>
        private Title createAgeTitle()
        {

            Title title = new Title("年齢");

            title.setLocation(30, 150).Size = new Size(38, 15);

            return title;

        }

        /// <summary>
        /// ageLabel
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        private AgeLabel createAgeLabel(Person person)
        {

            AgeLabel ageLabel = new AgeLabel(person);

            ageLabel.setLocation(100, 150).Size = new Size(38, 15);

            // オブザーバーとして登録する
            addObserver(ageLabel);

            return ageLabel;

        }

        /// <summary>
        /// personImagePictureBox
        /// </summary>
        /// <returns></returns>
        private PersonImagePictureBox createPersonImagePictureBox(Person person)
        {

            PersonImagePictureBox personImagePictureBox = new PersonImagePictureBox(person);

            personImagePictureBox.setLocation(360, 30);
            personImagePictureBox.setSize(60,80);

            // オブザーバーとして登録する
            addObserver(personImagePictureBox);

            // イベントリスナーとして登録する
            addActionListener(personImagePictureBox);

            return personImagePictureBox;

        }

        /// <summary>
        /// saveButton
        /// </summary>
        /// <param name="tabIndex"></param>
        /// <returns></returns>
        private Button createSaveButton(int tabIndex)
        {

            Button button = new Button();

            button.Location = new Point(270, 200);
            button.Name = "saveButton";
            button.Size = new Size(150, 23);
            button.TabIndex = tabIndex;
            button.Text = "入力した内容を保存する";
            button.UseVisualStyleBackColor = true;
            button.Click += saveButton_Click;

            return button;

        }

        private void saveButton_Click(object? sender, EventArgs e)
        {
            if (!changeFlg) return;
            // 保存イベントのリスナーに声をかける
            foreach (ActionListener actionListener in actionListeners)
            {

                actionListener.listen(Event.Save);

            }

            // 変更を通知する
            notify();

        }

        private void notify()
        {
            bool isLibrary = place is Library;
            //if (place is Library)
            //{
            if (place is Library)   //ライブラリウィンドウにあるPersonPanelであるばあい
                addLibraryContextMenu();
            else  //新規登録ウィンドウにあるPersonPanelであるばあい
                addRegisterContextMenu();


            foreach (Control control in Controls)
            {

                if (control is TextBox)
                {

                    control.Enabled = !isLibrary;

                }
                else if (control is ComboBox)
                {

                    control.Enabled = !isLibrary;

                }
                else if (control is DateTimePicker)
                {

                    control.Enabled = !isLibrary;

                }
                else if (control is Button)
                {

                    control.Enabled = !isLibrary;

                }
            }
            //}

            // オブザーバーに更新を促す
            foreach (Observer observer in observers)
            {

                observer.update();

            }

        }

        public PersonPanel addViewer(Viewer viewer)
        {

            Debug.Assert(viewer != null);

            // おなじビューワーとは関係を構築しない
            if (!viewers.Contains(viewer))
            {

                viewers.Add(viewer);

                Debug.Assert(viewers.Contains(viewer));
                Debug.Assert(viewers.Last().Equals(viewer));

                if (viewer is ActionListener)
                {

                    // イベントリスナーとして登録する
                    addActionListener(viewer as ActionListener);

                }

            }

            return this;

        }

        /// <summary>
        /// オブザーバーを登録します。
        /// </summary>
        /// <param name="observer"></param>
        /// <returns></returns>
        public PersonPanel addObserver(Observer observer)
        {

            Debug.Assert(observer != null);

            observers.Add(observer);

            Debug.Assert(observers.Contains(observer));

            return this;

        }
        
        /// <summary>
        /// イベントリスナーを登録します。
        /// </summary>
        /// <param name="actionListener"></param>
        /// <returns></returns>
        public PersonPanel addActionListener(ActionListener actionListener)
        {

            Debug.Assert(actionListener != null);

            actionListeners.Add(actionListener);

            Debug.Assert(actionListeners.Contains(actionListener));

            return this;

        }

        public PersonPanel addActivationHandler(ActivationHandler activationHandler)
        {

            Debug.Assert(activationHandler != null);

            activationHandlers.Add(activationHandler);

            Debug.Assert(activationHandlers.Contains(activationHandler));

            return this;

        }

        public int getId()
        {

            return id;

        }

        public PersonPanel refresh()
        {

            notify();

            return this;

        }

        public PersonPanel addPlace(Place place)
        {

            Debug.Assert(place != null);

            this.place = place;

            Debug.Assert(this.place != null);

            notify();

            return this;

        }

        public PersonPanel setClientSize(int weight,int height)
        {
            ClientSize = new Size(weight, height);
            return this;
        }

        //PersonPanelを変更できるようにするか
        public void SetChangeFlg(bool flg)
        {
            changeFlg = flg;

            foreach(var listener in actionListeners)
            {

                if (listener is ComboBox)
                {
                    var comboBox = listener as ComboBox;
                    comboBox.Enabled = flg;
                }
                else if (listener is TextBox)
                {
                    var textBox = listener as TextBox;
                    textBox.ReadOnly = !flg;
                }
                else if(listener is DateTimePicker)
                {
                    var datePicker = listener as DateTimePicker;
                    datePicker.Enabled = flg;
                }
            }
        }

        //サインインしているかどうか(仮でtrue返してます)
        public bool IsSignin()
        {
            return true;
        }
    }

}
