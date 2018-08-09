using ColorViewer.Models;

namespace ColorViewer.ViewModels
{
    public class ViewModelFactory
    {
        private ColorManager colorManager;

        public ViewModelFactory(ColorManager colorManager)
        {
            this.colorManager = colorManager;
        }

        public ColorViewModel CreateColorViewModel(Color color)
        {
            return new ColorViewModel(color, colorManager);
        }
    }
}