using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GameOfLife.Models;

namespace GameOfLife.GUI
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    GUISettings _gs;
    Simulator _sim;
    const int GridSize = 20;

    public MainWindow()
    {
      InitializeComponent();
      //Window_Loaded();
      _gs = new GUISettings() { Width = 20, Height = 20 };
      _sim = new Simulator(_gs);
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
      for (int i = _gs.LowerBoundHorizontal; i <= _gs.Width; i++)
      {
        simGrid.ColumnDefinitions.Add(
                      new ColumnDefinition());
      }
      for (int i = _gs.LowerBoundVertical; i <= _gs.Height; i++)
      {
        simGrid.RowDefinitions.Add(
                      new RowDefinition());
      }

      for (int i = _gs.LowerBoundHorizontal; i <= _gs.Width; i++)
      {
        for (int j = _gs.LowerBoundVertical; j <= _gs.Height; j++)
        {
          Rectangle rect = new Rectangle();
          Grid.SetColumn(rect, j-1);
          Grid.SetRow(rect, i-1);
          rect.DataContext = _sim.GetCell(i, j);
          //rect.SetBinding(OpacityProperty);
          rect.Fill = Brushes.AliceBlue;
          simGrid.Children.Add(rect);
        }
      }

      simGrid.ShowGridLines = true;
    }

    private void Window_ContentRendered(object sender, RoutedEventArgs e)
    {

    }

    private void button_Click(object sender, RoutedEventArgs e)
    {

    }

    private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    private void scrollBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {

    }

    private void button1_Click(object sender, RoutedEventArgs e)
    {

    }
  }
}
