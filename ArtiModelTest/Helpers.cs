using System.IO;
using System.Reflection;

namespace xModelTest {
    class Helpers {

        public static string ReadTestFile(string name) {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "xModelTest.Files." + name;

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream)) {
                return reader.ReadToEnd();
            }
        }
    }
}
