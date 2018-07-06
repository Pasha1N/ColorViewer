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
        private int valueTypeColorR=0;

        public int ColorR
        {
            get => valueTypeColorR;
            set
            {
                valueTypeColorR = value;
                OnPropertyChanced(new PropertyChangedEventArgs(nameof(ColorR)));
            }
         
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanced(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }
    }
}
