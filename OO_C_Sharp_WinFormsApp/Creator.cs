using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OO_C_Sharp_WinFormsApp
{

    public class UserCreator
    {

        public virtual ExtendedUser create()
        {

            return new ExtendedUser();

        }

    }

    public class AdministratorCreator : UserCreator
    {

        public virtual ExtendedUser create()
        {

            return new ExtendedUser(Role.Administrator);

        }

    }

}