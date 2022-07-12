using GraphicsChatApp.Controls;

namespace GraphicsChatApp.Hosting
{
    public static class AppHostBuilderExtensions
    {
        public static MauiAppBuilder UseSkiaGraphicsView(this MauiAppBuilder builder)
        {
            builder.ConfigureMauiHandlers(handlers =>
            {
                handlers.AddHandler(typeof(SkiaGraphicsView), typeof(SkiaGraphicsViewHandler));
            });

            return builder;
        }
    }
}