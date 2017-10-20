using System.Linq;
using NUnit.Framework;
using xModelTest;

namespace Arti.Tests {

    [TestFixture]
    public class xModelTest {

        ArtiObject _sw_desc;

        [SetUp]
        public void Setup() {
            _sw_desc = new ArtiObject(Helpers.ReadTestFile("SystemDescription.arti"));
            Assert.NotNull(_sw_desc, "Should see model");
        }

        [Test]
        public void TestTopLevelKeysExist() {

            var keys = _sw_desc.Keys();
            var collection = keys as string[] ?? keys.ToArray();
            CollectionAssert.Contains(collection, "$Meta");
            CollectionAssert.Contains(collection, "$Classes");
            CollectionAssert.Contains(collection, "$Instances");
            //CollectionAssert.Contains(collection, "ADifferent");
            //CollectionAssert.Contains(collection, "AModule1");
            //CollectionAssert.Contains(collection, "AModule2");
            //CollectionAssert.Contains(collection, "HelloWorld");
            //CollectionAssert.Contains(collection, "Core0_HelloWorld");
            //CollectionAssert.Contains(collection, "Core1_HelloWorld");
            //CollectionAssert.Contains(collection, "LowPriority");
            //CollectionAssert.Contains(collection, "HighPriority");
            //CollectionAssert.Contains(collection, "Millisecond");
            //CollectionAssert.Contains(collection, "Alarm25ms");
            //CollectionAssert.Contains(collection, "Alarm50ms");
            //CollectionAssert.Contains(collection, "Serializer");
        }

        [Test]
        public void TestSubNodesExist() {

            ArtiObject meta = _sw_desc["$Meta"];

            var meta_keys = meta.Keys();
            var collection = meta_keys as string[] ?? meta_keys.ToArray();
            CollectionAssert.Contains(collection, "description");
            CollectionAssert.Contains(collection, "merge_sources");
            CollectionAssert.Contains(collection, "generator");
            CollectionAssert.Contains(collection, "date");

            ArtiObject app_values = _sw_desc["$Classes"]["AR_CORE"]["states"]["CURRENTAPPLICATION"]["values"];
            var app_keys = app_values.Keys();
            var enumerable = app_keys as string[] ?? app_keys.ToArray();
            CollectionAssert.Contains(enumerable, "0");
            CollectionAssert.Contains(enumerable, "1");
            CollectionAssert.Contains(enumerable, "2");
        }

        [Test]
        public void TestNodesHaveValues() {

            Assert.False(_sw_desc.IsValue);
            Assert.False(_sw_desc.IsArray);
            Assert.True(_sw_desc.IsObject);

            Assert.IsNull(_sw_desc.Value());
            Assert.IsNull(_sw_desc.Array());

            Assert.True(_sw_desc["$Meta"]["description"].IsValue);
            Assert.That(_sw_desc["$Meta"]["description"].Value(), Is.EqualTo("Merged ARTI description"));

            Assert.False(_sw_desc["$Meta"]["missing"].IsValue);

            var node = _sw_desc["$Meta"]["generator"];
            Assert.IsTrue(node.IsValue);
            Assert.That(node.Value(), Is.EqualTo("arti_merge.rb"));

            node = _sw_desc["$Classes"]["AR_CORE"]["states"]["CURRENTAPPLICATION"]["values"]["2"];
            Assert.IsTrue(node.IsValue);
            Assert.That(node.Value(), Is.EqualTo("Application1"));
        }

        [Test]
        public void TestNodesHaveChildren() {
            Assert.True(_sw_desc.HasChildren);
            Assert.False(_sw_desc["$Meta"]["description"].HasChildren);
            Assert.False(_sw_desc["Core0_HelloWorld"]["classes"].HasChildren);
        }

        [Test]
        public void TestNodesHaveArrays() {
            Assert.False(_sw_desc.IsArray);
            Assert.False(_sw_desc["$Meta"]["description"].IsArray);
            Assert.True(_sw_desc["$Instances"]["Core0_HelloWorld"]["classes"].IsArray);

            var ary = _sw_desc["$Instances"]["Core0_HelloWorld"]["classes"].Array();
            CollectionAssert.AreEquivalent(new[] { "AR_CORE", "RTAOS_CORE" }, ary);
        }

        [Test]
        public void TestCanChangeValues() {
            Assert.That(_sw_desc["$Meta"]["description"].Value(), Is.EqualTo("Merged ARTI description"));
            _sw_desc["$Meta"]["description"].UpdateValue("New value");
            Assert.That(_sw_desc["$Meta"]["description"].Value(), Is.EqualTo("New value"));

            var whole = _sw_desc.ToString();
            StringAssert.Contains("\"description\": \"New value\"", whole);
        }

        [Test]
        public void TestCanAddValues() {
            Assert.IsNull(_sw_desc["$Meta"]["new_value"].Value());
            _sw_desc["$Meta"].AddValue("new_value", "Added value");
            Assert.That(_sw_desc["$Meta"]["new_value"].Value(), Is.EqualTo("Added value"));

            var whole = _sw_desc.ToString();
            StringAssert.Contains("\"new_value\": \"Added value\"", whole);
        }

        [Test]
        public void TestCanRemoveValues() {
            Assert.That(_sw_desc["$Meta"]["description"].Value(), Is.EqualTo("Merged ARTI description"));
            _sw_desc["$Meta"].Remove("description");
            Assert.IsNull(_sw_desc["$Meta"]["description"].Value());

            var whole = _sw_desc.ToString();
            StringAssert.DoesNotContain("Merged ARTI description", whole);
        }

        [Test]
        public void TestCanRemoveNodes() {
            Assert.True(_sw_desc["$Instances"]["Core0_HelloWorld"]["states"].HasChildren);
            _sw_desc["$Instances"]["Core0_HelloWorld"].Remove("states");
            Assert.False(_sw_desc["$Instances"]["Core0_HelloWorld"]["states"].HasChildren);

            var whole = _sw_desc.ToString();
            StringAssert.DoesNotContain("Os_ControlledCoreInfo[0U].RunningISR->application", whole);
        }

        [Test]
        public void TestCanMerge() {
            var meta = _sw_desc["$Meta"];
            var ser = _sw_desc["$Instances"]["Serializer"];

            Assert.False(_sw_desc["$Meta"]["FromSerializer"]["states"]["STATE"].HasChildren);
            meta.AddObject("FromSerializer", ser);
            Assert.True(_sw_desc["$Meta"]["FromSerializer"]["states"]["STATE"].HasChildren);
        }
    }

}