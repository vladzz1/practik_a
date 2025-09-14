using practik_a2;
using System.Configuration;
using System.Windows;
using System.Windows.Controls;
namespace practik_a3;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    Sales sales;
    public MainWindow()
    {
        InitializeComponent();

        string connectionString = ConfigurationManager.ConnectionStrings["SalesConnection"].ConnectionString;

        sales = new Sales(connectionString);
    }
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        DataGrid.ItemsSource = sales.showProducts();
    }
    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        DataGrid.ItemsSource = sales.showClients();
    }
    private void Button_Click_2(object sender, RoutedEventArgs e)
    {
        DataGrid.ItemsSource = sales.showEmployees();
    }
    private void Button_Click_3(object sender, RoutedEventArgs e)
    {
        DataGrid.ItemsSource = sales.showSalles();
    }
}