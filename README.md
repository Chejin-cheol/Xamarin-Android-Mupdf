# Xamarin-Android-Mupdf
Xamarin-Android에서 이용가능한 Mupdf Binding  Library

# 개요 #
**Android-Mupdf-viewer를 Xamarin으로 바인딩하여 사용할 수 있는 dll 라이브러리** <br>
**대상 :** xamarin.forms / xamarin.android <br>
**Xamarin.Android**에서는 Intent를 통하여 Activity를 호출하고
**Xamarin.forms**에서는 DependecyService를 구현하여 Activity를 호출합니다. 
**archetecture:** arm-7 , arm-64 <br>


# 사용 #

pdf를 바인딩하여 사용할 액티비티를 구성합니다.

**해당라이븝러리 참조

    using Com.Artifex.MuPdfDemo;

    public class PDFActivity : Activity
    {
        protected MuPDFCore _core;
        private MuPDFReaderView mDocView;
        private MuPDFPageAdapter mAdapter;
        Android.Widget.RelativeLayout mPDFView;

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
    
    
 **viewer gesture를 ReaderView 상속을 통해 접근**
 
    XFMuPDFReaderView : MuPDFReaderView
    
    protected override void OnSizeChanged(int w, int h, int oldw, int oldh) ...
    protected override void OnMoveToChild(int i) ...
    public override bool OnSingleTapUp(MotionEvent e)  ...

  
**viewer swipable 어댑터 , 제스처등록 **  

    if (_core == null)
    return;
    
    mDocView = new XFMuPDFReaderView(this);
    mAdapter = new MuPDFPageAdapter(this, _core);
    mDocView.SetAdapter(mAdapter);
    mDocView.DisplayedViewIndex = page;

**마지막으로 액티비티 레이아웃에 등록합니다**

    mPDFView.AddView(mDocView);


# 메모리관리 #

