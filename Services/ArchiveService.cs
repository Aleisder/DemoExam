using DemoExam.Dto;
using DemoExam.Model;
using DemoExam.Model.Archive;
using DemoExam.Repository;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Documents;

namespace DemoExam.Services
{
    internal class ArchiveService
    {
        public static readonly ObservableCollection<Volume> Volumes = new();

        static ArchiveService()
        {
            ArchiveRepository.GetVolumes().ForEach(volume => Volumes.Add(volume));
        }

        public static void AddVolume(string name)
        {
            ArchiveRepository.AddVolume(name);
            Volume last = ArchiveRepository.GetLastVolume();
            Volumes.Add(last);
        }

        public static List<VolumeDto> GetVolumes()
        {
            List<Volume> volumes = ArchiveRepository.GetVolumes();

            List<VolumeDto> volumesDto = new();

            foreach (var volume in volumes)
            {
                List<Act> acts = ArchiveRepository.GetActsByVolumeId(volume.Id);
                List<Case> cases = ArchiveRepository.GetCasesByVolume(volume);

                var volumeDto = new VolumeDto(volume.Id, volume.Name, acts.Count, cases.Count);
                volumesDto.Add(volumeDto);
            }
            return volumesDto;
        }

        public static List<ActDto> GetActsByVolumeId(int volumeId)
        {
            List<ActDto> actDtos = new();
            ArchiveRepository.GetActsByVolumeId(volumeId).ForEach(x =>
            {

                int all = 0;
                int open = 0;
                int closed = 0;
                List<Case> cases = ArchiveRepository.GetCasesByActId(x.Id);
                cases.ForEach(caseItem =>
                {
                    all++;
                    if (caseItem.IsClosed) { closed++; }
                    else { open++; }
                });

                var actDto = new ActDto(x.Id, x.Name, all, open, closed);
                actDtos.Add(actDto);
            });
            return actDtos;
        }

        public static List<CaseDto> GetCasesByActId(int actId)
        {
            List<Case> cases = ArchiveRepository.GetCasesByActId(actId);

            List<CaseDto> caseDtos = new();

            cases.ForEach(x =>
            {
                Model.Archive.Section section = SectionRepository.GetSectionById(x.SectionId);
                User investigator = UserRepository.GetById(x.InvestigatorId);

                CaseDto caseDto = new CaseDto(x.Id, x.Name, x.ActId, x.CreatedAt, x.Intruder, investigator.ToString(), section.Name, x.Evidence);

                caseDtos.Add(caseDto);
            });
            return caseDtos;
        }


    }
}
