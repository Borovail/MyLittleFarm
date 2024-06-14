public class AddGoldToPlayerCommand : Command
{
    private Player _player;
    private float _goldAmount;
    public AddGoldToPlayerCommand(Player player, float goldAmount)
    {
        _player = player;
        _goldAmount = goldAmount;
    }
    public override void Execute()
    {
        _player.Gold += _goldAmount;
    }
}

