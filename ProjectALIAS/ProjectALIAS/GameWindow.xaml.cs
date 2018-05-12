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
        //поля
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
        //Конструктори
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
        //Повернення до меню вибору параметрів гри
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
            newWord();//Генеруємо нове слово
            //Задаємо тривалість і інші параметри таймеру
            roundTime = roundDuration;
            roundTimer.Interval = new TimeSpan(0,0,1);
            roundTimer.Tick += new EventHandler(TimerTick);
            roundTimer.Start();
            //Ховаємо і показуємо потрібні кнопки
            next.Visibility = Visibility.Visible;
            skip.Visibility = Visibility.Visible;
            start.Visibility = Visibility.Hidden;
            //Активація наступної по черзі команди гравців
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
        //Оновлення залишкового часу раунду
        public void TimerTick(object sender, EventArgs e)
        {
            if (roundTime >= 0)
            {
                TimerBox.Text = "До кінця раунду " + roundTime.ToString() + " секунд";
                roundTime--;
                teamtext.Text = "";
                teamInfo();
            }
            else//Кінець раунду
            {
                roundTimer.Stop(); //Зупинка таймера
                roundTimer = new DispatcherTimer(); //Переініціалізація таймера (бо багався)
                //Активація і деактивація кнопок
                next.Visibility = Visibility.Hidden;
                skip.Visibility = Visibility.Hidden;
                start.Visibility = Visibility.Visible;
                //Очистка тексту з полів таймера і слова
                TimerBox.Clear();
                WordBox.Clear();
                //Деактивація команди
                teamList[currentTeamNumber - 1].isActive = false;
                //Перевірка, чи за раунд команда набрала виграшну кількість очок
                if (teamList[currentTeamNumber - 1].wins == true)
                {
                    Victory();
                }
            }
        }
        public void teamInfo()//Інформація про команду
        {
            int i = 1;
            foreach(Team t in teamList)
            {
                teamtext.Text += "Команда " + i + ": " + t.currentscore + " очок." + Environment.NewLine;
                i++;
            }
        }
        public void SkipWord(object sender, EventArgs e)//Пропуск слова
        {
            newWord();
        }
        public void NextWord(object sender, EventArgs e)//Наступне слово
        {
            newWord();
            foreach (Team t in teamList)//Перевірка, чи в кінці раунду команда набрала виграшну кількість очок
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
        public void Victory()//Вивід інформації по закінченні гри
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
            //Перевірка, чи всі слова використані
            foreach (Word w in words)
            {
                if(w.isUsed == false)
                {
                    unusedWordsCount++;
                }
            }
            //Генерування нового, ще не використаного, слова
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
            //Оновлення списку невикористаних слів, якщо вже всі були
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
