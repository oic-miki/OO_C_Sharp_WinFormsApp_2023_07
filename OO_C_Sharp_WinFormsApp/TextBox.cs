using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OO_C_Sharp_WinFormsApp
{

    public abstract class BaseTextBox : TextBox, ActionListener
    {

        private Person person;
        private List<Observer> observers = new List<Observer>();

        public BaseTextBox(Person person)
        {

            Debug.Assert(person != null);

            this.person = person;

            Debug.Assert(this.person != null);

        }

        protected Person getPerson()
        {

            return person;

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

        public BaseTextBox addObserver(Observer observer)
        {

            Debug.Assert(observer != null);

            observers.Add(observer);

            Debug.Assert(observers.Contains(observer));

            return this;

        }

        public BaseTextBox setSize(int x, int y) 
        {
            Size = new Size(x, y);

            return this;
        }

        public BaseTextBox setLocation(int x, int y)
        {

            // 表示位置を指定する
            Location = new Point(x, y);

            return this;

        }

    }

    public class FamilyNameTextBox : BaseTextBox, Observer
    {

        public FamilyNameTextBox(Person person) : base(person)
        {

            Name = "familyNameTextBox";

            update();

        }

        public void update()
        {

            Text = getPerson().getFamilyName();

        }

        protected override void listen()
        {

            // 最新の情報を設定する
            getPerson().addFamilyName(Text);

        }

    }

    public class PersonNameTextBox : BaseTextBox, Observer
    {

        public PersonNameTextBox(Person person) : base(person)
        {

            Name = "personNameTextBox";

            update();

        }

        public void update()
        {

            Text = getPerson().getName();

        }

        protected override void listen()
        {

            // 最新の情報を設定する
            getPerson().addName(Text);

        }

    }

}