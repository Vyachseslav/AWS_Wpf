using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS_Wpf_Project.Interface
{
    public interface IModable
    {
        DataTable Load();
        Task<DataTable> LoadAsync();
    }
}
