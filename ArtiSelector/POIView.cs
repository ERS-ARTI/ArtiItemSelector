using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Arti;

namespace ArtiItemSelector {
    public class POIView {
        private readonly TextBox _description;
        private readonly TreeView _tree;

        private class InstEventInfo {
            public ArtiSwClassEvent ClassEvent   { get; set; }
            public ArtiSwInstanceEvent InstEvent { get; set; }
            public ArtiSwInstance Instance { get; set; }
        }
        public POIView(TreeView tree, TextBox description) {
            this._tree = tree;
            this._description = description;
        }

        public void LoadEvents(List<ArtiSwClass> classes, List<ArtiSwInstance> instances) {
            _description.Text = "";
            _tree.Nodes.Clear();

            // The events come from the classes that an instance implements
            foreach (var instance in instances) {
                var n = new TreeNode(instance.Name) { Tag = instance };
                _tree.Nodes.Add(n);
                foreach (var classname in instance.ClassNames) {
                    foreach (var @class in classes) {
                        if (@class.Name == classname) {
                            foreach (var class_event in @class.Events) {
                                var inst_event = instance.Events.Find(x => x.Name == class_event.Name);
                                var info = new InstEventInfo() { ClassEvent = class_event, InstEvent = inst_event, Instance = instance };
                                var inst_node = new TreeNode(class_event.Name) { Tag = info };
                                if (!string.IsNullOrEmpty(inst_event?.PointOfInterest)) {
                                    inst_node.ForeColor = Color.Crimson;
                                    inst_node.Text += $" ({inst_event?.PointOfInterest})";
                                }
                                n.Nodes.Add(inst_node);
                            }
                        }
                    }
                }
                n.Expand();
            }
        }

        private static string SplitLines(string description) {
            if (string.IsNullOrEmpty(description)) {
                return description;
            }
            return description.Replace("\n", "\r\n\r\n");
        }
        public void SelectionChanged(TreeViewEventArgs e) { 
            var ev = e.Node.Tag as InstEventInfo;
            if (ev != null) {
                _description.Text = $"{ev.Instance.Name}: { SplitLines(ev.ClassEvent.Description) }\r\n\r\n(Double-click to change)";
            }
            var inst = e.Node.Tag as ArtiSwInstance;
            if (inst != null) {
                _description.Text = $"{inst.Name} supports the events from: {string.Join(", ", inst.ClassNames)}";
            }
        }

        public void EditRequest() {
            var node = _tree.SelectedNode;
            var ev = node.Tag as InstEventInfo;
            if (ev == null) {
                return;
            }
            var poi = "";
            if (ev.InstEvent != null) {
                poi = ev.InstEvent.PointOfInterest;
            }

            var dlg = new TextInput("Point of Interest", "Enter name", poi);
            var new_poi = dlg.Run();
            if (new_poi != poi) {
                if (string.IsNullOrEmpty(new_poi)) {
                    if (ev.InstEvent != null) {
                        ev.InstEvent.RemovePointOfInterest();
                        node.Text = ev.ClassEvent.Name;
                        node.ForeColor = Color.FromName("WindowText");
                    }
                }
                else {
                    ev.Instance.SetPointOfInterest(ev.ClassEvent.Name, new_poi);
                    node.ForeColor = Color.Crimson;
                    node.Text = $"{ev.ClassEvent.Name} ({new_poi})";
                }
            }
        }
    }
}