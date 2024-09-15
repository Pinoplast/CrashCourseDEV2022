using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Input;
using Team1_WpfApp.Command;
using Team1_WpfApp.Fairytale;

namespace Team1_WpfApp.ViewModels
{
	public class MainWindowViewModel : INotifyPropertyChanged
	{
        public event PropertyChangedEventHandler? PropertyChanged;

        private string displayText;
        private string actionLog;
        private string piggyName;

        private Piggi? selectedPiggi { get; set; }

        public ObservableCollection<Piggi> pigletsList { get; set; }

        public RelayCommand MyCommand
        {
            get;
            private set;
        }

        // команда добавления нового объекта
        RelayCommand? addPiggi;
        public RelayCommand AddPiggi
        {
            get
            {
                return addPiggi ??
                  (addPiggi = new RelayCommand(obj =>
                  {

                      if (piggyName is null || piggyName == String.Empty) piggyName = "Tip - top";
                      Piggi piggi = new(piggyName, pigletsList.Count + 1);
                      pigletsList.Add(piggi);
                      SelectedPiggi = piggi;
                  }));
            }
        }

        public RelayCommand selectPiggi
        {
            get;
            private set;
        }     

        public string DisplayText
		{
			get
			{
                return displayText;
			}
			set
			{
                if (displayText != value)
                {
                    displayText = value;
                    OnPropertyChanged("DisplayText");
                }
			}
		}

        public string ActionLog
        {
            get
            {
                return actionLog;
            }
            set
            {
                if (actionLog != value)
                {
                    actionLog = value;
                    OnPropertyChanged("ActionLog");
                }
            }
        }

        public string PiggyName
        {
            get
            {
                return piggyName;
            }
            set
            {
                if (piggyName != value)
                {
                    piggyName = value;
                    OnPropertyChanged("PiggyName");
                }
            }
        }

        public Piggi? SelectedPiggi
        {
            get { return selectedPiggi; }
            set
            {
                selectedPiggi = value;
                OnPropertyChanged("SelectedPiggi");
            }
        }

        public MainWindowViewModel()
		{
            // Казка "Троє поросят"

            #region 1. Поросята та вовк

            //a) потрібен абстрактний клас Animals
            // поля - ім'я
            //методи -?

            //б) потрібен клас Piggy, що наслідує Animals
            // поросята вміють веселитись та прокачували скіли, будувати будинок - два методи
            // поля - розум, працьовитість, швидкість
            // Породжуємо трьох поросят: Ніф-Ніф, Наф-Наф і Нуф-Нуф

            //в) потрібен клас Wolf, що наслідує Animals
            // вовк вміє полювати та істи - два методи (коли дуже голодний, то йде шукати поросят)
            // поля - хитрість, сила подиху, голод

            // Породжуємо вовка
            // вміє знижувати міцніть будинків та ламати їх силою подиху - метод 
            // вміє обдурювати поросят - метод
            #endregion

            #region 2. Будинок

            //a) потрібен клас Building
            // поля - назва, міцність, статус
            // має фундамент, стіни, криша, методи -?

            //породжуємо три об'єкти будинків, що будують поросята
            //в залежності від характеристик поросят генеруються різні будинки, де його міцність = сумі міцності матеріалів
            #endregion

            #region 3. Матеріали для будинку

            //a) потрібен клас Material, породжує об'єкти Солома, Дерево, Камень 
            // поля - назва, міцність
            // метод - випадкова генерація характеристики міцності в заданих межах

            #endregion

            // 1. Поросята відпочивають, їм генеруються скіли.
            // створити по одному
            pigletsList = new ObservableCollection<Piggi>()
            {                           
                new Piggi("Ніф-Ніф", 1),
                new Piggi("Наф-Наф", 2),
                new Piggi("Нуф-Нуф", 3)
            };
            
            MyCommand = new RelayCommand(obj => { StartFairyTale(); });
            selectPiggi = new RelayCommand(obj =>
            {
                if (SelectedPiggi != null)
                    ActionLog = SelectedPiggi.GetMesssage();
            });

        }

        public void StartFairyTale()
        {
            DisplayText = "";
            StringBuilder log = new StringBuilder();
            #region 4. Сценарій

            // 2. Будуємо будинки - вибір матеріалів випадковий, в залежності від скілів поросят

            foreach (var piggi in pigletsList)
            {
                //log.Append(piggi.GetMesssage());
                piggi.buildHouse();
                log.Append(piggi.myHouse.GetMesssage());
                log.Append("-------------------------------------------\n");
            }

            // 3. Вовка чекає поки не зголодніє і приходить до першого поросята

            var wolf = new Wolf("Вовк", 10);
            log.Append(wolf.GetMesssage());

            //      - дихає на будинок скільки є сил, якщо розвалив, то їсть та йде до наступного поросяти
            int deadPiggiCount = 0;
            foreach (var piggi in pigletsList)
            {
                log.Append(wolf.destructionBuilding(piggi.myHouse));

                if (!piggi.myHouse.buildingStatus)
                    if (piggi.catched(wolf.speed))
                    {
                        deadPiggiCount++;
                        log.Append($"Я з'їв {piggi.Name} \n");
                    }
                    else
                        log.Append($"{piggi.Name} втік\n");

            }
            //      - намагається обдурити, якщо так, то їсть та йде до наступного поросяти
            //      - не вийшло розвалити та обдурити - порося вижило, йде до наступного поросяти
            //      - пройшов всіх, або втік в ліс, або когось зжер(

            log.Append("---------------------------------------------------------------\n");

            PunisherPiggi superPiggi = new PunisherPiggi("Cупер порося");
            log.Append(superPiggi.GetMesssage());

            string status = superPiggi.punishTheWolf(wolf, deadPiggiCount);
            log.Append(status);

            DisplayText = log.ToString();

            #endregion

        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
