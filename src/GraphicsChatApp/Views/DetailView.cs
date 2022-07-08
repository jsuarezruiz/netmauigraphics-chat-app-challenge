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

            Content = new GraphicsView
            {
                Drawable = new DetailDrawable
                {   
                    User = user,
                    Messages = new ObservableCollection<Message>(MessageService.Instance.GetMessages(user))
                }
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