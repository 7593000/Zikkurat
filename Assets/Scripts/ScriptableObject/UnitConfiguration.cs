using UnityEngine;
[CreateAssetMenu(fileName = "NewUnitConfig", menuName = "Configuration/Create UnitConfig", order = 51)]
public class UnitConfiguration : ScriptableObject
{
 
    [Tooltip("Минимальное растояние до цели")]
    [SerializeField] private float _activeDistance = 4f;
    [Tooltip("дальность убегания")]
    [SerializeField] private float  _escapeDistance = 10f;
    [Tooltip("Количество жизней")]
    [SerializeField] private int _health = 100;
    [Tooltip("Скорость перемещения")]
    [SerializeField] private float _speedMoving = 3f;
    [Tooltip("Скорость поворота")]
    [SerializeField] private float _rotationSpeed = 4f;
    [Tooltip( "Урон быстрой атаки" )]
    [SerializeField] private float _damageFastAttack = 4f;
    [Tooltip("Урон медленной атаки")]
    [SerializeField] private float _damageStrongAttack = 7f;
    [Tooltip("Скорость быстрой атаки ")]
    [SerializeField] private float _speedFastAttack = 2f;
    [Tooltip("Скорость медленной атаки")]
    [SerializeField] private float _speedStrongAttack = 4f;
    [Tooltip("Процент промаха при атаке")]
    [SerializeField] private float _missAttack = 0.09f;
    [Tooltip("Вероятность критического  удара")]
    [SerializeField] private float _chanceCrit = 15f;
    [Tooltip( "Коэффициент критического удара" )]
    [SerializeField] private float _critRatio = 1.5f;
    [Tooltip("Процентное соотношение вероятности слабой и сильной атак")]
    [SerializeField] private float _weakStrongAttackRatio = 4f;
    [Tooltip("Вероятность двойного удара")]
    [SerializeField] private float _doubleBlow = 0.4f;
    /////////////////////////////////////////////////////////////////////////////////////////////


    /// <summary>
    /// Минимальное растояние до цели
    /// </summary>
    public float ActiveDistance { get => _activeDistance; }
    /// <summary>
    /// Растояние убегания
    /// </summary>
    public float EscapeDistance { get => _escapeDistance; }

    /// <summary>
    /// Количество жизней
    /// </summary>
    public float Health { get => _health; }
    /// <summary>
    /// Скорость перемещения
    /// </summary>
    public float SpeedMoving { get => _speedMoving; }

    /// <summary>
    /// Скорость поворота
    /// </summary>
    public float RotationSpeed { get => _rotationSpeed; }
    /// <summary>
    /// Урон от медленной атаки
    /// </summary>
    public float DamageFastAttack => _damageFastAttack;
    /// <summary>
    /// Урон от сильной аттаки
    /// </summary>
    public float DamageStrongAttack => _damageStrongAttack;
    /// <summary>
    /// Скорость быстрой атаки
    /// </summary>
    public float SpeedFastAttack { get => _speedFastAttack; }
    /// <summary>
    /// Скорость медленной атаки
    /// </summary>
    public float SpeedStrongAttack { get => _speedStrongAttack; }
    /// <summary>
    /// Процент промаха при атаке
    /// </summary>
    public float MissAttack { get => _missAttack; }
    /// <summary>
    /// шанс крита
    /// </summary>
    public float СhanceCrit => _chanceCrit;
    /// <summary>
    /// Коэффициент критического удара
    /// </summary>
    public float CritRation => _critRatio;
    /// <summary>
    /// Процентное соотношение вероятности слабой и сильной атак
    /// </summary>
    public float WeakStrongAttackRatio { get => _weakStrongAttackRatio; }
    /// <summary>
    /// Процент выпадания двойного удара
    /// </summary>
    public float DoubleBlow {  get => _doubleBlow; }
}
