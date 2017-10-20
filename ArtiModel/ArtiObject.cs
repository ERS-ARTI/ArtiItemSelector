using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Globalization;


namespace Arti {

    // Wrapper around a JSON Object, array or value
    // e.g.
    //  {
    //      "id": 1,
    //      "name": "A green door",
    //      "price": 12.50,
    //      "tags": ["home", "green"],
    //      "person" : {
    //          "forename" : "bob",
    //          "lastname" : "bee"
    //      }
    //  }
    // Or
    //      ["home", "green"]
    // Or
    //      "bee"
    //
    public class ArtiObject
    {
        protected dynamic _object;

        public ArtiObject(string json) {
            _object = JObject.Parse(json ?? "{}");
        }

        public static ArtiObject Create(string json) {
            return new ArtiObject(json);
        }

        private ArtiObject(dynamic jtoken) {
            _object = jtoken;
        }

        public override string ToString() {
            return _object.ToString();
        }

        public ArtiObject this[string index] {
            get {
                var i = _object.GetValue(index);
                return new ArtiObject(i);
            }
        }


        public bool IsValue => (_object is JValue);

        public bool IsArray => (_object is JArray);

        public bool IsObject => (_object is JObject);

        // Value operations
        public string Value() {
            return IsValue ? _object.Value.ToString() : null;
        }

        public void UpdateValue(string v) {
            if (IsValue) {
                ((JValue)_object).Value = v;
            }
        }

        // Array operations
        public IEnumerable<string> Array() {
            if (!IsArray) {
                return null;
            }
            var values = new List<string>();
            foreach (var item in (JArray)_object) {
                values.Add(((JValue)item).ToString(CultureInfo.InvariantCulture));
            }
            return values;
        }

        public void ArrayAppend(ArtiObject ser) {
            (_object as JArray)?.Add(JObject.Parse(ser.ToString()));
        }

        public void ArrayAppend(string s) {
            (_object as JArray)?.Add(s);
        }

        // Object operations
        public IEnumerable<string> Keys() {
            var keys = new List<string>();
            if (IsObject) {
                foreach (var item in _object.Children()) {
                    if (item is JProperty) {
                        keys.Add(item.Name);
                    }
                }
            }
            return keys;
        }

        public bool HasChildren {
            get {
                if (IsObject) {
                    return ((JObject)_object).HasValues;
                }
                return false;
            }
        }
        public void AddObject(string key, ArtiObject ser) {
            (_object as JObject)?.Add(key, JObject.Parse(ser.ToString()));
        }

        public void AddValue(string name, string value) {
            if (IsObject) {
                (_object as JObject)?.Add(name, value);
            }
        }

        public void Remove(string key) {
            (_object as JObject)?.Remove(key);
        }

    }
}
