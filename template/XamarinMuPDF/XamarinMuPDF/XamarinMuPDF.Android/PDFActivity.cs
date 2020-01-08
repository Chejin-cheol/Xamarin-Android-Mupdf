using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Artifex.MuPdfDemo;

namespace XamarinMuPDF.Droid
{
    [Activity(LaunchMode = Android.Content.PM.LaunchMode.SingleTop, Theme = "@android:style/Theme.NoTitleBar", ConfigurationChanges = Android.Content.PM.ConfigChanges.Orientation | Android.Content.PM.ConfigChanges.ScreenSize | Android.Content.PM.ConfigChanges.KeyboardHidden, HardwareAccelerated = true)]
    public class PDFActivity : Activity
    {
        protected MuPDFCore _core;
        private MuPDFReaderView mDocView;
        private MuPDFPageAdapter mAdapter;
        Android.Widget.RelativeLayout mPDFView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.pdf_layout);
            var page = Intent.GetIntExtra("page",1) - 1;

            mPDFView = (Android.Widget.RelativeLayout)FindViewById(Resource.Id.pdfView);

            
            var file_path = Android.Net.Uri.Parse("file://" + Intent.GetStringExtra("fileName"));
            var uri = Android.Net.Uri.Decode(file_path.EncodedPath);

            Console.WriteLine(file_path);
            Console.WriteLine(uri);
            Console.WriteLine("lay me me");
            _core = openFile(uri);
            setMuPDFView(page);

        }

        private MuPDFCore openFile(String path)
        {
            try
            {
                MuPDFCore core = new MuPDFCore(this, path);
                OutlineActivityData.Set(null);
                return core;
            }
            catch (Exception e)
            {

                Console.WriteLine("MuPDFCore-openFile: (error)" + e);

                return null;
            }
        }

        public void setMuPDFView(int page)
        {
            if (_core == null)
                return;

            // Now create the UI.
            // First create the document view
            mDocView = new MuPDFReaderView(this);
            mAdapter = new MuPDFPageAdapter(this, _core);
            mDocView.SetAdapter(mAdapter);
            mDocView.DisplayedViewIndex = page;


            // Stick the document view and the buttons overlay into a parent view

            if (mPDFView != null)
            {
                try
                {
                    mPDFView.AddView(mDocView);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e + "     <===========");
                }
            }
        }

        public override void OnConfigurationChanged(Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);
        }

        protected override void OnDestroy()
        {
            ClearPDF();
            ReleaseInstance();

            if (_core != null)
            {
                _core.OnDestroy();
            }

            base.OnDestroy();

            Dispose();
            GC.Collect();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            GC.Collect();
        }

        private void ClearPDF()
        {
            if (mDocView != null)
            {
                DisposeReaderView();
                mDocView.Dispose();
                mPDFView.Dispose();
                mAdapter.ReleaseBitmaps();
                mAdapter.Dispose();


                if (_core != null)
                {
                    _core.OnDestroy();
                    _core.Dispose();
                    _core = null;
                    mAdapter = null;
                    mDocView = null;
                    mPDFView = null;
                }
            }
        }

        void DisposeReaderView()
        {

            for (int i = 0; i < mDocView.ChildCount; i++)
            {
                MuPDFPageView mupdfPageView = (MuPDFPageView)mDocView.GetChildAt(i);
                ((IMuPDFView)mupdfPageView).ReleaseBitmaps();
                ((IMuPDFView)mupdfPageView).ReleaseResources();

                if (mDocView.MChildViews.ValueAt(i) != mupdfPageView)
                {
                    var view = (IMuPDFView)mDocView.MChildViews.ValueAt(i);
                    view.ReleaseBitmaps();
                    view.ReleaseResources();
                    view.Dispose();
                    view = null;

                }

                for (int j = 0; j < mupdfPageView.ChildCount; j++)
                {
                    var pageItem = mupdfPageView.GetChildAt(j);
                    if (pageItem is ImageView)
                    {
                        ImageView img = ((ImageView)pageItem);
                        img.DestroyDrawingCache();
                        img.Drawable.SetCallback(null);
                        img.SetImageBitmap(null);
                        img.Dispose();
                        img = null;
                    }
                    pageItem.Dispose();
                    pageItem = null;
                }
                mupdfPageView.Dispose();
                mupdfPageView = null;
            }

            mDocView.DestroyDrawingCache();
            mDocView.MChildViews.Dispose();
            mDocView.MChildViews = null;

            mDocView.MGestureDetector.Dispose();
            mDocView.MStepper.Dispose();
            mDocView.MScroller.Dispose();
            mDocView.MScaleGestureDetector.Dispose();

            mDocView.MGestureDetector = null;
            mDocView.MStepper = null;
            mDocView.MScroller = null;
            mDocView.MScaleGestureDetector = null;
        }
    }
}