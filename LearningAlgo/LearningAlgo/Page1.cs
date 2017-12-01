using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace LearningAlgo
{
	public class Page1 : ContentPage
	{
		public Page1 ()
		{
            var b = new Button { Text = "button" };
            b.Clicked += delegate
            {
                var stack = Content as StackLayout;

                stack.Children.Add(new Label { Text = "Text", });
            
            };

            Content = new StackLayout {
				Children = {
                    new Label { Text = "Welcome to Xamarin.Forms!" },
                    b,
                    new BoxView{ WidthRequest = 30, HeightRequest = 30, BackgroundColor = Color.Aqua, TranslationX = Width}
                }
			};
		}

        public void OnClick(object sender, EventHandler args)
        {
            var stack = Content as StackLayout;

            stack.Children.Add(new Label { Text = "Text", });
        }
	}
}