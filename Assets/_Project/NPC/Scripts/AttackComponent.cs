using UnityEngine;

public sealed class AttackComponent : IAttack
{

    /// <summary>
    /// урон атаки
    /// </summary>
    private float _damageAttack;
    /// <summary>
    /// Коэффициент крита
    /// </summary>
    private float _critRatio;
    /// <summary>
    /// шанс промазать
    /// </summary>
    private float _missAttack;
    /// <summary>
    /// Шанс критического удара
    /// </summary>
    private float _critAttack;
    /// <summary>
    /// Шанс двойного удара
    /// </summary>
    private float _doubleBlow;

    public AttackComponent(  float damage , float missAttack , float crit , float critRatio, float doubleBlow )
    {
        
        _damageAttack = damage;
        _missAttack = missAttack;
        _critRatio = critRatio;
        _critAttack = crit;
        _doubleBlow = doubleBlow;
    }

    public (float,bool,bool) Attack()
    {
        return  DamageCalculation();
     

    }
    /// <summary>
    /// Расчет коэффициента урона
    /// </summary>
    /// <returns></returns>
    private (float,bool,bool) DamageCalculation()
    {
        if ( MissCalculation() )
        {
            return (0,false,false);
        }

        if ( CritCalculation() )
        {
          
            return (_damageAttack * _critRatio, DoubleBlow(), true);
        }

        return (_damageAttack, DoubleBlow(), false);
    }
    /// <summary>
    /// Расчет коэффициента промаха
    /// </summary>
    /// <returns></returns>
    private bool MissCalculation() => RandomRange() < _missAttack;
    /// <summary>
    /// Расчет двойного удара
    /// </summary>
    /// <returns></returns>
    private bool DoubleBlow() => RandomRange() < _doubleBlow;
    /// <summary>
    /// Расчет коэффициента крита
    /// </summary>
    /// <returns></returns>
    public bool CritCalculation() => RandomRange() < _critAttack;

    public float RandomRange()
    {
        return Random.Range( 0f , 1f );
    }


}
