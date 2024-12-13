namespace Lab1
{
    public partial class Form1 : Form
    {
        Dictionary<char, string> charToKOI8R = new Dictionary<char, string>()
        {
            {'À', "0xE1"}, {'Á', "0xE2"}, {'Â', "0xF7"}, {'Ã', "0xE7"}, {'Ä', "0xE4"}, {'Å', "0xE5"}, {'Æ', "0xF6"}, {'Ç', "0xFA"},
            {'È', "0xE9"}, {'É', "0xEA"}, {'Ê', "0xEB"}, {'Ë', "0xEC"}, {'Ì', "0xED"}, {'Í', "0xEE"}, {'Î', "0xEF"}, {'Ï', "0xF0"},
            {'Ð', "0xF2"}, {'Ñ', "0xF3"}, {'Ò', "0xF4"}, {'Ó', "0xF5"}, {'Ô', "0xE6"}, {'Õ', "0xE8"}, {'Ö', "0xE3"}, {'×', "0xFE"},
            {'Ø', "0xFB"}, {'Ù', "0xFD"}, {'Ú', "0xFF"}, {'Û', "0xF9"}, {'Ü', "0xF8"}, {'Ý', "0xFC"}, {'Þ', "0xE0"}, {'ß', "0xF1"},

            {'à', "0xC1"}, {'á', "0xC2"}, {'â', "0xD7"}, {'ã', "0xC7"}, {'ä', "0xC4"}, {'å', "0xC5"}, {'æ', "0xD6"}, {'ç', "0xDA"},
            {'è', "0xC9"}, {'é', "0xCA"}, {'ê', "0xCB"}, {'ë', "0xCC"}, {'ì', "0xCD"}, {'í', "0xCE"}, {'î', "0xCF"}, {'ï', "0xD0"},
            {'ð', "0xD2"}, {'ñ', "0xD3"}, {'ò', "0xD4"}, {'ó', "0xD5"}, {'ô', "0xC6"}, {'õ', "0xC8"}, {'ö', "0xC3"}, {'÷', "0xDE"},
            {'ø', "0xDB"}, {'ù', "0xDD"}, {'ú', "0xDF"}, {'û', "0xD9"}, {'ü', "0xD8"}, {'ý', "0xDC"}, {'þ', "0xC0"}, {'ÿ', "0xD1"},

            {'A', "0x41"}, {'B', "0x42"}, {'C', "0x43"}, {'D', "0x44"}, {'E', "0x45"}, {'F', "0x46"}, {'G', "0x47"}, {'H', "0x48"},
            {'I', "0x49"}, {'J', "0x4A"}, {'K', "0x4B"}, {'L', "0x4C"}, {'M', "0x4D"}, {'N', "0x4E"}, {'O', "0x4F"}, {'P', "0x50"},
            {'Q', "0x51"}, {'R', "0x52"}, {'S', "0x53"}, {'T', "0x54"}, {'U', "0x55"}, {'V', "0x56"}, {'W', "0x57"}, {'X', "0x58"},
            {'Y', "0x59"}, {'Z', "0x5A"},

            {'a', "0x61"}, {'b', "0x62"}, {'c', "0x63"}, {'d', "0x64"}, {'e', "0x65"}, {'f', "0x66"}, {'g', "0x67"}, {'h', "0x68"},
            {'i', "0x69"}, {'j', "0x6A"}, {'k', "0x6B"}, {'l', "0x6C"}, {'m', "0x6D"}, {'n', "0x6E"}, {'o', "0x6F"}, {'p', "0x70"},
            {'q', "0x71"}, {'r', "0x72"}, {'s', "0x73"}, {'t', "0x74"}, {'u', "0x75"}, {'v', "0x76"}, {'w', "0x77"}, {'x', "0x78"},
            {'y', "0x79"}, {'z', "0x7A"},
        };

        Dictionary<string, char> KOI8RToChar = new Dictionary<string, char>()
        {
            { "0xE1", 'À' }, { "0xE2", 'Á' }, { "0xF7", 'Â' }, { "0xE7", 'Ã' }, { "0xE4", 'Ä' }, { "0xE5", 'Å' }, { "0xF6", 'Æ' }, { "0xFA", 'Ç' },
            { "0xE9", 'È' }, { "0xEA", 'É' }, { "0xEB", 'Ê' }, { "0xEC", 'Ë' }, { "0xED", 'Ì' }, { "0xEE", 'Í' }, { "0xEF", 'Î' }, { "0xF0", 'Ï' },
            { "0xF2", 'Ð' }, { "0xF3", 'Ñ' }, { "0xF4", 'Ò' }, { "0xF5", 'Ó' }, { "0xE6", 'Ô' }, { "0xE8", 'Õ' }, { "0xE3", 'Ö' }, { "0xFE", '×' },
            { "0xFB", 'Ø' }, { "0xFD", 'Ù' }, { "0xFF", 'Ú' }, { "0xF9", 'Û' }, { "0xF8", 'Ü' }, { "0xFC", 'Ý' }, { "0xE0", 'Þ' }, { "0xF1", 'ß' },

            { "0xC1", 'à' }, { "0xC2", 'á' }, { "0xD7", 'â' }, { "0xC7", 'ã' }, { "0xC4", 'ä' }, { "0xC5", 'å' }, { "0xD6", 'æ' }, { "0xDA", 'ç' },
            { "0xC9", 'è' }, { "0xCA", 'é' }, { "0xCB", 'ê' }, { "0xCC", 'ë' }, { "0xCD", 'ì' }, { "0xCE", 'í' }, { "0xCF", 'î' }, { "0xD0", 'ï' },
            { "0xD2", 'ð' }, { "0xD3", 'ñ' }, { "0xD4", 'ò' }, { "0xD5", 'ó' }, { "0xC6", 'ô' }, { "0xC8", 'õ' }, { "0xC3", 'ö' }, { "0xDE", '÷' },
            { "0xDB", 'ø' }, { "0xDD", 'ù' }, { "0xDF", 'ú' }, { "0xD9", 'û' }, { "0xD8", 'ü' }, { "0xDC", 'ý' }, { "0xC0", 'þ' }, { "0xD1", 'ÿ' },

            { "0x41", 'A' }, { "0x42", 'B' }, { "0x43", 'C' }, { "0x44", 'D' }, { "0x45", 'E' }, { "0x46", 'F' }, { "0x47", 'G' }, { "0x48", 'H' },
            { "0x49", 'I' }, { "0x4A", 'J' }, { "0x4B", 'K' }, { "0x4C", 'L' }, { "0x4D", 'M' }, { "0x4E", 'N' }, { "0x4F", 'O' }, { "0x50", 'P' },
            { "0x51", 'Q' }, { "0x52", 'R' }, { "0x53", 'S' }, { "0x54", 'T' }, { "0x55", 'U' }, { "0x56", 'V' }, { "0x57", 'W' }, { "0x58", 'X' },
            { "0x59", 'Y' }, { "0x5A", 'Z' },

            { "0x63", 'c' }, { "0x64", 'd' }, { "0x65", 'e' }, { "0x66", 'f' }, { "0x67", 'g' }, { "0x68", 'h' }, { "0x69", 'i' },
            { "0x6A", 'j' }, { "0x6B", 'k' }, { "0x6C", 'l' }, { "0x6D", 'm' }, { "0x6E", 'n' }, { "0x6F", 'o' }, { "0x70", 'p' },
            { "0x71", 'q' }, { "0x72", 'r' }, { "0x73", 's' }, { "0x74", 't' }, { "0x75", 'u' }, { "0x76", 'v' }, { "0x77", 'w' },
            { "0x78", 'x' }, { "0x79", 'y' }, { "0x7A", 'z' }
        };
        public Form1()
        {
            InitializeComponent();
        }

        public string[] encode(string text)
        {
            string[] res = { "", "" };

            int strLength = text.Length;

            for (int i = 0; i < strLength; i++)
            {
                if (charToKOI8R.ContainsKey(text[i]))
                {
                    res[0] += charToKOI8R[text[i]];
                    res[1] += Convert.ToString(text[i], 2);
                    res[1] += " ";
                }
            }

            return res;
        }

        public string decode(string text)
        {
            string spltd = "";
            int strLength = text.Length;

            for (int i = 0; i < strLength; i++)
            {
                if (i % 4 == 0)
                {
                    spltd += " ";
                }
                spltd += text[i];
            }

            string res = "";
            string[] test = spltd.Split(' ');

            foreach (string i in test)
            {
                if (KOI8RToChar.ContainsKey(i))
                {
                    res += KOI8RToChar[i];
                }
            }

            return res;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string textToEncode = textBox1.Text;
            string[] encoded = encode(textToEncode);
            textBox2.Text = encoded[0];
            textBox3.Text = encoded[1];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string textToDecode = textBox2.Text;
            textBox1.Text = decode(textToDecode);
            textBox4.Text = textBox1.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}