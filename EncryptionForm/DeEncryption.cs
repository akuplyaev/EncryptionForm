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

    public static string Vig(string str, string code) {
        List<List<char>> vg = new List<List<char>>(Encryption.CreateTableVig());
        string tr = "";
        string result = "";
        while (str.Length > tr.Length) {

            tr += code;
        }
        while (tr.Length > str.Length) {
            tr = tr.Remove(str.Length, tr.Length - str.Length);
        }
        int index = 0;
        foreach (char ls in str) {  
            if (ls != ' ') {               
              int f= vg[vg[0].IndexOf(tr[index])].IndexOf(ls);
                result+=vg[0][f];

            }
            else {
                result += ls;
            }
            index++;
        }

        return result;
    }

 
    
    static public string Encription_one(string str, int key) {
        string st = Cezar(str,key);
        string res = "";
        Dictionary<char, int> ds = new Dictionary<char, int>(Encryption.Dkt(st));
        List<char> alf = new List<char>(Encryption.CreateA());
        foreach (char ch in st) {
                switch (ch) {
                    case ' ':
                        res += ch;
                        break;
                    default:
                        if (ds[ch] == 0) {
                            res += ch;
                            ds[ch]++;
                        }
                        else {
                            int count=ds[ch];
                            res += alf[alf.IndexOf(ch)-count];
                            ds[ch]++;
                        }
                        break;
                }
            }
        
        return res;

    }



    }
}
    

