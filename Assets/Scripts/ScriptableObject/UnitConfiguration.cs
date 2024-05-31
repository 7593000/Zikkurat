using UnityEngine;
[CreateAssetMenu(fileName = "NewUnitConfig", menuName = "Configuration/Create UnitConfig", order = 51)]
public class UnitConfiguration : ScriptableObject
{
 
    [Tooltip("����������� ��������� �� ����")]
    [SerializeField] private float _activeDistance = 4f;
    [Tooltip("��������� ��������")]
    [SerializeField] private float  _escapeDistance = 10f;
    [Tooltip("���������� ������")]
    [SerializeField] private int _health = 100;
    [Tooltip("�������� �����������")]
    [SerializeField] private float _speedMoving = 3f;
    [Tooltip("�������� ��������")]
    [SerializeField] private float _rotationSpeed = 4f;
    [Tooltip( "���� ������� �����" )]
    [SerializeField] private float _damageFastAttack = 4f;
    [Tooltip("���� ��������� �����")]
    [SerializeField] private float _damageStrongAttack = 7f;
    [Tooltip("�������� ������� ����� ")]
    [SerializeField] private float _speedFastAttack = 2f;
    [Tooltip("�������� ��������� �����")]
    [SerializeField] private float _speedStrongAttack = 4f;
    [Tooltip("������� ������� ��� �����")]
    [SerializeField] private float _missAttack = 0.09f;
    [Tooltip("����������� ������������  �����")]
    [SerializeField] private float _chanceCrit = 15f;
    [Tooltip( "����������� ������������ �����" )]
    [SerializeField] private float _critRatio = 1.5f;
    [Tooltip("���������� ����������� ����������� ������ � ������� ����")]
    [SerializeField] private float _weakStrongAttackRatio = 4f;
    [Tooltip("����������� �������� �����")]
    [SerializeField] private float _doubleBlow = 0.4f;
    /////////////////////////////////////////////////////////////////////////////////////////////


    /// <summary>
    /// ����������� ��������� �� ����
    /// </summary>
    public float ActiveDistance { get => _activeDistance; }
    /// <summary>
    /// ��������� ��������
    /// </summary>
    public float EscapeDistance { get => _escapeDistance; }

    /// <summary>
    /// ���������� ������
    /// </summary>
    public float Health { get => _health; }
    /// <summary>
    /// �������� �����������
    /// </summary>
    public float SpeedMoving { get => _speedMoving; }

    /// <summary>
    /// �������� ��������
    /// </summary>
    public float RotationSpeed { get => _rotationSpeed; }
    /// <summary>
    /// ���� �� ��������� �����
    /// </summary>
    public float DamageFastAttack => _damageFastAttack;
    /// <summary>
    /// ���� �� ������� ������
    /// </summary>
    public float DamageStrongAttack => _damageStrongAttack;
    /// <summary>
    /// �������� ������� �����
    /// </summary>
    public float SpeedFastAttack { get => _speedFastAttack; }
    /// <summary>
    /// �������� ��������� �����
    /// </summary>
    public float SpeedStrongAttack { get => _speedStrongAttack; }
    /// <summary>
    /// ������� ������� ��� �����
    /// </summary>
    public float MissAttack { get => _missAttack; }
    /// <summary>
    /// ���� �����
    /// </summary>
    public float �hanceCrit => _chanceCrit;
    /// <summary>
    /// ����������� ������������ �����
    /// </summary>
    public float CritRation => _critRatio;
    /// <summary>
    /// ���������� ����������� ����������� ������ � ������� ����
    /// </summary>
    public float WeakStrongAttackRatio { get => _weakStrongAttackRatio; }
    /// <summary>
    /// ������� ��������� �������� �����
    /// </summary>
    public float DoubleBlow {  get => _doubleBlow; }
}
