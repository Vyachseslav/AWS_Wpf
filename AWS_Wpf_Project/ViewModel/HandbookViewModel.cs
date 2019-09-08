using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS_Wpf_Project.ViewModel
{
    public class HandbookViewModel : ViewModelBase
    {
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

        public HandbookViewModel()
        {
            _ = Load();
        }

        private async Task Load()
        {
            FittingTable = await Model.FittingModel.LoadAsync();
            SelectedFitting = FittingTable.Rows[0].Table.AsDataView()[0];

            BriefcaseTable = await Model.BriefcaseModel.LoadAsync();
            SelectedBriefcase = BriefcaseTable.Rows[0].Table.AsDataView()[0];

            ComponentGroupTable = Model.ComponentGroupModel.Load();
            SelectedComponentGroup = ComponentGroupTable.Rows[0].Table.AsDataView()[0];

            EquipmentTable = await Model.EquipmentModel.LoadAsync();
            SelectedEquipment = EquipmentTable.Rows[0].Table.AsDataView()[0];
        }
    }
}
