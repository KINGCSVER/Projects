using MyMonefy.Models;
using MyMonefy.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMonefy.Services.Classes;

public class CurrentDateManager
{
    public DataViewModel Data;
    public DateTime _currentDate = DateTime.Today;

    public CurrentDateManager(DataViewModel _data)
    {
        Data = _data;
    }

    public void CurrentDateUpdate()
    {
        if (Data.dates.Count != 0)
        {
            foreach (var _date in Data.dates)
            {
                if (_date.date == _currentDate)
                {
                    return;
                }
            }
            Date newDate = new Date(_currentDate);
            Data.dates.Add(newDate);
        }
        else
        {
            Date newDate = new Date(_currentDate);
            Data.dates.Add(newDate);
        }
    }
}
