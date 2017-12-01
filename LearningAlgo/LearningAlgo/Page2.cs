using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace LearningAlgo
{
	public class Page2 : ContentPage
	{
        private AbsoluteLayout Relative;

        int count;

		public Page2 ()
		{
            Relative = new AbsoluteLayout();

            var button = new Button
            {
                Text = "fuck me!!!!!",
            };

            button.Clicked += delegate
            {
                count += 50;
                Relative.Children.Add(new Label { Text = count.ToString() }, new Rectangle(0, count, 50, 50));

            };

            Relative.Children.Add(button, new Rectangle(0, 0, 50, 100));
            
            Content = Relative;
		}


	}
}