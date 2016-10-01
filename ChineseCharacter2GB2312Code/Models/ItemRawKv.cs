using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseCharacter2GB2312Code
{
    class ItemRawKv
    {
        private string _content = string.Empty;
        private string _name = string.Empty;
        public string Content
        {
            get
            {
                return _content;
            }
            set
            {
                _content = value;
            }
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
    }
}
