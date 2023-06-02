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

namespace OO_C_Sharp_WinFormsApp
{

    public interface Viewer
    {

        Viewer add(Control control);

        Viewer removeControlAll();

        Viewer show();

    }

    public class NullViewer : Viewer, NullObject
    {

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

        public Viewer activate(int id)
        {

            return this;

        }

    }

    public partial class PersonPanelViewer : Form, Viewer, ActionListener, ActivationHandler
    {

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

    }

}
