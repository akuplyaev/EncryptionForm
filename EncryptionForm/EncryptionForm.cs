using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace EncryptionForm {
    public partial class EncryptionForm : Form {
        public EncryptionForm() {
            InitializeComponent();
        }
        

        private void Form1_Load(object sender, EventArgs e) {
            comboBox1.SelectedIndex = 0;
        }

        private void btnIn_Click(object sender, EventArgs e) {
            string str = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(textBox3.Text) && (comboBox1.SelectedIndex != 3)) {
                MessageBox.Show("Введите ключ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            else if (string.IsNullOrEmpty(textBox1.Text)) {
                MessageBox.Show("Введите сообщение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {    
            switch (comboBox1.SelectedIndex) {
                    case 0:
                        int key = Convert.ToInt32(textBox3.Text);
                        textBox2.Text = Encryption.Cezar(str, key);
                        break;
                    case 1:
                        string code = textBox3.Text.Trim();
                        textBox2.Text = Encryption.Vig(str,code);
                        break;
                    case 2:
                        int key1 = Convert.ToInt32(textBox3.Text);
                        textBox2.Text = Encryption.Encription_one(str,key1);
                        break;
                    case 3:
                        textBox2.Text = Encryption.Crypt(str);
                        break;
                }
            }
        }
        // В зависимости от выбранного combox устанавливаются правила ввода 
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e) {
            string c = e.KeyChar.ToString();
            switch (comboBox1.SelectedIndex) {
                case 1: if (!Regex.Match(c, @"[a-zA-Z, ]").Success && e.KeyChar != 8) {
                        e.Handled = true;
                    }
                    break;                                           
                default:
                    if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8) e.Handled = true;
                    break;
            }
            
        }
        //Ввод только букв алфавита [a-zA-Z] и пробела
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e) {           
            string c = e.KeyChar.ToString();
            if (!Regex.Match(c, @"[a-zA-Z, ]").Success && e.KeyChar != 8) {
                e.Handled = true;
            }
            
        }

        private void btnOut_Click(object sender, EventArgs e) {
            string str = textBox1.Text.Trim();
            {
                switch (comboBox1.SelectedIndex) {
                    case 0:
                        int key = Convert.ToInt32(textBox3.Text);
                        textBox2.Text = DeEncryption.Cezar(str, key);
                        break;
                    case 1:
                        string code = textBox3.Text.Trim();
                        textBox2.Text =DeEncryption.Vig(str, code);
                        break;
                    case 2:                       
                      //  textBox2.Text = DeEncryption.Encription_one(str, key1);
                        break;
                }
            }
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e) {
            switch (comboBox1.SelectedIndex){
                case 2:
                    btnOut.Visible = false;
                    break;
                case 3:
                    btnOut.Visible = false;
                    break;
                default :
                    btnOut.Visible = true;
                    break;
            }
        }

        

       
    }
}
