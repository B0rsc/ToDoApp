using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using ToDoApp.Models;
using Xamarin.Forms;

namespace ToDoApp.ViewModels
{
    public class TodoViewModel : BaseViewModel
    {
        private ObservableCollection<TodoTask> _tasks;
        public ObservableCollection<TodoTask> Tasks
        {
            get { return _tasks; }
            set { SetProperty(ref _tasks, value); }
        }

        private string _newItemText;
        public string NewTaskText
        {
            get { return _newItemText; }
            set { SetProperty(ref _newItemText, value); }
        }


        public ICommand AddTaskCommand { get; set; }
        public ICommand RemoveTaskCommand { get; set; }

        public TodoViewModel()
        {
            Tasks = new ObservableCollection<TodoTask>();

            AddTaskCommand = new Command(ExecuteAddTasksCommand);
            RemoveTaskCommand = new Command(ExecuteRemoveTaskCommand);

        }

        public void ExecuteAddTasksCommand()
        {
            if (!string.IsNullOrWhiteSpace(NewTaskText))
            {
                var newItem = new TodoTask { Text = NewTaskText, IsDone = false };
                Tasks.Add(newItem);
                NewTaskText = string.Empty;
            }
        }

        private TodoTask _selectedTask;
        public TodoTask SelectedTask
        {
            get => _selectedTask;
            set => SetProperty(ref _selectedTask, value);
        }

        private void ExecuteRemoveTaskCommand()
        {

            Tasks.Remove(SelectedTask);
            SelectedTask = null;


        }

       


    }
}



