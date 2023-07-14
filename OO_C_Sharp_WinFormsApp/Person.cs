using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OO_C_Sharp_WinFormsApp
{

    public interface Person
    {

        /// <summary>
        /// IDを返します。
        /// </summary>
        /// <returns></returns>
        int getId();

        /// <summary>
        /// 姓を返します。
        /// </summary>
        /// <returns></returns>
        String getFamilyName();

        Person addFamilyName(String familyName);

        /// <summary>
        /// 名を返します。
        /// </summary>
        /// <returns></returns>
        String getName();

        Person addName(String name);

        /// <summary>
        /// フルネームを返します。
        /// </summary>
        /// <returns></returns>
        String fullName();

        /// <summary>
        /// 誕生日を返します。
        /// </summary>
        /// <returns></returns>
        DateTime getBirthday();

        Person addBirthday(DateTime birthday);

        /// <summary>
        /// 年齢を返します。
        /// </summary>
        /// <returns></returns>
        int age();

        /// <summary>
        /// イメージを返します。
        /// </summary>
        /// <returns></returns>
        Image getImage();

        Person addImage(Image image);

        Person addBook(Book book);

        Person removeBook(Book book);


		bool hasBook();

        List<Book> getBookList();
    }

    /// <summary>
    /// 単一責務な『人』オブジェクトです。
    /// </summary>
    public class PersonModel : Person
    {

        /// <summary>
        /// ID
        /// </summary>
        private int id;

       

        /// <summary>
        /// 姓
        /// </summary>
        private String familyName;

        /// <summary>
        /// 名
        /// </summary>
        private String name;

        /// <summary>
        /// 誕生日
        /// </summary>
        private DateTime birthday;

        /// <summary>
        /// イメージ
        /// </summary>
        private Image image;

        List<Book> books = new();
		/// <summary>
		/// デフォルトのコンストラクタです。
		/// </summary>
		public PersonModel()
        {

            /*
             * ID
             */
            addId(0);

            /*
             * 姓
             */
            addFamilyName("");

            /*
             * 名
             */
            addName("");

            /*
             * 誕生日
             */
            addBirthday(DateTime.Today);

            /*
             * イメージ
             */
            addImage(Properties.Resources.noImage_60x80);
        }

        /// <summary>
        /// コンストラクタです。
        /// </summary>
        /// <param name="id"></param>
        /// <param name="familyName"></param>
        /// <param name="name"></param>
        /// <param name="yearOfBirth"></param>
        /// <param name="monthOfBirth"></param>
        /// <param name="dayOfBirth"></param>
        /// <param name="image"></param>
        public PersonModel(int id, String familyName, String name, int yearOfBirth, int monthOfBirth, int dayOfBirth, Image image)
        {

            /*
             * ID
             */
            addId(id);

            /*
             * 姓
             */
            addFamilyName(familyName);

            /*
             * 名
             */
            addName(name);

            /*
             * 誕生日
             */
            addBirthday(new DateTime(yearOfBirth, monthOfBirth, dayOfBirth, 0, 0, 0));

            /*
             * イメージ
             */
            addImage(image);

        }
        public bool hasBook()
        {
	        return true;
        }


		public int getId()
        {

            return id;

        }

        public Person addId(int id)
        {

            Debug.Assert(id >= 0);

            this.id = id;

            Debug.Assert(this.id >= 0);

            return this;

        }

        public virtual String getFamilyName()
        {

            return familyName;

        }

        public virtual Person addFamilyName(String familyName)
        {

            Debug.Assert(familyName != null);

            this.familyName = familyName;

            Debug.Assert(this.familyName != null);

            return this;

        }

        public String getName()
        {

            return name;

        }

        public virtual Person addName(String name)
        {

            Debug.Assert(name != null);

            this.name = name;

            Debug.Assert(this.name != null);

            return this;

        }

        public String fullName()
        {

            return getFamilyName() + " " + getName();

        }

        public DateTime getBirthday()
        {

            return birthday;

        }

        public virtual Person addBirthday(DateTime birthday)
        {

            Debug.Assert(birthday != null);

            this.birthday = birthday;

            Debug.Assert(this.birthday != null);

            return this;

        }

        public int age()
        {

            int age = DateTime.Today.Year - getBirthday().Year;

            // 誕生日前であれば年齢から 1 を引く
            if (DateTime.Today.Month.CompareTo(getBirthday().Month) < 0
                || DateTime.Today.Month.Equals(getBirthday().Month) && DateTime.Today.Day.CompareTo(getBirthday().Day) < 0)
            {

                age--;

            }

            return age;

        }

        public virtual Image getImage()
        {

            return image;

        }

        public virtual Person addImage(Image image)
        {

            Debug.Assert(image != null);

            this.image = image;

            Debug.Assert(this.image != null);

            return this;

        }

        public List<Book> getBookList()
        {
	        return books;
        }

        public Person addBook(Book book)
        {
	        books.Add(book);
            return this;
        }

        public Person removeBook(Book book)
        {
	        books.Remove(book);
	        return this;
        }
	}

    public class NullPerson : PersonModel, NullObject
    {

        private static Person person = new NullPerson();

        protected NullPerson()
        {

            /*
             * スーパークラスの値追加メソッドがオーバーライドされているため、
             * 直接スーパークラスのメソッドを発効する。
             */

            /*
             * 姓
             */
            base.addFamilyName("");

            /*
             * 名
             */
            base.addName("");

            /*
             * 誕生日
             */
            base.addBirthday(DateTime.Today);

            /*
             * イメージ
             */
            base.addImage(Properties.Resources.noImage_60x80);

        }

        public static Person get()
        {

            return person;

        }

        public override Person addFamilyName(String familyName)
        {

            return this;

        }

        public override Person addName(String name)
        {

            return this;

        }

        public override Person addBirthday(DateTime birthday)
        {

            return this;

        }

        public override Person addImage(Image image)
        {

            return this;

        }

    }

    public class ExtendedPerson : PersonModel
    {

        private List<Family> historyOfFamily = new List<Family>();
        private Visual visual = NullVisual.get();

        public ExtendedPerson()
        {

        }

        public ExtendedPerson(int id, Family family, String name, DateTime birthday, Visual visual)
        {

            /*
             * ID
             */
            addId(id);

            /*
             * 姓
             */
            addFamily(family);

            /*
             * 名
             */
            addName(name);

            /*
             * 誕生日
             */
            addBirthday(birthday);

            /*
             * イメージ
             */
            addVisual(visual);

        }

        public ExtendedPerson(int id, String familyName, String name, int yearOfBirth, int monthOfBirth, int dayOfBirth, Image image)
            : base(id, familyName, name, yearOfBirth, monthOfBirth, dayOfBirth, image)
        {

        }

        public override String getFamilyName()
        {

            return getFamily().getName();

        }

        public override Person addFamilyName(String familyName)
        {

            Debug.Assert(familyName != null);
            
            if (familyName.Length > 0)
            {

                addFamily(new FamilyModel(familyName));

                Debug.Assert(getFamily() is not NullObject);
                Debug.Assert(getFamilyName().Equals(familyName));

            }

            return this;

        }

        public Family getFamily()
        {

            if (historyOfFamily.Count > 0)
            {

                // 最新の家族を返す
                return historyOfFamily.Last();

            }

            return NullFamily.get();

        }

        public Person addFamily(Family family)
        {

            Debug.Assert(family != null);

            /*
             * 家族にふさわしいかどうかを決めることができる
             */
            if (family is not NullObject)
            {

                historyOfFamily.Add(family.addPerson(this));

                Debug.Assert(getFamily().Equals(family));

            }

            return this;

        }

        public override Image getImage()
        {

            return getVisual().getImage();

        }

        public override Person addImage(Image image)
        {

            Debug.Assert(image != null);

            addVisual(new VisualModel(image));

            Debug.Assert(getVisual() is not NullObject);
            Debug.Assert(getImage().Equals(image));

            return this;

        }

        public Visual getVisual()
        {

            return visual;

        }

        public Person addVisual(Visual visual)
        {

            Debug.Assert(visual != null);

            /*
             * イメージ通りかどうかを決めることができる
             * 
             */
            if (visual is not NullObject)
            {

                this.visual = visual.addPerson(this);

                Debug.Assert(getVisual().Equals(visual));

            }

            return this;

        }

    }

}