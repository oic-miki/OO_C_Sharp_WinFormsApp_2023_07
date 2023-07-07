using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OO_C_Sharp_WinFormsApp {

	public class Title : Label {

		public Title(String text)
		{

			Debug.Assert(text != null);

			AutoSize = true;
			TabStop = false;
			Name = Text = text;

		}

		public Title setLocation(int x, int y)
		{

			// 表示位置を指定する
			Location = new Point(x, y);

			return this;

		}

	}

	public abstract class BaseLabel : Label, Observer {

		private Person person;
		private Book book;

		public BaseLabel(Person person)
		{

			Debug.Assert(person != null);

			this.person = person;

			Debug.Assert(this.person != null);

			AutoSize = true;
			TabStop = false;

		}
		public BaseLabel(Book book)
		{

			Debug.Assert(book != null);

			this.book = book;

			Debug.Assert(this.book != null);

			AutoSize = true;
			TabStop = false;

		}
		protected Person getPerson()
		{

			return person;

		}
		protected Book getBook()
		{

			return book;

		}
		public abstract void update();

		public BaseLabel setLocation(int x, int y)
		{

			// 表示位置を指定する
			Location = new Point(x, y);

			return this;

		}

		public BaseLabel setFontSize(int size)
		{
			this.Font = new Font(Font.FontFamily, size);

			return this;
		}

	}

	public class PersonIdLabel : BaseLabel {

		public PersonIdLabel(Person person) : base(person)
		{

			Name = "personIdLabel";

			update();

		}

		public override void update()
		{

			// 最新の情報を表示する
			Text = getPerson().getId().ToString();

		}

	}

	public class UserRoleLabel : BaseLabel {

		private User user;
		private RoleMap roleMap = RoleMap.get();

		public UserRoleLabel(User user) : base(user)
		{

			this.user = user;

			Debug.Assert(this.user != null);
			Debug.Assert(this.user.Equals(user));

			Name = "userRoleLabel";

			update();

		}

		public override void update()
		{

			// 最新の情報を表示する
			if (user.isAdministrator())
			{

				Text = roleMap.acquireAlias(Role.Administrator);

			}
			else
			{

				Text = roleMap.acquireAlias(Role.None);

			}

		}

	}

	public class FamilyNameLabel : BaseLabel, Observer {

		public FamilyNameLabel(Person person) : base(person)
		{

			Name = "familyNameLabel";

			update();

		}

		public override void update()
		{

			// 最新の情報を表示する
			Text = getPerson().getFamilyName();

		}

	}

	public class PersonNameLabel : BaseLabel, Observer {

		public PersonNameLabel(Person person) : base(person)
		{

			Name = "personNameLabel";

			update();

		}

		public override void update()
		{

			// 最新の情報を表示する
			Text = getPerson().getName();

		}

	}

	public class AgeLabel : BaseLabel, Observer {

		public AgeLabel(Person person) : base(person)
		{

			Name = "ageLabel";

			update();

		}

		public override void update()
		{

			// 最新の情報を表示する
			Text = getPerson().age().ToString();

		}

	}

	namespace Book_ {
		public class BookIdLabel : BaseLabel {

			public BookIdLabel(Book book) : base(book)
			{

				Name = "bookIdLabel";

				update();

			}

			public override void update()
			{

				// 最新の情報を表示する
				Text = getBook().getId().ToString();

			}
		}

		public class BookNameLabel : BaseLabel, Observer {

			public BookNameLabel(Book book) : base(book)
			{

				Name = "bookNameLabel";

				update();

			}

			public override void update()
			{
				// 最新の情報を表示する
				Text = getBook().getName();

			}

		}
		public class BookIsbnLabel : BaseLabel, Observer {

			public BookIsbnLabel(Book book) : base(book)
			{

				Name = "bookIsbnLabel";

				update();

			}

			public override void update()
			{
				// 最新の情報を表示する
				Text = getBook().getInternationalStandardBookNumber();
			}
		}
		public class BookPriceLabel : BaseLabel, Observer {

			public BookPriceLabel(Book book) : base(book)
			{

				Name = "bookPriceLabel";

				update();

			}

			public override void update()
			{
				// 最新の情報を表示する
				Text = getBook().getPrice().ToString();
			}
		}
		public class BookFormatLabel : BaseLabel, Observer {

			public BookFormatLabel(Book book) : base(book)
			{

				Name = "bookFormatLabel";

				update();

			}

			public override void update()
			{
				// 最新の情報を表示する
				Text = getBook().getFormat();
			}
		}
		public class BookLendLabel : BaseLabel, Observer {

			public BookLendLabel(Book book) : base(book)
			{


				Name = "貸出可能";

				update();

			}

			public override void update()
			{
				// 最新の情報を表示する
				if (getBook().getLendState() == BookModel.LendState.Lendable)
				{
					Text = "貸出可能";
				}
				else if (getBook().getLendState() == BookModel.LendState.Loaned)
				{
					Text = "貸出中";
				}

			}
		}
	}

}