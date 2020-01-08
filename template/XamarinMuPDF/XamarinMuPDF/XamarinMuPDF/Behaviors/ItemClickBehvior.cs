using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using XamarinMuPDF.Model;
using XamarinMuPDF.ViewModel;

namespace XamarinMuPDF.Behaviors
{
    public class ItemClickBehvior : Behavior<ListView> 
    {
        public static readonly BindableProperty ContextProperty = BindableProperty.Create(nameof(Context), typeof(BehaviorViewModel), typeof(ItemClickBehvior), null);
        BehaviorViewModel Context
        {
            get { return (BehaviorViewModel)GetValue(ContextProperty); }
            set { SetValue(ContextProperty, value); }
        }

        protected override void OnAttachedTo(ListView bindable)
        {
            bindable.ItemSelected += ItemClick;
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(ListView bindable)
        {
            bindable.ItemSelected -= ItemClick;
            base.OnDetachingFrom(bindable);
        }

        public void ItemClick(Object sender, SelectedItemChangedEventArgs e)
        {
            var filePath = ((Item)e.SelectedItem).Path;
            Context.eventCallback(this, filePath);
        }
    }
}
