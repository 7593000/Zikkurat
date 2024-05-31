using UnityEngine;

public sealed class AttackComponent : IAttack
{

    /// <summary>
    /// ���� �����
    /// </summary>
    private float _damageAttack;
    /// <summary>
    /// ����������� �����
    /// </summary>
    private float _critRatio;
    /// <summary>
    /// ���� ���������
    /// </summary>
    private float _missAttack;
    /// <summary>
    /// ���� ������������ �����
    /// </summary>
    private float _critAttack;
    /// <summary>
    /// ���� �������� �����
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
    /// ������ ������������ �����
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
    /// ������ ������������ �������
    /// </summary>
    /// <returns></returns>
    private bool MissCalculation() => RandomRange() < _missAttack;
    /// <summary>
    /// ������ �������� �����
    /// </summary>
    /// <returns></returns>
    private bool DoubleBlow() => RandomRange() < _doubleBlow;
    /// <summary>
    /// ������ ������������ �����
    /// </summary>
    /// <returns></returns>
    public bool CritCalculation() => RandomRange() < _critAttack;

    public float RandomRange()
    {
        return Random.Range( 0f , 1f );
    }


}
