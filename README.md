# Xamarin-Android-Mupdf
Xamarin-Android에서 이용가능한 Mupdf Binding  Library

# 개요 #
**Android-Mupdf-viewer를 Xamarin으로 바인딩하여 사용할 수 있는 dll 라이브러리** <br>
**대상 :** xamarin.forms / xamarin.android <br>
**참조 :** https://github.com/viavansi/mupdf-android/tree/master/src/main/java/com/artifex
**Archetecture :** arm-7 , arm-64 <br>


# 사용 #
pdf를 바인딩하여 사용할 액티비티를 구성합니다.<br>
**Xamarin.Android**에서는 Intent를 통하여 Activity를 호출하고<br>
**Xamarin.forms**에서는 DependecyService를 구현하여 Activity를 호출합니다. <br>

**해당라이븝러리 참조**

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

  
**pdf를 View 객체에 등록한다.**  

    if (_core == null)
    return;
    
    mDocView = new XFMuPDFReaderView(this);
    mAdapter = new MuPDFPageAdapter(this, _core);
    mDocView.SetAdapter(mAdapter);
    mDocView.DisplayedViewIndex = page;

**마지막으로 액티비티 레이아웃에 pdfViewer를 등록합니다**

    mPDFView.AddView(mDocView);


# 메모리관리 #

**activity 종료시 모든 MuPDF객체의 Dispose가 필요하며 ImageView와 Drawable객체는 Release후 Dispose합니다.** 

**core객체의 반환**    

    _core.OnDestroy();
    _core.Dispose();
    _core = null;
    
**viewer 객체의 리소스 반환**

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
    
    
