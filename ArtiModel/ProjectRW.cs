using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Arti {

    /// <summary>
    /// Knows how to read/write data from an ARTI project file
    /// </summary>
    internal class ProjectRW {

        /// <summary>
        /// Class used for controlling what gets serialized into the project file
        /// </summary>
        internal class ProjectFacade {
            [JsonRequired]
            // ReSharper disable once InconsistentNaming
            public string[] FileNames = { };

            // ReSharper disable once InconsistentNaming
            public string[] ActiveStates = { };
            // ReSharper disable once InconsistentNaming
            public string[] ActiveEvents = { };

            // ReSharper disable once InconsistentNaming
            public Dictionary<string, string> POIs = new Dictionary<string, string>();

            public string Serialize(bool pretty = true) {
                return JsonConvert.SerializeObject(this, pretty ? Formatting.Indented : Formatting.None);
            }
        }

        public static string Save(string projectFile, Dictionary<string, ArtiSwDescription> sources, bool pretty) {
            var facade = new ProjectFacade { FileNames = sources.Keys.ToArray() };

            var filenames = new List<string>();
            foreach (var src_file in sources.Keys) {
                try {
                    var uri1 = new Uri(projectFile);
                    var uri2 = new Uri(src_file);
                    filenames.Add(uri1.MakeRelativeUri(uri2).ToString());
                } catch (UriFormatException) {
                    filenames.Add(src_file);
                }
            }
            facade.FileNames = filenames.ToArray();

            var selected_states = new List<string>();
            var selected_events = new List<string>();
            var pois = new Dictionary<string, string>();
            foreach (var description in sources) {
                foreach (var klass in description.Value.Classes) {
                    selected_states.AddRange(from state in klass.States
                        where state.Selected
                        select NameFor(klass, state));
                    selected_events.AddRange(from evt in klass.Events where evt.Selected select NameFor(klass, evt));
                }
                foreach (var instance in description.Value.Instances) {
                    foreach (var evt in instance.Events) {
                        var poi = evt.PointOfInterest;
                        if (!string.IsNullOrEmpty(poi)) {
                            pois[$"{instance.Name}.{evt.Name}"] = poi;
                        }
                    }
                }
            }
            facade.ActiveStates = selected_states.ToArray();
            facade.ActiveEvents = selected_events.ToArray();
            facade.POIs = pois;

            return facade.Serialize(pretty);
        }

        private static string NameFor(ArtiSwClass klass, ArtiSwNode evt) {
            return $"{klass.Name}.{evt.Name}";
        }

        public static void Load(Dictionary<string, ArtiSwDescription> sources, string jsonDescription) {
            sources.Clear();

            var facade = JsonConvert.DeserializeObject<ProjectFacade>(jsonDescription);
            foreach (var file_name in facade.FileNames) {
                AddSource(file_name, sources);
            }
            foreach (var source in sources) {
                foreach (var klass in source.Value.Classes) {
                    foreach (var state in klass.States) {
                        if (facade.ActiveStates.Contains(NameFor(klass, state))) {
                            state.Selected = true;
                        }
                    }
                    foreach (var evt in klass.Events) {
                        var id = NameFor(klass, evt);
                        if (facade.ActiveEvents.Contains(id)) {
                            evt.Selected = true;
                        }
                    }
                }

                foreach (var inst in source.Value.Instances) {
                    foreach (var inst_evt in inst.Events) {
                        inst_evt.RemovePointOfInterest();
                    }
                    var pois = PoisFor(inst.Name, facade.POIs);
                    foreach (var evt_poi in pois) {
                        inst.SetPointOfInterest(evt_poi.Key, evt_poi.Value);
                    }
                }
            }
        }

        private static Dictionary<string, string> PoisFor(string name, Dictionary<string, string> poIs) {
            var pois = new Dictionary<string, string>();
            foreach (var poi in poIs) {
                var parts = poi.Key.Split('.');
                var inst_name = parts[0];
                if (name == inst_name) {
                    pois[parts[1]] = poi.Value;
                }
            }
            return pois;
        }

        private static string NameFor(ArtiSwInstance inst, ArtiSwInstanceEvent evt) {
            return $"{inst.Name}.{evt.Name}";
        }

        private static void AddSource(string file, Dictionary<string, ArtiSwDescription> sources) {
            if (sources.ContainsKey(file)) {
                return; // Already exists
            }
            var desc = new ArtiSwDescription(File.ReadAllText(file));
            sources.Add(file, desc);
        }

    }
}