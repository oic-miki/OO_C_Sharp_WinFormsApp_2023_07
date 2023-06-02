using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OO_C_Sharp_WinFormsApp
{

    public class Status
    {

        private Enum value = BasicStatus.None;

        public Status()
        {

        }

        public Enum getValue()
        {

            return value;

        }

        public virtual Status addValue(Enum value)
        {

            Debug.Assert(value != null);

            this.value = value;

            Debug.Assert(this.value != null);

            return this;

        }

    }

    public class NullStatus : Status, NullObject
    {

        private static Status status = new NullStatus();

        public static Status get()
        {

            return status;

        }

        public override Status addValue(Enum value)
        {

            return this;

        }

    }

    public enum BasicStatus
    {

        None,

    }

    public enum SaveStatus
    {

        Temporary,
        Complete,

    }

}
