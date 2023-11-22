using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMonefy.Models
{
    public class Date
    {
        public DateTime date { get; set; }

        public ObservableCollection<Category> Categories { get; set; } = new ObservableCollection<Category>()
        {
            new Category() { Name = "Balance", Costs =0 },
            new Category() { Name = "Food", Costs =0 },
            new Category() { Name = "House", Costs =0 },
            new Category() { Name = "Communication", Costs =0 },
            new Category() { Name = "Transport", Costs =0 },
            new Category() { Name = "Taxi", Costs =0 },
            new Category() { Name = "Car", Costs =0 },
            new Category() { Name = "Alcohol", Costs =0 },
            new Category() { Name = "Clothes", Costs =0 },
            new Category() { Name = "Grocery", Costs =0 },
            new Category() { Name = "Hygiene", Costs =0 },
            new Category() { Name = "Spotify", Costs =0 },
            new Category() { Name = "Health", Costs =0 }
        };

        public Date(DateTime _date)
        {
            date =_date;
        }
    }
}
