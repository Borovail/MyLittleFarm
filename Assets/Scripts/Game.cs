using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private ShopController _shopController;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private Player _player;
    [SerializeField] private CameraFollow _camera;
 

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
    }

    private void Start()
    {
        _shopController.Initialize(_shopCommandFactory, _commandInvoker);
        _player.Initialize(_commandInvoker, _playerStats);
        _camera.Initialize(_player.transform);
    }
}

