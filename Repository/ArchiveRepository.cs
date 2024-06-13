using DemoExam.Model.Archive;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DemoExam.Repository
{
    class ArchiveRepository : Repository
    {
        public readonly UserRepository UserRepository = new();

        public List<Volume> GetVolumes()
        {
            string query = @"
                SELECT 
                	[Act].[id] AS 'act_id',
                	[Act].[name] AS 'act_name',
                	[Case].[id] AS 'case_id',
                	[Case].[name] AS 'case_name',
                    [Case].[closed_at] AS 'case_closed_at',
                    [Case].[intruder] AS 'case_intruder',
                    [Case].[investigator_id] AS 'case_investigator_id',
                    [Case].[section_id] AS 'case_section_id',
                    [Case].[evidence] AS 'case_evidence'
                FROM [Case]  
                RIGHT JOIN [Act] ON [Case].[act_id] = [Act].[id];
            ";

            using var connection = new SqlConnection(connectionString);
            using var command = new SqlCommand(query, connection);
            using var reader = command.ExecuteReader();
            var volumes = new List<Volume>();

            while (reader.Read())
            {
                int actId = reader.GetInt32(0);
                string actName = reader.GetString(1);


            }
            return volumes;
        }

        public List<Section> GetSections()
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "SELECT * FROM [Section]";
            using var command = new SqlCommand(query, connection);
            using var reader = command.ExecuteReader();
            var sections = new List<Section>();
            while (reader.Read())
            {
                int id = reader.GetInt16(0);
                string name = reader.GetString(1);
                string punishment = reader.GetString(2);

                var section = new Section(id, name, punishment);
                sections.Add(section);
            }
            reader.Close();
            connection.Close();
            return sections;
        }

        public static List<Act> GetActsByVolumeId(int volumeId) => new List<Act>();

        public static List<Case> GetCasesByActId(int actId) => new List<Case>();

        public static void AddVolume(string name)
        {
        }

        public static void AddAct(string name, int volumeId)
        {
        }

        public static void AddCase(Case caseItem)
        {
        }

        public static void DeleteVolumeById(int volumeId)
        {
        }

        public static void DeleteActById(int actId)
        {

        }

        public static void UpdateVolume(Volume volume)
        {
        }

        public static void UpdateAct(Act act)
        {
        }

        public static void UpdateCase(Case caseItem)
        {
        }

        public static Act GetActById(int id) => new Act(1, "", new List<Case>());

        public static Volume GetLastVolume() => new Volume(1, "sdfa", new List<Act>());

        public static Volume GetByName(string name) => new Volume(1, "sdfa", new List<Act>());

        public static Volume GetVolumeByName(string name) => new Volume(1, "sdfa", new List<Act>());

        public static bool ActExistsByName(string name, string volumeName)
        {
            return true;
        }

        public static List<Case> GetCasesByVolume(Volume volume)
        {
            return new List<Case>();
        }

    }
}
