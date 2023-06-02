using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OO_C_Sharp_WinFormsApp
{

    /// <summary>
    /// 家族
    /// </summary>
    public interface Family
    {

        int getId();

        String getName();

        Family addName(String name);

        Family addPerson(Person person);

        Family removePerson(Person person);

    }

    public class FamilyModel : Family
    {

        private int id;

        private String name;

        private Dictionary<int, Person> people = new Dictionary<int, Person>();

        public FamilyModel()
        {

            addId(0);

            addName("");

        }

        /// <summary>
        /// 新規作成用のコンストラクタです。
        /// </summary>
        /// <param name="name"></param>
        public FamilyModel(String name)
        {

            addId(0);

            addName(name);

        }

        /// <summary>
        /// 既存データ用のコンストラクタです。
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public FamilyModel(int id, String name)
        {

            addId(id);

            addName(name);

        }

        public int getId()
        {

            return id;

        }

        public Family addId(int id)
        {

            Debug.Assert(id >= 0);

            this.id = id;

            Debug.Assert(this.id >= 0);

            return this;

        }

        public String getName()
        {

            return name;

        }

        public virtual Family addName(String name)
        {

            Debug.Assert(name != null);

            this.name = name;

            Debug.Assert(this.name != null);

            return this;

        }

        public virtual Family addPerson(Person person)
        {

            Debug.Assert(person != null);

            people.Add(person.getId(), person);

            Debug.Assert(people.ContainsKey(person.getId()));
            Debug.Assert(people.ContainsValue(person));

            return this;

        }

        public virtual Family removePerson(Person person)
        {

            Debug.Assert(person != null);

            people.Remove(person.getId());

            Debug.Assert(!people.ContainsKey(person.getId()));

            return this;

        }

    }

    public class NullFamily : FamilyModel, NullObject
    {

        private static Family family = new NullFamily();

        private NullFamily()
        {

            /*
             * スーパークラスの値追加メソッドがオーバーライドされているため、
             * 直接スーパークラスのメソッドを発効する。
             */
            base.addName("");

        }

        public static Family get()
        {

            return family;

        }

        public override Family addName(String name)
        {

            return this;

        }

        public override Family addPerson(Person person)
        {

            return this;

        }

        public override Family removePerson(Person person)
        {

            return this;

        }

    }

}