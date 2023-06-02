using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OO_C_Sharp_WinFormsApp
{

    public class Title : Label
    {

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

    public abstract class BaseLabel : Label, Observer
    {

        private Person person;

        public BaseLabel(Person person)
        {

            Debug.Assert(person != null);

            this.person = person;

            Debug.Assert(this.person != null);

            AutoSize = true;
            TabStop = false;

        }

        protected Person getPerson()
        {

            return person;

        }

        public abstract void update();

        public BaseLabel setLocation(int x, int y)
        {

            // 表示位置を指定する
            Location = new Point(x, y);

            return this;

        }

    }

    public class PersonIdLabel : BaseLabel
    {

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
    
    public class UserRoleLabel : BaseLabel
    {

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

    public class FamilyNameLabel : BaseLabel, Observer
    {

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

    public class PersonNameLabel : BaseLabel, Observer
    {

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
    
    public class AgeLabel : BaseLabel, Observer
    {

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

}