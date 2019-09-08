using AWS_Wpf_Project.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AWS_Wpf_Project.ViewModel
{
    public class HandbookViewModel : ViewModelBase
    {
        private IModable _selectedModel;
        private DataTable _selectedDataTable;

        private DataTable _fittingTable;
        private DataTable _briefcaseTable;
        private DataTable _componentGroupTable;
        private DataTable _equipmentTable;

        private DataRowView _selectedFitting;
        private DataRowView _selectedBriefcase;
        private DataRowView _selectedcomponentGroup;
        private DataRowView _selectedEquipment;

        private int _rowCount;
        

        public int RowCount
        {
            get { return _rowCount; }
            set
            {
                _rowCount = value;
                OnPropertyChanged();
            }
        }

        public DataTable FittingTable
        {
            get { return _fittingTable; }
            set
            {
                _fittingTable = value;
                OnPropertyChanged("FittingTable");
            }
        }

        public DataRowView SelectedFitting
        {
            get { return _selectedFitting; }
            set
            {
                _selectedFitting = value;
                OnPropertyChanged("SelectedFitting");
            }
        }

        public DataTable BriefcaseTable
        {
            get { return _briefcaseTable; }
            set
            {
                _briefcaseTable = value;
                OnPropertyChanged("BriefcaseTable");
            }
        }

        public DataRowView SelectedBriefcase
        {
            get { return _selectedBriefcase; }
            set
            {
                _selectedBriefcase = value;
                OnPropertyChanged("SelectedBriefcase");
            }
        }

        public DataTable ComponentGroupTable
        {
            get { return _componentGroupTable; }
            set
            {
                _componentGroupTable = value;
                OnPropertyChanged("ComponentGroupTable");
            }
        }

        public DataRowView SelectedComponentGroup
        {
            get { return _selectedcomponentGroup; }
            set
            {
                _selectedcomponentGroup = value;
                OnPropertyChanged();
            }
        }

        public DataTable EquipmentTable
        {
            get { return _equipmentTable; }
            set
            {
                _equipmentTable = value;
                OnPropertyChanged("EquipmentTable");
            }
        }

        public DataRowView SelectedEquipment
        {
            get { return _selectedEquipment; }
            set
            {
                _selectedEquipment = value;
                OnPropertyChanged("SelectedEquipment");
            }
        }

        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                string filterString = String.Empty;
                if (!String.IsNullOrEmpty(_searchText))
                {
                    filterString = "[Name] like '%" + _searchText + "%' OR [ComponentGroup] like '%" + _searchText + "%'";
                }
                else
                {
                    filterString = String.Empty;
                }
                _selectedDataTable.DefaultView.RowFilter = filterString;
                OnPropertyChanged();
            }
        }

        private RelayCommand _openHandbooksCommand;
        public RelayCommand OpenHandbookCommand
        {
            get
            {
                return _openHandbooksCommand ??
                  (_openHandbooksCommand = new RelayCommand(obj =>
                  {
                      MessageBox.Show(SearchText);
                  }));
            }
        }

        private RelayCommand _activateTab;
        public RelayCommand ActivateTabCommand
        {
            get
            {
                return _activateTab ??
                  (_activateTab = new RelayCommand(obj =>
                  {
                      int index = (int)obj;
                      switch(index)
                      {
                          case 0:
                              _selectedModel = new Model.FittingModel();
                              _selectedDataTable = FittingTable;
                              break;
                          case 1:
                              _selectedModel = new Model.BriefcaseModel();
                              _selectedDataTable = BriefcaseTable;
                              break;
                          case 2:
                              _selectedModel = new Model.ComponentGroupModel();
                              _selectedDataTable = ComponentGroupTable;
                              break;
                          case 3:
                              _selectedModel = new Model.EquipmentModel();
                              _selectedDataTable = EquipmentTable;
                              break;
                          default:
                              _selectedModel = new Model.FittingModel();
                              _selectedDataTable = FittingTable;
                              break;
                      }

                      RowCount = _selectedDataTable.Rows.Count;
                  }));
            }
        }


        public HandbookViewModel()
        {
            _ = Load();

            _selectedModel = new Model.FittingModel();            
        }

        private async Task Load()
        {
            FittingTable = await Model.FittingModel.LoadAsync();
            SelectedFitting = FittingTable.Rows[0].Table.AsDataView()[0];
            RowCount = FittingTable.Rows.Count;
            _selectedDataTable = FittingTable;

            BriefcaseTable = await Model.BriefcaseModel.LoadAsync();
            SelectedBriefcase = BriefcaseTable.Rows[0].Table.AsDataView()[0];

            ComponentGroupTable = Model.ComponentGroupModel.Load();
            SelectedComponentGroup = ComponentGroupTable.Rows[0].Table.AsDataView()[0];

            EquipmentTable = await Model.EquipmentModel.LoadAsync();
            SelectedEquipment = EquipmentTable.Rows[0].Table.AsDataView()[0];
        }
    }
}
