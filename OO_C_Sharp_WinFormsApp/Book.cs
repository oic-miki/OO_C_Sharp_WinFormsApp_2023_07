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
    }

    public class BookModel : Book
    {

        private int id;
        private String name;
        private String isbn;
        private int price;
        private String format;

        public BookModel(int id)
        {

            addId(id);

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

        public Book addName(string name)
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

        public Book addPrice(int price)
        {
            Debug.Assert(price >=0 );

            this.price = price;

            Debug.Assert(this.price >=0);
            return this;
        }

        public String getFormat()
        {
            return format;
        }

        public Book addFormat(String format)
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


    }

}
