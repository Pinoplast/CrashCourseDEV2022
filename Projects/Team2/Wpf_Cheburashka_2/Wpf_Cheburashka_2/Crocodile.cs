﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;
using Wpf_Cheburashka_2;

namespace Cheburaska_Pattern
{
    class Crocodile : Colleague, IPerson
    {
        int count; // кількість будматеріалу, яку може підняти персонаж
        int strong;
        string name;
        string work;
        bool f = true;
        bool h = true;
        public string Name
        {
            get => name;
            set => name = value;
        }
        
        public Crocodile(IMediator mediator, int strong) : base(mediator)
        {
            name = "Гена";
            this.strong = strong;
        }

        public void Send(string message, int count= 0)
        {
            this.count = count;
            mediator.Send(message, this);
        }

        public void Notify(string message)
        {
            MainWindow mainwindow = (MainWindow)System.Windows.Application.Current.MainWindow;
            if (f)
            {
                f = false;
                String str = "Привіт! " + message;
                ((Label)((Grid)mainwindow.Content).Children[5]).Content = str;
            }
            else
            {
                if(count != 0)
                    GetWork(message, count);
                else
                    ((Label)((Grid)mainwindow.Content).Children[5]).Content = message;
            }
        }

        public int GetWork(string work, int count)
        {
            this.work = work;
            int a;
            if (count <= strong)
            {
                a = count;
            }
            else
            {
                a = 0;
            }
            this.count = a;
            Say();
            return a;
        }
        
        public void Say()
        {
            MainWindow mainwindow = (MainWindow)System.Windows.Application.Current.MainWindow;
            string s = "";
            if (this.count != 0)
            { s = s + $"Я будую {this.work} і несу, будматеріал кількістю {this.count} "; }
            else { s = s + $"Я не можу підняти стільки, найбільше можу підняти кількістю {this.strong} "; }

            ((Label)((Grid)mainwindow.Content).Children[5]).Content = s;
            
            if(h)
            {
                ((Image)((Grid)mainwindow.Content).Children[9]).Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/images/1t.png"));
                h = !h;
            }
            else ((Image)((Grid)mainwindow.Content).Children[9]).Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/images/door.png"));

        }
    }
}