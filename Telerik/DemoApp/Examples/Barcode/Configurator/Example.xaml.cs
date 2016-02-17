using System;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.QuickStart;
using System.Windows.Media.Imaging;
using System.Windows.Input;
using Microsoft.Win32;
using System.IO;
using Telerik.Windows.Media.Imaging;
using System.Windows.Media;
#if SILVERLIGHT
using SelectionChangedEventArgs = Telerik.Windows.Controls.SelectionChangedEventArgs;
using System.Windows.Media;
#endif

namespace Telerik.Windows.Examples.Barcode.Configurator
{
    public partial class Example : UserControl
    {
        public Example()
        {
            InitializeComponent();

            string vCardText = "BEGIN:VCARD\r\nVERSION:2.1\r\nN:";
            vCardText += "Donovan Percy\r\n";
            vCardText += "TEL;WORK;VOICE:+44 71 556 87 87\r\n";
            vCardText += "EMAIL;PREF;INTERNET:DPersy@yahoo.com\r\n";
            vCardText += "END:VCARD";

            QRCode3.Text = vCardText;

            QRCode4.Text = @"http://maps.google.com/maps?q=42.6465611111111,23.357225&num=1&t=m&z=12";
        }

        private void Tab1GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                QRCode1.Text = string.Empty;

                if (Tab1ModeCombo.SelectedIndex == 0)
                    QRCode1.Mode = QRClassLibrary.Modes.CodeMode.Byte;
                else
                    QRCode1.Mode = QRClassLibrary.Modes.CodeMode.Alphanumeric;

                SetQRCodeErrorCorrectionLevel(QRCode1, Tab1ErrorCombo.SelectedItem as RadComboBoxItem);
                SetQRCodeVersion(QRCode1, Tab1SizeCombo.SelectedIndex);

                System.Uri finalUrl;
                bool result = System.Uri.TryCreate(Tab1InputBox.Text, UriKind.Absolute, out finalUrl);
                if (finalUrl != null && result)
                    QRCode1.Text = finalUrl.ToString();

                QRCode1.Visibility = System.Windows.Visibility.Visible;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                QRCode1.Text = string.Empty;
                QRCode1.Visibility = System.Windows.Visibility.Collapsed;

                OnQRCodeGenerationError();
            }
        }

        private void Tab1ExportButton_Click(object sender, RoutedEventArgs e)
        {
            ExportQRCode(this.QRCode1);
        }

        private void Tab2Fnc1Combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (QRCode2 != null)
            {
                if ((sender as RadComboBox).SelectedIndex == 0)
                {
                    Tab2FNC1TextBox.Text = "Application Indicator";
                    Tab2FNC1TextBox.IsEnabled = false;
                }
                else if (((sender as RadComboBox).SelectedIndex == 1))
                {
                    Tab2FNC1TextBox.Text = "Application Indicator";
                    Tab2FNC1TextBox.IsEnabled = false;
                }
                else if (((sender as RadComboBox).SelectedIndex == 2))
                {                    
                    Tab2FNC1TextBox.IsEnabled = true;
                    Tab2FNC1TextBox.Text = "Valid values are {a-z, A-Z, 00-99}";
                }
            }
        }

        private void Tab2Generate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                QRCode2.Text = String.Empty;

                SetQRCodeMode();
                SetQRCodeErrorCorrectionLevel(QRCode2, Tab2ErrorCombo.SelectedItem as RadComboBoxItem);
                SetQRCodeVersion(QRCode2, Tab2SizeCombo.SelectedIndex);

                QRCode2.Text = Tab2InputBox.Text;

                QRCode2.Visibility = System.Windows.Visibility.Visible;

                if (Tab2Fnc1Combo.SelectedIndex == 0)
                {
                    QRCode2.FNC1 = QRClassLibrary.Modes.FNC1Mode.None;
                    Tab2FNC1TextBox.Text = "Application Indicator";
                    Tab2FNC1TextBox.IsEnabled = false;
                }
                else if (Tab2Fnc1Combo.SelectedIndex == 1)
                {
                    QRCode2.FNC1 = QRClassLibrary.Modes.FNC1Mode.FNC1FirstPosition;
                    Tab2FNC1TextBox.Text = "Application Indicator";
                    Tab2FNC1TextBox.IsEnabled = false;
                }
                else
                {
                    QRCode2.FNC1 = QRClassLibrary.Modes.FNC1Mode.FNC1SecondPosition;
                    Tab2FNC1TextBox.IsEnabled = true;
                }

                if (Tab2Fnc1Combo.SelectedIndex == 2)
                {
                    QRCode2.ApplicationIndicator = Tab2FNC1TextBox.Text;
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                QRCode2.Text = String.Empty;
                QRCode2.Visibility = System.Windows.Visibility.Collapsed;

                OnQRCodeGenerationError();
            }
        }

        private void Tab2ExportButton_Click(object sender, RoutedEventArgs e)
        {
            ExportQRCode(this.QRCode2);
        }

        private void Tab2ECICombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Tab2ECICombo != null)
            {
                if (Tab2ECICombo.SelectedIndex == 1)
                {
                    Tab2InputBox.Text = "κωδικός";
                    QRCode2.ECI = QRClassLibrary.Modes.ECIMode.ISO8859_7;
                }
                else if (Tab2ECICombo.SelectedIndex == 2)
                {
                    Tab2InputBox.Text = "رمز";
                    QRCode2.ECI = QRClassLibrary.Modes.ECIMode.ISO8859_6;
                }
                else if (Tab2ECICombo.SelectedIndex == 3)
                {
                    Tab2InputBox.Text = "код";
                    QRCode2.ECI = QRClassLibrary.Modes.ECIMode.ISO8859_5;
                }
                else if (Tab2ECICombo.SelectedIndex == 4)
                {
                    Tab2InputBox.Text = "kodas";
                    QRCode2.ECI = QRClassLibrary.Modes.ECIMode.ISO8859_4;
                }
                else if (Tab2ECICombo.SelectedIndex == 5)
                {
                    Tab2InputBox.Text = "kodiċi";
                    QRCode2.ECI = QRClassLibrary.Modes.ECIMode.ISO8859_3;
                }
                else if (Tab2ECICombo.SelectedIndex == 6)
                {
                    Tab2InputBox.Text = "Šta ima novoga?";
                    QRCode2.ECI = QRClassLibrary.Modes.ECIMode.ISO8859_2;
                }
                else if (Tab2ECICombo.SelectedIndex == 7)
                {
                    Tab2InputBox.Text = "code";
                    QRCode2.ECI = QRClassLibrary.Modes.ECIMode.ISO8859_1;
                }
                else if (Tab2ECICombo.SelectedIndex == 8)
                {
                    Tab2InputBox.Text = "קוד";
                    QRCode2.ECI = QRClassLibrary.Modes.ECIMode.ISO8859_8;
                }
                else if (Tab2ECICombo.SelectedIndex == 9)
                {
                    Tab2InputBox.Text = "kod";
                    QRCode2.ECI = QRClassLibrary.Modes.ECIMode.ISO8859_9;
                }
                else if (Tab2ECICombo.SelectedIndex == 10)
                {
                    Tab2InputBox.Text = "รหัส";
                    QRCode2.ECI = QRClassLibrary.Modes.ECIMode.ISO8859_11;
                }
                else if (Tab2ECICombo.SelectedIndex == 11)
                {
                    Tab2InputBox.Text = "kood";
                    QRCode2.ECI = QRClassLibrary.Modes.ECIMode.ISO8859_13;
                }
                else if (Tab2ECICombo.SelectedIndex == 12)
                {
                    Tab2InputBox.Text = "codi";
                    QRCode2.ECI = QRClassLibrary.Modes.ECIMode.ISO8859_15;
                }
                else if (Tab2ECICombo.SelectedIndex == 13)
                {
                    Tab2InputBox.Text = "đńňóôő!";
                    QRCode2.ECI = QRClassLibrary.Modes.ECIMode.Windows1250;
                }
                else if (Tab2ECICombo.SelectedIndex == 14)
                {
                    Tab2InputBox.Text = "Здравей!";
                    QRCode2.ECI = QRClassLibrary.Modes.ECIMode.Windows1251;
                }
                else if (Tab2ECICombo.SelectedIndex == 0)
                {
                    Tab2InputBox.Text = "QR Code by Telerik";
                    if (QRCode2 != null)
                        QRCode2.ECI = QRClassLibrary.Modes.ECIMode.None;
                }
            }
        }

        private void Tab3Generate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                QRCode3.Text = string.Empty;

                SetQRCodeErrorCorrectionLevel(QRCode3, Tab3ErrorCombo.SelectedItem as RadComboBoxItem);
                int version = int.Parse((Tab3SizeCombo.SelectedItem as RadComboBoxItem).Content.ToString());
                QRCode3.Version = version;

                string vCardText = "BEGIN:VCARD\r\nVERSION:2.1\r\nN:";
                vCardText += FNInput.Text + " " + LNInput.Text + "\r\n";
                vCardText += "TEL;WORK;VOICE:" + PhoneInput.Text + "\r\n";
                vCardText += "EMAIL;PREF;INTERNET:" + EmailInput.Text + "\r\n";
                vCardText += "END:VCARD";

                QRCode3.Text = vCardText;

                QRCode3.Visibility = System.Windows.Visibility.Visible;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                QRCode3.Text = string.Empty;
                QRCode3.Visibility = System.Windows.Visibility.Collapsed;

                OnQRCodeGenerationError();
            }
        }

        private void Tab3ExportButton_Click(object sender, RoutedEventArgs e)
        {
            ExportQRCode(this.QRCode3);
        }

        private void Tab4Generate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                QRCode4.Text = string.Empty;

                SetQRCodeErrorCorrectionLevel(QRCode4, Tab4ErrorCombo.SelectedItem as RadComboBoxItem);
                int version = int.Parse((Tab4SizeCombo.SelectedItem as RadComboBoxItem).Content.ToString());
                QRCode4.Version = version;

                double latDegrees;
                double longDegrees;
                double latMinutes;
                double longMinutes;
                double latSeconds;
                double longSeconds;
                double Latitude, Longitude;

                double.TryParse(Degrees1.Text.ToString(), out latDegrees);
                double.TryParse(Minutes1.Text.ToString(), out latMinutes);
                double.TryParse(Seconds1.Text.ToString(), out latSeconds);
                double.TryParse(Degrees2.Text.ToString(), out longDegrees);
                double.TryParse(Minutes2.Text.ToString(), out longMinutes);
                double.TryParse(Seconds2.Text.ToString(), out longSeconds);

                if (latDegrees < -90 || latDegrees > 90)
                    latDegrees = 1;
                if (longDegrees < -90 || longDegrees > 90)
                    latDegrees = 1;

                if (latMinutes < 0 || latMinutes > 59)
                    latMinutes = 1;
                if (longMinutes < 0 || longMinutes > 59)
                    longMinutes = 1;

                if (latSeconds < 0 || latSeconds > 59.99)
                    latSeconds = 1;
                if (longSeconds < 0 || longSeconds > 59.99)
                    longSeconds = 1;

                if (latDegrees < 0)
                    Latitude = latDegrees - (latMinutes / 60) - (latSeconds / 3600);
                else
                    Latitude = latDegrees + (latMinutes / 60) + (latSeconds / 3600);

                if (longDegrees < 0)
                    Longitude = longDegrees - (longMinutes / 60) - (longSeconds / 3600);
                else
                    Longitude = longDegrees + (longMinutes / 60) - (longSeconds / 3600);

                Math.Round(Latitude, 10);
                Math.Round(Longitude, 10);

                string url = "http://maps.google.com/maps?q=" + Latitude.ToString() + "," + Longitude.ToString() + "&num=1&t=m&z=12";
                QRCode4.Text = url;

                QRCode4.Visibility = System.Windows.Visibility.Visible;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                QRCode4.Text = string.Empty;
                QRCode4.Visibility = System.Windows.Visibility.Collapsed;

                OnQRCodeGenerationError();
            }
        }

        private void Tab4ExportButton_Click(object sender, RoutedEventArgs e)
        {
            ExportQRCode(this.QRCode4);
        }

        private void OnQRCodeGenerationError()
        {
            RadWindow.Alert(new DialogParameters()
            {
                Header = new TextBlock()
                {
                    VerticalAlignment = System.Windows.VerticalAlignment.Center,
                    Foreground = new SolidColorBrush(Colors.White),
                    FontFamily = new FontFamily("Segoe UI"),
                    FontSize = 14,
                    Text = "Invalid text length",
                },
                Content = new TextBlock()
                {
                    Text = "The Text is too long to be encoded with the current Version, ErrorCorrectionLevel and Mode.",
                    TextWrapping = TextWrapping.Wrap,
                    Width = 280
                },
            });
        }

        private void SetQRCodeMode()
        {
            if (Tab2ModeCombo.SelectedIndex == 0)
                QRCode2.Mode = QRClassLibrary.Modes.CodeMode.Byte;
            else if (Tab2ModeCombo.SelectedIndex == 1)
                QRCode2.Mode = QRClassLibrary.Modes.CodeMode.Alphanumeric;
            else if (Tab2ModeCombo.SelectedIndex == 2)
                QRCode2.Mode = QRClassLibrary.Modes.CodeMode.Numeric;
            else
                QRCode2.Mode = QRClassLibrary.Modes.CodeMode.Kanji;
        }

        private void SetQRCodeErrorCorrectionLevel(RadBarcodeQR qrCode, RadComboBoxItem level)
        {
            if (level.Content.ToString() == "L")
                qrCode.ErrorCorrectionLevel = QRClassLibrary.Modes.ErrorCorrectionLevel.L;
            else if (level.Content.ToString() == "M")
                qrCode.ErrorCorrectionLevel = QRClassLibrary.Modes.ErrorCorrectionLevel.M;
            else if (level.Content.ToString() == "Q")
                qrCode.ErrorCorrectionLevel = QRClassLibrary.Modes.ErrorCorrectionLevel.Q;
            else
                qrCode.ErrorCorrectionLevel = QRClassLibrary.Modes.ErrorCorrectionLevel.H;
        }

        private void SetQRCodeVersion(RadBarcodeQR qrCode, int version)
        {
            if (version == 0)
            {
                qrCode.ClearValue(RadBarcodeQR.VersionProperty);
            }
            else
            {
                qrCode.Version = version;
            }
        }

        private void ExportQRCode(RadBarcodeQR qRCode)
        {
            string extension = "png";
            SaveFileDialog dialog = new SaveFileDialog()
            {
                DefaultExt = extension,
#if WPF 
                FileName = "QRBarCode",
#elif SILVERLIGHT
                DefaultFileName = "QRBarCode",
#endif
                Filter = "Png (*.png)|*.png"
            };

            if (dialog.ShowDialog() == true)
            {
                using (Stream stream = dialog.OpenFile())
                {
                    ExportExtensions.ExportToImage(qRCode, stream, new PngBitmapEncoder());
                }
            }
        }

        private void TextBlock_ErrorCorrection(object sender, MouseButtonEventArgs e)
        {
            RadWindow.Alert(new DialogParameters()
            {
                Header = new TextBlock()
                {
                    VerticalAlignment = System.Windows.VerticalAlignment.Center,
                    Foreground = new SolidColorBrush(Colors.White),
                    FontFamily = new FontFamily("Segoe UI"),
                    FontSize = 14,
                    Text = "Property Information",
                },
                Content = new TextBlock()
                {
                    Text = "The Error Correction Level determines what portion of the QR Data is dedicated to error correction bits.",
                    TextWrapping = TextWrapping.Wrap,
                    Width = 280
                }
            });   
        }

        private void TextBlock_Version(object sender, MouseButtonEventArgs e)
        {
            RadWindow.Alert(new DialogParameters()
            {
                Header = new TextBlock()
                {
                    VerticalAlignment = System.Windows.VerticalAlignment.Center,
                    Foreground = new SolidColorBrush(Colors.White),
                    FontFamily = new FontFamily("Segoe UI"),
                    FontSize = 14,
                    Text = "Property Information",
                },
                Content = new TextBlock()
                {
                    Text = "Size 1 is 21x21 modules, and size 40 is 177x177 modules.",
                    TextWrapping = TextWrapping.Wrap,
                    Width = 280
                }
            });              
        }

        private void TextBlock_Encoding(object sender, MouseButtonEventArgs e)
        {
            RadWindow.Alert(new DialogParameters()
            {
                Header = new TextBlock()
                {
                    VerticalAlignment = System.Windows.VerticalAlignment.Center,
                    Foreground = new SolidColorBrush(Colors.White),
                    FontFamily = new FontFamily("Segoe UI"),
                    FontSize = 14,
                    Text = "Property Information",
                },
                Content = new TextBlock()
                {
                    Text = "Determines the type of characters allowed.",
                    TextWrapping = TextWrapping.Wrap,
                    Width = 280
                }
            });           
        }

        private void TextBlock_FNC1(object sender, MouseButtonEventArgs e)
        {
            RadWindow.Alert(new DialogParameters()
            {
                Header = new TextBlock()
                {
                    VerticalAlignment = System.Windows.VerticalAlignment.Center,
                    Foreground = new SolidColorBrush(Colors.White),
                    FontFamily = new FontFamily("Segoe UI"),
                    FontSize = 14,
                    Text = "Property Information",
                },
                Content = new TextBlock()
                {
                    Text = "Allows for additional formatting options for the data.",
                    TextWrapping = TextWrapping.Wrap,
                    Width = 280
                }
            });          
        }

        private void TextBlock_ECI(object sender, MouseButtonEventArgs e)
        {
            RadWindow.Alert(new DialogParameters()
            {
                Header = new TextBlock()
                {
                    VerticalAlignment = System.Windows.VerticalAlignment.Center,
                    Foreground = new SolidColorBrush(Colors.White),
                    FontFamily = new FontFamily("Segoe UI"),
                    FontSize = 14,
                    Text = "Property Information",
                },
                Content = new TextBlock()
                {
                    Text = "Allows for different character encoding sets.",
                    TextWrapping = TextWrapping.Wrap,
                    Width = 280
                }
            });                      
        }
    }
}
