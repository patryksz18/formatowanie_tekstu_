﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace formatowanie_tekstu_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ApplyFormatting(object sender, RoutedEventArgs e)
        {
            // Uzyskanie bieżącego tekstu z RichTextBox
            TextRange textRange = new TextRange(TextBoxInput.Document.ContentStart, TextBoxInput.Document.ContentEnd);

            // Pogrubienie
            if (BoldCheckBox.IsChecked == true)
            {
                textRange.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Bold);
            }
            else
            {
                textRange.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Normal);
            }

            // Kursywa
            if (ItalicCheckBox.IsChecked == true)
            {
                textRange.ApplyPropertyValue(TextElement.FontStyleProperty, FontStyles.Italic);
            }
            else
            {
                textRange.ApplyPropertyValue(TextElement.FontStyleProperty, FontStyles.Normal);
            }

            // Podkreślenie
            if (UnderlineCheckBox.IsChecked == true)
            {
                textRange.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Underline);
            }
            else
            {
                textRange.ApplyPropertyValue(Inline.TextDecorationsProperty, null);
            }
            // Kolor czcionki
            string color = "black"; // domyślny kolor
            if (CzerwonyRadioButton.IsChecked == true)
                color = "red";
            else if (NiebieskiRadioButton.IsChecked == true)
                color = "blue";
            else if (ZielonyRadioButton.IsChecked == true)
                color = "green";
            TextBoxInput.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(color));
            // Krój czcionki
            if (ArialRadioButton.IsChecked == true)
                TextBoxInput.FontFamily = new FontFamily("Arial");
            else if (TimesRadioButton.IsChecked == true)
                TextBoxInput.FontFamily = new FontFamily("Times New Roman");
            else if (CourierRadioButton.IsChecked == true)
                TextBoxInput.FontFamily = new FontFamily("Courier New");
            // Rozmiar czcionki
            TextBoxInput.FontSize = FontSizeSlider.Value;
            // Zaktualizowanie paska postępu
            UpdateProgress();


        }
        private void UpdateProgress()
        {
            double progress = 0;

            if (BoldCheckBox.IsChecked == true) progress += 10;
            if (ItalicCheckBox.IsChecked == true) progress += 10;
            if (UnderlineCheckBox.IsChecked == true) progress += 10;

            if (CzerwonyRadioButton.IsChecked == true || NiebieskiRadioButton.IsChecked == true || ZielonyRadioButton.IsChecked == true) progress += 20;
            if (ArialRadioButton.IsChecked == true || TimesRadioButton.IsChecked == true || CourierRadioButton.IsChecked == true) progress += 20;

            progress += FontSizeSlider.Value / FontSizeSlider.Maximum * 20;  

            ProgressBar.Value = progress;
        }
    }
}