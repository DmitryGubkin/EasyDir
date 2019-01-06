using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace EasyDir
{
    class ComboBoxHelper
    {
       private readonly object[] SearchTypesItmes = { "No Search","Top Folder","All Sub Folders"};
       private readonly object[] NameMatchItems = { "No Name Match", "Match Name", "Absolute Name Match" };
       
        public void FillComboBox(ComboBox _comboBox, ComboBoxTypes _type)
        {
            if (_comboBox != null)
            {
                if(_comboBox.Items.Count>0)
                {
                    _comboBox.Items.Clear();
                }

                object[] _Items = null;

                if(_type == ComboBoxTypes.Search)
                {
                    _Items = SearchTypesItmes;
                }
                if(_type == ComboBoxTypes.NameMatch)
                {
                    _Items = NameMatchItems;
                }

                if (_Items!=null)
                {
                    foreach (var _item in _Items)
                    {
                        _comboBox.Items.Add(_item);
                    }
                    _comboBox.SelectedIndex = 0;
                }
               
            }
        }

       public object GetSearchMode(ComboBox comboBox)
        {
            if (SearchTypesItmes.Contains(comboBox.SelectedItem))
            {
                if(comboBox.SelectedItem == SearchTypesItmes[0])
                {
                    return SearchTypes.None;
                }

                if (comboBox.SelectedItem == SearchTypesItmes[1])
                {
                    return SearchTypes.TopFolder;
                }

                if (comboBox.SelectedItem == SearchTypesItmes[2])
                {
                    return SearchTypes.AllSubFolders;
                }

            }
            return SearchTypes.None;
        }

        public object GetNameMatchMode(ComboBox comboBox)
        {
            if (NameMatchItems.Contains(comboBox.SelectedItem))
            {
                if(comboBox.SelectedItem == NameMatchItems[0])
                {
                    return NameMatchModes.None;
                }

                if (comboBox.SelectedItem == NameMatchItems[1])
                {
                    return NameMatchModes.MatchName;
                }

                if (comboBox.SelectedItem == NameMatchItems[2])
                {
                    return NameMatchModes.AbsoluteMatch;
                }

            }
            return NameMatchModes.None;
        }
    }
}
