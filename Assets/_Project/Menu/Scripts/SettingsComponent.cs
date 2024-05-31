using UnityEngine;
using UnityEngine.UI;

public class SettingsComponent : MonoBehaviour
{
    [SerializeField, Tooltip("HP")] private SliderComponent _slider1;
    [SerializeField, Tooltip("Damage Fast Attack")] private SliderComponent _slider2;
    [SerializeField, Tooltip("Damage Strong Attack")] private SliderComponent _slider3;
    [SerializeField, Tooltip("Speed Fast Attack")] private SliderComponent _slider4;
    [SerializeField, Tooltip("Speed Strong Attack")] private SliderComponent _slider5;
    [SerializeField, Tooltip("Chance Crit ")] private SliderComponent _slider6;
    [SerializeField, Tooltip("Crit Ration")] private SliderComponent _slider7;
    [SerializeField, Tooltip("Miss Attack")] private SliderComponent _slider8;
    [SerializeField, Tooltip("Weak strong attack ratio")] private SliderComponent _slider9;
    [SerializeField, Tooltip("Chance double bLow")] private SliderComponent _slider10;


    private BotStatsConfig _config;

    private float _hp;
    private float _damageFastAttack;
    private float _damageStrongAttack;
    private float _speedFastAttack;
    private float _speedStrongAttack;
    private float _chanceCrit;
    private float _critRation;
    private float _missAttack;
    private float _wsar;
    private float _doubleBlow;

    /// <summary>
    /// Загрузить настройки из класса с настройками BotStatsConfig
    /// </summary>
    /// <param name="config">BotStatsConfig  копия от ScriptableObject</param>
    public void LoadSettings(BotStatsConfig config = null)
    {
        if (config != null)
        {
            _config = config;
        }


        _hp = _config.Health;
        _damageFastAttack = _config.DamageFastAttack;
        _damageStrongAttack = _config.DamageStrongAttack;
        _speedFastAttack = _config.SpeedFastAttack;
        _speedStrongAttack = _config.SpeedStrongAttack;
        _chanceCrit = _config.ChanceCrit;
        _critRation = _config.CritRatio;
        _missAttack = _config.MissAttack;
        _wsar = _config.WeakStrongAttackRatio;
        _doubleBlow = _config.DoubleBlow;

        _slider1.SetValue(_hp);
        _slider2.SetValue(_damageFastAttack  );
        _slider3.SetValue(_damageStrongAttack  );
        _slider4.SetValue(_speedFastAttack);
        _slider5.SetValue(_speedStrongAttack);
        _slider6.SetValue(_chanceCrit);
        _slider7.SetValue(_critRation);
        _slider8.SetValue(_missAttack);
        _slider9.SetValue(_wsar);
        _slider10.SetValue(_doubleBlow);


    }
   
    public void ResetSettings()
    {
        _slider1.SetValue(_hp);
        _slider2.SetValue(_damageFastAttack);
        _slider3.SetValue(_damageStrongAttack);
        _slider4.SetValue(_speedFastAttack);
        _slider5.SetValue(_speedStrongAttack);
        _slider6.SetValue(_chanceCrit);
        _slider7.SetValue(_critRation);
        _slider8.SetValue(_missAttack);
        _slider9.SetValue(_wsar);
        _slider10.SetValue(_doubleBlow);
    }
    /// <summary>
    /// Сохранить настройки 
    /// </summary>
    public void SaveSettings()
    {
         _config.SaveSettings(_slider1.GetValue, _slider2.GetValue, _slider3.GetValue, _slider4.GetValue, _slider5.GetValue, _slider6.GetValue, _slider7.GetValue, _slider8.GetValue, _slider9.GetValue, _slider10.GetValue);

    }


}
