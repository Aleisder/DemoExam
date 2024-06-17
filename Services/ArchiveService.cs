using DemoExam.Model.Archive;
using DemoExam.Model.UserPool;
using DemoExam.Repository;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Media.Animation;

namespace DemoExam.Services
{
    public class ArchiveService
    {
        public static readonly ObservableCollection<Volume> Volumes = new();

        public ArchiveService()
        {
            //ArchiveRepository.GetVolumes().ForEach(volume => Volumes.Add(volume));
        }

        public static List<MenuItem> GetItems()
        {
            var menu = new List<MenuItem>();
            foreach (var item in Volumes)
            {
                menu.Add(new MenuItem(item.Name));
            }
            return menu;
        }

        public static void AddVolume(string name)
        {
            ArchiveRepository.AddVolume(name);
            Volume last = ArchiveRepository.GetLastVolume();
            Volumes.Add(last);
        }

        public static List<Volume> GetVolumes()
        {
 
            return new List<Volume>();
        }

        public List<Act> GetActsByVolumeId(int volumeId)
        {
            return new List<Act>();
        }

        public List<Case> GetCasesByActId(int actId)
        {
            return new List<Case>();
        }


    }
}
