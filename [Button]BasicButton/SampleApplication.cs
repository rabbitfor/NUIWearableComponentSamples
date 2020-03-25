using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    public class BasicButtonSampleApplication : NUIApplication
    {
        public BasicButtonSampleApplication() : base()
        {
        }

        protected override void OnCreate()
        {
            base.OnCreate();
            Window window = NUIApplication.GetDefaultWindow();
            window.BackgroundColor = Color.Black;

            // Create a button with the style
            var button = new Button(new BasicButtonStyle())
            {
                Text = "Hello World!",

                // Positioning it to the bottom
                ParentOrigin = ParentOrigin.BottomCenter,
                PivotPoint = PivotPoint.BottomCenter,
                PositionUsesPivotPoint = true,
                Position = new Position(0, -20)
            };
            window.Add(button);
        }
    }
}