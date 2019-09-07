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
            using (SqlConnection conn = new SqlConnection(Connection.MainConnection.MainConn))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    string commandText = "exec ShowFittings";
                    cmd.CommandText = commandText;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da = new SqlDataAdapter(cmd);
                    ds = new DataSet();
                    da.Fill(ds);

                    return ds.Tables[0];
                }
            }
        }

        public static async Task<DataTable> LoadAsync()
        {
            return await Task.Run(() => Load());
        }
    }
}
