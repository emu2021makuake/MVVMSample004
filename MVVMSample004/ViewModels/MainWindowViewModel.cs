using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Windows.Input;

namespace MVVMSample004.ViewModels
{
    class MainWindowViewModel : ObservableObject
    {
        private string _receiveMessage;
        public string ReceiveMessage
        {
            get => _receiveMessage;
            set => SetProperty(ref _receiveMessage, value);
        }

        public ICommand SendCommand { get; }

        public MainWindowViewModel()
        {
            WeakReferenceMessenger.Default.Register<Models.Message>(this, OnReceive);

            SendCommand = new RelayCommand(() =>
            {
                WeakReferenceMessenger.Default.Send(
                    new Models.Message { Num = 123, Str = DateTime.Now.ToString() }) ;
            });
        }

        private void OnReceive(object recipient, Models.Message message)
        {
            ReceiveMessage = $"Num={message.Num}, Str={message.Str}";
        }

    }
}
