using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LearningAlgo
{
	public partial class MainPage : ContentPage
	{
        int Count;

		public MainPage()
		{
			InitializeComponent();

            var list = new List<Tracer.PrintTable>
            {
                new Tracer.PrintTable
                {
                    FlowID = "1",
                    PrintID = "2",
                },
                new Tracer.PrintTable
                {
                    FlowID = "2",
                    PrintID = "3",
                },
                new Tracer.PrintTable
                {
                    FlowID = "3",
                    PrintID = ":END",
                },
                new Tracer.PrintTable
                {
                    FlowID = "4",
                    PrintID = "1",
                },
            };

            Tracer.Trace(null, list);
		}

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            Dialog.LayoutTo(new Rectangle(width, 100, 200, 200), 0);
        }

        private void OnClick(object sender, EventArgs args)
        {
            /*
            MainLayout.Children.Add(new Label{ Text = Count.ToString(), },
                Constraint.RelativeToParent(view => 0),
                Constraint.RelativeToParent(view => 100 + Count),
                Constraint.RelativeToParent(view => 20),
                Constraint.RelativeToParent(view => 20));
               */
            Count += 20;

            Sub.Children.Add(new Label { Text = Count.ToString()});
        }

    }
}
