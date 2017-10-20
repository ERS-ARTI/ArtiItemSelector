using System;
using NUnit.Framework;

namespace xModel.Tests {

    [TestFixture]
    public class xModelTest {

        // TODO: Check can add values
        // TODO: Check can merge
        // TODO: Check can remove

        [Test]
        public void ReadAFile() {
            var model = new xModel(@"V:\Play\ARTI\WorkflowDemo\ARTI_Components\ADifferent.arti");
            Assert.NotNull(model, "Should see model");

            //            foreach (var value in model.Keys()) {
            //                Console.WriteLine(value.Path);
            //            }
            //            Assert.NotNull(model.Item("$Meta"), "Should see $Meta");
            //            Assert.NotNull(model.Item("_Classes_"), "Should see _Classes_");
            //            Assert.NotNull(model.Item("ADifferent"), "Should see ADifferent");

            //            Assert.IsNull(model.Item("_doofer_"), "Should not see doofer");

            //            var x = model.Item("$Meta");
            ////            x.AddAfterSelf("bob");
            //            Console.WriteLine(x.ToString());

            //            foreach (var child in x.Children()) {
            //                string y = child.Path;
            ////                string z = child.Name;
            //                Console.WriteLine(y);
            //            }
        }
    }
}