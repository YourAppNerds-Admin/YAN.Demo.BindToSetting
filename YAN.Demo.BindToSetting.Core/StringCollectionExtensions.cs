using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace YAN.Demo.BindToSetting.Core
{
    public static class StringCollectionExtensions 
    {
        public static ObservableCollection<string> ToObservableStringCollection(this StringCollection Source)
        {
            ObservableCollection<string> Collection = new ObservableCollection<string>();
            foreach (var Item in Source)
            {
                Collection.Add(Item);
            }
            return Collection;
        }

        public static StringCollection ToStringCollection(this ObservableCollection<string> Source)
        {
            StringCollection Collection = new StringCollection();
            foreach (var Item in Source)
            {
                Collection.Add(Item);
            }
            return Collection;
        }

        public static ObservableCollection<ListviewCheckboxItem> ToObservableListviewCheckboxCollection(this StringCollection Source)
        {
            ObservableCollection<ListviewCheckboxItem> Collection = new ObservableCollection<ListviewCheckboxItem>();
            for (int Index = 0; Index < Source.Count; Index += 2)
            {
                try
                {
                    bool IsChecked = Convert.ToBoolean(Source[Index + 1]);
                    Collection.Add(new ListviewCheckboxItem(Source[Index], Convert.ToBoolean(Source[Index + 1])));
                }
                catch
                {
                    Collection.Add(new ListviewCheckboxItem(Source[Index]));
                    Index -= 1;
                }                
            }
            return Collection;
        }

        public static StringCollection ToStringCollection(this ObservableCollection<ListviewCheckboxItem> Source)
        {
            StringCollection Collection = new StringCollection();
            foreach (var Item in Source)
            {
                Collection.Add(Item.Text);
                Collection.Add(Item.IsChecked.ToString());
            }
            return Collection;
        }
    }
}
