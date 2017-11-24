using System;

using Xamarin.Forms;

namespace LearningAlgo
{
    public class Test1 : ContentPage
    {
        public Test1()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

