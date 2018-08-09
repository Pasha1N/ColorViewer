namespace ColorViewer.Models
{
    public class Color
    {
        private string codeTheColor = string.Empty;

        public Color(string codeTheColor)
        {
            this.codeTheColor = codeTheColor;
        }

        public string CodeTheColor => codeTheColor;
    }
}