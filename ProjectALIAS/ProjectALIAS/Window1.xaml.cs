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
using System.Windows.Shapes;
using System.IO;

namespace ProjectALIAS
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        public void backToMainWindow(object sender, RoutedEventArgs e)
        {
            MainWindow w1 = new MainWindow();
            w1.Show();
            Close();
        }
        public void startNewGame(object sender, RoutedEventArgs e)
        {
            
            List<string> wordsList = new List<string>();
            string line = "";
            StreamReader FileReader = new StreamReader("Words.txt");
            while ((line = FileReader.ReadLine()) != null)
            {
                wordsList.Add(line);
            }
            FileReader.Close();
            //Обробка результатів вибору користувача буде знизу
            int teamNumber = int.Parse(TeamNumber.SelectedValue.ToString()); //Кількість команд
            int difficulty = 0; //Складність слів
            switch (Difficulty.SelectedIndex)
            {
                case 0:
                    difficulty = 0;
                    break;
                default:
                    difficulty = Difficulty.SelectedIndex;
                    break;
            }
            int targetScore = int.Parse(Target.SelectedValue.ToString()); //Цільові очки
            int roundDuration = int.Parse(Time.SelectedValue.ToString()); //Час раунду
            string themeTag = ""; //Стрічка, яка відповідатиме за перевірку тематики
            switch (Theme.SelectedIndex)
            {
                case 0:
                    themeTag = " ";
                    break;
                case 1:
                    themeTag = "cos";
                    break;
                case 2:
                    themeTag = "chem";
                    break;
                case 3:
                    themeTag = "art";
                    break;
                case 4:
                    themeTag = "fun";
                    break;
                case 5:
                    themeTag = "animal";
                    break;
            }
            List<string> tagWordsList = new List<string>();// Робочий список слів з вибраною тематикою
            foreach(string s in wordsList)
            {
                if (themeTag == "cos" && s.Contains("cos") == true)
                {
                    tagWordsList.Add(s);
                }
                else if (themeTag == "chem" && s.Contains("chem") == true)
                {
                    tagWordsList.Add(s);
                }
                else if (themeTag == "art" && s.Contains("art") == true)
                {
                    tagWordsList.Add(s);
                }
                else if (themeTag == "fun" && s.Contains("fun") == true)
                {
                    tagWordsList.Add(s);
                }
                else if (themeTag == "animal" && s.Contains("animal") == true)
                {
                    tagWordsList.Add(s);
                }
                else if (themeTag == " " && s.Contains(" ") == true)
                {
                    tagWordsList.Add(s);
                }
            }
            List<string> diffWordsList = new List<string>();// Робочий список слів з вибраною тематикою та складністю
            foreach (string s in tagWordsList)
            {
                if (difficulty == 0 && s.Contains(" ") == true)
                {
                    diffWordsList.Add(s);
                }
                if (difficulty == 1 && s.Contains("1") == true)
                {
                    diffWordsList.Add(s);
                }
                if (difficulty == 2 && s.Contains("2") == true)
                {
                    diffWordsList.Add(s);
                }
                if (difficulty == 3 && s.Contains("3") == true)
                {
                    diffWordsList.Add(s);
                }
                if (difficulty == 4 && s.Contains("4") == true)
                {
                    diffWordsList.Add(s);
                }
                if (difficulty == 5 && s.Contains("5") == true)
                {
                    diffWordsList.Add(s);
                }
            }
            List<string> finalWordsList = new List<string>();// Список слів без зайвої інформації
            foreach (string s in diffWordsList)
            {
                finalWordsList.Add(s.Split(' ')[0]);
            }
            GameWindow w1 = new GameWindow(finalWordsList);//Передача списку слів у нове вікно
            //for (int i = 0; i < diffWordsList.Count; i++) //Вивід списку зі словами без зайвої інфо
            //{
            //    w1.WordBox.Text += finalWordsList[i] + Environment.NewLine;
            //}
            
            w1.Show();

            Close();

        }
        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            List<int> data = new List<int>();
            data.Add(2);
            data.Add(3);
            data.Add(4);
            data.Add(5);
            var comboBox = sender as ComboBox;
            comboBox.ItemsSource = data;
            comboBox.SelectedIndex = 0;
        }
        private void ComboBox1_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> data = new List<string>();
            data.Add("Всі");
            data.Add("1");
            data.Add("2");
            data.Add("3");
            data.Add("4");
            data.Add("5");
            var comboBox = sender as ComboBox;
            comboBox.ItemsSource = data;
            comboBox.SelectedIndex = 0;
        }
        private void ComboBox2_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> data = new List<string>();
            data.Add("Всі слова");
            data.Add("Козаки");
            data.Add("Хімія");
            data.Add("Мистецтво");
            data.Add("Розваги");
            data.Add("Тварини");
            var comboBox = sender as ComboBox;
            comboBox.ItemsSource = data;
            comboBox.SelectedIndex = 0;
        }
        private void ComboBox3_Loaded(object sender, RoutedEventArgs e)
        {
            List<int> data = new List<int>();
            data.Add(30);
            data.Add(45);
            data.Add(60);
            data.Add(75);
            data.Add(90);
            var comboBox = sender as ComboBox;
            comboBox.ItemsSource = data;
            comboBox.SelectedIndex = 0;
        }
        private void ComboBox4_Loaded(object sender, RoutedEventArgs e)
        {
            List<int> data = new List<int>();
            data.Add(30);
            data.Add(40);
            data.Add(50);
            data.Add(60);
            data.Add(70);
            var comboBox = sender as ComboBox;
            comboBox.ItemsSource = data;
            comboBox.SelectedIndex = 0;
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            string value = comboBox.SelectedItem as string;
            Title = "Selected: " + value;
        }
    }
}
