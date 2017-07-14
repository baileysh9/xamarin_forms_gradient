using Xamarin.Forms;

namespace GradientTest
{
    public partial class GradientTestPage : ContentPage
    {
        public GradientTestPage()
        {
            InitializeComponent();

            Color[] gradientColors = new Color[] { Color.Black, Color.Orange, Color.Black };

			GradientModel g = new GradientModel()
			{
				GradientColors = gradientColors,
				ViewWidth = 300,
				ViewHeight = 50,
				RoundCorners = true,
				CornerRadius = 10,
				LeftToRight = true
			};

			gradientView.SetBinding(GradientViewRender.GradientColorsProperty, "GradientColors");
			gradientView.SetBinding(GradientViewRender.CornerRadiusProperty, "CornerRadius");
			gradientView.SetBinding(GradientViewRender.ViewWidthProperty, "ViewWidth");
			gradientView.SetBinding(GradientViewRender.ViewHeightProperty, "ViewHeight");
			gradientView.SetBinding(GradientViewRender.RoundCornersProperty, "RoundCorners");
			gradientView.SetBinding(GradientViewRender.LeftToRightProperty, "LeftToRight");

			gradientView.BindingContext = g;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}
