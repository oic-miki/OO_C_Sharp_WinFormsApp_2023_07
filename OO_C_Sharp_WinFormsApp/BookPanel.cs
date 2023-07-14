using OO_C_Sharp_WinFormsApp.Book_;
using OO_C_Sharp_WinFormsApp.MyNamespace;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using Button = System.Windows.Forms.Button;
using ComboBox = System.Windows.Forms.ComboBox;
using Label = System.Windows.Forms.Label;
using TextBox = System.Windows.Forms.TextBox;

namespace OO_C_Sharp_WinFormsApp {

	public class BookPanel : Panel, ISerializable {

		private Book book;
		private Place place = NullPlace.get();
		private List<Viewer> viewers = new List<Viewer>();
		private List<Observer> observers = new List<Observer>();
		private List<ActionListener> actionListeners = new List<ActionListener>();
		private List<ActivationHandler> activationHandlers = new List<ActivationHandler>();
		private Button lendButton;
		private Button returnButton;
		public BookPanel(Book book)
		{

			Debug.Assert(book != null);

			this.book = book;

			int tabIndex = 0;

			/*
			 * ID
			 */
			Controls.Add(createBookIdTitle());
			Controls.Add(createBookIdLabel(book));

			/*
			 * 名
			 */
			Controls.Add(createBookNameTitle());
			Controls.Add(createBookNameLabel(book));
			Controls.Add(createBookNameTextBox(book, tabIndex++));
			/*
			 * Isbn
			 */
			Controls.Add(createBookIsbnTitle());
			Controls.Add(createBookIsbnLabel(book));
			Controls.Add(createBookIsbnTextBox(book, tabIndex++));

			/*
<<<<<<< HEAD
=======
			 * 価格
			 */
			Controls.Add(createBookPriceTitle());
			Controls.Add(createBookPriceLabel(book));
			Controls.Add(createBookPriceTextBox(book, tabIndex++));

			/*
			 * フォーマット
			 */
			Controls.Add(createBookFormatTitle());
			Controls.Add(createBookFormatLabel(book));
			Controls.Add(createBookFormatTextBox(book, tabIndex++));


			Controls.Add(createSaveButton(tabIndex++));

			Controls.Add(createLendButton(tabIndex++));
			Controls.Add(createReturnButton(tabIndex++));

			/*
			 * 貸出フラグ
			 */
			Controls.Add(createBookLendLabel(book));
			/*
>>>>>>> 83be79adc6f489966abfa8947b2c1a082a697c3c
			 * パネル
			 */
			setLocation(20, 20);
			setClientSize(450, 250);
			BorderStyle = BorderStyle.Fixed3D;
			Name = "bookPanel";
			Text = book.getName();

			// ドラッグ＆ドロップを実行可能にする
			initializeDragDrop();


		}

		private void initializeDragDrop()
		{

			MouseDown += event_MouseDown;

		}

		private void event_MouseDown(object sender, MouseEventArgs e)
		{

			if (DoDragDrop(this, DragDropEffects.Move) == DragDropEffects.Move)
			{

				setLocation(e.X, e.Y);

			}
			else if (e.Button == MouseButtons.Right)
			{

				if (ContextMenuStrip != null)
				{

					// コンテキストメニューを表示する
					ContextMenuStrip.Show(this, e.X, e.Y);

				}

			}

			foreach (ActivationHandler activationHandler in activationHandlers)
			{

				activationHandler.activate(getBook().getId());

			}

			bringToFront();

		}

		/// <summary>
		/// Initializes a new instance of the <see cref='System.Drawing.Point'/> class with the specified coordinates.
		/// </summary>
		public BookPanel setLocation(int x, int y)
		{

			// 表示位置を指定する
			Location = new Point(x, y);

			return this;

		}

		/// <summary>
		///  Brings this control to the front of the zorder.
		/// </summary>
		public BookPanel bringToFront()
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
		private Title createBookIdTitle()
		{

			Title title = new Title("ID");

			title.setLocation(30, 30).Size = new Size(38, 15);

			return title;

		}

		/// <summary>
		/// bookIdLabel
		/// </summary>
		/// <param name="book"></param>
		/// <returns></returns>
		private BookIdLabel createBookIdLabel(Book book)
		{

			BookIdLabel bookIdLabel = new BookIdLabel(book);

			bookIdLabel.setLocation(100, 30).Size = new Size(38, 15);
			//bookIdLabel.setLocation(100, 30);

			// オブザーバーとして登録する
			addObserver(bookIdLabel);

			return bookIdLabel;

		}

		/// <summary>
		/// 名
		/// </summary>
		/// <returns></returns>
		private Title createBookNameTitle()
		{

			Title title = new Title("書籍名");

			title.setLocation(30, 60).Size = new Size(38, 15);

			return title;

		}

		private BookNameLabel createBookNameLabel(Book book)
		{

			BookNameLabel bookNameLabel = new BookNameLabel(book);

			bookNameLabel.setLocation(100, 60).Size = new Size(38, 15);
			// オブザーバーとして登録する
			addObserver(bookNameLabel);

			return bookNameLabel;

		}
		private BookNameTextBox createBookNameTextBox(Book book, int tabIndex)
		{
			var bookNameTextBox = new BookNameTextBox(book);

			bookNameTextBox.setLocation(220, 60).setSize(100, 23);
			bookNameTextBox.TabIndex = tabIndex;

			// オブザーバーとして登録する
			addObserver(bookNameTextBox);

			// イベントリスナーとして登録する
			addActionListener(bookNameTextBox);

			return bookNameTextBox;

		}
		private Title createBookIsbnTitle()
		{

			Title title = new Title("ISBN");

			title.setLocation(30, 90).Size = new Size(38, 15);

			return title;

		}

		private BookIsbnLabel createBookIsbnLabel(Book book)
		{

			BookIsbnLabel bookIsbnLabel = new BookIsbnLabel(book);

			bookIsbnLabel.setLocation(100, 90).Size = new Size(38, 15);
			// オブザーバーとして登録する
			addObserver(bookIsbnLabel);

			return bookIsbnLabel;

		}
		private BookIsbnTextBox createBookIsbnTextBox(Book book, int tabIndex)
		{
			var bookIsbnTextBox = new BookIsbnTextBox(book);

			bookIsbnTextBox.setLocation(220, 88).setSize(100, 23);
			bookIsbnTextBox.TabIndex = tabIndex;

			// オブザーバーとして登録する
			addObserver(bookIsbnTextBox);

			// イベントリスナーとして登録する
			addActionListener(bookIsbnTextBox);

			return bookIsbnTextBox;

		}
		private Title createBookPriceTitle()
		{

			Title title = new Title("価格");

			title.setLocation(30, 120).Size = new Size(38, 15);

			return title;

		}

		private BookPriceLabel createBookPriceLabel(Book book)
		{

			BookPriceLabel bookPriceLabel = new BookPriceLabel(book);
			bookPriceLabel.setLocation(100, 120);
			// オブザーバーとして登録する
			addObserver(bookPriceLabel);

			return bookPriceLabel;

		}
		private BookPriceTextBox createBookPriceTextBox(Book book, int tabIndex)
		{
			var bookPriceTextBox = new BookPriceTextBox(book);

			bookPriceTextBox.setLocation(220, 118).setSize(100, 23);
			bookPriceTextBox.TabIndex = tabIndex;

			// オブザーバーとして登録する
			addObserver(bookPriceTextBox);

			// イベントリスナーとして登録する
			addActionListener(bookPriceTextBox);

			return bookPriceTextBox;

		}
		private Title createBookFormatTitle()
		{

			Title title = new Title("フォーマット");

			title.setLocation(30, 150).Size = new Size(38, 15);

			return title;

		}

		private BookFormatLabel createBookFormatLabel(Book book)
		{

			BookFormatLabel bookFormatLabel = new BookFormatLabel(book);

			bookFormatLabel.setLocation(100, 150);
			// オブザーバーとして登録する
			addObserver(bookFormatLabel);

			return bookFormatLabel;

		}
		private BookFormatTextBox createBookFormatTextBox(Book book, int tabIndex)
		{
			var bookFormatTextBox = new BookFormatTextBox(book);

			bookFormatTextBox.setLocation(220, 148).setSize(100, 23);
			bookFormatTextBox.TabIndex = tabIndex;

			// オブザーバーとして登録する
			addObserver(bookFormatTextBox);

			// イベントリスナーとして登録する
			addActionListener(bookFormatTextBox);

			return bookFormatTextBox;

		}
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

		private Button createLendButton(int tabIndex)
		{

			lendButton = new Button();

			lendButton.Location = new Point(200, 200);
			lendButton.Name = "saveButton";
			lendButton.Size = new Size(50, 23);
			lendButton.TabIndex = tabIndex;
			lendButton.Text = "借りる";
			lendButton.UseVisualStyleBackColor = true;
			lendButton.Click += saveButton_Click;

			return lendButton;

		}

		private Button createReturnButton(int tabIndex)
		{

			returnButton = new Button();

			returnButton.Location = new Point(100, 200);
			returnButton.Name = "ReturnButton";
			returnButton.Size = new Size(70, 23);
			returnButton.TabIndex = tabIndex;
			returnButton.Text = "返却する";
			returnButton.UseVisualStyleBackColor = true;
			returnButton.Click += saveButton_Click;

			return returnButton;

		}


		private void saveButton_Click(object? sender, EventArgs e)
		{

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

			// オブザーバーに更新を促す
			foreach (Observer observer in observers)
			{

				observer.update();

			}

		}
		public BookPanel addPlace(Place place)
		{

			Debug.Assert(place != null);

			this.place = place;

			Debug.Assert(this.place != null);

			notify();

			return this;

		}
		public BookPanel addViewer(Viewer viewer)
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
		public BookPanel addObserver(Observer observer)
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
		public BookPanel addActionListener(ActionListener actionListener)
		{

			Debug.Assert(actionListener != null);

			actionListeners.Add(actionListener);

			Debug.Assert(actionListeners.Contains(actionListener));

			return this;

		}

		public BookPanel addActivationHandler(ActivationHandler activationHandler)
		{

			Debug.Assert(activationHandler != null);

			activationHandlers.Add(activationHandler);

			Debug.Assert(activationHandlers.Contains(activationHandler));

			return this;

		}

		public Book getBook()
		{

			return book;

		}

		public BookPanel refresh()
		{

			notify();

			return this;

		}

		public BookPanel setClientSize(int weight, int height)
		{
			ClientSize = new Size(weight, height);
			return this;
		}
		public BookPanel addPerson(Person person)
		{
			if (person.hasBook())
			{

				foreach (var books in person.getBookList())
				{
					
					if (book.Equals_Book(books))
					{
						returnButton.Enabled = true;
						lendButton.Enabled = false;
					}
					else
					{
						lendButton.Enabled = true;
						returnButton.Enabled = false;
					}
				}
			}
			return this;
		}
	}	

}
