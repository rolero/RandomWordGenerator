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
using System.IO;
using System.Collections;

namespace RandomWordGenerator {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private static ArrayList words = new ArrayList();

        private void mainWindow_Loaded(object sender, RoutedEventArgs e) {
            outputTB.Text = "Generate random words from \"words.txt\"";
            ReadData();

        }

        private void generateButton_Click(object sender, RoutedEventArgs e) {
            string randomWords = "";
            Random rand = new Random();
            try {
                for (int i = 0; i < 10; i++) {
                    randomWords += words[rand.Next(0, words.Count)];
                    randomWords += "\n";
                }
            } catch (Exception ex) {
                outputTB.Text = ex.ToString();
            }
            outputTB.Text = randomWords;
        }

        private void editButton_Click(object sender, RoutedEventArgs e) {
            try {
                System.Diagnostics.Process.Start("words.txt");
            } catch (Exception ex) {
                outputTB.Text = ex.ToString();
            }
        }

        private void ReadData() {
            StreamReader inFile = null;
            try {
                inFile = new StreamReader("words.txt");
                while (!inFile.EndOfStream) {
                    words.Add(inFile.ReadLine());
                }
            } catch (Exception ex) {
                outputTB.Text = ex.ToString();
            } finally {
                if (inFile != null)
                    inFile.Close();
            }
        }

        private void reloadButton_Click(object sender, RoutedEventArgs e) {
            outputTB.Text = "Reloading text file...";
            ReadData();
            outputTB.Text = "Done.";
        }
    }
}
