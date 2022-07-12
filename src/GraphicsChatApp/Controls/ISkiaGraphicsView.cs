namespace GraphicsChatApp.Controls
{
    public interface ISkiaGraphicsView : IView
    {
        IDrawable Drawable { get; }

        void Invalidate();
    }
}