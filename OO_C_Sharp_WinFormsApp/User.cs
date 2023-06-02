using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OO_C_Sharp_WinFormsApp
{

    /// <summary>
    /// 利用者
    /// </summary>
    public interface User : Person
    {

        User addRole(Role role);

        bool isAdministrator();

    }

    public interface RecordableUser : User
    {

        Person addId(int id);

        bool isNewCreated();

    }

    public class UserModel : ExtendedPerson, User
    {

        /// <summary>
        /// 役割
        /// </summary>
        private Role role = Role.None;

        public UserModel()
        {

        }

        public UserModel(Role role)
        {

            addRole(role);

        }

        public UserModel(int id, Family family, String name, DateTime birthday, Visual visual)
            : base(id, family, name, birthday, visual)
        {

        }

        public UserModel(int id, Family family, String name, DateTime birthday, Visual visual, Role role)
            : base(id, family, name, birthday, visual)
        {

            addRole(role);

        }

        public User addRole(Role role)
        {

            Debug.Assert(role != null);

            this.role = role;

            Debug.Assert(this.role != null);
            Debug.Assert(this.role.Equals(role));

            return this;

        }

        public bool isAdministrator()
        {

            return role is Role.Administrator;

        }

    }

    public class NullUser : NullPerson, User, NullObject
    {

        private static User user = new NullUser();

        private NullUser()
        {

        }

        public static User get()
        {

            return user;

        }

        public User addRole(Role role)
        {

            return this;

        }

        public bool isAdministrator()
        {

            return false;

        }

    }

    public class ExtendedUser : UserModel, RecordableUser
    {

        public ExtendedUser()
        {

        }

        public ExtendedUser(Role role)
        {

            addRole(role);

        }

        public ExtendedUser(int id, Family family, String name, DateTime birthday, Visual visual)
            : base(id, family, name, birthday, visual)
        {

        }

        public ExtendedUser(int id, Family family, String name, DateTime birthday, Visual visual, Role role)
            : base(id, family, name, birthday, visual)
        {

            addRole(role);

        }

        public bool isNewCreated()
        {

            return getId() == 0;

        }

    }

}
