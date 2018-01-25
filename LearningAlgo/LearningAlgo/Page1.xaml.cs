using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LearningAlgo
{
    /// <summary>
    /// aa
    /// </summary>
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page1 : ContentPage
	{
		public Page1 ()
		{
			InitializeComponent ();
		}

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            Box1.TranslateTo(100, 100);
            Box1.WidthRequest = 100;
            Box1.HeightRequest = 100;
            Box1.BackgroundColor = Color.Red;

            Box2.TranslateTo(200, 400);
            Box2.WidthRequest = 100;
            Box2.HeightRequest = 100;
            Box2.BackgroundColor = Color.Blue;
        }

        /*
        async void Tapped(object sender, EventArgs args)
        {
            var rc = Box1.Bounds;
            
            // Box1.LayoutTo(rc);
            // await Box1.LayoutTo(new Rectangle(10 - Box1.TranslationX, 30 - Box1.TranslationY, 100, 100), 1000);

            System.Diagnostics.Debug.WriteLine("deg : {0}, {1}, {2}, {3}", Box1.X, Box1.Y, Box1.Width, Box1.Height);

            rc = Box1.Bounds;
            rc.X = 100;
            rc.Y = 100;
            await Box1.LayoutTo(new Rectangle(0, 0, 100, 100), 1000);

            

            Box1.BackgroundColor = Color.Black;

            System.Diagnostics.Debug.WriteLine("deg : {0}, {1}, {2}, {3}", Box1.TranslationX, Box1.TranslationY, rc.Width, rc.Height);
            System.Diagnostics.Debug.WriteLine("deg : {0}, {1}, {2}, {3}", Box1.X, Box1.Y, rc.Width, rc.Height);
        }
        */
	}
}