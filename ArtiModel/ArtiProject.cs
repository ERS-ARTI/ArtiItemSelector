using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Arti {
    /// <summary>
    /// Represents the overall project, connecting all of the input files
    /// by reading them into a set of ArtiSwDescriptions
    /// Uses the ProjectRW class to read and write the project.arti_project (contains the set of Filenames, ActiveStates and ActiveEvents).
    /// Used the MergedOutput class to write a merged file
    /// </summary>
    public class ArtiProject {
        public IEnumerable FileNames => _sources.Keys;
        public bool Dirty { get; set; }
        private readonly Dictionary<string, ArtiSwDescription> _sources = new Dictionary<string, ArtiSwDescription>();

        public void LoadFromProjectFile(string jsonDescription) {
            ProjectRW.Load(_sources, jsonDescription);
            Dirty = false;
        }

        public string SaveToProjectFile(string projectFile = ".", bool pretty = true) {
            return ProjectRW.Save(projectFile, _sources, pretty);
        }

        public void IsSaved() {
            Dirty = false;
        }

        public void AddSource(string file, string json = null) {
            if (!_sources.ContainsKey(file)) {
                if (json == null && !File.Exists(file)) {
                    MessageBox.Show(file, "File missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var desc = new ArtiSwDescription(json ?? File.ReadAllText(file));
                _sources.Add(file, desc);
                Dirty = true;
            }
        }

        public void RemoveSource(string file) {
            _sources.Remove(file);
            Dirty = true;
        }

        public ArtiSwDescription GetDescriptionFor(string file) {
            return _sources[file];
        }

        public string CreateMergedOutputString(string generator) {
            return MergedOutput.AsString(generator, _sources);
        }
    }
}