using System;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

[Serializable]
public class BotStatsConfig
{
    [Tooltip("Минимальное растояние до цели")]
    [SerializeField] private float _activeDistance;
    [Tooltip("дальность убегания")]
    [SerializeField] private float _escapeDistance;
    [Tooltip("Количество жизней")]
    [SerializeField] private float _health;
    [Tooltip("Скорость перемещения")]
    [SerializeField] private float _speedMoving;
    [Tooltip("Скорость поворота")]
    [SerializeField] private float _rotationSpeed;
    [Tooltip("Урон быстрой атаки")]
    [SerializeField] private float _damageFastAttack;
    [Tooltip("Урон медленной атаки")]
    [SerializeField] private float _damageStrongAttack;
    [Tooltip("Скорость быстрой атаки")]
    [SerializeField] private float _speedFastAttack;
    [Tooltip("Скорость медленной атаки")]
    [SerializeField] private float _speedStrongAttack;

    [Tooltip("Процент промаха при атаке")]
    [SerializeField] private float _missAttack;
    [Tooltip("Вероятность критического удара")]
    [SerializeField] private float _chanceCrit;
    [Tooltip("Коэффициент критического удара")]
    [SerializeField] private float _critRatio;
    [Tooltip("Процентное соотношение вероятности слабой и сильной атак")]
    [SerializeField] private float _weakStrongAttackRatio;
    [Tooltip(" Процент выпадания двойного удара")]
    [SerializeField] private float _doubleBlow;
    
    

    #region SETTINGS
    /// <summary>
    /// Минимальное растояние до цели
    /// </summary>
    public float ActiveDistance
    {
        get => _activeDistance;
        set => _activeDistance = value;
    }

    /// <summary>
    /// Растояние убегания
    /// </summary>
    public float EscapeDistance
    {
        get => _escapeDistance;
        set => _escapeDistance = value;
    }

    /// <summary>
    /// Количество жизней
    /// </summary>
    public float Health
    {
        get => _health;
        set => _health = value;
    }

    /// <summary>
    /// Скорость перемещения
    /// </summary>
    public float SpeedMoving
    {
        get => _speedMoving;
        set => _speedMoving = value;
    }

    /// <summary>
    /// Скорость поворота
    /// </summary>
    public float RotationSpeed
    {
        get => _rotationSpeed;
        set => _rotationSpeed = value;
    }

    /// <summary>
    /// Урон от быстрой атаки
    /// </summary>
    public float DamageFastAttack
    {
        get => _damageFastAttack;
        set => _damageFastAttack = value;
    }

    /// <summary>
    /// Урон от сильной атаки
    /// </summary>
    public float DamageStrongAttack
    {
        get => _damageStrongAttack;
        set => _damageStrongAttack = value;
    }

    /// <summary>
    /// Скорость быстрой атаки
    /// </summary>
    public float SpeedFastAttack
    {
        get => _speedFastAttack;
        set => _speedFastAttack = value;
    }

    /// <summary>
    /// Скорость медленной атаки
    /// </summary>
    public float SpeedStrongAttack
    {
        get => _speedStrongAttack;
        set => _speedStrongAttack = value;
    }

    /// <summary>
    /// Процент промаха при атаке
    /// </summary>
    public float MissAttack
    {
        get => _missAttack;
        set => _missAttack = value;
    }

    /// <summary>
    /// Вероятность критического удара
    /// </summary>
    public float ChanceCrit
    {
        get => _chanceCrit;
        set => _chanceCrit = value;
    }

    /// <summary>
    /// Коэффициент критического удара
    /// </summary>
    public float CritRatio
    {
        get => _critRatio;
        set => _critRatio = value;
    }
     /// <summary>
     /// Соотношение медленной атаки к быстрой
     /// </summary>
    public float WeakStrongAttackRatio { get => _weakStrongAttackRatio; set => _weakStrongAttackRatio = value; }
    /// <summary>
    /// Процент выпадания двойного удара
    /// </summary>
    public float DoubleBlow { get => _doubleBlow; set => _doubleBlow = value; }
    #endregion

    #region CONSTRUCTION 

    public BotStatsConfig(UnitConfiguration config)
    {
        _activeDistance = config.ActiveDistance;
        _escapeDistance = config.EscapeDistance;
        _health = config.Health;
        _speedMoving = config.SpeedMoving;
        _rotationSpeed = config.RotationSpeed;
        _damageFastAttack = config.DamageFastAttack;
        _speedFastAttack = config.SpeedFastAttack;
        _damageStrongAttack = config.DamageStrongAttack;
        _speedStrongAttack = config.SpeedStrongAttack;
        _missAttack = config.MissAttack;
        _chanceCrit = config.СhanceCrit;
        _critRatio = config.CritRation;
        _weakStrongAttackRatio = config.WeakStrongAttackRatio;
        _doubleBlow = config.DoubleBlow;
    }

    // Default  
    public BotStatsConfig() { }
    #endregion  

    public void SaveSettings(float health, float dFastAttack, float dStrongAttack, float SFastAttack, float SStrongAttack, 
        float chanceCreit, float critRation, float missAttack, float wsar, float doubleBlow)
    {
        Health = health;
        DamageFastAttack = dFastAttack;
        DamageStrongAttack  = dStrongAttack;
        SpeedFastAttack = SFastAttack;
        SpeedStrongAttack   = SStrongAttack;
        ChanceCrit = chanceCreit;
        CritRatio   = critRation;
        MissAttack = missAttack;
        WeakStrongAttackRatio = wsar;
        DoubleBlow = doubleBlow;
    }
}
