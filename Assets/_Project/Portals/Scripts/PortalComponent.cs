using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PortalComponent : MonoBehaviour
{
    protected Material _materialPortal;

    [SerializeField] private bool _isActive = true;
    [SerializeField] protected Texture2D _cursorTexture;
                     protected CursorMode _cursorMode = CursorMode.Auto;
                     protected Vector2 _hotSpot = Vector2.zero;
                     protected Coroutine _summonCoroutine;
    [SerializeField] protected BotStatsConfig _botStatsConfig;
    [SerializeField] protected PortalConfiguration _portalConfig;
    [SerializeField] protected UnitConfiguration _unitConfig;
                     private List<BotComponent> _portalBots = new();
                     private CreateBotsPool _poolBots;
  
  
    
    
    public float GetTimeReport { get; private set; }
  
    /// <summary>
    /// Список ботов портала 
    /// </summary>
    public IReadOnlyList<BotComponent> GetPortalBots => _portalBots;    
   
    public Material GetMaterial { get; protected set; }

    public ColorFraction ColorPortal { get; protected set; }

    private object queueLock = new object();

    private BotComponent SearchAvailableItems()
    {
        lock (queueLock)//используется для обеспечения синхронизации доступа к ресурсам 
        {
            return _poolBots.GetBot();
        }

    }

    protected void SummonBots(BotComponent bot)
    {
        //todo=> убрать Find
        //Transform objBody = bot.transform.Find("polySurface");
        //Transform objShield = bot.transform.Find("PolyartShield");

        if (_portalConfig.MaterialFraction != null  )
        {
            //objBody.GetComponent<Renderer>().material = _portalConfig.MaterialFraction;
            //objShield.GetComponent<Renderer>().material = _portalConfig.MaterialFraction;
         
            bot.InstallColor(_portalConfig.MaterialFraction);
            bot.GetColorBot = ColorPortal;
        }

        StartPointSummon startPointSummon = GetComponentInChildren<StartPointSummon>();

        bot.transform.SetPositionAndRotation(startPointSummon.transform.position, bot.GetTargetDefault.transform.rotation);
        bot.name = $"Bot-{_portalConfig.ColorPortal} fraction";
        bot.Container(_botStatsConfig);
        bot.gameObject.SetActive(true);
        bot.Activity = true;
        _portalBots.Add(bot);
    }
    protected IEnumerator SpawmBots()
    {
        float startTime = Time.time;  
        float summonInterval = _portalConfig.SummonTimer; 

        while (_isActive)
        {
            float elapsedTime = Time.time - startTime;  
            float remainingTime = summonInterval - elapsedTime;  

             
            remainingTime = Mathf.Max(0, remainingTime);

            
            GetTimeReport = remainingTime;

            if (remainingTime <= 0)
            {
                SummonBots(SearchAvailableItems());
                startTime = Time.time; // Перезапускаем таймер
            }

            yield return null;  
        }
    }
 

    protected void InstallPortal()
    {
        _summonCoroutine = StartCoroutine(SpawmBots());
    }


    protected virtual void Awake()
    {


        ColorPortal = _portalConfig.ColorPortal;
        GetMaterial = _portalConfig.MaterialFraction;
        _botStatsConfig = new BotStatsConfig(_unitConfig);





    }

    protected virtual void Start()
    {
        _poolBots = FindFirstObjectByType<CreateBotsPool>();
        _materialPortal = GetComponent<Renderer>().material;
        InstallPortal();
    }
}
