using System;
using Xamarin.Forms;
namespace GradientTest
{
    public class GradientViewRender : View
    {
        public static readonly BindableProperty GradientColorsProperty = BindableProperty.Create<GradientViewRender, Color[]>(p => p.GradientColors, new Color[]{Color.White} );

		public Color[] GradientColors
		{
			get { return (Color[])base.GetValue(GradientColorsProperty); }
			set { base.SetValue(GradientColorsProperty, value); }
		}

		public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create<GradientViewRender, double>(p => p.CornerRadius, 0);

		public double CornerRadius
		{
			get { return (double)base.GetValue(CornerRadiusProperty); }
			set { base.SetValue(CornerRadiusProperty, value); }
		}

		public static readonly BindableProperty ViewHeightProperty = BindableProperty.Create<GradientViewRender, double>(p => p.ViewHeight, 0);

		public double ViewHeight
		{
			get { return (double)base.GetValue(ViewHeightProperty); }
			set { base.SetValue(ViewHeightProperty, value); }
		}

		public static readonly BindableProperty ViewWidthProperty = BindableProperty.Create<GradientViewRender, double>(p => p.ViewWidth, 0);

		public double ViewWidth
		{
			get { return (double)base.GetValue(ViewWidthProperty); }
			set { base.SetValue(ViewWidthProperty, value); }
		}

		public static readonly BindableProperty RoundCornersProperty = BindableProperty.Create<GradientViewRender, bool>(p => p.RoundCorners, false);

		public bool RoundCorners
		{
			get { return (bool)base.GetValue(RoundCornersProperty); }
			set { base.SetValue(RoundCornersProperty, value); }
		}

		public static readonly BindableProperty LeftToRightProperty = BindableProperty.Create<GradientViewRender, bool>(p => p.LeftToRight, true);

		public bool LeftToRight
		{
			get { return (bool)base.GetValue(LeftToRightProperty); }
			set { base.SetValue(LeftToRightProperty, value); }
		}
    }
}
