using DemoExam.Configuration;
using DemoExam.Model.Archive;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;

namespace DemoExam.Repository
{
    class ArchiveRepository
    {
        private static readonly SqlDatabase Context = new();

        public static List<Volume> GetVolumes() => Context.Volumes.ToList();

        public static List<Act> GetActsByVolumeId(int volumeId) => Context.Acts.Where(x =>  x.VolumeId == volumeId).ToList();

        public static List<Case> GetCasesByActId(int actId) => Context.Cases.Where(x => x.ActId == actId).ToList();

        public static void AddVolume(string name)
        {
            string query = "INSERT INTO [Volume] (name) VALUES ({0})";
            Context.Database.ExecuteSqlRaw(query, name);
            Context.SaveChanges();
        }

        public static void AddAct(string name, int volumeId)
        {
            string query = "INSERT INTO [Act] (name, volume_id) VALUES ({0}, {1})";
            Context.Database.ExecuteSqlRaw(query, name, volumeId);
            Context.SaveChanges();
        }

        public static void AddCase(Case caseItem)
        {
            string query = "INSERT INTO [Case] (name, act_id, created_at, updated_at, closed_at, intruder, investigator_id, section_id, evidence) VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8})";
            Context.Database.ExecuteSqlRaw(query, caseItem.Name, caseItem.ActId, DateTime.Now, DateTime.Now, DateTime.Now, caseItem.Intruder, caseItem.InvestigatorId, caseItem.SectionId, caseItem.Evidence);
            Context.SaveChanges();
        }

        public static void DeleteVolumeById(int volumeId)
        {
            string query = "DELETE [Volume] WHERE id = {0}";
            Context.Database.ExecuteSqlRaw(query, volumeId);
            Context.SaveChanges();
        }

        public static void DeleteActById(int actId)
        {
            string query = "DELETE [Act] WHERE id = {0}";
            Context.Database.ExecuteSqlRaw(query, actId);
            Context.SaveChanges();
        }

        public static void UpdateVolume(Volume volume)
        {
            string query = "UPDATE [Volume] SET name = {1} WHERE id = {0}";
            Context.Database.ExecuteSqlRaw(query, volume.Id, volume.Name);
            Context.SaveChanges();
        }

        public static void UpdateAct(Act act)
        {
            string query = "UPDATE [Act] SET name = {1}, volume_id = {2} WHERE id = {0}";
            Context.Database.ExecuteSqlRaw(query, act.Id, act.Name, act.VolumeId);
            Context.SaveChanges();
        }

        public static void UpdateCase(Case caseItem)
        {
            string query = "UPDATE [Case] SET name = '{1}', act_id = {2}, updated_at = '{3}', intruder = {4}, investigator_id = {5}, section_id = {6}, evidence = '{7}' WHERE id = {0}";
            Context.Database.ExecuteSqlRaw(query, caseItem.Id, caseItem.Name, DateTime.Now, caseItem.Intruder, caseItem.InvestigatorId, caseItem.SectionId, caseItem.Evidence);
            Context.SaveChanges();
        }

        public static Act GetActById(int id) => Context.Acts.Where(x => x.Id == id).First();

        public static Volume GetLastVolume() => Context.Volumes.OrderBy(x => x.Id).Last();

        public static Volume GetByName(string name) => Context.Volumes.Where(x => x.Name == name).First();

        public static Volume GetVolumeByName(string name) => Context.Volumes.Where(x => x.Name == name).First();

        public static bool ActExistsByName(string name, string volumeName)
        {
            return Context.Acts.Any(x => x.Name == name && x.VolumeId == GetVolumeByName(volumeName).Id);
        }

        public static List<Case> GetCasesByVolume(Volume volume)
        {
            List<int> actsId = GetActsByVolumeId(volume.Id).Select(x => x.Id).ToList();
            return Context.Cases.Where(x => actsId.Contains(x.ActId)).ToList();
        }

    }
}
