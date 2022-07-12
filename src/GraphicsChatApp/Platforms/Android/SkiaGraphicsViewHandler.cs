﻿using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;

namespace GraphicsChatApp.Controls
{
    public partial class SkiaGraphicsViewHandler : ViewHandler<ISkiaGraphicsView, PlatformSkiaView>
    {
        protected override PlatformSkiaView CreatePlatformView() => new(Context);

        public static void MapDrawable(SkiaGraphicsViewHandler handler, ISkiaGraphicsView graphicsView)
        {
            handler.PlatformView?.UpdateDrawable(graphicsView);
        }

        public static void MapInvalidate(SkiaGraphicsViewHandler handler, ISkiaGraphicsView graphicsView, object? arg)
        {
            handler.PlatformView?.Invalidate();
        }
    }
}