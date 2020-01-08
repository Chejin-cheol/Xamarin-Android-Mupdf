using System;
using System.Collections.Generic;
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

[assembly: Dependency(typeof(PDFService))]
namespace XamarinMuPDF.Droid.FormsDependency
{
    class PDFService : IPDFService
    {
        public void moveToPage(string fileName)
        {
            var intent = new Intent(MainActivity._context, typeof(PDFActivity));
            intent.PutExtra("page", 1);
            intent.PutExtra("fileName", fileName);
            intent.AddFlags(ActivityFlags.ClearTop);
            MainActivity._context.StartActivity(intent);
        }
    }
}