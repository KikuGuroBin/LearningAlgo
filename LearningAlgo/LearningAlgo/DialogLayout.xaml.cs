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
	public partial class DialogLayout : ContentView
	{
		public DialogLayout ()
		{
			InitializeComponent ();
		}

        private async void OnClick(object sender, EventArgs args)
        {
            var rc = Bounds;
            rc.X += 100;
            await this.LayoutTo(rc, 100);
            
            rc.Y += 100;
            await this.LayoutTo(rc, 250);

            rc.X -= 100;
            await this.LayoutTo(rc, 200);

            rc.Y -= 100;
            await this.LayoutTo(rc, 50);
        }
	}
}