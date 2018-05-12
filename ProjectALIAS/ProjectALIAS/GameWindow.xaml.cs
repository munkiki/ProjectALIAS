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
using System.Windows.Threading;

namespace ProjectALIAS
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        List<string> wordsList;
        int targetScore;
        int roundDuration;
        List<Team> teamList;
        int roundTime;
        public GameWindow()
        {
            InitializeComponent();
        }
        DispatcherTimer roundTimer = new DispatcherTimer();
        public GameWindow(List<string> t, int target, int time, List<Team> tList)
        {
            InitializeComponent();
            wordsList = t;
            targetScore = target;
            roundDuration = time;
            teamList = tList;
            roundTime = roundDuration;
        }
        
        public void backToWindow1(object sender, RoutedEventArgs e)
        {
            Window1 w1 = new Window1();
            w1.Show();
            Close();
        }
        public void ShowInfo()//Показує інформацію про поточну гру (для себе)
        {
            WordBox.Text += "The round duration is: " + roundDuration + Environment.NewLine;
            WordBox.Text += "The target score is: " + targetScore + Environment.NewLine;
            WordBox.Text += "The list of words:" + Environment.NewLine;
            foreach(string s in wordsList)
            {
                WordBox.Text += s + Environment.NewLine;
            }
        }
        public void StartRound(object sender, EventArgs e)//Початок раунду
        {
            roundTimer.Interval = new TimeSpan(0, 0, 1);
            roundTimer.Tick += new EventHandler(TimerTick);
            roundTimer.Start();
            
        }
        public void TimerTick(object sender, EventArgs e)//Оновлення залишкового часу раунду
        {
            if (roundTime >= 0)
            {
                TimerBox.Text = "До кінця раунду " + roundTime.ToString() + " секунд";
                roundTime--;
            }
            else roundTimer.Stop();
        }

        
    }
    public class Team
    {
        int currentscore = 0;
        bool isActive = false;
        bool wins = false;
    }
}
