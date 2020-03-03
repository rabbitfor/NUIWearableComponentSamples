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
            
            Window window = NUIApplication.GetDefaultWindow();

            View root = new View()
            {
                Size2D = new Size2D(1920, 1080),
                BackgroundColor = Color.White,
                BoxShadow = new Shadow() {
                }
            };
            window.Add(root);

            var view = new Control
            {
                Size = new Size(100, 100),
                BackgroundColor = Color.Blue,
                CornerRadius = 30,
                ImageShadow = new ImageShadow
                {
                    Url = "/home/jy/2019/dali/NUIWearableStyleCollection/res/gallery-small-11.jpg",
                    Offset = new Vector2(10, 10),
                }
                // MinValue = 0,
                // MaxValue = 100,
                // CurrentValue = 50,
                // BufferValue = 70
            };
            root.Add(view);


            view.Style.CornerRadius = new Selector<float?>() {
                Normal = 50,
                Pressed = 10,
            };

            view.Style.BackgroundColor = null;

            // Tizen.Log.Info("JYJY", "view.CornerRadius1: " + view.CornerRadius + "\n");

            // view.Style.CornerRadius = 0;

            // Tizen.Log.Info("JYJY", "view.CornerRadius2: " + view.CornerRadius + "\n");

            // view.Style.CornerRadius = new Selector<float?>() {
            //     All = null,
            // };

            // Tizen.Log.Info("JYJY", "view.CornerRadius3: " + view.CornerRadius + "\n");

            
        }
    }
}
