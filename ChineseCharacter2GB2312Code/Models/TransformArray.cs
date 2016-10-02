using ChineseCharacter2GB2312Code.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ChineseCharacter2GB2312Code
{
    class TransformArray
    {
        public ObservableCollection<TransformItem> Item { get; private set; }
        private HashSet<string> _nameSet;
        public TransformArray()
        {
            Item = new ObservableCollection<TransformItem>();
            _nameSet = new HashSet<string>();
        }
        internal void Add(string _content, string _name)
        {
            if (_nameSet.Contains(_name))
            {
                throw new ArgumentException("Array name already exists");
            }
            else if (KeywordMacher.Match(_name))
            {
                throw new ArgumentException("Array name is in conflict with keyword(C99)");
            }
            else
            {
                _nameSet.Add(_name);
            }

            Item.Add(new TransformItem { RawInfo = new ItemRawKv { Content = _content, Name = _name } });
        }

        public override string ToString()
        {
            return _getListString();
        }

        internal void Clear()
        {
            _nameSet.Clear();
            Item.Clear();
        }

        internal void RemoveAt(int _index)
        {
            _nameSet.Remove(Item[_index].RawInfo.Name);
            Item.RemoveAt(_index);
        }

        private string _getListString()
        {
            var _builder = new StringBuilder();

            foreach (var _item in Item)
            {
                _builder.Append(_item + Environment.NewLine);
            }

            return _builder.ToString();
        }
    }
}
