using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinMuPDF.ViewModel
{
    internal abstract class BehaviorViewModel 
    {
        abstract public void eventCallback(Object sender , Object data);
        abstract public void eventCallback(Object sender , ICollection<Object> data);
    }
}
