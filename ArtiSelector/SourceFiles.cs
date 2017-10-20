using System.Collections;
using System.IO;
using System.Windows.Forms;

namespace ArtiItemSelector {

    /// <summary>
    /// Object to attach key/value pair to a ListBox item
    /// </summary>
    internal class SourceData {
        private string Item { get; }
        public string Value { get; }

        public SourceData(string name, string value) {
            Item = name;
            Value = value;
        }

        public override string ToString() {
            return Item;
        }
    }

    /// <summary>
    /// Wrapper for the list box that holds the source file list
    /// </summary>
    public class SourceFiles {
        private readonly ListBox _list_of_files;

        public SourceFiles(ListBox listOfFiles) {
            _list_of_files = listOfFiles;
        }

        public int SelectedIndex {
            get {
                return _list_of_files.SelectedIndex;
            }
            set {
                _list_of_files.SelectedIndex = value;
            }
        }

        public string SelectedFile {
            get {
                var data_source = _list_of_files.Items[_list_of_files.SelectedIndex] as SourceData;
                if (data_source != null) {
                    var file = data_source.Value;
                    return file;
                }
                return "";
            }
        }

        public bool Visible {
            get { return _list_of_files.Visible; }
            set { _list_of_files.Visible = value; }
        }

        public void Load(IEnumerable fileNames) {
            var orig = _list_of_files.SelectedIndex;
            _list_of_files.Items.Clear();
            foreach (string file in fileNames) {
                var f = Path.GetFileName(file);
                _list_of_files.Items.Add(new SourceData(f, file));
            }
            if (orig < _list_of_files.Items.Count) {
                _list_of_files.SelectedIndex = orig;
            }
            if (_list_of_files.SelectedIndex < 0) {
                _list_of_files.SelectedIndex = _list_of_files.Items.Count - 1;
            }
        }
    }
}