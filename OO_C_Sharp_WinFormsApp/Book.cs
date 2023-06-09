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

        Book addName(String name);

        String getInternationalStandardBookNumber();

        Book addInternationalStandardBookNumber(String isbn);

    }

    public class BookModel : Book
    {

        private int id;
        private String name;
        private String isbn;

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

            this.name = name;

            return this;

        }

        public string getInternationalStandardBookNumber()
        {

            return isbn;

        }

        public Book addInternationalStandardBookNumber(string isbn)
        {

            this.isbn = isbn;

            return this;

        }

    }

}
