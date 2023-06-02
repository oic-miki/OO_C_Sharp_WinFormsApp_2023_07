using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OO_C_Sharp_WinFormsApp
{

    public interface Observer
    {

        void update();

    }

    public class NullObserver : Observer, NullObject
    {

        private static Observer observer = new NullObserver();

        private NullObserver()
        {

        }

        public static Observer get()
        {

            return observer;

        }

        public void update()
        {

        }

    }

}
