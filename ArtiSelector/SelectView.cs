using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Arti;

namespace ArtiItemSelector {
    public class SelectView {
        private readonly TextBox _description;
        private readonly TreeView _tree;

        public SelectView(TextBox description, TreeView tree) {
            _description = description;
            _tree = tree;
        }

        public void SelectionChanged(TreeViewEventArgs e) {
            var ev = e.Node.Tag as ArtiSwClassEvent;
            if (ev != null) {
                _description.Text = SplitLines(ev.Description);
            }
            var st = e.Node.Tag as ArtiSwClassState;
            if (st != null) {
                _description.Text = SplitLines(st.Description);
            }
            var cls = e.Node.Tag as ArtiSwClass;
            if (cls != null) {
                _description.Text = SplitLines(cls.Description);
            }
        }

        private static string SplitLines(string description) {
            if (string.IsNullOrEmpty(description)) {
                return description;
            }
            return description.Replace("\n", "\r\n\r\n");
        }

        public void LoadEvents(List<ArtiSwClass> classes) {
            _description.Text = "";
            _tree.Nodes.Clear();
            _tree.CheckBoxes = true;
            foreach (var cls in classes) {
                if (cls.Events.Count > 0) {
                    var n = new TreeNode(cls.Name) { Checked = cls.Selected, Tag = cls };
                    _tree.Nodes.Add(n);
                    foreach (var ev in cls.Events) {
                        var e = new TreeNode(ev.Name) { Checked = ev.Selected, Tag = ev };
                        n.Nodes.Add(e);
                    }
                    n.Expand();
                }
            }
        }

        public void LoadStates(List<ArtiSwClass> classes) {
            _description.Text = "";
            _tree.Nodes.Clear();
            _tree.CheckBoxes = true;
            foreach (var cls in classes) {
                if (cls.States.Count > 0) {
                    var n = new TreeNode(cls.Name) { Checked = cls.Selected, Tag = cls };
                    _tree.Nodes.Add(n);
                    foreach (var st in cls.States) {
                        var e = new TreeNode(st.Name) { Checked = st.Selected, Tag = st };
                        n.Nodes.Add(e);
                    }
                    n.Expand();
                }
            }
        }

        public void CheckboxChanged(TreeViewEventArgs e) {
            var ev = e.Node.Tag as ArtiSwClassEvent;
            if (ev != null) {
                ev.Selected = e.Node.Checked;
            }
            var st = e.Node.Tag as ArtiSwClassState;
            if (st != null) {
                st.Selected = e.Node.Checked;
            }
            var cls = e.Node.Tag as ArtiSwClass;
            if (cls != null) {
                cls.Selected = e.Node.Checked;
                foreach (TreeNode node in e.Node.Nodes) {
                    node.Checked = e.Node.Checked;
                }
            }
        }
    }
}