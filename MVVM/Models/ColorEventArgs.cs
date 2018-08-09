namespace ColorViewer.Models
{
    public sealed class ColorEventArgs
    {
        private Color color;

        public ColorEventArgs(Color color)
        {
            this.color = color;
        }

        public Color Color => color;
    }
}