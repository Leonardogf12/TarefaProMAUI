namespace TarefaPro.MAUI
{
    public static class GridHelper
    {
        public static void SetRowAndColumn(View view, int row = 0, int column = 0)
        {
            Grid.SetRow(view, row);
            Grid.SetColumn(view, column);
        }
    }
}
