using System.Reflection.Metadata;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using WpfApp2.model;

namespace WpfApp2.component;

public class TLineTextBlock:TextBlock{
    //  默认值
    public static readonly SolidColorBrush DefaultBackground= new SolidColorBrush(Color.FromRgb(0xcf,0xcf,0xcf));
    public static readonly SolidColorBrush DefaultForeground= new SolidColorBrush(Color.FromRgb(0x00,0x84,0x97));
    public static readonly Thickness DefaultThickness= new Thickness(2,0,0,0);
    private int DefaultWidth = 37; 
    private double DefaultLineHeight = 0.1; 
    
    public TLineTextBlock(){
        Init();
    }


    
    public TextBlock Init(){
        LineHeight=DefaultLineHeight;
        Background = DefaultBackground;
        Foreground = DefaultForeground;
        Padding=DefaultThickness;
        Width=DefaultWidth;
        return this;
    }
    
}