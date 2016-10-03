using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseCharacter2GB2312Code.Models
{
    /// <summary>
    /// CPP11关键字匹配器(Contains all of C99 Keywords)
    /// </summary>
    class KeywordMacher
    {
        private static string[] StrArr = { "asm", "do", "if", "return", "typedef", "auto", "double", "inline", "short",
                                           "typeid", "bool", "dynamic_cast", "int", "signed", "typename", "break", "else",
                                           "long", "sizeof", "union", "case", "enum", "mutable", "static", "unsigned",
                                           "catch", "explicit", "namespace", "static_cast", "using", "char", "export",
                                           "new", "struct", "virtual", "class", "extern", "operator", "switch", "void",
                                           "const", "false", "private", "template", "volatile", "const_cast", "float",
                                           "protected", "this", "wchar_t", "continue", "for", "public", "throw", "while",
                                           "default", "friend", "register", "true", "delete", "goto", "reinterpret_cast",
                                           "try", "alignas", "alignof", "char16_t", "char32_t", "constexpr", "decltype",
                                           "noexcept", "nullptr", "static_assert", "thread_local" };

        /// <summary>
        /// 返回指定字符串是否与CPP11关键字冲突
        /// </summary>
        /// <param name="str">string to test</param>
        public static bool Match(string str)
        {
            return StrArr.Contains(str);
        }
    }
}
