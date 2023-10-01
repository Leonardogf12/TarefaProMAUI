namespace TarefaPro.MAUI.Helpers.Components
{
    public class ScaleUpScaleDownHelper
    {
        const int DefaultScale = 1;
        const double Scale = 0.95;
        const uint  DurationOfAnimantion = 100;

        public async Task SetScaleOnElement(View element, 
                                            double scale = Scale,
                                            uint durationOfAnimation = DurationOfAnimantion)
        {           
            await element.ScaleTo(scale, durationOfAnimation, Easing.Linear);
            await element.ScaleTo(DefaultScale, durationOfAnimation, Easing.Linear);
        }
    }
}
