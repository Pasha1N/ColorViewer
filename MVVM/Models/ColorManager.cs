using System;
using System.Collections.Generic;

namespace ColorViewer.Models
{
    public class ColorManager
    {
        private ICollection<Color> colors = new List<Color>();

        public IEnumerable<Color> Colors => colors;

        public event EventHandler<ColorEventArgs> colorAdded;
        public event EventHandler<ColorEventArgs> colorDeleted;

        public void OnColorAdded(ColorEventArgs e)
        {
            colorAdded?.Invoke(this, e);
        }

        public void OnColorDeleted(ColorEventArgs e)
        {
            colorDeleted?.Invoke(this, e);
        }

        public void AddColor(Color color)
        {
            colors.Add(color);
            OnColorAdded(new ColorEventArgs(color));
        }

        public void DeleteColor(Color color)
        {
            if (colors.Remove(color))
            {
                OnColorDeleted(new ColorEventArgs(color));
            }
        }
    }
}