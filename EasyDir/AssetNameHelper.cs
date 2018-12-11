using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;


namespace EasyDir
{
    class AssetNameHelper
    {
        public static readonly AssetNameHelper instance = new AssetNameHelper();
        private CheckedListBox checkedList;

        public CheckedListBox CheckedListBoxControl
        {
            get => checkedList;
            set => checkedList = value;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private AssetNameHelper() { }
        private string _nodeName = "Asset_Name";

        public string NodeName
        {
            get
            {
                GetSelNodeName();
                return _nodeName;
            }

            set
                {
                    if (_nodeName!=value)
                    {
                        _nodeName = value;
                        Notify("NodeName");
                        RenameNode(value);
                    
                    }
                }
        }

        public CheckedListBox CheckedList { get => checkedList; set => checkedList = value; }
        public CheckedListBox CheckedList1 { get => checkedList; set => checkedList = value; }

        public void AddNode(string _name)
        {
            checkedList.Items.Add(_name,true);
        }

        public void AddNodes(List<string> _names)
        {
            if( _names!= null && _names.Count>0)
            {
                bool flag = true;

                if (_names.Count>9)
                {
                    var AddDlg = MessageBox.Show((_names.Count.ToString()) + " Names Patterns will be added.\nAdd them ?", "Add Names Patterns",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (AddDlg == DialogResult.No)
                        flag = false;
                  
                }

                if(flag)
                {
                    foreach (var _name in _names)
                    {
                        AddNode(_name);
                    }
                }
            }
        }

        public void RemoveNode()
        {
            if(checkedList.Items.Count>0 && checkedList.SelectedItems.Count>0)
            {
                checkedList.Items.Remove(checkedList.SelectedItem);
            }
        }

        public void ClearAll ()
        {
            if(checkedList.Items.Count>0)
            {
                checkedList.Items.Clear();
            }

        }


        public void CheckUnCheckll( bool _check)
        {
            if (checkedList.Items.Count > 0)
            {
                for (int i = 0; i < checkedList.Items.Count; i++)
                {
                    checkedList.SetItemChecked(i, _check);
                }
            }
        }
    
        public void InvertAll()
        {
            if (checkedList.Items.Count > 0)
            {
                for (int i = 0; i < checkedList.Items.Count; i++)
                {
                    checkedList.SetItemChecked(i, !checkedList.GetItemChecked(i));
                }
            }
        }

        public void RemoveCheked()
        {
            if (checkedList.Items.Count > 0)
            {
                List<object> _toRemove = new List<object>();
                for (int i = 0; i < checkedList.Items.Count; i++)
                {
                    if (checkedList.GetItemChecked(i) == true)
                    {
                        _toRemove.Add(checkedList.Items[i]);
                    }
                }

                _toRemove.ForEach(x => checkedList.Items.Remove(x));

                for (int i = 0; i < checkedList.Items.Count; i++)
                {
                    checkedList.SetItemChecked(i, false);
                }
                _toRemove = null;
            }
        }

        public void RenameNode(string _name)
        {
            if (String.IsNullOrEmpty(_name) == false &&
                checkedList.Items.Count>0 &&
                checkedList.SelectedItems.Count>0)
            {
                checkedList.Items[checkedList.SelectedIndex] = _name;
            }
        }

        private void GetSelNodeName()
        {
            if (checkedList.Items.Count>0 && checkedList.SelectedItems.Count>0)
            {
                _nodeName = checkedList.Items[checkedList.SelectedIndex].ToString();
            }
        }

        protected void Notify(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public List<string> GetNames()
        {
            List<string> AssetNames = new List<string>();
            if (checkedList == null || checkedList.Items.Count == 0)
            {
                return AssetNames;
            }
            else
            {
                for (int i =0; i<checkedList.Items.Count; i++)
                {
                    if(checkedList.GetItemChecked(i) == true &&  
                        String.IsNullOrEmpty(checkedList.Items[i].ToString()) == false)
                    {
                        if(AssetNames.Contains(checkedList.Items[i].ToString()) == false)
                        {
                            AssetNames.Add(checkedList.Items[i].ToString());
                        }
                    }
                }
                return AssetNames;
            }
        }
    }
}
