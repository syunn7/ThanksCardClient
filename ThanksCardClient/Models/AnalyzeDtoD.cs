#nullable disable
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanksCardClient.Services;

namespace ThanksCardClient.Models
{
    public class AnalyzeDtoD : BindableBase
    {
        #region NameProperty
        private string _ToOrganizationName;
        public string ToOrganizationName
        {
            get { return _ToOrganizationName; }
            set { SetProperty(ref _ToOrganizationName, value); }
        }
        #endregion

        #region NameProperty
        private string _FromOrganizationName;
        public string FromOrganizationName
        {
            get { return _FromOrganizationName; }
            set { SetProperty(ref _FromOrganizationName, value); }
        }
        #endregion

        #region NameProperty
        private int _ThanksCount;
        public int ThanksCount
        {
            get { return _ThanksCount; }
            set { SetProperty(ref _ThanksCount, value); }
        }
        #endregion

        public async Task<List<AnalyzeDtoD>> GetAnalyzeDtoDsAsync()
        {
            IRestService rest = new RestService();
            List<AnalyzeDtoD> AnalyzeDtoD = await rest.GetAnalyzeDtoDsAsync();
            return AnalyzeDtoD;
        }
    }
}