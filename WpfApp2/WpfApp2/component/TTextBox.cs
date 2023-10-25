using System.Collections.Generic;
using System.Net.Mime;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace WpfApp2.component;

public class TTextBox:TextBox{
    
    public void ITextBox(){
        TextWrapping=TextWrapping.NoWrap;
    }

    
}