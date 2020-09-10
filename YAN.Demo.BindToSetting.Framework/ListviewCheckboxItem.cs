using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace YAN.Demo.BindToSetting.Framework
{
    public class ListviewCheckboxItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string PropertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));

        private string Text_;
        public string Text
        {
            get => Text_;
            set
            {
                Text_ = value;
                OnPropertyChanged();
            }
        }

        private bool IsChecked_;
        public bool IsChecked
        {
            get => IsChecked_;
            set
            {
                IsChecked_ = value;
                OnPropertyChanged();
            }
        }

        public ListviewCheckboxItem(string Text, bool IsChecked = true)
        {
            this.Text = Text;
            this.IsChecked = IsChecked;
        }
    }
}
