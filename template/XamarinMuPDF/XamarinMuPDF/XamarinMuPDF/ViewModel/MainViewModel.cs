using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using XamarinMuPDF.Behaviors;
using XamarinMuPDF.Dependency;
using XamarinMuPDF.Model;

namespace XamarinMuPDF.ViewModel
{
    class MainViewModel : BehaviorViewModel , INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
   
        public IFileService _fileService;
        public IPDFService _pdfService;
     

        //item source
        private List<Item> _items = new List<Item>();
        public List<Item> Items
        {
            get => _items;
            set
            {
                _items = value;
                OnPropertyChanged("Items");
            }
        }

        public MainViewModel()
        {
            _fileService = DependencyService.Get<IFileService>();
            _pdfService = DependencyService.Get<IPDFService>();
            Items = _fileService.GetFileList(".pdf");
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        // event callback
        public override void eventCallback(Object sender , object data)
        {
            var type = sender.GetType();

            if(type == typeof(ItemClickBehvior))
            {
                _pdfService.moveToPage(data.ToString());
            }
        }

        public override void eventCallback(Object sender, ICollection<object> data)
        {
           
            if (sender.GetType() == typeof(Behavior))
            {

            }
        }
    }
}
