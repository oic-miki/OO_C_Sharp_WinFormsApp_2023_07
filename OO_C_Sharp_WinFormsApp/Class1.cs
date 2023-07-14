using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OO_C_Sharp_WinFormsApp
{
    internal class Class1
    {
        public bool SinginTest()
        {
            bool singIn = new PersonPanel(NullUser.get()).IsSignin();
            Debug.Assert(singIn == true);
            return singIn;
        }
    }
}
