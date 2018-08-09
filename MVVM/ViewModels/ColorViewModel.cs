using ColorViewer.Models;
using System.Windows.Input;

namespace ColorViewer.ViewModels
{
    public class ColorViewModel
    {
        private Color color;
        private ColorManager colorManager;
        private ICommand deleteCommand;

        public ColorViewModel(Color color, ColorManager colorManager)
        {
            deleteCommand = new DelegateCommand(Delete);
            this.color = color;
            this.colorManager = colorManager;
        }

        public string ColorCode => color.CodeTheColor;

        public ICommand DeleteCommand => deleteCommand;

        public void Delete()
        {
            colorManager.DeleteColor(color);
        }
    }
}