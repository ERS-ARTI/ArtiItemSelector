using System.Collections.Generic;
using System.Windows.Forms;
using Arti;

namespace ArtiItemSelector {

    /// <summary>
    /// Object to attach key/value pair to a DataGridView item
    /// </summary>
    // Don't refactor this without running the risk of breaking the info grid
    internal class BindingSourceData {
        private string _value;
        private string _name;
        public string Item => _name;
        public string Value => _value;

        public BindingSourceData(string name, string value) {
            _name = name;
            _value = value;
        }

        public override string ToString() {
            return Item;
        }
    }

    /// <summary>
    /// Wrapper for the data grid
    /// </summary>
    public class ArtiMetaData {
        private readonly DataGridView _info_grid;

        public ArtiMetaData(DataGridView infoGrid) {
            _info_grid = infoGrid;
        }

        public bool Visible {
            set { _info_grid.Visible = value; }
        }

        public void Load(List<ArtiSwNode> metaData) {
            // Info Grid
            var source = new BindingSource();
            var list = new List<BindingSourceData>();
            foreach (var item in metaData) {
                string val;
                if (item.IsArray) {
                    val = string.Join(", ", item.Array());
                }
                else {
                    val = item.Value();
                }
                list.Add(new BindingSourceData(item.Name, val));
            }
            source.DataSource = list;
            _info_grid.DataSource = source;
        }
    }
}