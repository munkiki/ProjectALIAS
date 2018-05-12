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
        int currentTeamNumber = 0;
        int TeamNumber;
        DispatcherTimer roundTimer = new DispatcherTimer();
        List<Word> words = new List<Word>();
        Random x = new Random();
        public GameWindow()
        {
            InitializeComponent();
        }
        public GameWindow(List<string> t, int target, int time, List<Team> tList, int tNumber)
        {
            InitializeComponent();
            wordsList = t;
            targetScore = target;
            roundDuration = time;
            teamList = tList;
            roundTime = roundDuration;
            TeamNumber = tNumber;
            foreach(string s in wordsList)
            {
                words.Add(new Word(s));
            }
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
            newWord();
            roundTime = roundDuration;
            roundTimer.Interval = new TimeSpan(0,0,1);
            roundTimer.Tick += new EventHandler(TimerTick);
            roundTimer.Start();
            next.Visibility = Visibility.Visible;
            skip.Visibility = Visibility.Visible;
            start.Visibility = Visibility.Hidden;
            if (currentTeamNumber < TeamNumber)
            {
                currentTeamNumber++;
            }
            else
            {
                currentTeamNumber = 1;
            }
            teamList[currentTeamNumber - 1].isActive = true;
        }
        public void TimerTick(object sender, EventArgs e)//Оновлення залишкового часу раунду
        {
            if (roundTime >= 0)
            {
                TimerBox.Text = "До кінця раунду " + roundTime.ToString() + " секунд";
                roundTime--;
                teamtext.Text = "";
                teamInfo();
            }
            else//Вихід з циклу раунду
            {
                roundTimer.Stop();
                roundTimer = new DispatcherTimer();
                next.Visibility = Visibility.Hidden;
                skip.Visibility = Visibility.Hidden;
                start.Visibility = Visibility.Visible;
                TimerBox.Clear();
                WordBox.Clear();
                teamList[currentTeamNumber - 1].isActive = false;
                if (teamList[currentTeamNumber - 1].wins == true)//Перевірка, чи за раунд команда набрала виграшну кількість очок
                {
                    Victory();
                }
            }
        }
        public void teamInfo()
        {
            int i = 1;
            foreach(Team t in teamList)
            {
                teamtext.Text += "Команда " + i + ": " + t.currentscore + " очок." + Environment.NewLine;
                i++;
            }
        }
        public void SkipWord(object sender, EventArgs e)
        {
            newWord();
        }
        public void NextWord(object sender, EventArgs e)
        {
            newWord();
            foreach (Team t in teamList)
            {
                if (t.isActive == true)
                {
                    t.currentscore++;
                    if (t.currentscore >= targetScore)
                    {
                        t.wins = true;
                    }
                }    
            }
        }
        public void Victory()
        {
            VictoryResultsWindow w1 = new VictoryResultsWindow();
            
            w1.victoryBox.Text += "Команда " + currentTeamNumber + " перемогла!" + Environment.NewLine;
            w1.victoryBox.Text += "Остаточний рахунок:" + Environment.NewLine;
            int i = 0;
            foreach(Team t in teamList)
            {
                i++;
                w1.victoryBox.Text += "Команда " + i + ": " + t.currentscore + " очок." + Environment.NewLine;
            }
            w1.Show();
            Close();
        }
        public void newWord()//Вивід нового слова в гру
        {
            int unusedWordsCount = 0;
            foreach(Word w in words)
            {
                if(w.isUsed == false)
                {
                    unusedWordsCount++;
                }
            }
            if (unusedWordsCount != 0)
            {
                int randomNumber = x.Next(words.Count);
                if (words[randomNumber].isUsed == false)
                {
                    WordBox.Text = words[randomNumber].Name;
                    words[randomNumber].isUsed = true;
                }
                else
                {
                    newWord();
                }
            }
            else
            {
                foreach(Word w in words)
                {
                    w.isUsed = false;
                }
            }
        }
    }
    public class Team
    {
        public int currentscore = 0;
        public bool isActive = false;
        public bool wins = false;
    }
    public class Word
    {
        public string Name;
        public bool isUsed = false;
        public Word(string t)
        {
            Name = t;
        }
    }
}
