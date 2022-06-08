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
            containerRegistry.RegisterForNavigation<Login>();
            containerRegistry.RegisterForNavigation<Home>();
            containerRegistry.RegisterForNavigation<CreateThanksCard>();
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
            containerRegistry.RegisterForNavigation<ClassificationCreate>();
            containerRegistry.RegisterForNavigation<ClassificationEdit>();
            //containerRegistry.RegisterForNavigation<DetailList>();
            containerRegistry.RegisterForNavigation<Manual>();
            containerRegistry.RegisterForNavigation<ThanksCardDisplay>();
            containerRegistry.RegisterForNavigation<ListThanksCard>();
            containerRegistry.RegisterForNavigation<Aggregation>();
        }
    }
}