using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BeaconIdentifierApp.Core.BeaconsManager;
using BeaconIdentifierApp.Core.Models;

namespace BeaconIdentifierApp.Core.ViewModels
{
    public class MainViewModel
    {
        private readonly IDataHelper _dataHelper;   

        public MainViewModel(IDataHelper dataHelper)
        {
            this._dataHelper = dataHelper;
        }

        public async Task<List<Discount>> PullDiscountsData(string filter = default)
        {
            if (!string.IsNullOrEmpty(filter))
            {
                return await _dataHelper.GetDiscountsForABeaconRegion(filter);
            }
            else
            {
                return await _dataHelper.GetDiscounts();
            }
        }

        public async Task<List<string>> GetBeaconIds()
        {
            return await _dataHelper.GetBeaconsIds();
        }
    }
}
