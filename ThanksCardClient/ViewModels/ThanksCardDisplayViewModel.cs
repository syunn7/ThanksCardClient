using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanksCardClient.Models;

#nullable disable
namespace ThanksCardClient.ViewModels
{
    public class ThanksCardDisplayViewModel : BindableBase, INavigationAware
    {
        private readonly IRegionManager regionManager;

        private ThanksCard _ThanksCard;
        public ThanksCard ThanksCard
        {
            get { return _ThanksCard; }
            set { SetProperty(ref _ThanksCard, value); }
        }

        private List<Employee> _Employees;
        public List<Employee> Employees
        {
            get { return _Employees; }
            set { SetProperty(ref _Employees, value); }
        }

        private List<Organization> _Organizations;
        public List<Organization> Organizations
        {
            get { return _Organizations; }
            set { SetProperty(ref _Organizations, value); }
        }

        public ThanksCardDisplayViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;

        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }

        public async void OnNavigatedTo(NavigationContext navigationContext)
        {
            // 画面遷移元から送られる SelectedTag パラメーターを取得。
            this.ThanksCard = navigationContext.Parameters.GetValue<ThanksCard>("SelectedThanksCard");

            Employee employee = new Employee();
            this.Employees = await employee.GetEmployeesAsync();
            Organization organization = new Organization();
            this.Organizations = await organization.GetOrganizationsAsync();
        }
        #region   HomeCommand
        private DelegateCommand _HomeCommand;
        public DelegateCommand HomeCommand =>
            _HomeCommand ?? (_HomeCommand = new DelegateCommand(ExecuteHomeCommand));
        void ExecuteHomeCommand()
        {
            this.regionManager.RequestNavigate("MainRegion", nameof(Views.Home));
        }
        #endregion
    }
}