using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System;
using Tizen.NUI.Binding;
using System.ComponentModel;



namespace Tizen.NUI.Samples
{
    public class NUISampleApplication : NUIApplication
    {
        public NUISampleApplication(int width, int hight) : base(new Size2D(width, hight), new Position2D(0, 0))
        {
        }

        View container;

        int maxItem = 0;

        int itemWidth = 360;

        Control goLeft;

        Control goRight;

        Animation animation = null;

        int currentItem = 0;

        protected override void OnCreate()
        {
            base.OnCreate();
            
            Window window = NUIApplication.GetDefaultWindow();
            window.BackgroundColor = Color.Black;

            Tizen.NUI.Components.StyleManager.Instance.Theme = "wearable";

            container = new View()
            {
                WidthResizePolicy = ResizePolicyType.FitToChildren,
                HeightResizePolicy = ResizePolicyType.FitToChildren,
                PositionUsesPivotPoint = true,
                ParentOrigin = ParentOrigin.TopLeft,
                PivotPoint = PivotPoint.TopLeft,
            };


            //---Basic Button---------------------------------
            var parent1 = new View()
            {
                Size = new Size(itemWidth, itemWidth)
            };
            var button1 = new Button()
            {
                Size = new Size(210, 72),
                Text = "Basic button",
                PositionUsesPivotPoint = true,
                ParentOrigin = ParentOrigin.Center,
                PivotPoint = PivotPoint.Center,
            };
            parent1.Add(button1);
            container.Add(parent1);
            maxItem++;

            //---Button with animation-------------------------
            var parent2 = new View()
            {
                Size = new Size(itemWidth, itemWidth),
                Position = new Position(360, 0)
            };
            var button2 = new Button(new OverlayAnimationButtonStyle())
            {
                Size = new Size(200, 200),
                CornerRadius = 100,
                IconURL = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "icon.png",
                IconRelativeOrientation = Button.IconOrientation.Top,
                IconPadding = new Extents(0, 0, 50, 0),
                Text = "Press",
                PositionUsesPivotPoint = true,
                ParentOrigin = ParentOrigin.Center,
                PivotPoint = PivotPoint.Center,
            };
            parent2.Add(button2);
            container.Add(parent2);
            maxItem++;

            //---Lottie Switch-------------------------
            var parent3 = new View()
            {
                Size = new Size(itemWidth, itemWidth),
                Position = new Position(720, 0)
            };
            var button3 = new Switch()
            {
                Size = new Size(200, 200),
                PositionUsesPivotPoint = true,
                ParentOrigin = ParentOrigin.Center,
                PivotPoint = PivotPoint.Center,
            };
            parent3.Add(button3);
            container.Add(parent3);
            maxItem++;

            //---Lottie CheckBox-------------------------
            var parent4 = new View()
            {
                Size = new Size(itemWidth, itemWidth),
                Position = new Position(1440, 0)
            };
            var button41 = new CheckBox()
            {
                Size = new Size(100, 100),
                Position = new Position(0, -50),
                PositionUsesPivotPoint = true,
                ParentOrigin = ParentOrigin.Center,
                PivotPoint = PivotPoint.Center,
                IsSelected = true,
            };
            var button42 = new CheckBox()
            {
                Size = new Size(100, 100),
                Position = new Position(0, 50),
                PositionUsesPivotPoint = true,
                ParentOrigin = ParentOrigin.Center,
                PivotPoint = PivotPoint.Center,
            };
            parent4.Add(button41);
            parent4.Add(button42);
            container.Add(parent4);
            maxItem++;

            //---Lottie RadioButton-------------------------
            var parent5 = new View()
            {
                Size = new Size(itemWidth, itemWidth),
                Position = new Position(1080, 0)
            };
            var button51 = new RadioButton()
            {
                Size = new Size(100, 100),
                Position = new Position(0, -50),
                PositionUsesPivotPoint = true,
                ParentOrigin = ParentOrigin.Center,
                PivotPoint = PivotPoint.Center,
                IsSelected = true,
            };
            var button52 = new RadioButton()
            {
                Size = new Size(100, 100),
                Position = new Position(0, 50),
                PositionUsesPivotPoint = true,
                ParentOrigin = ParentOrigin.Center,
                PivotPoint = PivotPoint.Center,
            };
            var group = new RadioButtonGroup();
            group.Add(button51);
            group.Add(button52);
            parent5.Add(button51);
            parent5.Add(button52);
            container.Add(parent5);
            maxItem++;

            window.Add(container);


            // Prev/Next button
            goLeft = new Control()
            {
                Position = new Position(-50, 0),
                Size = new Size(100, 100),
                CornerRadius = 50,
                PositionUsesPivotPoint = true,
                ParentOrigin = ParentOrigin.CenterLeft,
                PivotPoint = PivotPoint.CenterLeft,
            };
            goLeft.Style.BackgroundColor =  new Selector<Color>
            {
                Other = new Color(0.3f, 0.3f, 0.3f, 0.7f),
                Pressed = new Color(0.3f, 0.3f, 0.3f, 0.4f),
            };
            goLeft.TouchEvent += OnGoLeft;
            window.Add(goLeft);

            goRight = new Control()
            {
                Position = new Position(50, 0),
                Size = new Size(100, 100),
                CornerRadius = 50,
                PositionUsesPivotPoint = true,
                ParentOrigin = ParentOrigin.CenterRight,
                PivotPoint = PivotPoint.CenterRight,
            };
            goRight.Style.BackgroundColor =  new Selector<Color>
            {
                Other = new Color(0.3f, 0.3f, 0.3f, 0.7f),
                Pressed = new Color(0.3f, 0.3f, 0.3f, 0.4f),
            };
            goRight.TouchEvent += OnGoRight;
            window.Add(goRight);
        }

        bool OnGoLeft(object target, View.TouchEventArgs args)
        {
            if (args.Touch.GetState(0) != PointStateType.Down || currentItem == 0)
            {
                return false;
            }

            currentItem--;

            if (animation == null)
            {
                animation = new Animation(200);
            }
            else
            {
                animation.Stop();
                animation.Clear();
            }

            animation.AnimateTo(container, "PositionX", -itemWidth * currentItem, new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseOut));
            animation.Play();

            return true;
        }

        bool OnGoRight(object target, View.TouchEventArgs args)
        {
            if (args.Touch.GetState(0) != PointStateType.Down || currentItem == maxItem - 1)
            {
                return false;
            }

            currentItem++;

            if (animation == null)
            {
                animation = new Animation(200);
            }
            else
            {
                animation.Stop();
                animation.Clear();
            }

            animation.AnimateTo(container, "PositionX", -itemWidth * currentItem, new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseOut));
            animation.Play();

            return true;
        }
        

    }
}
