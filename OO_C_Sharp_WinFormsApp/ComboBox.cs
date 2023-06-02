using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace OO_C_Sharp_WinFormsApp
{

    public abstract class BaseComboBox : ComboBox, ActionListener
    {

        private User user;
        private List<Observer> observers = new List<Observer>();

        public BaseComboBox(User user)
        {

            Debug.Assert(user != null);

            this.user = user;

            Debug.Assert(this.user != null);

        }

        protected User getUser()
        {

            return user;

        }

        public void listen(object sender)
        {

            if (sender is Event.Save)
            {

                // 声かけを伝搬する
                listen();

                // 変更を通知する
                notify();

            }

        }

        protected abstract void listen();

        private void notify()
        {

            // オブザーバーに更新を促す
            foreach (Observer observer in observers)
            {

                observer.update();

            }

        }

        public BaseComboBox addObserver(Observer observer)
        {

            Debug.Assert(observer != null);

            observers.Add(observer);

            Debug.Assert(observers.Contains(observer));

            return this;

        }

        public BaseComboBox setLocation(int x, int y)
        {

            // 表示位置を指定する
            Location = new Point(x, y);

            return this;

        }

    }

    public class UserRoleComboBox : BaseComboBox, Observer
    {

        private RoleMap roleMap = RoleMap.get();

        public UserRoleComboBox() : base(NullUser.get())
        {

        }

        public UserRoleComboBox(User user) : base(user)
        {

            Name = "userRoleComboBox";

            Items.AddRange(roleMap.aliases());

            update();

        }

        public void update()
        {

            if (getUser().isAdministrator())
            {

                SelectedItem = roleMap.acquireAlias(Role.Administrator);

            }
            else
            {

                SelectedItem = roleMap.acquireAlias(Role.None);

            }

        }

        protected override void listen()
        {

            // 最新の情報を設定する
            getUser().addRole(roleMap.acquireRole(SelectedItem.ToString()));

        }

    }

}