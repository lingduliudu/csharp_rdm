using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using WpfApp2.component;
using WpfApp2.effect;
using WpfApp2.model;

namespace WpfApp2{
    public partial class MainWindow : Window{
        public MainWindow(){
            InitializeComponent();
            ChangeRichText(RichBox, null);
        }

        private void ChangeRichText(object sender, TextChangedEventArgs args){
            initLineNum();
            Dispatcher.BeginInvoke(() =>{
               IEnumerable<TextRange> wordRanges = TRichTextBox.GetAllWordRanges(RichBox.Document);
               foreach (TextRange wordRange in wordRanges)
               {
                   if (KeywordEffect.keywordMap.ContainsKey(wordRange.Text)){
                       wordRange.ApplyPropertyValue(TextElement.ForegroundProperty,KeywordEffect.keywordMap[wordRange.Text]);
                   }
                   else{
                       wordRange.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.Black);
                   }
               }
            });
        }

        private void OnMouseClick(object sender,MouseButtonEventArgs args){
            Dispatcher.BeginInvoke(() =>{
                Point position = Mouse.GetPosition(RichBox);
                if (position == null) return;
                TextPointer textPointer = RichBox.GetPositionFromPoint(position, true);
                if (textPointer == null) return;
                if (textPointer.Paragraph == null) return;
                var blocks = FlowDocument?.Blocks;
                foreach (var block in blocks){
                    if (block == textPointer.Paragraph){
                        textPointer.Paragraph.Background = Brushes.Aqua;
                        continue;
                    }
                    block.Background = Brushes.Azure;
                }
            });
            
        }

        private void OnKeyUp(object sender, KeyEventArgs e){
            Dispatcher.BeginInvoke(() =>
            {
                TextPointer textPointer = RichBox.CaretPosition;
                if (textPointer == null) return;
                if (textPointer.Paragraph == null) return;
                var blocks = FlowDocument?.Blocks;
                foreach (var block in blocks){
                    if (block == textPointer.Paragraph){
                        textPointer.Paragraph.Background = Brushes.Aqua;
                    }
                    else{
                        block.Background = Brushes.Azure;
                    }
                }

            });
           
        }

        private void initLineNum(){
             int? lines = FlowDocument?.Blocks?.Count;
             LineNumGrid.Children.Clear();
            if (lines == null || lines == 0) {
                TLineTextBlock tb = new TLineTextBlock();
                tb.FontSize = (this.DataContext as MainModel).FontSize;
                tb.Text=1+"";
                // 设置提示
                ToolTip toolTip = new ToolTip();
                toolTip.Placement=PlacementMode.Right;
                toolTip.Content="这是第"+1+"行";
                tb.ToolTip = toolTip;
                LineNumGrid.Children.Add(tb);
                return;
            }
            int index = 1;
            foreach (var block in FlowDocument.Blocks){
                TLineTextBlock tb = new TLineTextBlock();
                tb.Background=block.Background;
                tb.FontSize = (this.DataContext as MainModel).FontSize;
                tb.Text=index+"";
                // 设置提示
                ToolTip toolTip = new ToolTip();
                toolTip.Placement=PlacementMode.Right;
                toolTip.Content="这是第"+index+"行";
                tb.ToolTip = toolTip;
                LineNumGrid.Children.Add(tb);
                index++;
            }
        }
        private void changeLineNumColor(int index){
            UIElementCollection tbs =  LineNumGrid.Children;
            for (var i = 1; i <= tbs.Count; i++){
                if(i == index){
                    (tbs[i] as TextBlock).Background=Brushes.Blue;
                }
            }
        }
        /**
         * @Description: 鼠標移動
         * @author Hao.Yuan
         */
        private  void OnMouseMove(object sender,MouseEventArgs args){
            (sender as Rectangle).Fill = Brushes.Red;
        }
    }

}