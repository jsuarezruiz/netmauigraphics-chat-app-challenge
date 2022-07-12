namespace GraphicsChatApp.Controls
{
    public class SkiaGraphicsView : View, ISkiaGraphicsView
    {
        public IDrawable Drawable { get; set; }

        public void Invalidate()
        {
            Handler?.Invoke(nameof(IGraphicsView.Invalidate));
        }
    }
}
