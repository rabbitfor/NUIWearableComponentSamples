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
            window.BackgroundColor = Color.White;

            webView = new Tizen.NUI.WebView();
            
            webView.Size = new Size( 500, 500 );

            

            window.Add( webView );
            // webView.LoadUrl( "https://m.naver.com/" );
            webView.LoadHTMLString(
            @"
                <body style='background-color:yellow;margin:0px;padding:0px;'>
                    <div id='abc' style='overflow-wrap:break-word;'></div>
                    <div id='box' style='background-color:black;'></div>
                </body>
                <script>
                    setInterval(function() {
                        document.getElementById('box').style.width = document.body.clientWidth / 2;
                        document.getElementById('box').style.height = document.body.clientHeight / 2;
                        document.getElementById('abc').innerHTML = new Date();
                    }, 1000)
                </script>
            ");

            View view = new View()
            {
                Size = new Size(100, 100),
                Position = new Position(0, 500),
                BackgroundColor = Color.Magenta,
            };
            view.TouchEvent += OnTouchView;

            window.Add(view);

            // View root = new View()
            // {
            //     Size2D = new Size2D(1920, 1080),
            //     BackgroundColor = Color.White,
            //     BoxShadow = new Shadow() {
            //     }
            // };
            // window.Add(root);

            // var view = new Button
            // {
            //     Size = new Size(100, 100),
            //     // MinValue = 0,
            //     // MaxValue = 100,
            //     // CurrentValue = 50,
            //     // BufferValue = 70
            // };
            // root.Add(view);
        }

        bool OnTouchView(object obj, View.TouchEventArgs args)
        {
            if (args.Touch.GetState(0) == PointStateType.Up)
            {
                webView.Size = new Size(1000, 1000);
            }
            return true;
        }

        private Tizen.NUI.WebView webView;
    }
}
