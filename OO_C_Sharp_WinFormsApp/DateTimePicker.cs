using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OO_C_Sharp_WinFormsApp
{

    public abstract class BaseDateTimePicker : DateTimePicker, ActionListener
    {

        private Person person;
        private List<Observer> observers = new List<Observer>();

        public BaseDateTimePicker(Person person)
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

        public BaseDateTimePicker addObserver(Observer observer)
        {

            Debug.Assert(observer != null);

            observers.Add(observer);

            Debug.Assert(observers.Contains(observer));

            return this;

        }

        public BaseDateTimePicker setLocation(int x, int y)
        {

            // 表示位置を指定する
            Location = new Point(x, y);

            return this;

        }

        public BaseDateTimePicker setSize(int w, int h)
        {
            Size=new Size(w,h);
            return this;
        }
    }

    public class PersonBirthdayDateTimePicker : BaseDateTimePicker, Observer
    {

        public PersonBirthdayDateTimePicker(Person person) : base(person)
        {

            Name = "personBirthdayDateTimePicker";

            update();

        }

        public void update()
        {

            Value = getPerson().getBirthday();

        }

        protected override void listen()
        {

            // 最新の情報を設定する
            getPerson().addBirthday(Value);

        }

    }

}