using System;
using CoreAnimation;
using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using System.Linq;

[assembly: ExportRenderer(typeof(GradientTest.GradientViewRender), typeof(GradientTest.iOS.GradientViewRenderer))]
namespace GradientTest.iOS
{
	public class GradientViewRenderer : ViewRenderer<GradientTest.GradientViewRender, UIView>
	{
		UIView mainView;
		UIView gradientView;
        Color[] gradientColors;
		double cornerRadius;
		double viewHeight;
		double viewWidth;
		bool roundCorners;
		bool leftToRight;

		protected override void OnElementChanged(ElementChangedEventArgs<GradientTest.GradientViewRender> e)
		{
			base.OnElementChanged(e);

			if (Control == null)
			{
                gradientColors = (Color[])e.NewElement.GradientColors;
				cornerRadius = (double)e.NewElement.CornerRadius;
				viewWidth = (double)e.NewElement.ViewWidth;
				viewHeight = (double)e.NewElement.ViewHeight;
				roundCorners = (bool)e.NewElement.RoundCorners;
				leftToRight = (bool)e.NewElement.LeftToRight;

				mainView = new UIView(new CGRect(0, 0, viewWidth, viewHeight));
				//contentView = new UIView(new CGRect(0, 0, viewWidth, viewHeight));
				gradientView = new UIView(new CGRect(0, 0, viewWidth, viewHeight));

				CreateLayout();
			}

			if (e.OldElement != null)
			{
				// Unsubscribe from event handlers and cleanup any resources
			}

			if (e.NewElement != null)
			{
				gradientColors = (Color[])e.NewElement.GradientColors;
				cornerRadius = (double)e.NewElement.CornerRadius;
				viewWidth = (double)e.NewElement.ViewWidth;
				viewHeight = (double)e.NewElement.ViewHeight;
				roundCorners = (bool)e.NewElement.RoundCorners;
				leftToRight = (bool)e.NewElement.LeftToRight;

				CreateLayout();
			}
		}

		protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (e.PropertyName == GradientViewRender.ViewHeightProperty.PropertyName)
			{
				this.viewHeight = (double)this.Element.ViewHeight;
				CreateLayout();
			}
			else if (e.PropertyName == GradientViewRender.ViewWidthProperty.PropertyName)
			{
				this.viewWidth = (double)this.Element.ViewWidth;
				CreateLayout();
			}
            else if (e.PropertyName == GradientViewRender.GradientColorsProperty.PropertyName)
			{
                this.gradientColors = (Color[])this.Element.GradientColors;
				CreateLayout();
			}
			else if (e.PropertyName == GradientViewRender.CornerRadiusProperty.PropertyName)
			{
				this.cornerRadius = (double)this.Element.CornerRadius;
				CreateLayout();
			}
			else if (e.PropertyName == GradientViewRender.RoundCornersProperty.PropertyName)
			{
				this.roundCorners = (bool)this.Element.RoundCorners;
				CreateLayout();
			}
			else if (e.PropertyName == GradientViewRender.LeftToRightProperty.PropertyName)
			{
				this.leftToRight = (bool)this.Element.LeftToRight;
				CreateLayout();
			}
		}

		private void CreateLayout()
		{
            //Clean up any previous views
			if (Control != null)
			{
				foreach (UIView view in Control)
				{
					view.RemoveFromSuperview();
				}
			}

			mainView = new UIView(new CGRect(0, 0, viewWidth, viewHeight));
			gradientView = new UIView(new CGRect(0, 0, viewWidth, viewHeight));

			mainView.BackgroundColor = UIColor.Clear;

			CreateGradient();
            mainView.ClipsToBounds = true;
			gradientView.Layer.MasksToBounds = false;
		
			mainView.AddSubview(gradientView);

			SetNativeControl(mainView);
		}

		public void CreateGradient()
		{
			CAGradientLayer gradient = new CAGradientLayer();

			CGRect tempRect = new CGRect(0, 0, this.viewWidth, this.viewHeight);
			gradient.Frame = tempRect;

            //Need to convert the colors to CGColor objects
            CGColor[] cgColors = new CGColor[gradientColors.Count()];

            for (int i = 0; i < gradientColors.Count(); i++)
            {
                Color temp = gradientColors[i];
                cgColors[i] = temp.ToCGColor();
            }

            gradient.Colors = cgColors;

			//Determine if the gradient should be vertical or left to right
			if (leftToRight)
			{
				gradient.StartPoint = new CGPoint(0, 0.5);
				gradient.EndPoint = new CGPoint(1, 0.5);
			}
			else
			{
				gradient.StartPoint = new CGPoint(0.5, 0);
				gradient.EndPoint = new CGPoint(0.5, 1);
			}

			CGRect rec = new CGRect(0, 0, viewWidth, viewHeight);

			var rounded = UIRectCorner.TopLeft | UIRectCorner.TopRight | UIRectCorner.BottomLeft | UIRectCorner.BottomRight;

            if (roundCorners)
            {
				UIBezierPath path = UIBezierPath.FromRoundedRect(rec, rounded, new CGSize(cornerRadius, cornerRadius));

				CAShapeLayer shape = new CAShapeLayer();
				shape.Path = path.CGPath;

				gradientView.Layer.Mask = shape;
            }

            gradientView.Layer.InsertSublayer(gradient, 0);
		}
	}
}
