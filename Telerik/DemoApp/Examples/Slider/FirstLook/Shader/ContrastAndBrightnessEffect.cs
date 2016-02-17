// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/resources/sharedsource/licensingbasics/sharedsourcelicenses.mspx.
// All other rights reserved.

using System.Windows.Media.Effects;
using System.Windows;
namespace Telerik.Windows.Examples.Slider.Shader
{
	public class ContrastAndBrightnessEffect : ShaderEffect
	{
		/// <summary>
		/// This property is mapped to the Brightness variable within the pixel shader. 
		/// </summary>
		public static readonly DependencyProperty BrightnessProperty = DependencyProperty.Register("Brightness", typeof(double), typeof(ContrastAndBrightnessEffect), new PropertyMetadata(0.0, PixelShaderConstantCallback(0)));

		/// <summary>
		/// This property is mapped to the Contrast variable within the pixel shader. 
		/// </summary>
		public static readonly DependencyProperty ContrastProperty = DependencyProperty.Register("Contrast", typeof(double), typeof(ContrastAndBrightnessEffect), new PropertyMetadata(1.0, PixelShaderConstantCallback(1)));

		/// <summary>
		/// A refernce to the pixel shader used.
		/// </summary>
		private static PixelShader pixelShader = new PixelShader();

		/// <summary>
		/// Creates an instance of the shader from the included pixel shader.
		/// </summary>
		static ContrastAndBrightnessEffect()
		{
			pixelShader.UriSource = new System.Uri("/Slider;component/FirstLook/Shader/ContrastAndBrightness.ps", System.UriKind.RelativeOrAbsolute);
		}

		/// <summary>
		/// Creates an instance and updates the shader's variables to the default values.
		/// </summary>
		public ContrastAndBrightnessEffect()
		{
			this.PixelShader = pixelShader;

			this.UpdateShaderValue(BrightnessProperty);
			this.UpdateShaderValue(ContrastProperty);
		}

		/// <summary>
		/// Gets or sets the Brightness variable within the shader.
		/// </summary>
		public double Brightness
		{
			get { return (double)GetValue(BrightnessProperty); }
			set { SetValue(BrightnessProperty, value); }
		}

		/// <summary>
		/// Gets or sets the Contrast variable within the shader.
		/// </summary>
		public double Contrast
		{
			get { return (double)GetValue(ContrastProperty); }
			set { SetValue(ContrastProperty, value); }
		}
	}
}
