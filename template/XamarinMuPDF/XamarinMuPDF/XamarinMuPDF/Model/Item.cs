using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinMuPDF.Model
{
    public class Item
    {
        private string name;
        private string path;

        public string Name
        {
            get => name;
            set => name = value;
        }

        public string Path
        {
            get => path;
            set => path = value;
        }
    }
}
