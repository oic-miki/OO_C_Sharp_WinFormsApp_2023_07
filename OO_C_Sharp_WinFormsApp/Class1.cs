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
        public void SinginTest()
        {
            Debug.Assert(new PersonPanel(NullUser.get()).IsSignin() == true);
        }
    }
}
