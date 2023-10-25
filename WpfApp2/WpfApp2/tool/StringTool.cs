using System;
using System.Collections.Generic;

namespace WpfApp2.tool;

public class StringTool{
    
    public   Dictionary<int,string> getAllKeyPosition(string text,string word){
        Dictionary<int,string> dictionary = new Dictionary<int, string>();
        int index = 0;
        int count = 0;
        while ((index = text.IndexOf(word, index)) != -1){
            count++;
            if(ValidCheck(text,word,index)) dictionary.Add(index,word);
            index = index + word.Length;
        }
        return dictionary;
    }
    
    public  bool ValidCheck(string content,string keyword,int index){
        // 查找前一个元素
        string before = null;
        string after = null;
        bool beforeFlag = false;
        bool afterFlag = false;
        if (index != 0){
            before = content.Substring(index-1,1);
        }
        if ((index+keyword.Length) <= (content.Length-1)){
            after = content.Substring(index+keyword.Length,1);
        }

        if (before == null || before == "\n" || before == " " ||before == "\t"){
            beforeFlag = true;
        }
            
        if (after == null || after == "\n" || after == " "||after == "\t"){
            afterFlag = true;
        }
        return  beforeFlag&&afterFlag? true:false;
    }
}