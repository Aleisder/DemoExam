

using DemoExam.Model;
using DemoExam.Model.Archive;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Documents;

namespace DemoExam.Handlers
{
    public class ArchiveEventHandler
    {

        public readonly ObservableCollection<Volume> volumes = new();
        public readonly ObservableCollection<Act> acts = new();
        public readonly ObservableCollection<Case> cases = new();

        public readonly ObservableCollection<ArchiveListItem> BackStack = new();

        public void PushToBackStack(ArchiveListItem item)
        {
            BackStack.Add(item);
        }

        public void OpenChapterByCommand(string command)
        {

            


            if (command.StartsWith("/volume"))
            {


            }

  
        }

        public void GoBack()
        {

        }

        private Command ParseCommand(string command)
        {
            List<string> arguments = new (command.Split(' '));
            int id = int.Parse(arguments[1]);
            return new Command(arguments[0], id);
        }


        class Command
        {
            public string Value;
            public int Id;

            public Command(string command, int id)
            {
                Value = command;
                Id = id;
            }
        }


    }
}
