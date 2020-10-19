using System.Reactive;
using ReactiveUI;
using Todo.Models;

namespace Todo.ViewModels
{
    public class AddItemViewModel : ViewModelBase
    {
        private string description;

        public AddItemViewModel()
        {
            var okEnabled = this.WhenAnyValue(
                x => x.Description,
                x => !string.IsNullOrWhiteSpace(x));

            Ok = ReactiveCommand.Create(
                () => new TodoItem { Description = Description },
                okEnabled);
            
            Cancel = ReactiveCommand.Create(() => (TodoItem)null);
        }

        public ReactiveCommand<Unit, TodoItem> Ok { get; set; }
        public ReactiveCommand<Unit, TodoItem> Cancel { get; set; }

        public string Description
        {
            get => description;
            set => this.RaiseAndSetIfChanged(ref description, value);
        }
    }
}