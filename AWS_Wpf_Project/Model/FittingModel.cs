﻿using AWS_Wpf_Project.Sql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS_Wpf_Project.Model
{
    public class FittingModel : ViewModelBase
    {
        private int _id;
        private string _name;
        private double _price;
        private string _componentGroup;

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

        public string ComponentGroup
        {
            get { return _componentGroup; }
            set { _componentGroup = value; OnPropertyChanged("ComponentGroup"); }
        }

        public FittingModel() { }

        public FittingModel(int id, string name, double price, string componentGroup)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.ComponentGroup = componentGroup;
        }

        public static DataTable Load()
        {
            return new MainSqlMethod().LoadData("exec ShowFittings");
        }

        public static async Task<DataTable> LoadAsync()
        {
            return await Task.Run(() => Load());
        }
    }
}
