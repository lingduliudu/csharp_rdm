using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using WpfApp2.effect;
using WpfApp2.tool;

namespace WpfApp2.component;

public class TRichTextBox:RichTextBox{
    
    // 位置
    private static TextPointer? restore;
    // 默认内容颜色
    private SolidColorBrush DefaultForeground = new SolidColorBrush(Colors.Black);
    
    public TRichTextBox():base(){
        base.PreviewMouseMove+=PagePaddingZero;
    }
    private void PagePaddingZero(object sender,MouseEventArgs args){
            Document.PagePadding=new Thickness(0,0,0,0);
    }
    
    
    // 渲染找到的字体
    public void EffectWord(string word){
        // 记录位置
        restore = CaretPosition;
        // 回归位置
        RestoreCaretPosition();
        
    }
    
    public static IEnumerable<TextRange> GetAllWordRanges(FlowDocument document)
    {
        string pattern = @"[^\W\d](\w|[-']{1,2}(?=\w))*";
        TextPointer pointer = document.ContentStart;
        while (pointer != null)
        {
            if (pointer.GetPointerContext(LogicalDirection.Forward) == TextPointerContext.Text)
            {
                string textRun = pointer.GetTextInRun(LogicalDirection.Forward);
                MatchCollection matches = Regex.Matches(textRun, pattern);
                foreach (Match match in matches)
                {
                    int startIndex = match.Index;
                    int length = match.Length;
                    TextPointer start = pointer.GetPositionAtOffset(startIndex);
                    TextPointer end = start.GetPositionAtOffset(length);
                    yield return new TextRange(start, end);
                }
            }

            pointer = pointer.GetNextContextPosition(LogicalDirection.Forward);
        }
        
    }
    
    
    
    /**
 * @Description: 回滚位置
 * @author Hao.Yuan
 */
    private void RestoreCaretPosition(){
        if (restore != null){
            CaretPosition = restore;
        }
    }
    
}