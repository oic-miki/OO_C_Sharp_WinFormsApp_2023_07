using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OO_C_Sharp_WinFormsApp
{

    public interface Place
    {

        int getId();

        String getName();

        Place addName(String name);

        Place add(PlaceRegister placeRegister);

    }

    public class NullPlace : Place, NullObject
    {

        private static Place place = new NullPlace();

        private int id = 0;
        private String name = "";

        private NullPlace()
        {

        }

        public static Place get()
        {

            return place;

        }

        public int getId()
        {

            return id;

        }

        public String getName()
        {

            return name;

        }

        public Place addName(String name)
        {

            return this;

        }

        public Place add(PlaceRegister placeRegister)
        {

            return this;

        }

    }

}