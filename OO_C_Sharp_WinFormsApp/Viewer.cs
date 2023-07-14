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
using System.Xml.Linq;

namespace OO_C_Sharp_WinFormsApp {

	public interface Viewer {

		Viewer add(Control control);

		Viewer removeControlAll();

		Viewer show();

		Viewer setSize(int width, int height);

	}

	public class NullViewer : Viewer, NullObject {

		private static Viewer viewer = new NullViewer();

		private NullViewer()
		{

		}

		public static Viewer get()
		{

			return viewer;

		}

		public Viewer add(Control control)
		{

			return this;

		}

		public Viewer removeControlAll()
		{

			return this;

		}

		public Viewer show()
		{

			return this;

		}

		public Viewer setSize(int width, int height)
		{
			return this;
		}

		public Viewer activate(int id)
		{
			return this;

		}

	}

	public partial class PersonPanelViewer : Form, Viewer, ActionListener, ActivationHandler {

		private Dictionary<int, PersonPanel> PersonPanelMap = new Dictionary<int, PersonPanel>();

		public PersonPanelViewer()
		{

			InitializeComponent();

			Text = "PersonPanelViewer";

		}

		public Viewer add(Control control)
		{

			Debug.Assert(control != null);

			// Control が PersonPanel であれば追加する
			if (control is PersonPanel)
			{

				PersonPanel personPanel = control as PersonPanel;

				Controls.Add(personPanel.addViewer(this));
				PersonPanelMap.Add(personPanel.getId(), personPanel);

				Debug.Assert(Controls.Contains(personPanel));
				Debug.Assert(PersonPanelMap.ContainsKey(personPanel.getId()));
				Debug.Assert(PersonPanelMap.ContainsValue(personPanel));

			}
			else
			{

				Controls.Add(control);

			}

			return this;

		}

		public Viewer removeControlAll()
		{

			foreach (Control control in Controls)
			{

				Controls.Remove(control);

				Debug.Assert(!Controls.Contains(control));

			}

			PersonPanelMap.Clear();

			Debug.Assert(PersonPanelMap.Count == 0);

			return this;

		}

		public Viewer show()
		{

			Show();

			return this;

		}

		public void listen(object sender)
		{

			foreach (PersonPanel personPanel in PersonPanelMap.Values)
			{

				personPanel.refresh();

			}

		}

		public void activate(int id)
		{

			Debug.Assert(id >= 0);

			PersonPanelMap[id].bringToFront();

		}

		public Viewer setSize(int width, int height)
		{
			Size = new Size(width, height);
			return this;
		}
	}

	public partial class BookPanelViewer : Form, Viewer, ActionListener, ActivationHandler {
		private Dictionary<int, BookPanel> BookPanelMap = new();

		public BookPanelViewer()
		{
			InitializeComponent();
			Text = "BookPanelViewer";

		}

		public Viewer add(Control control)
		{

			Debug.Assert(control != null);

			// Control が BookPanel であれば追加する
			if (control is BookPanel)
			{

				BookPanel bookPanel = control as BookPanel;

				Controls.Add(bookPanel.addViewer(this));
				BookPanelMap.Add(bookPanel.getBook().getId(), bookPanel);

				Debug.Assert(Controls.Contains(bookPanel));
				Debug.Assert(BookPanelMap.ContainsKey(bookPanel.getBook().getId()));
				Debug.Assert(BookPanelMap.ContainsValue(bookPanel));

			}
			else
			{

				Controls.Add(control);

			}

			return this;

		}

		public Viewer removeControlAll()
		{

			foreach (Control control in Controls)
			{

				Controls.Remove(control);

				Debug.Assert(!Controls.Contains(control));

			}

			BookPanelMap.Clear();

			Debug.Assert(BookPanelMap.Count == 0);

			return this;

		}

		public Viewer show()
		{

			Show();

			return this;

		}

		public void listen(object sender)
		{

			foreach (BookPanel bookPanel in BookPanelMap.Values)
			{

				bookPanel.refresh();

			}

		}

		public void activate(int id)
		{

			Debug.Assert(id >= 0);

			BookPanelMap[id].bringToFront();

		}

		public Viewer setSize(int width, int height)
		{
			Size = new Size(width, height);
			return this;
		}
	}

}
