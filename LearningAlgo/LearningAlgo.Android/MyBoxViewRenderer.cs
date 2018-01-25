using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

using LearningAlgo;
using LearningAlgo.Droid;

[assembly: ExportRenderer(typeof(MyBoxView), typeof(MyBoxViewRenderer))]
namespace LearningAlgo.Droid
{
    public class MyBoxViewRenderer : BoxRenderer
    {
        
        double _gx, _gy; // 初期の相対値
        double _ox, _oy; // 前回の絶対位置

        protected override void OnElementChanged(ElementChangedEventArgs<BoxView> e)
        {
            base.OnElementChanged(e);

            Touch += OnTouch;
        }
        
        private void OnTouch(object sender, TouchEventArgs e)
        {
            switch (e.Event.Action)
            {
                case MotionEventActions.Down:
                    // 初期の相対値を保存
                    _gx = e.Event.GetX();
                    _gy = e.Event.GetY();
                    break;
                case MotionEventActions.Move:
                    // 移動距離を計算
                    double dx = e.Event.RawX - _ox;
                    double dy = e.Event.RawY - _oy;

                    // コールバック呼び出し
                    // TODO: delta 方式なのか誤差が大きい
                    var el = this.Element as MyBoxView;
                    el.OnDrug(el, new DrugArgs(dx, dy));
                    break;
                case MotionEventActions.Up:
                    break;
            }
            // 現在の絶対位置を保存
            _ox = e.Event.RawX;
            _oy = e.Event.RawY;
        }
    }
}