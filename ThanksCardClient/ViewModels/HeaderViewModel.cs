#nullable disable
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using ThanksCardClient.Models;
using ThanksCardClient.Services;

namespace ThanksCardClient.ViewModels
{
    public class HeaderViewModel : BindableBase
    {
        private Employee _AuthorizedEmployee;
        public Employee AuthorizedEmployee
        {
            get { return _AuthorizedEmployee; }
            set { SetProperty(ref _AuthorizedEmployee, value); }
        }
        public HeaderViewModel()
        {
            this.AuthorizedEmployee = SessionService.Instance.AuthorizedEmployee;
        }
    }
}
