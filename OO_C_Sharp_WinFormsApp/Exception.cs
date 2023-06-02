using System.Runtime.Serialization;

namespace OO_C_Sharp_WinFormsApp
{

    [Serializable]
    internal class NotRecordableException : Exception
    {

        public NotRecordableException() : base("このオブジェクトは保存ができないタイプです。")
        {

        }

    }
}