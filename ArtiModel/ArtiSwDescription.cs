using System.Collections.Generic;
using System.Linq;

namespace Arti {

    /// <summary>
    /// Associates a name with an ArtiObject
    /// Base class to many others in this file
    /// </summary>
    public class ArtiSwNode {
        protected ArtiObject _object;
        protected bool _selected;
        protected string _name;

        public ArtiSwNode(string name, ArtiObject model) {
            _object = model;
            _name = name;
        }

        public string Name => _name;

        public override string ToString() {
            return Name;
        }

        public void AddValue(string key, string value) {
            _object.AddValue(key, value);
        }

        public void EnsureValue(string key, string value) {
            if (_object.Keys().Contains(key)) {
                _object[key].UpdateValue(value);
            } else {
                _object.AddValue(key, value);
            }
        }


        public bool Selected {
            get {
                return _selected;
            }

            set {
                _selected = value;
            }
        }

        public bool IsArray => _object.IsArray;
        public bool IsValue => _object.IsValue;
        public bool IsObject => _object.IsObject;

        public string Value() {
            return _object.Value();
        }

        public IEnumerable<string> Array() {
            return _object.Array();
        }

        internal ArtiObject RawData => _object;
    }

    /// <summary>
    /// Model for a Class in the ARTI description file. 
    /// Contains states, events and constants
    /// </summary>
    public class ArtiSwClass : ArtiSwNode {
        protected List<ArtiSwClassState> _states;
        protected List<ArtiSwClassEvent> _events;
        protected List<ArtiSwClassConstant> _constants;

        public ArtiSwClass(string name, ArtiObject model) : base(name, model) {
            _states = new List<ArtiSwClassState>();
            var states = _object["states"];
            if (states != null) {
                foreach (var key in states.Keys()) {
                    _states.Add(new ArtiSwClassState(name, key, states[key]));
                }
            }

            _events = new List<ArtiSwClassEvent>();
            var events = _object["events"];
            if (events != null) {
                foreach (var key in events.Keys()) {
                    _events.Add(new ArtiSwClassEvent(name, key, events[key]));
                }
            }

            _constants = new List<ArtiSwClassConstant>();
            var statics = _object["constants"];
            if (statics != null) {
                foreach (var key in statics.Keys()) {
                    _constants.Add(new ArtiSwClassConstant(name, key, statics[key]));
                }
            }
        }

        public string Description => _object["description"].Value();

        public List<ArtiSwClassState> States => _states;
        public List<ArtiSwClassEvent> Events => _events;
        public List<ArtiSwClassConstant> Constants => _constants;
    }

    /// <summary>
    /// Model for an Instance in the ARTI description file. 
    /// Contains states, events and constants
    /// </summary>
    public class ArtiSwInstance : ArtiSwNode {
        protected List<ArtiSwInstanceState> _states;
        protected List<ArtiSwInstanceConstant> _constants;
        protected List<ArtiSwInstanceEvent> _events;

        public ArtiSwInstance(string name, ArtiObject model) : base(name, model) {
            _states = new List<ArtiSwInstanceState>();
            var states = _object["states"];
            if (states != null) {
                foreach (var key in states.Keys()) {
                    _states.Add(new ArtiSwInstanceState(key, states[key]));
                }
            }

            _events = new List<ArtiSwInstanceEvent>();

            if (!_object.Keys().Contains("events")) {
                var e = ArtiObject.Create("{ }");
                _object.AddObject("events", e);
            }
            var events = _object["events"];

            foreach (var key in events.Keys()) {
                _events.Add(new ArtiSwInstanceEvent(name, key, events[key]));
            }

            _constants = new List<ArtiSwInstanceConstant>();
            var statics = _object["constants"];
            if (statics != null) {
                foreach (var key in statics.Keys()) {
                    _constants.Add(new ArtiSwInstanceConstant(key, statics[key]));
                }
            }
        }

        public List<string> ClassNames {
            get {
                var ret = new List<string>();
                var cls = _object["classes"];
                if (cls.IsArray) {
                    foreach (var name in cls.Array()) {
                        ret.Add(name);
                    }
                }
                return ret;
            }
        }

        public List<string> StateNames {
            get {
                var ret = new List<string>();
                var st = _object["states"];
                if (st.IsObject) {
                    foreach (var name in st.Keys()) {
                        ret.Add(name);
                    }
                }
                return ret;
            }
        }

        public ArtiSwInstanceState State(string name) {
            return _states.Find(n => n.Name == name);
        }

        public List<string> EventNames {
            get {
                var ret = new List<string>();
                var ev = _object["events"];
                if (ev.IsObject) {
                    foreach (var name in ev.Keys()) {
                        ret.Add(name);
                    }
                }
                return ret;
            }
        }

        public ArtiSwInstanceEvent Event(string name) {
            return _events.Find(n => n.Name == name);
        }

        public void SetPointOfInterest(string key, string value) {
            var e = Event(key);
            if (e == null) {
                _object["events"].AddObject(key, ArtiObject.Create("{}"));
                e = new ArtiSwInstanceEvent(Name, key, _object["events"][key]);
                _events.Add(e);

            }
            e.EnsureValue("POI", value);
            e.PointOfInterest = value;
        }


        public List<ArtiSwInstanceState> States => _states;
        public List<ArtiSwInstanceEvent> Events => _events;
        public List<ArtiSwInstanceConstant> Constants => _constants;

    }

    /// <summary>
    /// Model for a State object in a Class in the ARTI description file. 
    /// </summary>
    public class ArtiSwClassState : ArtiSwNode {
        readonly string _parent_name;
        public ArtiSwClassState(string parentName, string name, ArtiObject model) : base(name, model) {
            _parent_name = parentName;
        }

        public string Description => _object["description"].Value();

        public string Type => _object["type"].Value();

        public override string ToString() {
            return _parent_name + "." + Name;
        }
    }

    /// <summary>
    /// Model for a State object in an Instance in the ARTI description file. 
    /// </summary>
    public class ArtiSwInstanceState : ArtiSwNode {
        public ArtiSwInstanceState(string name, ArtiObject model) : base(name, model) {
        }

        public string Evaluate => _object["evaluate"].Value();
    }

    /// <summary>
    /// Model for an Event object in a Class in the ARTI description file. 
    /// </summary>
    public class ArtiSwClassEvent : ArtiSwNode {
        readonly string _parent_name;
        public ArtiSwClassEvent(string parentName, string name, ArtiObject model) : base(name, model) {
            _parent_name = parentName;
        }

        public string Description => _object["description"].Value();

        public override string ToString() {
            return _parent_name + "." + Name;
        }
    }

    /// <summary>
    /// Model for an Event object in an Instance in the ARTI description file. 
    /// </summary>
    public class ArtiSwInstanceEvent : ArtiSwNode {
        readonly string _parent_name;
        public string PointOfInterest;

        public ArtiSwInstanceEvent(string parentName, string name, ArtiObject model) : base(name, model) {
            _parent_name = parentName;
        }

        public string Description => _object["description"].Value();

        public override string ToString() {
            return _parent_name + "." + Name;
        }

        public void RemovePointOfInterest() {
            PointOfInterest = null;
            _object.UpdateValue(null);
        }
    }

    /// <summary>
    /// Model for a Constant object in a Class in the ARTI description file. 
    /// </summary>
    public class ArtiSwClassConstant : ArtiSwNode {
        readonly string _parent_name;
        public ArtiSwClassConstant(string parentName, string name, ArtiObject model) : base(name, model) {
            _parent_name = parentName;
        }

        public string Description => _object["description"].Value();

        public string Type => _object["type"].Value();

        public override string ToString() {
            return _parent_name + "." + Name;
        }
    }

    /// <summary>
    /// Model for a Constant object in an Instance in the ARTI description file. 
    /// </summary>
    public class ArtiSwInstanceConstant : ArtiSwNode {
        public ArtiSwInstanceConstant(string name, ArtiObject model) : base(name, model) {
        }
    }


    /// <summary>
    /// Model for the data in the ARTI description file. 
    /// Contains meta, classes and instances
    /// </summary>
    public class ArtiSwDescription {

        protected ArtiObject _model, _meta;
        protected List<ArtiSwNode> _metas;
        protected List<ArtiSwClass> _classes;
        protected List<ArtiSwInstance> _instances;

        public ArtiSwDescription(string json) {
            _model = new ArtiObject(json);

            _meta = _model["$Meta"];
            _metas = new List<ArtiSwNode>();
            foreach (var key in _meta.Keys()) {
                _metas.Add(new ArtiSwNode(key, _meta[key]));
            }

            _classes = new List<ArtiSwClass>();
            var klasses = _model["$Classes"];
            if (klasses != null) {
                foreach (var key in klasses.Keys()) {
                    _classes.Add(new ArtiSwClass(key, klasses[key]));
                }
            }

            _instances = new List<ArtiSwInstance>();
            var insts = _model["$Instances"];
            if (insts != null) {
                foreach (var key in insts.Keys()) {
                    _instances.Add(new ArtiSwInstance(key, insts[key]));
                }
            }
        }

        internal void AddMetaData(string v, string src) {
            if (_meta.Keys().Contains(v)) {
                _meta[v].UpdateValue(src);
                _metas.RemoveAll(i => i.Name == v); //
                _metas.Add(new ArtiSwNode(v, _meta[v]));
            } else {
                _meta.AddValue(v, src);
                _metas.Add(new ArtiSwNode(v, _meta[v]));
            }
        }

        public override string ToString() {
            return _model.ToString();
        }

        public bool HasMeta => _meta != null;

        public bool HasClasses => _classes.Count > 0;

        public bool HasInstances => _instances.Count > 0;

        public List<ArtiSwNode> MetaData => _metas;
        public List<ArtiSwClass> Classes => _classes;
        public List<ArtiSwInstance> Instances => _instances;
        public ArtiObject RawMetaData => _meta;
    }
}
