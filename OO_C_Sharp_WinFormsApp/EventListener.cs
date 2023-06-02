using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OO_C_Sharp_WinFormsApp
{

    public enum Event
    {

        Save,

    }

    public interface ActionListener
    {

        void listen(Object sender);

    }

}
