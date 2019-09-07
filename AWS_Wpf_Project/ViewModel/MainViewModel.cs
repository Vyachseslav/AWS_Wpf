using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AWS_Wpf_Project.View;

namespace AWS_Wpf_Project.ViewModel
{
    public class MainViewModel
    {
        #region fields

        private RelayCommand _openHandbooksCommand;

        #endregion

        #region Commands

        public RelayCommand OpenHandbookCommand
        {
            get
            {
                return _openHandbooksCommand ??
                  (_openHandbooksCommand = new RelayCommand(obj =>
                  {
                      Handbook handbook = new Handbook();
                      handbook.Show();
                  }));
            }
        }

        #endregion
    }
}
