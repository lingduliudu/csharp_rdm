using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace WpfApp2.effect;

public class KeywordEffect{
    public static Dictionary<string, SolidColorBrush> keywordMap = new Dictionary<string, SolidColorBrush>();
    public static HashSet<Key> normalKey = new HashSet<Key>();

    
    static KeywordEffect(){
        keywordMap["class"] = Brushes.Blue;
        keywordMap["public"] = Brushes.Blue;
        // 正常key
        normalKey.Add(Key.A);
        normalKey.Add(Key.B);
        normalKey.Add(Key.C);
        normalKey.Add(Key.D);
        normalKey.Add(Key.E);
        normalKey.Add(Key.F);
        normalKey.Add(Key.G);
        normalKey.Add(Key.H);
        normalKey.Add(Key.I);
        normalKey.Add(Key.J);
        normalKey.Add(Key.K);
        normalKey.Add(Key.L);
        normalKey.Add(Key.M);
        normalKey.Add(Key.N);
        normalKey.Add(Key.O);
        normalKey.Add(Key.P);
        normalKey.Add(Key.Q);
        normalKey.Add(Key.R);
        normalKey.Add(Key.S);
        normalKey.Add(Key.T);
        normalKey.Add(Key.U);
        normalKey.Add(Key.V);
        normalKey.Add(Key.W);
        normalKey.Add(Key.X);
        normalKey.Add(Key.Y);
        normalKey.Add(Key.Z);
    }
}