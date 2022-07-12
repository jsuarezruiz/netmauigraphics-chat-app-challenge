using Android.Content;

namespace GraphicsChatApp.Controls
{
    public class PlatformSkiaView : Microsoft.Maui.Graphics.Skia.Views.SkiaGraphicsView
    {
        public PlatformSkiaView(Context context, IDrawable drawable = null) : base(context, drawable)
        {
 
        }
    }
}