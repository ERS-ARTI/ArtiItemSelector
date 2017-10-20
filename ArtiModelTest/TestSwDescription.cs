using NUnit.Framework;
using System;
using xModelTest;

namespace Arti.Tests {

    [TestFixture]
    public class TestSwDescription {
        ArtiSwDescription _sw_desc;

        [SetUp]
        public void Setup() {
            _sw_desc = new ArtiSwDescription(Helpers.ReadTestFile("OS.arti"));
            Assert.NotNull(_sw_desc, "Should see model");
        }

        [Test]
        public void TestCanLoadADescription() {
            Assert.True(_sw_desc.HasMeta, "Should have meta");
            Assert.True(_sw_desc.HasClasses, "Should have classes");
            Assert.True(_sw_desc.HasInstances, "Should have instances");
        }

        [Test]
        public void TestCanAccessClasses() {
            foreach (var klass in _sw_desc.Classes) {
                Console.WriteLine(klass.Name);
            }

            ArtiSwClass c_AR_CORE = _sw_desc.Classes.Find(x => x.Name == "AR_CORE");
            Assert.That(c_AR_CORE.Name, Is.EqualTo("AR_CORE"));

            Assert.That(c_AR_CORE.Description, Does.Contain("specified by AUTOSAR to describe a single core managed by an AUTOSAR OS"));

            ArtiSwClassState s_CURRENTAPPLICATION = c_AR_CORE.States.Find(x => x.Name == "CURRENTAPPLICATION");
            Assert.That(s_CURRENTAPPLICATION.Name, Is.EqualTo("CURRENTAPPLICATION"));
            Assert.That(s_CURRENTAPPLICATION.Description, Is.EqualTo("Application"));
            Assert.That(s_CURRENTAPPLICATION.Type, Is.EqualTo("map"));
            // values?

            ArtiSwClassEvent e_APPLICATION = c_AR_CORE.Events.Find(x => x.Name == "APPLICATION");
            Assert.That(e_APPLICATION.Name, Is.EqualTo("APPLICATION"));
            Assert.That(e_APPLICATION.Description, Is.EqualTo("AUTOSAR OS Application change"));
            // values?

            ArtiSwClassConstant s_PhysicalCore = c_AR_CORE.Constants.Find(x => x.Name == "PhysicalCore");
            Assert.That(s_PhysicalCore.Name, Is.EqualTo("PhysicalCore"));
            Assert.That(s_PhysicalCore.Description, Is.EqualTo("Core number"));
            Assert.That(s_PhysicalCore.Type, Is.EqualTo("string"));
            //// values?

        }

        [Test]
        public void TestCanAccessInstances() {
            foreach (var instance in _sw_desc.Instances) {
                Console.WriteLine(instance.Name);
            }

            ArtiSwInstance task = _sw_desc.Instances.Find(x => x.Name == "HighPriority");
            Assert.IsNotNull(task);

            var task_classes = task.ClassNames;
            CollectionAssert.Contains(task_classes, "AR_TASK");
            CollectionAssert.Contains(task_classes, "RTAOS_TASK");

            ArtiSwInstanceState s_ACTIVATIONS = task.States.Find(x => x.Name == "ACTIVATIONS");
            Assert.That(s_ACTIVATIONS.Name, Is.EqualTo("ACTIVATIONS"));
            Assert.That(s_ACTIVATIONS.Evaluate, Is.EqualTo("((Os_ControlledCoreInfo[1U].ReadyTasks.p1 & 0x1) << 1) >> 1"));

            ArtiSwInstanceConstant s_BasePriority = task.Constants.Find(x => x.Name == "BasePriority");
            Assert.That(s_BasePriority.Name, Is.EqualTo("BasePriority"));
            Assert.That(s_BasePriority.Value, Is.EqualTo("2"));
        }

    }
}