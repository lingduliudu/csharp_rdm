using CommunityToolkit.Mvvm.ComponentModel;

namespace WpfApp2.model;

public partial class  LineNumber:ObservableObject{
    [ObservableProperty]
    public int num;
    [ObservableProperty]
    public int? fontSize;
}