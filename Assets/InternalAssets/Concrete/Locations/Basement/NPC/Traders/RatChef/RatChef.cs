using SouthBasement.Basement.NPC.Traders;
using SouthBasement.InventorySystem.ItemBase;
using SouthBasement.InventorySystem;
using SouthBasement.Items;
using SouthBasement.Scripts.Helpers;
using SouthBasement.TraderItemDescriptionHUD;
using Zenject;

namespace SouthBasement
{
    public class RatChef : TraderBase
    {
        private ItemsContainer _itemsContainer;
        private TraderHUD _traderHUD;

        [Inject]
        private void Construct(ItemsContainer itemsContainer, TraderHUD traderHUD)
        {
            _itemsContainer = itemsContainer;
            _traderHUD = traderHUD;
        }

        private void Start()
        {
            SpawnItems();
            GetComponentInChildren<TriggerCallback>().OnTriggerExit += (_) => _traderHUD.Disable();
        }

        protected override ItemsContainer GetItemsContainer() => _itemsContainer;
        protected override string TraderName() => "Rat Chef";
        protected override TraderHUD GetTraderHUD() => _traderHUD;
        protected override Item GetItem()
            => _itemsContainer.GetRandomInTypeAndCategory(typeof(FoodItem),ItemsTags.Cockroach);
        protected override bool CanRepeat() => false;
    }
}
