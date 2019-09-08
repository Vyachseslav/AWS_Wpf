using System.Windows;
using AWS_Wpf_Project.Interface;

namespace AWS_Wpf_Project.Services
{
    class StandartMessageService : IMessagable
    {
        public void ShowErrorMessage(string title, string text)
        {
            MessageBox.Show(text, title, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public void ShowInfoMessage(string title, string text)
        {
            MessageBox.Show(text, title, MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
