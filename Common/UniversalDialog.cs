using System;
using System.Windows.Forms;
using System.Drawing;

namespace Shapoco.Common
{
    class UniversalDialog<T> : Form
    {
        public static T ShowDialog(
            string text, string caption, MessageBoxIcon icon,
            string[] buttonTextArray, T[] resultValueArray)
        {
            var f = new UniversalDialog<T>(
                text, caption, icon, buttonTextArray, resultValueArray);
            f.ShowDialog();
            return f.DialogResult;
        }

        public UniversalDialog(
            string text, string caption, MessageBoxIcon icon,
            string[] buttonTextArray, T[] resultValueArray)
        {
            // todo: そのうち綺麗にする

            // アイコン
            Label lblIcon = new Label() {
                AutoSize = false,
                Bounds = new Rectangle(16, 8, 48, 48)
            };
            switch (icon) {
                case MessageBoxIcon.Error:
                    lblIcon.Image = SystemIcons.Error.ToBitmap();
                    break;
                case MessageBoxIcon.Warning:
                    lblIcon.Image = SystemIcons.Warning.ToBitmap();
                    break;
                case MessageBoxIcon.Information:
                    lblIcon.Image = SystemIcons.Information.ToBitmap();
                    break;
                case MessageBoxIcon.Question:
                    lblIcon.Image = SystemIcons.Question.ToBitmap();
                    break;
            }
            this.Controls.Add(lblIcon);

            // ボタンたち
            int x = 24, y = lblIcon.Bottom + 8;
            for (int i = 0; i < buttonTextArray.Length; ++i) {
                var button = new Button() {
                    Text = buttonTextArray[i],
                    Tag = resultValueArray[i],
                    Bounds = new Rectangle(x, y, 40 + buttonTextArray[i].Length * 12, 30)
                };
                x += button.Width + 16;
                this.Controls.Add(button);
                button.Click += Button_Click;
            }

            // メッセージ
            TextBox txtMessage = new TextBox() {
                Text = text,
                Bounds = new Rectangle(64, 16, 300, 50),
                ReadOnly = true,
                BorderStyle = BorderStyle.None,
                Multiline = true
            };
            this.Controls.Add(txtMessage);

            this.Font = SystemFonts.MessageBoxFont;
            this.Text = caption;
            this.ControlBox = false;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.ClientSize = new Size(x + 8, y + 48);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            var senderButton = (Button)sender;
            this.DialogResult = (T)(senderButton.Tag);
            this.Close();
        }

        public new T DialogResult { get; set; }
    }
}
