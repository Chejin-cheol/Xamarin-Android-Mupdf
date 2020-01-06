# Xamarin-Android-Mupdf
Xamarin-Android에서 이용가능한 Mupdf Binding  Library

# 개요 #
**Android-Mupdf-viewer를 Xamarin으로 바인딩하여 사용할 수 있는 dll 라이브러리** <br>
**대상 :** xamarin.forms-project / xamarin.android-project <br>
**archetecture:** arm-7 , arm-64 <br>



# 사용 #

**PDFActivity.cs**
pdf를 바인딩하여 사용할 액티비티를 구성합니다.

해당라이븝러리 참조

    using Com.Artifex.MuPdfDemo;

    public class PDFActivity : Activity
    {
        protected MuPDFCore _core;
        private MuPDFReaderView mDocView;
        private MuPDFPageAdapter mAdapter;

pdf 객체를 초기화

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


  
