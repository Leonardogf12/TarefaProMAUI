namespace TarefaPro.MAUI
{
    public static class RandomColorHelper
    {   

        public static Color RandomColor(string colorName) {

            Application.Current.Resources.TryGetValue(colorName, out var color);
            return (Color)color;
        }
    }
}
