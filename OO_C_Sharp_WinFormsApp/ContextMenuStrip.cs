using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OO_C_Sharp_WinFormsApp
{

    public class SampleContextMenuStrip : ContextMenuStrip
    {

        public SampleContextMenuStrip()
        {

            Items.AddRange(new ToolStripItem[] {

                // 初期状態はモードの切り替えのみ
                new SampleToolStripMenuItem(),

            });

        }

    }

}
