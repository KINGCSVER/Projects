using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using MyMonefy.ViewModels;

namespace MyMonefy.Services.Classes;

public class ChartManager
{
    public DataViewModel Data;

    public ChartManager(DataViewModel _data)
    {
        Data = _data;
    }
    public void UpdateChart()
    {
        Data.PieChart.Series.Clear();
        foreach (var item in Data.dates)
        {
            foreach (var j in item.Categories)
            {
                if (j.Name != item.Categories[0].Name)
                {
                    Data.PieChart.Series.Add(new PieSeries()
                    {
                        Fill = new SolidColorBrush(j.Color),
                        Values = new ChartValues<double>
                    {
                        j.Costs
                    }
                    });
                }
            }
        }
    }
}
