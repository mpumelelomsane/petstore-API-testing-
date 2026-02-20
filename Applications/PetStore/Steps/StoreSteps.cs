using System.Collections.Generic;
using FluentAssertions;
using Gauge.CSharp.Lib.Attribute;
using Applications.PetStore.Swagger.Api;

namespace Applications.PetStore.Steps
{
    public class StoreSteps
    {
        private Dictionary<string, int?> _inventory;
        private readonly StoreApi _storeApi = new StoreApi(StepsHelper.BasePath);

        [Step("Get store inventory")]
        public void GetStoreInventory()
        {
            _inventory = _storeApi.GetInventory();
            _inventory.Should().NotBeEmpty();
        }

        [Step("Check that inventory has status <status>")]
        public void CheckStatus(string status)
        {
            _inventory.Keys.Should().Contain(status);
        }
    }
}
