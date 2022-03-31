using System.ComponentModel;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Material.iOS;
using Xamarin.Forms.Platform.iOS;
using XFTest.iOS.Renderers;

[assembly: ExportRenderer(typeof(Entry), typeof(CustomEntryRenderer), new[] { typeof(VisualMarker.MaterialVisual) })]
namespace XFTest.iOS.Renderers
{
    public class CustomEntryRenderer : MaterialEntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            EntryRemoveUnderLine();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            EntryRemoveUnderLine();
        }

        protected void EntryRemoveUnderLine()
        {
            if (Control != null)
            {
                Control.BorderStyle = UITextBorderStyle.None;
                Control.Underline.Enabled = false;
                Control.Underline.DisabledColor = UIColor.Clear;
                Control.Underline.Color = UIColor.Clear;
                Control.Underline.BackgroundColor = UIColor.Clear;
                Control.ActiveTextInputController.UnderlineHeightActive = 0f;
                Control.PlaceholderLabel.BackgroundColor = UIColor.Clear;
            }
        }
    }
}