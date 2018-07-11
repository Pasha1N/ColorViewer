using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MVVM.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private byte colorA = 0;
        private byte colorR = 0;
        private byte colorG = 0;
        private byte colorB = 0;
        private string colorCode = string.Empty;


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

        public string ColorCode
        {
            get => colorCode;
            set
            {
                if (!colorCode.Equals(value))
                {
                    colorCode = value;
                    OnPropertyChanced(new PropertyChangedEventArgs(nameof(ColorCode)));
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

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanced(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }

        public void ConvertingToHexadecimalSystem()
        {
            ColorCode = Color.FromArgb(colorA, colorR, colorG, colorB).ToString();
        }



    }
}