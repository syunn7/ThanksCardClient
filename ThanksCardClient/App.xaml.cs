using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Prism.Ioc;
using Prism.Modularity;
using ThanksCardClient.Views;


namespace ThanksCardClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainWindow>();
            containerRegistry.RegisterForNavigation<Header>();
            containerRegistry.RegisterForNavigation<Logon>();
            containerRegistry.RegisterForNavigation<Login>();
            containerRegistry.RegisterForNavigation<Footer>();
            containerRegistry.RegisterForNavigation<Home>();
            containerRegistry.RegisterForNavigation<ThanksCardCreate>();
            containerRegistry.RegisterForNavigation<CreateThanksCard>();
            containerRegistry.RegisterForNavigation<ThanksCardList>();
            containerRegistry.RegisterForNavigation<ReceiveBox>();
            containerRegistry.RegisterForNavigation<SendBox>();
            //containerRegistry.RegisterForNavigation<PastList>();
            containerRegistry.RegisterForNavigation<EmployeeMg>();
            containerRegistry.RegisterForNavigation<EmployeeCreate>();
            containerRegistry.RegisterForNavigation<EmployeeEdit>();
            containerRegistry.RegisterForNavigation<OrganizationMg>();
            containerRegistry.RegisterForNavigation<OrganizationCreate>();
            containerRegistry.RegisterForNavigation<OrganizationEdit>();
            containerRegistry.RegisterForNavigation<ClassificationMg>();
            //containerRegistry.RegisterForNavigation<DetailList>();
            containerRegistry.RegisterForNavigation<Manual>();
            containerRegistry.RegisterForNavigation<ThanksCardDisplay>();
            //containerRegistry.RegisterForNavigation<Aggregation>();
            containerRegistry.RegisterForNavigation<UserMst>();
            containerRegistry.RegisterForNavigation<UserCreate>();
            containerRegistry.RegisterForNavigation<UserEdit>();
            containerRegistry.RegisterForNavigation<DepartmentMst>();
            containerRegistry.RegisterForNavigation<DepartmentCreate>();
            containerRegistry.RegisterForNavigation<DepartmentEdit>();
            containerRegistry.RegisterForNavigation<TagMst>();
            containerRegistry.RegisterForNavigation<TagCreate>();
            containerRegistry.RegisterForNavigation<TagEdit>();
        }
    }
}