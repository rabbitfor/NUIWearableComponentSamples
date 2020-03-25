using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    public class PressAnimationSampleApplication : NUIApplication
    {
        public PressAnimationSampleApplication() : base()
        {
        }

        protected override void OnCreate()
        {
            base.OnCreate();
            
            Window window = NUIApplication.GetDefaultWindow();
            window.BackgroundColor = Color.Black;

            var button = new Button(new RoundButtonStyle(), new Button.PressAnimationUIAdapter())
            {
                Text = "Hello World!",
                IconURL = "/usr/share/dotnet.tizen/framework/res/nui_component_default_switch_thumb_n.png",

                // Positioning it to the center
                ParentOrigin = ParentOrigin.Center,
                PivotPoint = PivotPoint.Center,
                PositionUsesPivotPoint = true
            };
            window.Add(button);
        }
    }
}