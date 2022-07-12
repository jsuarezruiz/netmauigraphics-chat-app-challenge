#if !WINDOWS
using Microsoft.Maui.Graphics.Platform;
#endif

using GraphicsChatApp.Models;
using System.Collections.ObjectModel;
using System.Reflection;
using GraphicsChatApp.Services;
using IImage = Microsoft.Maui.Graphics.IImage;

namespace GraphicsChatApp.Views;

public class HomeView : ContentPage
{
    public HomeView()
    {
        var homeDrawable = new HomeDrawable
        {
            Users = new ObservableCollection<User>(MessageService.Instance.GetUsers()),
            RecentChat = new ObservableCollection<Message>(MessageService.Instance.GetChats())
        };

        // Using .NET MAUI Graphics with Native drawing APIs
        /*
        Content = new GraphicsView
        {
            Drawable = homeDrawable
        };
        */

        // Using .NET MAUI Graphics with SkiaSharp
        Content = new Controls.SkiaGraphicsView
        {
            Drawable = homeDrawable
        };
    }
}

public class HomeDrawable : IDrawable
{
    public ObservableCollection<User> Users { get; set; }
    public ObservableCollection<Message> RecentChat { get; set; }

    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        DrawBackground(canvas, dirtyRect);
        DrawTitle(canvas, dirtyRect);
        DrawUsers(canvas, dirtyRect);
        DrawRecentChat(canvas, dirtyRect);
    }

    void DrawBackground(ICanvas canvas, RectF dirtyRect)
    {
        canvas.SaveState();

        canvas.FillColor = Color.FromArgb("#5B61B9");

        canvas.FillRectangle(dirtyRect);

        canvas.RestoreState();
    }

    void DrawTitle(ICanvas canvas, RectF dirtyRect)
    {
        canvas.SaveState();

        canvas.FontColor = Colors.White;
        canvas.FontSize = 20.0f;

        canvas.DrawString("Chat with your friends", 24, 48, HorizontalAlignment.Left);

        canvas.RestoreState();
    }

    void DrawUsers(ICanvas canvas, RectF dirtyRect)
    {
        canvas.SaveState();

        float x = 48.0f;
        float y = 124.0f;
        float radius = 20.0f;
        float margin = 36.0f;

        float imageHeight = 23.0f;
        float imageWidth = 16.0f;

        int i = 0;
        foreach (var user in Users)
        {
            var posX = x + (i * (radius + margin));

            // User Icon Background
            canvas.FillColor = user.Color;
            canvas.FillCircle(posX, y, radius);

#if !WINDOWS
            // User Icon
            IImage image;
            var assembly = GetType().GetTypeInfo().Assembly;
            using (var stream = assembly.GetManifestResourceStream($"GraphicsChatApp.Resources.{user.Image}"))
            {
                image = PlatformImage.FromStream(stream);
            }

            if (image != null)
            {
                canvas.DrawImage(image, posX - 8, y - 10, imageWidth, imageHeight);
            }
#endif

            i++;
        }

        canvas.RestoreState();
    }

    void DrawRecentChat(ICanvas canvas, RectF dirtyRect)
    {
        canvas.SaveState();

        canvas.FillColor = Colors.White;

        float x = 0f;
        float y = 180f;
        float height = dirtyRect.Height;
        float width = dirtyRect.Width;

        float cornerRadius = 18.0f;

        canvas.FillRoundedRectangle(x, y, width, height - y, cornerRadius, cornerRadius, 0, 0);

        canvas.RestoreState();

        canvas.SaveState();

        float iconX = 48f;
        float iconY = 240f;
        float radius = 24.0f;
        float margin = 64.0f;
        float textMargin = 12.0f;

        float imageHeight = 35.0f;
        float imageWidth = 24.0f;

        int i = 0;

        foreach (var chat in RecentChat)
        {
            float posY = iconY + (i * (radius + margin));

            // Sender Icon Background
            canvas.FillColor = chat.Sender.Color;
            canvas.FillCircle(iconX, posY, radius);

#if !WINDOWS
            // Sender Icon
            IImage image;
            var assembly = GetType().GetTypeInfo().Assembly;
            using (var stream = assembly.GetManifestResourceStream($"GraphicsChatApp.Resources.{chat.Sender.Image}"))
            {
                image = PlatformImage.FromStream(stream);
            }

            if (image != null)
            {
                canvas.DrawImage(image, iconX - 12, posY - 16, imageWidth, imageHeight);
            }
#endif

            // Sender Name 
            canvas.FontColor = Colors.Black;
            canvas.FontSize = 12.0f;
            canvas.DrawString(chat.Sender.Name, iconX + radius + textMargin, posY - textMargin, HorizontalAlignment.Left);

            // Time
            canvas.FontColor = Colors.Gray;
            canvas.FontSize = 9.0f;
            canvas.DrawString(chat.Time, 0, posY - textMargin, width - textMargin * 2, 24, HorizontalAlignment.Right, VerticalAlignment.Top, TextFlow.ClipBounds, 0);

            // Message
            canvas.FontColor = Colors.DarkGray;
            canvas.FontSize = 10.0f;
            canvas.DrawString(chat.Text, iconX + radius + textMargin, posY + textMargin, HorizontalAlignment.Left);

            i++;
        }

        canvas.RestoreState();
    }
}