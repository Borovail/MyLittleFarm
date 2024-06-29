using System;

public class PlayerStats : IDisposable
{
    private int _gold;

    public int Gold
    {
        get => _gold;
        set
        {
            _gold = value;
            EventBus.PlayerGoldChanged.Invoke(_gold);
        }
    }

    public PlayerStats(int gold)
    {
        _gold = gold;
    }

    public void Dispose()
    {
        EventBus.PlayerGoldChanged.RemoveAllListeners();
    }
}