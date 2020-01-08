using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using XamarinMuPDF.Dependency;
using XamarinMuPDF.Droid.FormsDependency;
using XamarinMuPDF.Model;

[assembly: Dependency(typeof(FileService))]
namespace XamarinMuPDF.Droid.FormsDependency
{
    class FileService : IFileService
    {
        public List<Item> GetFileList(string type)
        {
            string dPath = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath, Android.OS.Environment.DirectoryDownloads);
            if( ! Directory.Exists(dPath))
            {
                return null;
            }
            DirectoryInfo dInfo = new DirectoryInfo(dPath);
            FileInfo[] fInfo = dInfo.GetFiles();
            List<Item> files = new List<Item>(); 

            foreach( FileInfo f in fInfo)
            {
                 if(f.Extension == type.ToLower() ||  f.Extension == type.ToUpper())
                {
                    Item item = new Item();
                    item.Name = f.Name;
                    item.Path = Path.Combine( f.DirectoryName , f.Name);
                    files.Add(item);
                } 
            }

            return files;
        }
    }
}