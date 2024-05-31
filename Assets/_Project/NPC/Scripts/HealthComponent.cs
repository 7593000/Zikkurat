using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _currentHealth;
                     private BotComponent _bot;



   

    public void Container(BotComponent bot)
    {
        _bot = bot;
        _maxHealth = _bot.GetConfig.Health;
        _currentHealth = _maxHealth;
        _healthBar.UpdateHealth(_currentHealth, _maxHealth);
    }
    
    public void Health(float value)
    {
        _currentHealth = Mathf.Clamp(value + _currentHealth, 0, _maxHealth);
        _healthBar.UpdateHealth(_currentHealth, _maxHealth);
    }

    public HealthBar GetHealthBar => _healthBar;

    /// <summary>
    /// Возвращает фактор здоровья, разница между максимальным и текущим здоровьем.
    /// </summary>
    /// <returns></returns>
    public float GetHealthFactor() => _maxHealth - _currentHealth;

    /// <summary>
    /// Получить здоровье бота
    /// </summary>
    public float GetHealth => _currentHealth;

    /// <summary>
    /// Проверка здоровья после полученного урона
    /// </summary>
    /// <param name="value"></param>
    private void HealthCheck(float value)
    {
        if (value <= 0) _bot.Activity = false;
    }

    /// <summary>
    ///   разницы здоровья для коэффициента
    /// </summary>
    public float GetHealthDifference(float maxHeight, float minHeight)
    {
        float health = maxHeight - minHeight;
        float healthPercentage = (health / maxHeight) * 10;
        return healthPercentage;
    }

    
    public void TakeDamage(float damage)
    {
        if(damage == -1)
        {
            _currentHealth = 0;
        }
        else
        {
            _currentHealth -= damage;
        }
      

        HealthCheck(_currentHealth);

        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);

        _healthBar.UpdateHealth(_currentHealth, _maxHealth);
    }



#if UNITY_EDITOR  //todo => DEL
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(5);
        }
    }
#endif
}
