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
	public partial class Page3 : ContentPage
	{
        int count = 40;

		public Page3 ()
		{
			InitializeComponent ();
		}

        private void OnClick(object sender, EventArgs args)
        {
            count += 30;

            /* アブソリュートレイアウトにインスタンスを追加する */
            Main.Children.Add(new Label { Text = count.ToString()}, new Rectangle(0, count, 100, 50));
        }
	}
}