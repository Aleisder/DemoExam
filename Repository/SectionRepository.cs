using DemoExam.Configuration;
using DemoExam.Model.Archive;
using System.Collections.Generic;
using System.Linq;

namespace DemoExam.Repository
{
    public class SectionRepository
    {
        private static readonly SqlDatabase Context = new();

        public static List<Section> GetSections() => Context.Sections.ToList();

        public static Section GetSectionById(int id) => Context.Sections.Where(x => x.Id == id).First();

    }
}
