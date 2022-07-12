namespace GraphicsChatApp.Controls
{
    public static class SkiaGraphicsViewExtensions
    {
        public static void UpdateDrawable(this PlatformSkiaView PlatformGraphicsView, ISkiaGraphicsView graphicsView)
        {
            PlatformGraphicsView.Drawable = graphicsView.Drawable;
        }
    }
}