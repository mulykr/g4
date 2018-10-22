using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Threading;
using System.Threading;
using System.Windows.Media.Animation;

namespace Forms
{
    public partial class MainWindow : Window
    {

        public MainWindow()
            : base()
        {
            InitializeComponent();
        }

        private void NewWindow(object sender, RoutedEventArgs e)
        {
            Thread newThread = new Thread(new ThreadStart(StartPoint));
            newThread.SetApartmentState(ApartmentState.STA);
            newThread.IsBackground = true;
            newThread.Start();
        }

        private void StartPoint()
        {
            MainWindow temp = new MainWindow();
            temp.Show();
            Dispatcher.Run();
        }

        private void Click(object sender, RoutedEventArgs e)
        {
            Duration duration = new Duration(TimeSpan.FromSeconds(10));
            DoubleAnimation doubleanimation = new DoubleAnimation(100.0, duration);
            progressBar.BeginAnimation(ProgressBar.ValueProperty, doubleanimation);
        }
    }
}
