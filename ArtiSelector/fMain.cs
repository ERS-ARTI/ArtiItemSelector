using System;
using System.IO;
using System.Windows.Forms;
using Arti;

namespace ArtiItemSelector {
    public partial class FMain : Form {
        private const string DefaultOutput = "ActiveSubset.arti";
        private const string DefaultProject= "project.arti_project";

        private ArtiProject _m_project;
        private ArtiSwDescription _m_current_sw_description;
        private string _m_project_name = DefaultProject;
        private string _m_output_name = DefaultOutput;
        private readonly SourceFiles _m_sources;
        private readonly ArtiMetaData _m_metadata;
        private readonly SelectView _events_view;
        private readonly SelectView _states_view;
        private readonly POIView _poi_view;

        public FMain() {
            _m_project = new ArtiProject(); // Default empty project
            InitializeComponent();

            _m_sources = new SourceFiles(listOfFiles);
            _m_metadata = new ArtiMetaData(InfoGrid);
            _events_view = new SelectView(TraceItemDescription, TraceTree);
            _states_view = new SelectView(DebugItemDescription, DebugTree);
            _poi_view = new POIView(tvPOI, tbPOI);

            var args = Environment.GetCommandLineArgs();
            if (args.Length > 1) {
                var proposed_file = args[1];
                if (File.Exists(proposed_file)) {
                    var cwd = Path.GetDirectoryName(proposed_file);
                    if (!string.IsNullOrEmpty(cwd)) {
                        Directory.SetCurrentDirectory(cwd);
                    }
                    _m_project_name = args[1];
                    try {
                        _m_project.LoadFromProjectFile(File.ReadAllText(_m_project_name));
                    }
                    catch (Exception e) {
                        MessageBox.Show($"Error reading project file: {_m_project_name} ({e.Message})", "Invalid project file", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        Environment.Exit(1);
                    }
                }

                if (args.Length > 2) {
                    _m_output_name = args[2];
                    SaveMergedText();
                }
            }
        }

        private void FMainShown(object sender, EventArgs e) {
            RefreshViewOfSources();
            CheckDirty();
        }

        private void NewProjectClick(object sender, EventArgs e) {
            CloseProjectClick(sender, e);
            RefreshViewOfSources();
            CheckDirty();
        }

        private void OpenProjectClick(object sender, EventArgs e) {
            if (DoClosed()) {
                if (dlgOpenProject.ShowDialog() == DialogResult.OK) {
                    SetProjectFile(dlgOpenProject.FileName);
                    _m_project = new ArtiProject();
                    _m_project.LoadFromProjectFile(File.ReadAllText(_m_project_name));
                    RefreshViewOfSources();
                }
            }
            CheckDirty();
        }

        private void SetProjectFile(string newFile) {
            _m_project_name = newFile;
            _m_output_name = DefaultOutput;
            var cwd = Path.GetDirectoryName(_m_project_name);
            if (!String.IsNullOrEmpty(cwd)) {
                Directory.SetCurrentDirectory(cwd);
                _m_output_name = Path.Combine(cwd, DefaultOutput);
            }
        }

        private void SaveProjectClick(object sender, EventArgs e) {
            File.WriteAllText(_m_project_name, _m_project.SaveToProjectFile(_m_project_name));
            SaveMergedText();
            _m_project.IsSaved();
            lbProject.Text = _m_project_name;
            CheckDirty();
        }

        private void SaveAsClick(object sender, EventArgs e) {
            dlgSaveProject.FileName = _m_project_name;
            if (dlgSaveProject.ShowDialog() == DialogResult.OK) {
                SaveProjectClick(sender, e);
                if (dlgSaveProject.FileName != _m_project_name) {
                    SetProjectFile(dlgOpenProject.FileName);
                }
            }
            CheckDirty();
        }

        private void SaveMergedText() {
            File.WriteAllText(_m_output_name, _m_project.CreateMergedOutputString("ArtiItemSelector"));
            Dirty(false);
            RefreshFileContentsView();
            CheckDirty();
        }

        private void CloseProjectClick(object sender, EventArgs e) {
            if (DoClosed()) {
                _m_project = new ArtiProject();
                RefreshViewOfSources();
            }
            CheckDirty();
        }

        private bool DoClosed() {
            if (_m_project.Dirty) {
                var dialog_result = MessageBox.Show(@"Save project?", @"Project has changed", MessageBoxButtons.YesNoCancel);
                if (dialog_result == DialogResult.Yes) {
                    File.WriteAllText(_m_project_name, _m_project.SaveToProjectFile(_m_project_name));
                    File.WriteAllText(_m_output_name, _m_project.CreateMergedOutputString("ArtiItemSelector"));
                    _m_project.IsSaved();
                }
                if (dialog_result == DialogResult.Cancel) {
                    return false;
                }
            }
            return true;
        }

        private void AddSourcesClick(object sender, EventArgs e) {
            var open_result = dlgOpen.ShowDialog();
            if (open_result == DialogResult.OK) {
                foreach (var file in dlgOpen.FileNames) {
                    _m_project.AddSource(file);
                }
            }
            RefreshViewOfSources();
            CheckDirty();
        }

        private void RemoveSourceClick(object sender, EventArgs e) {
            if (_m_sources.SelectedIndex >= 0) {
                _m_project.RemoveSource(_m_sources.SelectedFile);
                RefreshViewOfSources();
            }
            CheckDirty();
        }

        private void ExitClick(object sender, EventArgs e) {
            Application.Exit();
        }


        private void SourceSelectionChanged(object sender, EventArgs e) {
            if (_m_sources.SelectedIndex >= 0) {
                var file = _m_sources.SelectedFile;
                _m_current_sw_description = _m_project.GetDescriptionFor(file);
                RefreshViewOfSelectedSource(file);
            }
        }


        private void TraceSelectionChanged(object sender, TreeViewEventArgs e) {
            _events_view.SelectionChanged(e);
        }

        private void DebugSelectionChanged(object sender, TreeViewEventArgs e) {
            _states_view.SelectionChanged(e);
        }

        private void PoiSelectionChanged(object sender, TreeViewEventArgs e) {
            _poi_view.SelectionChanged(e);
        }

        private void PoiEditRequest(object sender, EventArgs e) {
            _poi_view.EditRequest();
            Dirty(true);
        }

        private void PoiKeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == '\r') {
                _poi_view.EditRequest();
                Dirty(true);
            }
        }

        private void TraceCheckboxChanged(object sender, TreeViewEventArgs e) {
            _events_view.CheckboxChanged(e);
            RefreshFileContentsView();
            Dirty(true);
        }

        private void Dirty(bool b) {
            _m_project.Dirty = b;
            CheckDirty();
        }

        private void DebugCheckboxChanged(object sender, TreeViewEventArgs e) {
            _events_view.CheckboxChanged(e);
            RefreshFileContentsView();
            Dirty(true);
            CheckDirty();
        }

        private void RefreshViewOfSources() {
            _m_sources.Load(_m_project.FileNames);
            lbProject.Text = _m_project_name;

            var visible = (_m_sources.SelectedIndex >= 0);

            tabControl.Visible = visible;
            _m_metadata.Visible = visible;
            _m_sources.Visible = visible;
            lbSelectedSourceFile.Visible = visible;
            lbProject.Visible = visible;
            menuSave.Enabled = visible;
            menuSaveAs.Enabled = visible;
            addToProject.Enabled = visible;
            removeFromProject.Enabled = visible;
        }

        private void RefreshViewOfSelectedSource(string filename) {
            _m_metadata.Load(_m_current_sw_description.MetaData); // Info Grid
            _events_view.LoadEvents(_m_current_sw_description.Classes); // Trace Events
            _poi_view.LoadEvents(_m_current_sw_description.Classes, _m_current_sw_description.Instances); // POIs
            _states_view.LoadStates(_m_current_sw_description.Classes); // Debug States
            RefreshFileContentsView(); // Content

            lbSelectedSourceFile.Text = filename;
            lbProject.Text = _m_project_name;
        }

        private void RefreshFileContentsView() {
            CheckDirty();
            if (null != _m_current_sw_description) {
                //FileView.Text = RemoveActiveMemebers(_m_current_sw_description.ToString());
                FileView.Text = _m_current_sw_description.ToString();
            }
        }

        private void CheckDirty() {
            var current = this.Text;
            var new_title = current.Replace("*", "") + (_m_project.Dirty ? "*" : "");
            if (current != new_title) {
                this.Text = new_title;
            }
        }
    }
}
