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
        private Model.FittingModel FittingModel { get; set; }
        private Model.BriefcaseModel BriefcaseModel { get; set; }
        private Model.ComponentGroupModel ComponentGroupModel { get; set; }
        private Model.EquipmentModel EquipmentModel { get; set; }


        private int _selectedTabIndex = 0;
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

        private RelayCommand _refreshCommand;
        

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
                    switch(_selectedTabIndex)
                    {
                        case 0:
                            filterString = $"[Name] like '%{_searchText}%' OR [ComponentGroup] like '%{_searchText}%'";
                            break;
                        case 1:
                            filterString = $"[Name] like '%{_searchText}%' OR [Description] like '%{_searchText}%'";
                            break;
                        case 2:
                            filterString = $"[Name] like '%{_searchText}%'";
                            break;
                        case 3:
                            filterString = $"[Name] like '%{_searchText}%' OR [Description] like '%{_searchText}%'";
                            break;
                        default:
                            filterString = "[Name] like '%" + _searchText + "%' OR [ComponentGroup] like '%" + _searchText + "%'";
                            break;
                    }                    
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
                      _selectedTabIndex = index;
                      switch(index)
                      {
                          case 0:
                              _selectedModel = FittingModel;
                              _selectedDataTable = FittingTable;
                              break;
                          case 1:
                              _selectedModel = BriefcaseModel;
                              _selectedDataTable = BriefcaseTable;
                              break;
                          case 2:
                              _selectedModel = ComponentGroupModel;
                              _selectedDataTable = ComponentGroupTable;
                              break;
                          case 3:
                              _selectedModel = EquipmentModel;
                              _selectedDataTable = EquipmentTable;
                              break;
                          default:
                              _selectedModel = FittingModel;
                              _selectedDataTable = FittingTable;
                              break;
                      }

                      RowCount = _selectedDataTable.Rows.Count;
                  }));
            }
        }


        public HandbookViewModel()
        {
            FittingModel = new Model.FittingModel();
            BriefcaseModel = new Model.BriefcaseModel();
            ComponentGroupModel = new Model.ComponentGroupModel();
            EquipmentModel = new Model.EquipmentModel();

            _ = Load();

            _selectedModel = new Model.FittingModel();            
        }

        private async Task Load()
        {
            FittingTable = await FittingModel.LoadAsync();
            SelectedFitting = FittingTable.Rows[0].Table.AsDataView()[0];
            RowCount = FittingTable.Rows.Count;
            _selectedDataTable = FittingTable;

            BriefcaseTable = await BriefcaseModel.LoadAsync();
            SelectedBriefcase = BriefcaseTable.Rows[0].Table.AsDataView()[0];

            ComponentGroupTable = await ComponentGroupModel.LoadAsync();
            SelectedComponentGroup = ComponentGroupTable.Rows[0].Table.AsDataView()[0];

            EquipmentTable = await EquipmentModel.LoadAsync();
            SelectedEquipment = EquipmentTable.Rows[0].Table.AsDataView()[0];
        }

        private async void Refresh()
        {
            _selectedDataTable = await Task.Run(() => _selectedModel.LoadAsync());
        }

        public RelayCommand RefreshCommand
        {
            get
            {
                return _refreshCommand ??
                  (_refreshCommand = new RelayCommand(obj =>
                  {
                      Refresh();
                  }));
            }
        }
    }
}
