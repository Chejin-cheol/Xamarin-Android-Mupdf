# Xamarin-Android-Mupdf
Xamarin-Android에서 이용가능한 Mupdf Binding  Library

# 개요 #
**Android-Mupdf-viewer를 Xamarin으로 바인딩하여 사용할 수 있는 dll 라이브러리** <br>
**대상 :** xamarin.forms / xamarin.android <br>
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
        Android.Widget.RelativeLayout mPDFView;

MuPDFCore: pdff 렌더링을 위한 jni 코어


**코어 객체를 초기화**

    try
    {
        MuPDFCore core = new MuPDFCore(this, pdf_path);
        OutlineActivityData.Set(null);
        return core;
    }
    catch (Exception e)
    {

        Console.WriteLine("MuPDFCore-openFile: (error)" + e);

        return null;
    }
    
    
 viewer gesture를 interface 구현을 통해 접근
    XFMuPDFReaderView : MuPDFReaderView
    
    protected override void OnSizeChanged(int w, int h, int oldw, int oldh) ...
    protected override void OnMoveToChild(int i) ...
    public override bool OnSingleTapUp(MotionEvent e)  ...

  
