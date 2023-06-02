using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OO_C_Sharp_WinFormsApp
{

    public interface Application
    {

        bool isDebugMode();

    }

    public class NullApplication : Application, NullObject
    {

        private static Application application = new NullApplication();

        private NullApplication()
        {

        }

        public static Application get()
        {

            return application;

        }

        public bool isDebugMode()
        {

            return false;

        }

    }

}
