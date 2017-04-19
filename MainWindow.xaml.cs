﻿using System;
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

namespace TradingApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Globals.db = new Database(); // FIXME handle exception and show dialog
            RefreshPortfolios();
        }

        // Lets get all Portfolios from database
        private void RefreshPortfolios()
        {
            lvPortfolios.ItemsSource = Globals.db.GetAllPortfolios();
        }

        private void lvPortfolios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            //getting selected object from ListView
           Globals.SelectedPortfolio = (Portfolio)lvPortfolios.SelectedItem;

            //assigning needed info from selected objcet to labels

            //Balance
            lbBalance.Content = Globals.SelectedPortfolio.Balance;


            //Cash
            lbCash.Content = Globals.SelectedPortfolio.Cash;

            //Net
            lbNet.Content = Globals.SelectedPortfolio.Net;

        }

        // Action opens new window and sends infromation
        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {

                if (lvPortfolios.SelectedIndex >= 0)
                           {
                Globals.SelectedPortfolio = (Portfolio)lvPortfolios.SelectedItem;
                HomeWindow win2 = new HomeWindow();
                win2.Show();
                          }
              else
        {
                MessageBox.Show("No portfolio is selected", "Confirmation", MessageBoxButton.OK);
                       }


        }
    }
}
