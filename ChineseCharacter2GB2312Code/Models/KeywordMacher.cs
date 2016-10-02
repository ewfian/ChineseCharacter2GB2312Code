using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseCharacter2GB2312Code.Models
{
    /// <summary>
    /// C99关键字匹配器
    /// </summary>
    class KeywordMacher{
        private static string[] StrArr = {"char","double", "enum", "float", "int", "long", "short", "signed", "struct", "union", "unsigned", "void",
                                          "for" ,"do" ,"while" ,"break" ,"continue" ,"if","else" ,"goto" ,"switch" ,"case" ,"default" ,"return",
                                          "auto" ,"extern" ,"register" ,"static" ,"const" ,"sizeof" ,"typedef" ,"volatile" };

        /// <summary>
        /// 返回指定字符串是否与C99关键字冲突
        /// </summary>
        public static bool Match(string str){
            return StrArr.Contains(str);
        }
    }
}
