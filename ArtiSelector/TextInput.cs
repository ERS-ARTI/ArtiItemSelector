using System.Windows.Forms;

namespace ArtiItemSelector {
    public partial class TextInput : Form {
        private readonly string _original;

        public TextInput() {
            InitializeComponent();
        }

        public TextInput(string title, string prompt, string text) {
            InitializeComponent();
            _original = text;
            this.Text = title;
            Prompt.Text = prompt;
            Content.Text = text;
        }

        public string Run() {
            var result = ShowDialog();
            if (result == DialogResult.OK) {
                return Content.Text.Trim();
            }
            if (result == DialogResult.Abort) {
                return null;
            }
            return _original;
        }
    }
}
