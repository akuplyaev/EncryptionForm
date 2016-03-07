using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionForm {   
    static class DeEncryption {
    public   static string Cezar(string str,int key) {           
            List<char> alf = new List<char>(Encryption.CreateA());
            string res = "";           
            for (int i = 0; i < str.Length; i++) {
                char ch = (char)str[i];
                ch = Cezar(ch, key, alf);
                res += ch;
            }
            return res;           
        }
        static char Cezar(char ch, int key, List<char> alf) {
            int Size = alf.Count;
            int index = alf.IndexOf(ch);
            int res = index - key;
            if (ch == ' ')
                return ch;
            else if (res < 0) {
                while (res<0) {
                    res = res + Size;
                }
                ch = alf[res];
                return ch;
              
            }

            else {
                ch = alf[res];
                return ch;
            }
        }




    }
}
    

