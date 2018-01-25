using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;

namespace LearningAlgo
{
    public class MyBoxView : BoxView
    {
        public void OnDrug(object sender, DrugArgs args)
        {
            var rc = Bounds;
            rc.X += args.X;
            rc.Y += args.Y;

            this.LayoutTo(rc);
        }
    }
}
