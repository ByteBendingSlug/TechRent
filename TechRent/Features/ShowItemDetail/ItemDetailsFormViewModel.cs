using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TechRent.Shared.ViewModels;

namespace TechRent.Features.ShowItemDetail
{
    public class ItemDetailsFormViewModel : ViewModelBase
    {
        private string? _itemName;
        public string? ItemName
        {
            get => _itemName;
            set
            {
                _itemName = value;
                OnPropertyChanged(nameof(ItemName));
                OnPropertyChanged(nameof(CanSubmit));
            }
        }

        private string? _category;
        public string? Category
        {
            get => _category;
            set
            {
                _category = value;
                OnPropertyChanged(nameof(Category));
            }
        }

        private bool _isRented;
        public bool IsRented
        {
            get => _isRented;
            set
            {
                _isRented = value;
                OnPropertyChanged(nameof(IsRented));
            }
        }

        private bool _isSubmitting;
        public bool IsSubmitting
        {
            get => _isSubmitting;
            set
            {
                _isSubmitting = value;
                OnPropertyChanged(nameof(IsSubmitting));
            }
        }

        public bool CanSubmit => !string.IsNullOrEmpty(ItemName);
        public bool CanDelete => !IsRented;

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public ItemDetailsFormViewModel(ICommand submitCommand, ICommand cancelCommand)
        {
            SubmitCommand = submitCommand;
            CancelCommand = cancelCommand;
        }
    }
}

