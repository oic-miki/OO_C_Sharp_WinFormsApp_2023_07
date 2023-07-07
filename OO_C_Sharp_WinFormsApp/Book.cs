using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OO_C_Sharp_WinFormsApp
{

    public interface Book
    {
        int getId();

        String getName();

        int getPrice();

        string getFormat();

        Book addName(String name);

        Book addPrice(int price);

        Book addFormat(String format);

        String getInternationalStandardBookNumber();

        Book addInternationalStandardBookNumber(String isbn);

        Book setLendState(BookModel.LendState lendState);

		BookModel.LendState getLendState();
		Book lendBook();

    }

    public class NullBook : BookModel, NullObject
    {

        private static Book book = new NullBook();

        protected NullBook()
        {
            /*
             * スーパークラスの値追加メソッドがオーバーライドされているため、
             * 直接スーパークラスのメソッドを発効する。
             */

            /*
             * 本名
             */
            base.addName("");

            /*
             * 金額
             */
            base.addPrice(0);

            /*
             * 本のサイズ
             */
            base.addFormat("");
            /*
          * 貸し出しフラグ
          */
			base.setLendState(LendState.None);
        }

        public static Book get()
        {
            return book;
        }

        public override Book addName(String name)
        { 
            return this;
        }

        public override Book addPrice(int prise)
        {
            return this;
        }

        public override Book addFormat(String format)
        {
            return this;
        }
    }

    public class BookModel : Book
    {

	    private int id;
	    private String name = "";
	    private int price;
	    private String format;
	    private String isbn;

	    public enum LendState
	    {
		    None,
		    Lendable,
		    Loaned,
	    }

	    private LendState lendState;


	    public BookModel()
	    {
		    /*
		     * ID
		     */
		    addId(0);

		    /*
		    * 本名
		    */
		    addName("");

		    /*
		    * 金額
		    */
		    addPrice(0);

		    /*
		     * 本のサイズ
		     */
		    addFormat("");

		    /*
		    * ISBN
		    */
		    addInternationalStandardBookNumber("");

		    /*
		   * 貸し出しフラグ
		   */
		    setLendState(LendState.None);

	    }


	    public BookModel(int id, String name, int price, string format, String isbn, LendState lendState)
	    {

		    /*
		     * ID
		     */
		    addId(id);

		    /*
		     * 本名
		     */
		    addName(name);

		    /*
		     * 金額
		     */
		    addPrice(price);

		    /*
		     * 本のサイズ
		     */
		    addFormat(format);

		    /*
		    * ISBN
		    */
		    addInternationalStandardBookNumber(isbn);
		    /*
           * 貸し出しフラグ
           */
		    setLendState(lendState);
	    }


	    public int getId()
	    {

		    return id;

	    }

	    public Book addId(int id)
	    {
		    Debug.Assert(id >= 0);

		    this.id = id;

		    Debug.Assert(this.id >= 0);

		    return this;
	    }

	    public string getName()
	    {

		    return name;

	    }

	    public virtual Book addName(string name)
	    {
		    Debug.Assert(name != null);

		    this.name = name;

		    Debug.Assert(this.name != null);

		    return this;

	    }

	    public int getPrice()
	    {

		    return price;

	    }

	    public virtual Book addPrice(int price)
	    {
		    Debug.Assert(price >= 0);

		    this.price = price;

		    Debug.Assert(this.price >= 0);
		    return this;
	    }

	    public String getFormat()
	    {

		    return format;

	    }

	    public virtual Book addFormat(String format)
	    {
		    Debug.Assert(format != null);

		    this.format = format;

		    Debug.Assert(this.format != null);

		    return this;
	    }

	    public string getInternationalStandardBookNumber()
	    {

		    return isbn;

	    }

	    public Book addInternationalStandardBookNumber(string isbn)
	    {
		    Debug.Assert(isbn != null);

		    this.isbn = isbn;

		    Debug.Assert(this.isbn != null);

		    return this;

	    }

	    public Book setLendState(LendState lendState)
	    {
		    this.lendState = lendState;
		    return this;
	    }

	    public LendState getLendState()
	    {
		    return lendState;
	    }

	    public Book lendBook()
	    {
		    this.lendState = LendState.Loaned;
		    return this;
	    }
    }
}
