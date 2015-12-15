using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Project
{
    class EmptySearchTextBox : Exception
    {

        public EmptySearchTextBox()
        {
            MessageBox.Show("The textbox is empty", "Searching Error.");

        }
    }
}
