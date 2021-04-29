using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event
{
    public class FEvent
    {
        public delegate void OnFiveHandler(object sender, EventArgs eventArgs);
        public event OnFiveHandler FiveEvent;

        public void OnFiveEvent()
        {
            if (FiveEvent != null)
            {
                FiveEvent.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
