using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OO_C_Sharp_WinFormsApp
{

    /// <summary>
    /// イメージ
    /// </summary>
    public interface Visual
    {

        int getId();

        Image getImage();

        Visual addImage(Image image);

        Visual addPerson(Person person);

        Visual removePerson();

    }

    public class VisualModel : Visual
    {

        private int id;

        private Image image;

        private Person person = NullPerson.get();

        public VisualModel()
        {

            addId(0);

            addImage(Properties.Resources.noImage_60x80);

        }

        /// <summary>
        /// 新規作成用のコンストラクタです。
        /// </summary>
        /// <param name="image"></param>
        public VisualModel(Image image)
        {

            addId(0);

            addImage(image);

        }

        /// <summary>
        /// 既存データ用のコンストラクタです。
        /// </summary>
        /// <param name="id"></param>
        /// <param name="image"></param>
        public VisualModel(int id, Image image)
        {

            addId(id);

            addImage(image);

        }

        public int getId()
        {

            return id;

        }

        public Visual addId(int id)
        {

            Debug.Assert(id >= 0);

            this.id = id;

            Debug.Assert(this.id >= 0);

            return this;

        }

        public Image getImage()
        {

            return image;

        }

        public virtual Visual addImage(Image image)
        {

            Debug.Assert(image != null);

            this.image = image;

            Debug.Assert(this.image != null);

            return this;

        }

        public virtual Visual addPerson(Person person)
        {

            Debug.Assert(person != null);

            this.person = person;

            Debug.Assert(this.person != null);

            return this;

        }

        public virtual Visual removePerson()
        {

            person = NullPerson.get();

            Debug.Assert(person is NullObject);

            return this;

        }

    }

    public class NullVisual : VisualModel, NullObject
    {

        private static Visual visual = new NullVisual();

        private NullVisual()
        {

            /*
             * スーパークラスの値追加メソッドがオーバーライドされているため、
             * 直接スーパークラスのメソッドを発効する。
             */
            base.addImage(Properties.Resources.noImage_60x80);

        }

        public static Visual get()
        {

            return visual;

        }

        public override Visual addImage(Image image)
        {

            return this;

        }

        public override Visual addPerson(Person person)
        {

            return this;

        }

        public override Visual removePerson()
        {

            return this;

        }

    }

}