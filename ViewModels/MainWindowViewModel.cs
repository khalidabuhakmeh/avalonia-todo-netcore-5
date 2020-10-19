using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Text;
using ReactiveUI;
using Todo.Models;
using Todo.Services;

namespace Todo.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ViewModelBase content;
        
        public MainWindowViewModel(Database db)
        {
            Content = List = new TodoListViewModel(db.GetItems());
        }        
        
        public TodoListViewModel List { get; }

        public ViewModelBase Content
        {
            get => content;
            private set => this.RaiseAndSetIfChanged(ref content, value);
        }

        public void AddItem()
        {
            var vm = new AddItemViewModel();

            Observable
                .Merge(vm.Ok, vm.Cancel)
                .Take(1)
                .Subscribe(item =>
                {
                    if (item != null)
                    {
                        List.Items.Add(item);
                    }

                    Content = List;
                });

            Content = vm;
        }
    }
}
