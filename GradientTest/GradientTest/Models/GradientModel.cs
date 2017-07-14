using System;
namespace GradientTest
{
    public class GradientModel
    {
        public Xamarin.Forms.Color[] GradientColors { get; set; }
		public double ViewWidth { get; set; }
		public double ViewHeight { get; set; }
		public bool RoundCorners { get; set; }
        public double CornerRadius { get; set; }
		public bool LeftToRight { get; set; }
    }
}
