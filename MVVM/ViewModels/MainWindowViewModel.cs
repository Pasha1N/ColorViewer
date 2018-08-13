﻿using ColorViewer.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace ColorViewer.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private Command addCommand;
        private bool canAdd = true;
        private byte colorA = 0;
        private byte colorB = 0;
        private string colorCode = string.Empty;
        private byte colorG = 0;
        private ColorManager colorManager;
        private byte colorR = 0;
        private ICollection<ColorViewModel> colors = new ObservableCollection<ColorViewModel>();
        private ViewModelFactory modelFactory;

        public MainWindowViewModel(ColorManager colorManager, ViewModelFactory viewModelFactory)
        {
            addCommand = new DelegateCommand(Add);
            this.colorManager = colorManager;
            modelFactory = viewModelFactory;

            colorManager.colorAdded += (sender, e) =>
            {
                ColorViewModel color = modelFactory.CreateColorViewModel(e.Color);
                colors.Add(color);
                UpdateAdditionStatus();
            };

            colorManager.colorDeleted += (sender, e) =>
            {
                foreach (ColorViewModel color in colors)
                {
                    if (color.ColorCode.Equals(e.Color.CodeTheColor))
                    {
                        colors.Remove(color);
                        UpdateAdditionStatus();
                        break;
                    }
                }
            };

            //для colorA то есть для "alpha" устанавливается максимальное значение!
            colorA = 255;
            ConvertingToHexadecimalSystem();
            OnPropertyChanced(new PropertyChangedEventArgs(nameof(ColorCode)));
        }

        public ICommand AddCommand => addCommand;

        public bool CanAdd
        {
            get => canAdd;
            set
            {
                canAdd = value;
                OnPropertyChanced(new PropertyChangedEventArgs(nameof(ColorCode)));
            }
        }

        public byte ColorA
        {
            get => colorA;
            set
            {
                if (!colorA.Equals(value))
                {
                    colorA = value;
                    OnPropertyChanced(new PropertyChangedEventArgs(nameof(ColorA)));
                    ConvertingToHexadecimalSystem();
                }
            }
        }

        public byte ColorB
        {
            get => colorB;
            set
            {
                if (!colorB.Equals(value))
                {
                    colorB = value;
                    OnPropertyChanced(new PropertyChangedEventArgs(nameof(ColorB)));
                    ConvertingToHexadecimalSystem();
                }
            }
        }

        public string ColorCode
        {
            get => colorCode;
            set
            {
                if (!colorCode.Equals(value))
                {
                    CanAdd = true;
                    colorCode = value;
                    OnPropertyChanced(new PropertyChangedEventArgs(nameof(ColorCode)));
                    UpdateAdditionStatus();
                }
            }
        }

        public byte ColorG
        {
            get => colorG;
            set
            {
                if (!colorG.Equals(value))
                {
                    colorG = value;
                    OnPropertyChanced(new PropertyChangedEventArgs(nameof(ColorG)));
                    ConvertingToHexadecimalSystem();
                }
            }
        }

        public byte ColorR
        {
            get => colorR;
            set
            {
                if (!colorR.Equals(value))
                {
                    colorR = value;
                    OnPropertyChanced(new PropertyChangedEventArgs(nameof(ColorR)));
                    ConvertingToHexadecimalSystem();
                }
            }
        }

        public IEnumerable<ColorViewModel> Colors => colors;

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanced(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }

        public void Add()
        {
            Models.Color color = new Models.Color(colorCode);

            if (CanAdd)
            {
                colorManager.AddColor(color);
            }
        }

        public void ConvertingToHexadecimalSystem()
        {
            ColorCode = System.Windows.Media.Color.FromArgb(colorA, colorR, colorG, colorB).ToString();
        }

        public void UpdateAdditionStatus()
        {
            if (colors.Count > 0)
            {
                foreach (ColorViewModel color in colors)
                {
                    CanAdd = ColorCode != color.ColorCode;
                }
            }
            else
            {
                CanAdd = true;
            }

            OnPropertyChanced(new PropertyChangedEventArgs(nameof(CanAdd)));
        }
    }
}