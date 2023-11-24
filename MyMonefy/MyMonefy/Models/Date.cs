using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MyMonefy.Models
{
    public class Date
    {
        public DateTime date { get; set; }

        public ObservableCollection<Category> Categories { get; set; } = new ObservableCollection<Category>()
        {
            new Category() { Name = "Balance", Costs =0 },
            new Category() { Name = "Food", Costs =0 , Color = Colors.DarkOliveGreen},
            new Category() { Name = "House", Costs =0 , Color = Colors.CornflowerBlue},
            new Category() { Name = "Communication", Costs =0 , Color = Colors.Violet},
            new Category() { Name = "Transport", Costs =0 , Color = Colors.DarkOrange},
            new Category() { Name = "Taxi", Costs =0 , Color = Colors.Yellow},
            new Category() { Name = "Car", Costs =0 , Color = Colors.DarkGray},
            new Category() { Name = "Alcohol", Costs =0 , Color = Colors.LightCoral},
            new Category() { Name = "Clothes", Costs =0 , Color = Colors.DarkSlateBlue},
            new Category() { Name = "Grocery", Costs =0 , Color = Colors.HotPink},
            new Category() { Name = "Hygiene", Costs =0 , Color = Colors.DodgerBlue},
            new Category() { Name = "Spotify", Costs =0 , Color = Colors.LimeGreen},
            new Category() { Name = "Health", Costs =0 , Color = Colors.Red}
        };

        public Date(DateTime _date)
        {
            date =_date;
        }
    }
}
