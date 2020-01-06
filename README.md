# Xamarin-Android-Mupdf
Xamarin-Android에서 이용가능한 Mupdf Binding  Library

# 개요 #
**Android-Mupdf-viewer를 Xamarin으로 바인딩하여 사용할 수 있는 dll 라이브러리**
**대상 :** xamarin.forms-project / xamarin.android-project
**archetecture:** arm-7 , arm-64

# 사용 #
    using Com.Artifex.MuPdfDemo;

    public class PDFActivity : Activity
    {
        protected MuPDFCore _core;
        private MuPDFReaderView mDocView;
        private MuPDFPageAdapter mAdapter;
        
     protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.hymn_layout);
            var page = int.Parse(Intent.GetStringExtra("page")) - 1;

            mPDFView = (Android.Widget.RelativeLayout)FindViewById(Resource.Id.pdfView);

            var path = new Android_Path();
            var file_path = Android.Net.Uri.Parse("file://" + path.getLocalPath("Hymn", "hymn.pdf"));
            var uri = Android.Net.Uri.Decode(file_path.EncodedPath);
            _core = openFile(uri);
            setMuPDFView(page);

        }        
  
