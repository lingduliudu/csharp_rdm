
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace WpfApp2.model;

public partial class MainModel:ObservableObject{
    
    [ObservableProperty]
    private string? name="";
    
    [ObservableProperty]
    private double fontSize=12;
    
    [ObservableProperty]
    private List<LineNumber>? lineNums=new List<LineNumber>();

    [ObservableProperty] 
    private List<string> treeNode;
    
    [RelayCommand]
    private void RichTextChange(){
        Console.WriteLine("123");
    }


    public MainModel(){
    }
}