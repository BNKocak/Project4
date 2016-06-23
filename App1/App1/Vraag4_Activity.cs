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
using Com.Syncfusion.Charts;

namespace App1
{
    [Activity(Label = "@string/Vraag1")]
    public class Vraag4_Activity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            var iChart = new iChart();

            SfChart chart = iChart.Create(this, "Pie");

            SetContentView(chart);
        }
    }
}