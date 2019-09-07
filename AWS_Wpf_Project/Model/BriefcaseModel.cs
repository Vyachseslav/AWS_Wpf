using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS_Wpf_Project.Model
{
    internal class BriefcaseModel : ViewModelBase
    {
        private int _id;
        private string _name;
        private string _description;
        private DateTime _createDateTime;

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

        public string Description
        {
            get { return _description; }
            set { _description = value; OnPropertyChanged("Description"); }
        }

        public DateTime CreateDateTime
        {
            get { return _createDateTime; }
            set { _createDateTime = value; OnPropertyChanged("CreateDateTime"); }
        }


        public BriefcaseModel() { }

        public BriefcaseModel(int id, string name, string description, DateTime createDT)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.CreateDateTime = createDT;
        }

        public static DataTable Load()
        {
            using (SqlConnection conn = new SqlConnection(Connection.MainConnection.MainConn))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    string commandText = "exec ShowBriefcases";
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
