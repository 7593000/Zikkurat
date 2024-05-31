using System.Collections.Generic;
using UnityEngine;

public class CreateBotsPool : MonoBehaviour
{
    [SerializeField]
    private Portal[] _portals = new Portal[3];
    [SerializeField]
    private PoolBots _poolBots;
    [SerializeField]
    private BotComponent _unit;
    [Tooltip("���������� ����� �� 1 ������")]
    [SerializeField]
    private int _botsCount = 6;

    private List<BotComponent> _botList = new();

    public List<BotComponent> GetBotList => _botList;

    /// <summary>
    /// ���������� ����������� ���� �� ���� ��� ������� ������, ���� ��� ���� ������.
    /// </summary>
    public BotComponent GetBot()
    {
        foreach (var bot in _botList)
        {
            if (!bot.gameObject.activeSelf)
            {
                return bot;
            }
        }
        return AddBot();
    }

    /// <summary>
    /// ��������� ������ ���� � ��� � ���������� ���.
    /// </summary>
    public BotComponent AddBot()
    {
        var bot = CreateBot();
        _botList.Add(bot);
        return bot;
    }

    /// <summary>
    /// �����������, ���������������� ��� �����.
    /// </summary>
    private void Construct()
    {
        if (_poolBots == null || _unit == null)
        {
            Debug.LogError("PoolBots or Unit  not assigned.");
            return;
        }

        foreach (var portal in _portals)
        {
            if (portal != null)
            {
                for (int i = 0; i < _botsCount; i++)
                {
                    AddBot();
                }
            }
            else
            {
                Debug.LogError("Portal error: one of the portals is null.");
            }
        }
    }

    /// <summary>
    /// �������� ����� � ���������� �� � ���.
    /// </summary>
    /// <returns>��������� ���</returns>
    private BotComponent CreateBot()
    {
        BotComponent bot = Instantiate(_unit, _poolBots.transform.position, Quaternion.identity, _poolBots.transform);
        bot.gameObject.SetActive(false);
        bot.name = "Bot";
        return bot;
    }

    private void Awake()
    {
        Construct();
    }
}
