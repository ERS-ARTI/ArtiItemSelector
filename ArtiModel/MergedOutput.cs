using System;
using System.Collections.Generic;
using System.IO;

namespace Arti {

    /// <summary>
    /// Knows how to convert a set of ArtiSwDescription into a merged output file
    /// </summary>
    public class MergedOutput {
        public static string AsString(string generator, Dictionary<string, ArtiSwDescription> sources) {
            var json = new StringWriter();
            json.WriteLine("{");
            json.WriteLine("\"$Meta\": {");
            json.WriteLine("\"schema\": \"URL_to_schema_version\",");
            json.WriteLine("\"description\": \"Merged ARTI\",");
            json.WriteLine($"\"generator\": \"{generator}\",");
            var t = DateTime.Now.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ");
            json.WriteLine($"\"date\": \"{t}\", ");
            json.WriteLine("\"merge_sources\": [],");
            json.WriteLine("},");
            json.WriteLine("\"$Classes\": {},");
            json.WriteLine("\"$Instances\": {},");
            json.WriteLine("}");

            var merged_model = ArtiObject.Create(json.ToString());

            var output_meta = merged_model["$Meta"]["merge_sources"];
            var output_classes = merged_model["$Classes"];
            var output_instances = merged_model["$Instances"];

            foreach (var info in sources) {
                var source_file = info.Key;
                var source_data = info.Value;

                // Update output metadata
                source_data.AddMetaData("origin", source_file);
                output_meta.ArrayAppend(source_data.RawMetaData);

                // Remember which states and events are selected
                var selected_states = new List<string>();
                foreach (var source_class in source_data.Classes) {
                    foreach (var source_state in source_class.States) {
                        if (source_state.Selected) {
                            selected_states.Add(source_class.Name + "." + source_state.Name);
                        }
                    }
                }

                // Create output classes
                foreach (var source_class in source_data.Classes) {
                    output_classes.AddObject(source_class.Name, ArtiObject.Create("{\"states\": {},\"events\": {},\"constants\": {}, \"description\" : \"\" }"));

                    var output_class = output_classes[source_class.Name];

                    var output_events = output_class["events"];
                    foreach (var source_event in source_class.Events) {
                        output_events.AddObject(source_event.Name, source_event.RawData);

                        // Apply active value
                        var ev = output_events[source_event.Name];
                        ev.AddValue("active", source_event.Selected ? "true" : "false");
                    }

                    var output_states = output_class["states"];
                    foreach (var source_state in source_class.States) {
                        output_states.AddObject(source_state.Name, source_state.RawData);

                        // Apply active value
                        var ev = output_states[source_state.Name];
                        ev.AddValue("active", source_state.Selected ? "true" : "false");
                    }

                    var output_constants = output_class["constants"];
                    foreach (var source_constant in source_class.Constants) {
                        output_constants.AddObject(source_constant.Name, source_constant.RawData);
                    }
                    if (!string.IsNullOrEmpty(source_class.Description)) {
                        output_class["description"].UpdateValue(source_class.Description);
                    }
                }

                // Create output instances
                foreach (var source_instance in source_data.Instances) {
                    output_instances.AddObject(source_instance.Name, ArtiObject.Create("{\"classes\": [], \"states\": {},\"events\": {}, \"constants\" : {} }"));

                    var output_instance = output_instances[source_instance.Name];

                    var c = output_instance["classes"];
                    var expected_events = new List<ArtiSwClassEvent>();
                    foreach (var source_class in source_data.Classes) {
                        if (source_instance.ClassNames.Contains(source_class.Name)) {
                            c.ArrayAppend(source_class.Name);
                            foreach (var class_event in source_class.Events) {
                                expected_events.Add(class_event);
                            }
                        }
                    }

                    var output_events = output_instance["events"];
                    foreach (var source_class_event in expected_events) {

                        // Clone the JSON
                        var source_event = source_instance.Events.Find(n => (n.Name == source_class_event.Name));
                        output_events.AddObject(source_class_event.Name, (source_event == null) ? ArtiObject.Create("{}") : source_event.RawData);

                        // Apply active value
                        var ev = output_events[source_class_event.Name];
                        ev.AddValue("active", source_class_event.Selected ? "true" : "false");
                    }

                    var output_states = output_instance["states"];
                    foreach (var source_state in source_instance.States) {

                        // A state is selected if it is selected in a parent class
                        var select = false;
                        foreach (var klass in source_instance.ClassNames) {
                            var id = klass + "." + source_state.Name;
                            if (selected_states.Contains(id)) {
                                select = true;
                            }
                        }
                        source_state.Selected = select;

                        // Clone the JSON
                        output_states.AddObject(source_state.Name, source_state.RawData);

                        // Apply active value
                        var ev = output_states[source_state.Name];
                        ev.AddValue("active", source_state.Selected ? "true" : "false");
                    }

                    var output_constants = output_instance["constants"];
                    foreach (var source_constant in source_instance.Constants) {
                        // Clone the JSON
                        output_constants.AddValue(source_constant.Name, source_constant.Value());
                    }
                }
            }

            return merged_model.ToString();
        }
    }
}