using UnityEngine;
[CreateAssetMenu( fileName = "NewAttackType" , menuName = "Configuration/Attack Configuration" , order = 53 )]
public class AttackConfiguration : ScriptableObject
{

    //todo => DEL
    [SerializeField, Tooltip( "Скорость атаки" )]
    private float _speedAttack;
    [SerializeField, Tooltip( "Урон от атаки" )]
    private float _damage;
    [SerializeField, Tooltip( "Анимация атаки" )]
    private AnimationClip _clip;

    public float GetSpeedAttack => _speedAttack;
    public float GetDamage => _damage;

}

