using System.Collections.Generic;
using System.Linq;

namespace EncryptionForm {
    static class Encryption {
    public static List<char> CreateA() {
            List<char> alf = new List<char>();
            for (int i = 65; i <= 90; i++) {

                char ch = (char)i;
                alf.Add(ch);
            }
            return alf;
        }
        /* Создание алфавита [A-z] */
        static List<char> CreateAlf() {
            List<char> alf = new List<char>();
            for (int i = 65; i <= 90; i++) {
                char ch = (char)i;
                alf.Add(ch);
            }
            for (int i = 97; i <= 122; i++) {
                char ch = (char)i;
                alf.Add(ch);
            }
            return alf;
        }
        /* Шифрование методом простой одноалфавитной подстановки(Шифр Цезаря) */
        // метод для шифрования символа 
        static char Cezar(char ch, int key, List<char> alf) {
            int Size = alf.Count;
            int index = alf.IndexOf(ch);
            int max = index + key;           
                if (ch == ' ')
                    return ch;
               else if (max >= Size) {                
                    while (max>=Size) {
                        max = max - Size;                                            
                    }
                    ch = alf[max];  
                    return ch;
                }

                else {
                    ch = alf[max];
                    return ch;
                }                                        
        }
        //  шифрование строки,пробелы не шифруются
        public static string Cezar(string str,int key) {
            string res = "";
            List<char> alf = new List<char>(CreateA());           
            for (int i = 0; i < str.Length; i++) {
                char ch = (char)str[i];
                ch = Cezar(ch, key, alf);
                res += ch;
            }

            return res;
        }

        /* Шифрование методом многоалфавитной  одноконтурной обыкновенной подстановки с использование таблицы Виженера*/
        //Функция смещения алфавита для создания таблицы
      public  static List<char> CreateRowVig(List<char> alf) {
            List<char> sf = new List<char>();
            int key = 1;
            int count = alf.Count;
            foreach (char ch in alf) {
                int i = alf.IndexOf(ch);
                if (i + key < count) {
                    sf.Add(alf[i + key]);
                }
                else {
                    sf.Add(alf[count - i - key]);
                }
            }
            return sf;
        }

        // Создание таблицы Виженера  для алфавита [A-Z]
      public  static List<List<char>> CreateTableVig() {
            List<List<char>> vg = new List<List<char>>();
            List<char> alf = new List<char>(CreateA());
            vg.Add(alf);
            foreach (char ls in alf) {
                List<char> temp = CreateRowVig(alf);
                vg.Add(temp);
                alf = temp;
            }
            return vg;
        }

        //Шифрование строки с ключевым словом LEMON, пробелы не шифруются
        public static string Vig(string str,string code) {
            List<List<char>> vg = new List<List<char>>(CreateTableVig());           
            string tr = "";
            string result = "";
            while (str.Length > tr.Length) {

                tr += code;
            }
            while (tr.Length > str.Length) {
                tr = tr.Remove(str.Length, tr.Length - str.Length);
            }
            int index = 0;
            foreach (char ls in str) {  //чепез for
                if (ls != ' ') {
                    result += vg[vg[0].IndexOf(tr[index])][vg[0].IndexOf(ls)];//пересечение в таблице символа строки и символа ключа
                }
                else {
                    result += ls;
                }
                index++;
            }

            return result;
        }

        /*                Монофоническое шифрование                                      */
        // Таблица частот
        static Dictionary<char, int> Dkt(string str) {
            string newstr = "";
            foreach (char letter in str.Distinct()) {
                newstr += letter;
            }
            Dictionary<char, int> dic = new Dictionary<char, int>();
            foreach (char ch in newstr) {
                dic.Add(ch, 0);

            }
            return dic;
        }
        //Шифрование символа c учетом частоты его появления 
        static char Cezar_one(char ch, int key, int vector, List<char> alf) {
            int Size = alf.Count;
            int index = alf.IndexOf(ch);
            int max = index + key + vector;
            if (ch == ' ')
                return ch;
            else if (max >= Size) {
                while (max >= Size) {
                    max = max - Size;
                }
                ch = alf[max];
                return ch;
            }
            else {
                ch = alf[max];
                return ch;
            }
        }
        //Шифрование строки пробелов
        static public string Encription_one(string str,int key) {
            string res = "";           
            Dictionary<char, int> ds = new Dictionary<char, int>(Dkt(str));
            List<char> alf = new List<char>(CreateA());
            foreach (char ch in str) {
                switch (ch) {
                    case ' ':
                        res += ch;
                        break;
                    default:
                        if (ds[ch] == 0) {
                            res += Cezar(ch, key, alf);
                            ds[ch]++;
                        }
                        else {
                            res += Cezar_one(ch, key, ds[ch], alf);
                            ds[ch]++;
                        }
                        break;
                }
            }
            return res;

        }
    }
}












