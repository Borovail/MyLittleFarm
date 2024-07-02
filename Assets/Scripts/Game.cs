using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private ShopController _shopController;
    [SerializeField] private Player _player;
    [SerializeField] private CameraFollow _camera;
    [SerializeField] private InventoryController _inventoryController;
  

    private Inventory _inventory;
    private ShopCommandFactory _shopCommandFactory;
    private CommandInvoker _commandInvoker;
    private PlayerStats _playerStats;

    private EventBus _eventBus;

    private void Awake()
    {
        _playerStats = new PlayerStats(0);
        _eventBus = new EventBus();
        _shopCommandFactory = new ShopCommandFactory(_playerStats,_inventory);
        _commandInvoker = new CommandInvoker();
        _inventory = new Inventory();
        _inventoryController.Initialize(_inventory);
        _shopController.Initialize(_shopCommandFactory, _commandInvoker);
        _player.Initialize(_commandInvoker, _playerStats,_inventory);
        _camera.Initialize(_player.transform);
    }

  
}

