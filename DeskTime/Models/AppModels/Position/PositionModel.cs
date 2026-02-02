namespace DeskTime.Models.AppModels.Position
{
    public class PositionModel
    {
        private double _left;
        private double _top;
        public double Left 
        {
            get => _left; 
            set
            {
                _left = value;
                DeskTime.Classes.System.Settings.SaveSettings().GetAwaiter().GetResult();
            }
        }
        public double Top 
        { 
            get => _top; 
            set
            {
                _top = value;
                DeskTime.Classes.System.Settings.SaveSettings().GetAwaiter().GetResult();
            }
        }
    }
}
