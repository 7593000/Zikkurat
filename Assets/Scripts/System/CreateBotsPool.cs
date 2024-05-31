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
    [Tooltip("Количество ботов на 1 ворота")]
    [SerializeField]
    private int _botsCount = 6;

    private List<BotComponent> _botList = new();

    public List<BotComponent> GetBotList => _botList;

    /// <summary>
    /// Возвращает неактивного бота из пула или создает нового, если все боты заняты.
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
    /// Добавляет нового бота в пул и возвращает его.
    /// </summary>
    public BotComponent AddBot()
    {
        var bot = CreateBot();
        _botList.Add(bot);
        return bot;
    }

    /// <summary>
    /// Конструктор, инициализирующий пул ботов.
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
    /// Создание ботов и добавление их в пул.
    /// </summary>
    /// <returns>Созданный бот</returns>
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
