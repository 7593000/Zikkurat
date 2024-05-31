using System;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

[Serializable]
public class BotStatsConfig
{
    [Tooltip("����������� ��������� �� ����")]
    [SerializeField] private float _activeDistance;
    [Tooltip("��������� ��������")]
    [SerializeField] private float _escapeDistance;
    [Tooltip("���������� ������")]
    [SerializeField] private float _health;
    [Tooltip("�������� �����������")]
    [SerializeField] private float _speedMoving;
    [Tooltip("�������� ��������")]
    [SerializeField] private float _rotationSpeed;
    [Tooltip("���� ������� �����")]
    [SerializeField] private float _damageFastAttack;
    [Tooltip("���� ��������� �����")]
    [SerializeField] private float _damageStrongAttack;
    [Tooltip("�������� ������� �����")]
    [SerializeField] private float _speedFastAttack;
    [Tooltip("�������� ��������� �����")]
    [SerializeField] private float _speedStrongAttack;

    [Tooltip("������� ������� ��� �����")]
    [SerializeField] private float _missAttack;
    [Tooltip("����������� ������������ �����")]
    [SerializeField] private float _chanceCrit;
    [Tooltip("����������� ������������ �����")]
    [SerializeField] private float _critRatio;
    [Tooltip("���������� ����������� ����������� ������ � ������� ����")]
    [SerializeField] private float _weakStrongAttackRatio;
    [Tooltip(" ������� ��������� �������� �����")]
    [SerializeField] private float _doubleBlow;
    
    

    #region SETTINGS
    /// <summary>
    /// ����������� ��������� �� ����
    /// </summary>
    public float ActiveDistance
    {
        get => _activeDistance;
        set => _activeDistance = value;
    }

    /// <summary>
    /// ��������� ��������
    /// </summary>
    public float EscapeDistance
    {
        get => _escapeDistance;
        set => _escapeDistance = value;
    }

    /// <summary>
    /// ���������� ������
    /// </summary>
    public float Health
    {
        get => _health;
        set => _health = value;
    }

    /// <summary>
    /// �������� �����������
    /// </summary>
    public float SpeedMoving
    {
        get => _speedMoving;
        set => _speedMoving = value;
    }

    /// <summary>
    /// �������� ��������
    /// </summary>
    public float RotationSpeed
    {
        get => _rotationSpeed;
        set => _rotationSpeed = value;
    }

    /// <summary>
    /// ���� �� ������� �����
    /// </summary>
    public float DamageFastAttack
    {
        get => _damageFastAttack;
        set => _damageFastAttack = value;
    }

    /// <summary>
    /// ���� �� ������� �����
    /// </summary>
    public float DamageStrongAttack
    {
        get => _damageStrongAttack;
        set => _damageStrongAttack = value;
    }

    /// <summary>
    /// �������� ������� �����
    /// </summary>
    public float SpeedFastAttack
    {
        get => _speedFastAttack;
        set => _speedFastAttack = value;
    }

    /// <summary>
    /// �������� ��������� �����
    /// </summary>
    public float SpeedStrongAttack
    {
        get => _speedStrongAttack;
        set => _speedStrongAttack = value;
    }

    /// <summary>
    /// ������� ������� ��� �����
    /// </summary>
    public float MissAttack
    {
        get => _missAttack;
        set => _missAttack = value;
    }

    /// <summary>
    /// ����������� ������������ �����
    /// </summary>
    public float ChanceCrit
    {
        get => _chanceCrit;
        set => _chanceCrit = value;
    }

    /// <summary>
    /// ����������� ������������ �����
    /// </summary>
    public float CritRatio
    {
        get => _critRatio;
        set => _critRatio = value;
    }
     /// <summary>
     /// ����������� ��������� ����� � �������
     /// </summary>
    public float WeakStrongAttackRatio { get => _weakStrongAttackRatio; set => _weakStrongAttackRatio = value; }
    /// <summary>
    /// ������� ��������� �������� �����
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
        _chanceCrit = config.�hanceCrit;
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
