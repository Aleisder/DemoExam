using System.Collections.ObjectModel;

namespace DemoExam.Model.Archive
{
    public class MenuItem
    {
        public string Name { get; set; }
        public ObservableCollection<MenuItem> Items { get; set; }

        public MenuItem(string name)
        {
            Name = name;
            Items = new ObservableCollection<MenuItem>();
        }
    }
}
