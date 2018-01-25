using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LearningAlgo
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page4 : ContentPage
	{
        bool Showing;

        private StackLayout stack;

        private int[] bounds = new int[4];
        
		public Page4 ()
		{
			InitializeComponent ();

            stack = new StackLayout
            {
                Children =
                {
                    new Label{ Text = "aaa"},
                    new Label{ Text = "bbb"},
                    new Label{ Text = "ccc"},
                },
                BackgroundColor = Color.Red,
            };

            bounds[0] = 100;
            bounds[1] = 100;

            Main.Children.Add(stack,
                Constraint.RelativeToParent((p) =>
                {
                    return bounds[0];
                }),
                Constraint.RelativeToParent((p) =>
                {
                    return bounds[1];
                }),
                Constraint.RelativeToParent((p) =>
                {
                    return 100;
                }),
                Constraint.RelativeToParent((p) =>
                {
                    return 100;
                })
            );
		}

        int y = 50;

        void OnClick(object sender, EventArgs args)
        {
            var w = y;

            Main.Children.Add(new Label { Text = "ddd" },
                Constraint.RelativeToParent((p) =>
                {
                    return 0;
                }),
                Constraint.RelativeToParent((p) =>
                {
                    return w;
                }),
                Constraint.RelativeToParent((p) =>
                {
                    return 30;
                }),
                Constraint.RelativeToParent((p) =>
                {
                    return 30;
                })
            );

            y += 40;
        }

        async void OnClick2(object sender, EventArgs args)
        {
            var rc = stack.Bounds;
            rc.X += 50;
            rc.Y += 10;

            await stack.LayoutTo(rc);

            bounds[0] += 50;
            bounds[1] += 10;
        }
	}
}