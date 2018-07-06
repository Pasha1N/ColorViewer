using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.ViewModels
{
   public class MainWindowViewModel: INotifyPropertyChanged     
    {
        private int colorA =0;
        private int colorR = 0;
        private int colorG = 0;
        private int colorB = 0;
        private string colorCode = string.Empty;


        public int ColorA
        {
            get => colorA ;
            set
            {
                colorA  = value;
                OnPropertyChanced(new PropertyChangedEventArgs(nameof(ColorA)));
                ConvertingToHexadecimalSystem();
            }
        }

       public string ColorCode
        {
            get => colorCode;
        }

        public int ColorR
        {
            get => colorR ;
            set
            {
                colorR  = value;
                OnPropertyChanced(new PropertyChangedEventArgs(nameof(ColorR)));
                ConvertingToHexadecimalSystem();
            }
        }

        public int ColorG
        {
            get => colorG;
            set
            {
                colorG = value;
                OnPropertyChanced(new PropertyChangedEventArgs(nameof(ColorG)));
                ConvertingToHexadecimalSystem();
            }
        }

        public int ColorB
        {
            get => colorB;
            set
            {
                colorB = value;
                OnPropertyChanced(new PropertyChangedEventArgs(nameof(ColorB)));
                ConvertingToHexadecimalSystem();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanced(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }

        public void ConvertingToHexadecimalSystem()
        {
            string code = Convert.ToString(255, 16);
            code = string.Concat(code,Convert.ToString(colorR, 16));
            code = string.Concat(code,Convert.ToString(colorG, 16));
            code = string.Concat(code,Convert.ToString(colorB, 16));
            colorCode = code;
            OnPropertyChanced(new PropertyChangedEventArgs(nameof(colorCode)));
        }

    }
}
