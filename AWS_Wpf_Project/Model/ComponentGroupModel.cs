using System.Data;
using System.Threading.Tasks;
using AWS_Wpf_Project.Interface;
using AWS_Wpf_Project.Sql;

namespace AWS_Wpf_Project.Model
{
    internal class ComponentGroupModel : ViewModelBase, IModable
    {
        private int _id;
        private string _name;

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

        public ComponentGroupModel() { }

        public ComponentGroupModel(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public DataTable Load()
        {
            return new MainSqlMethod().LoadData("exec ShowComponentGroups");
        }

        public async Task<DataTable> LoadAsync()
        {
            return await Task.Run(() => Load());
        }
    }
}
