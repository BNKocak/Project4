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
    class iChart
    {
        public SfChart Create(Activity cls, string name)
        {
            SfChart chart = new SfChart(cls);

            //Initializing Primary Axis

            CategoryAxis primaryAxis = new CategoryAxis();

            primaryAxis.Title.Text = "Month";

            chart.PrimaryAxis = primaryAxis;

            //Initializing Secondary Axis

            NumericalAxis secondaryAxis = new NumericalAxis();

            secondaryAxis.Title.Text = "Temperature";

            chart.SecondaryAxis = secondaryAxis;

            DataModel dataModel = new DataModel();

            if(name == "Line")
            {
                chart.Series.Add(new LineSeries()
                {
                    DataSource = dataModel.HighTemperature
                });
            }
            if(name == "Bar")
            {
                chart.Series.Add(new BarSeries()
                {
                    DataSource = dataModel.HighTemperature
                });
            }
            if(name == "Pie")
            {
                chart.Series.Add(new PieSeries()
                {
                    DataSource = dataModel.HighTemperature
                });
            }
            

            return chart;
        }
    }
}