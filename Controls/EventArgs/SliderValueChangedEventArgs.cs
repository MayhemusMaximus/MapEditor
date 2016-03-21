using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapEditor.Controls.EventArgs
{
    public class SliderValueChangedEventArgs
    {
        public double Value { get; private set; }

        public SliderValueChangedEventArgs(double value)
        {
            this.Value = value;
        }
    }
}
