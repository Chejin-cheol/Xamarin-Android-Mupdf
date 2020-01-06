# Xamarin-Android-Mupdf
Xamarin-Android에서 이용가능한 Mupdf Binding  Library

# 개요 #
**Android-Mupdf-viewer를 Xamarin으로 바인딩하여 사용할 수 있는 dll 라이브러리** <br>
**대상 :** xamarin.forms-project / xamarin.android-project <br>
**archetecture:** arm-7 , arm-64 <br>



# 사용 #

**PDFActivity.cs**
해당라이븝러리 참조
    using Com.Artifex.MuPdfDemo;

    public class PDFActivity : Activity
    {
        protected MuPDFCore _core;
        private MuPDFReaderView mDocView;
        private MuPDFPageAdapter mAdapter;


<br>

    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        SetContentView(Resource.Layout.activity_main);

        mPDFView = (Android.Widget.RelativeLayout)FindViewById(Resource.Id.pdfView);

        var path = new Android_Path();
        var file_path = Android.Net.Uri.Parse("data path");
        var uri = Android.Net.Uri.Decode(file_path.EncodedPath);
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
            mDocView = new XFMuPDFReaderView(this);
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
  
