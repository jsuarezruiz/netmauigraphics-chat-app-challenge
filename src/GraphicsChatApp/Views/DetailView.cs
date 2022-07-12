using GraphicsChatApp.Models;
using GraphicsChatApp.Services;
using System.Collections.ObjectModel;

namespace GraphicsChatApp.Views
{
    public class DetailView : ContentPage
    {
        public DetailView()
        {
            var user = MessageService.Instance.GetUsers()[0];

            var detailDrawable = new DetailDrawable
            {
                User = user,
                Messages = new ObservableCollection<Message>(MessageService.Instance.GetMessages(user))
            };


            // Using .NET MAUI Graphics with Native drawing APIs
            /*
            Content = new GraphicsView
            {
                Drawable = detailDrawable
            };
            */

            // Using .NET MAUI Graphics with SkiaSharp
            Content = new Controls.SkiaGraphicsView
            {
                Drawable = detailDrawable
            };
        }
    }

    public class DetailDrawable : IDrawable
    {
        public User User { get; set; }
        public ObservableCollection<Message> Messages { get; set; }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            // TODO:
        }
    }
}