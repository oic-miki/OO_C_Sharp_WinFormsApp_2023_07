using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OO_C_Sharp_WinFormsApp {

	public abstract class BaseTextBox : TextBox, ActionListener {

		private Person person;
		private Book book;
		private List<Observer> observers = new List<Observer>();

		public BaseTextBox(Person person)
		{

			Debug.Assert(person != null);

			this.person = person;

			Debug.Assert(this.person != null);

		}

		public BaseTextBox(Book book)
		{

			Debug.Assert(book != null);

			this.book = book;

			Debug.Assert(this.book != null);

		}


		protected Person getPerson()
		{

			return person;

		}
		protected Book getBook()
		{
			return book;
		}

		public void listen(object sender)
		{

			if (sender is Event.Save)
			{

				// 声かけを伝搬する
				listen();

				// 変更を通知する
				notify();

			}

		}

		protected abstract void listen();

		private void notify()
		{

			// オブザーバーに更新を促す
			foreach (Observer observer in observers)
			{

				observer.update();

			}

		}

		public BaseTextBox addObserver(Observer observer)
		{

			Debug.Assert(observer != null);

			observers.Add(observer);

			Debug.Assert(observers.Contains(observer));

			return this;

		}

		public BaseTextBox setSize(int width, int height)
		{
			Size = new Size(width, height);

			return this;
		}

		public BaseTextBox setLocation(int x, int y)
		{

			// 表示位置を指定する
			Location = new Point(x, y);

			return this;

		}

	}

	public class FamilyNameTextBox : BaseTextBox, Observer {

		public FamilyNameTextBox(Person person) : base(person)
		{

			Name = "familyNameTextBox";

			update();

		}

		public void update()
		{

			Text = getPerson().getFamilyName();

		}

		protected override void listen()
		{

			// 最新の情報を設定する
			getPerson().addFamilyName(Text);

		}

	}

	public class PersonNameTextBox : BaseTextBox, Observer {

		public PersonNameTextBox(Person person) : base(person)
		{

			Name = "personNameTextBox";

			update();

		}

		public void update()
		{

			Text = getPerson().getName();

		}

		protected override void listen()
		{

			// 最新の情報を設定する
			getPerson().addName(Text);

		}

	}

	namespace MyNamespace {
		public class BookNameTextBox : BaseTextBox, Observer {

			public BookNameTextBox(Book book) : base(book)
			{

				Name = "bookNameTextBox";

				update();

			}

			public void update()
			{

				Text = getBook().getName();

			}

			protected override void listen()
			{

				// 最新の情報を設定する
				getBook().addName(Text);

			}

		}
		public class BookIsbnTextBox : BaseTextBox, Observer {

			public BookIsbnTextBox(Book book) : base(book)
			{

				Name = "bookIsbnTextBox";

				update();

			}

			public void update()
			{

				Text = getBook().getInternationalStandardBookNumber();

			}

			protected override void listen()
			{

				// 最新の情報を設定する
				getBook().addInternationalStandardBookNumber(Text);

			}

		}
		public class BookPriceTextBox : BaseTextBox, Observer {

			public BookPriceTextBox(Book book) : base(book)
			{

				Name = "bookPriceTextBox";

				update();

			}

			public void update()
			{

				Text = getBook().getPrice().ToString();

			}

			protected override void listen()
			{

				// 最新の情報を設定する
				getBook().addPrice(int.Parse(Text));

			}

		}
		public class BookFormatTextBox : BaseTextBox, Observer {

			public BookFormatTextBox(Book book) : base(book)
			{

				Name = "bookFormatTextBox";

				update();

			}

			public void update()
			{

				Text = getBook().getFormat();

			}

			protected override void listen()
			{

				// 最新の情報を設定する
				getBook().addFormat(Text);

			}

		}

	}

}