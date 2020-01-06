using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;

namespace Com.Artifex.MuPdfDemo
{
    partial class ReaderView
    {
        // We use GetAdapter(...) / SetAdapter created in Metadata.xml
        // instead of the missing Adapter { get; set; }
        protected override Java.Lang.Object RawAdapter
        {
            get { return GetAdapter().JavaCast<Java.Lang.Object>(); }
            set
            {
                var adapter = value.JavaCast<global::Android.Widget.IAdapter>();
                this.SetAdapter(adapter);
            }
        }


        // 커스텀

/*
  public void ApplyToChildren(ViewMapper mapper)
  {

  }

  public abstract partial class ViewMapper
  {
     public abstract void ApplyToView(View view);
  }
  */

    }


}