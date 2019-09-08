using AWS_Wpf_Project.Sql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS_Wpf_Project.Model
{
    internal class EquipmentModel : ViewModelBase
    {
        private int _id;
        private string _name;
        private string _description;
        private double _price;

        public int Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged("Id"); }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged("Name"); }
        }

        public double Price
        {
            get { return _price; }
            set { _price = value; OnPropertyChanged("Price"); }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; OnPropertyChanged("Description"); }
        }

        public EquipmentModel() { }

        public EquipmentModel(int id, string name, double price, string description)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.Description = description;
        }

        public static DataTable Load()
        {
            return new MainSqlMethod().LoadData("exec ShowEquipments");
        }

        public static async Task<DataTable> LoadAsync()
        {
            return await Task.Run(() => Load());
        }
    }
}
