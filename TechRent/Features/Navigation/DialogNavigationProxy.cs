﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechRent.Shared.ViewModels;

namespace TechRent.Features.Navigation
{
    public class DialogNavigationProxy
    {
        private ViewModelBase? _currentViewModel;
        public ViewModelBase? CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                CurrentViewModelChanged?.Invoke();
            }
        }

        public bool IsOpen => CurrentViewModel != null;


        public event Action? CurrentViewModelChanged;

        public void Close()
        {
            CurrentViewModel = null;
        }
    }
}

