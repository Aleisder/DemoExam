using DemoExam.Model.Archive;
using DemoExam.Model.UserPool;
using DemoExam.Repository;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DemoExam.Services
{
    internal class ArchiveService
    {
        public static readonly ObservableCollection<Volume> Volumes = new();

        static ArchiveService()
        {
            //ArchiveRepository.GetVolumes().ForEach(volume => Volumes.Add(volume));
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
