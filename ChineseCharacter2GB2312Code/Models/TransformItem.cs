using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ChineseCharacter2GB2312Code
{
    class TransformItem
    {
        private ItemRawKv _raw = new ItemRawKv();
        public ItemRawKv RawInfo
        {
            get
            {
                return _raw;
            }
            set
            {
                _raw = value;
                Code = Transform(value.Content, value.Name).ToString();
            }
        }
        public string Code { get; private set; }

        public override string ToString()
        {
            return Code;
        }
        private static StringBuilder Transform(string _stringArray, string _arrayName)
        {
            if (!Regex.IsMatch(_arrayName, "^[a-zA-Z_][a-zA-Z0-9_]*$"))
            {
                throw new ArgumentException("Illegal array name");
            }

            var tansformBuilder = new StringBuilder();
            var inputArrays = Encoding.Default.GetBytes(_stringArray);

            tansformBuilder.Append("unsigned char " + _arrayName + "[]={" + Environment.NewLine);

            for (int i = 0; i < inputArrays.Length; i++)
            {
                tansformBuilder.Append("  ");
                if (inputArrays[i] >= 128 && inputArrays[i] <= 247)
                {
                    tansformBuilder.Append(string.Format(@"0x{0},0x{1}",
                        Convert.ToString(inputArrays[i], 16).ToUpper(), Convert.ToString(inputArrays[i + 1], 16).ToUpper()));
                    i++;
                }
                else
                {
                    tansformBuilder.Append(string.Format("0x{0},0x00",
                        Convert.ToString(inputArrays[i], 16).ToUpper()));
                }
                if (i < inputArrays.Length - 1)
                {
                    tansformBuilder.Append("," + Environment.NewLine);
                }
                else
                {
                    tansformBuilder.Append(Environment.NewLine);
                }
            }
            tansformBuilder.Append("};\t//" + _stringArray + Environment.NewLine);

            return tansformBuilder;
        }
    }
}
