using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    public class NUISampleApplication : NUIApplication
    {
        public NUISampleApplication(int width, int hight) : base(new Size2D(width, hight), new Position2D(0, 0))
        {
        }

        protected override void OnCreate()
        {
            base.OnCreate();
            
            Window window = Window.Instance;

            View root = new View()
            {
                Size2D = new Size2D(1920, 1080),
                BackgroundColor = Color.White,
                BoxShadow = new Shadow() {
                }
            };
            window.Add(root);

            var view = new Button
            {
                Size = new Size(100, 100),
                // MinValue = 0,
                // MaxValue = 100,
                // CurrentValue = 50,
                // BufferValue = 70
            };
            root.Add(view);
        }
    }
}
