using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OO_C_Sharp_WinFormsApp
{

    public abstract class DataBase
    {

        public abstract int count();

        public abstract bool isEmpty();

        public abstract int createNewId();

    }

    public class FamilyDataBase : DataBase
    {

        private static FamilyDataBase familyDataBase = new FamilyDataBase();

        private Dictionary<int, Family> dataBase = new Dictionary<int, Family>()
        {

            { 1, new FamilyModel(1, "三木") },
            { 2, new FamilyModel(2, "Spielberg") },
            { 3, new FamilyModel(3, "ユーザー") },

        };
        private List<Family> families = new List<Family>();

        private FamilyDataBase()
        {

        }

        public static FamilyDataBase get()
        {

            return familyDataBase;

        }

        public override int count()
        {

            return dataBase.Count;

        }

        public override bool isEmpty()
        {

            return count() == 0;

        }

        public override int createNewId()
        {

            /*
             * 一意制約違反にならないようにIDの最大値を取得する
             */
            IOrderedEnumerable<KeyValuePair<int, Family>> sortedMap = dataBase.OrderBy(pair => pair.Key);
            if (sortedMap.Count() > 0)
            {

                return sortedMap.Last().Key + 1;

            }

            return 1;

        }

        public Family findById(int id)
        {

            Debug.Assert(id > 0);

            try
            {

                return dataBase[id];

            }
            catch (KeyNotFoundException e)
            {

                // NOP

            }

            return NullFamily.get();

        }

        public List<Family> list()
        {

            families.Clear();

            families.AddRange(dataBase.Values);

            return families;

        }

        public FamilyDataBase save(Family family)
        {

            Debug.Assert(family != null);

            dataBase.Add(family.getId(), family);

            Debug.Assert(dataBase.ContainsKey(family.getId()));
            Debug.Assert(dataBase[family.getId()].Equals(family));

            return this;

        }

    }

    public class VisualDataBase : DataBase
    {

        private static VisualDataBase visualDataBase = new VisualDataBase();

        private Dictionary<int, Visual> dataBase = new Dictionary<int, Visual>()
        {

            { 1, new VisualModel(1, Properties.Resources.noImage_60x80) },
            { 2, new VisualModel(2, Properties.Resources.image_01_60x80) },
            { 3, new VisualModel(3, Properties.Resources.image_02_60x80) },

        };
        private List<Visual> visuals = new List<Visual>();

        private VisualDataBase()
        {

        }

        public static VisualDataBase get()
        {

            return visualDataBase;

        }

        public override int count()
        {

            return dataBase.Count;

        }

        public override bool isEmpty()
        {

            return count() == 0;

        }

        public override int createNewId()
        {

            /*
             * 一意制約違反にならないようにIDの最大値を取得する
             */
            IOrderedEnumerable<KeyValuePair<int, Visual>> sortedMap = dataBase.OrderBy(pair => pair.Key);
            if (sortedMap.Count() > 0)
            {

                return sortedMap.Last().Key + 1;

            }

            return 1;

        }

        public Visual findById(int id)
        {

            Debug.Assert(id > 0);

            try
            {

                return dataBase[id];

            }
            catch (KeyNotFoundException e)
            {

                // NOP

            }

            return NullVisual.get();

        }

        public List<Visual> list()
        {

            visuals.Clear();

            visuals.AddRange(dataBase.Values);

            return visuals;

        }

        public VisualDataBase save(Visual visual)
        {

            Debug.Assert(visual != null);

            dataBase.Add(visual.getId(), visual);

            Debug.Assert(dataBase.ContainsKey(visual.getId()));
            Debug.Assert(dataBase[visual.getId()].Equals(visual));

            return this;

        }

    }

    public class PersonDataBase : DataBase
    {

        private static PersonDataBase personDataBase = new PersonDataBase();

        private Dictionary<int, Person> dataBase = new Dictionary<int, Person>()
        {
            /*
            {
                1,
                new ExtendedPerson(
                    // int id
                    1,
                    // Family family
                    FamilyDataBase.get().findById(1),
                    // String name
                    "崇行",
                    // DateTime birthday
                    makeBirthday(1969, 12, 18),
                    // Visual visual
                    VisualDataBase.get().findById(2))
            },
            {
                2,
                new ExtendedPerson(
                    // int id
                    2,
                    // Family family
                    FamilyDataBase.get().findById(2),
                    // String name
                    "Steven",
                    // DateTime birthday
                    makeBirthday(1946, 12, 18),
                    // Visual visual
                    VisualDataBase.get().findById(3))
            },
            */
        };
        private List<Person> people = new List<Person>();

        private PersonDataBase()
        {

        }

        public static PersonDataBase get()
        {

            return personDataBase;

        }

        private static DateTime makeBirthday(int yearOfBirth, int monthOfBirth, int dayOfBirth)
        {

            return new DateTime(yearOfBirth, monthOfBirth, dayOfBirth, 0, 0, 0);

        }

        public override int count()
        {

            return dataBase.Count;

        }

        public override bool isEmpty()
        {

            return count() == 0;

        }

        public override int createNewId()
        {

            /*
             * 一意制約違反にならないようにIDの最大値を取得する
             */
            IOrderedEnumerable<KeyValuePair<int, Person>> sortedMap = dataBase.OrderBy(pair => pair.Key);
            if (sortedMap.Count() > 0)
            {

                return sortedMap.Last().Key + 1;

            }

            return 1;

        }

        public Person findById(int id)
        {

            Debug.Assert(id > 0);

            try
            {

                return dataBase[id];

            }
            catch (KeyNotFoundException e)
            {

                // NOP

            }

            return NullPerson.get();

        }

        public List<Person> list()
        {

            people.Clear();

            people.AddRange(dataBase.Values);

            return people;

        }

        public PersonDataBase save(Person person)
        {

            Debug.Assert(person != null);

            dataBase.Add(person.getId(), person);

            Debug.Assert(dataBase.ContainsKey(person.getId()));
            Debug.Assert(dataBase[person.getId()].Equals(person));

            return this;

        }

        public PersonDataBase removeAll()
        {

            dataBase.Clear();

            return this;

        }

    }

    public class BookDataBase : DataBase
    {
        private static BookDataBase bookDataBase = new BookDataBase();

        private Dictionary<int, Book> dataBase = new Dictionary<int, Book>()
            { };
        private List<Book> users = new List<Book>();

        public override int count()
        {
            return users.Count;
        }

        public override bool isEmpty()
        {
            return count() == 0;
        }

        public override int createNewId()
        {
            var sortedMap = dataBase.OrderBy(pair => pair.Key);
            if (sortedMap.Any())
            {

                return sortedMap.Last().Key + 1;

            }

            return 1;
        }

        public static BookDataBase get()
        {

            return bookDataBase;

        }

        public BookDataBase save(Book book)
        {

            Debug.Assert(book != null);

            dataBase.Add(book.getId(), book);

            Debug.Assert(dataBase.ContainsKey(book.getId()));
            Debug.Assert(dataBase[book.getId()].Equals(book));

            return this;
        }
    }

    public class UserDataBase : DataBase
    {

        private static UserDataBase userDataBase = new UserDataBase();

        private PersonDataBase personDataBase = PersonDataBase.get();
        private List<User> users = new List<User>();

        private UserDataBase()
        {

            Family family = FamilyDataBase.get().findById(3);
            
            // Fatory Method を利用した実装です
            /*
            save(new AdministratorCreator().create().addFamilyName(family.getName()).addName("管理者A") as User);
            save(new UserCreator().create().addFamilyName(family.getName()).addName("利用者さん壱号") as User);
            save(new UserCreator().create().addFamilyName(family.getName()).addName("利用者さん弐号") as User);
            save(new UserCreator().create().addFamilyName(family.getName()).addName("利用者さん参号") as User);
            */
        }

        public static UserDataBase get()
        {

            return userDataBase;

        }

        public override int count()
        {

            // TODO 要修正
            return personDataBase.count();

        }

        public override bool isEmpty()
        {

            // TODO 要修正
            return personDataBase.isEmpty();

        }

        public override int createNewId()
        {

            return personDataBase.createNewId();

        }

        public User findById(int id)
        {

            Person person = personDataBase.findById(id);

            if (person is User)
            {

                return person as User;

            }

            return NullUser.get();

        }

        public List<User> list()
        {

            users.Clear();

            foreach (Person person in personDataBase.list())
            {

                if (person is User)
                {

                    users.Add(person as User);

                }

            }

            return users;

        }

        public UserDataBase save(User user)
        {
            
            if (user is not RecordableUser)
            {

                throw new NotRecordableException();

            }

            personDataBase.save((user as RecordableUser).addId(createNewId()));

            return this;

        }

        public UserDataBase removeAll()
        {

            personDataBase.removeAll();

            return this;

        }

    }

}