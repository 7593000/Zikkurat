using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class HealthBarComponent : MonoBehaviour
{ 
                     private Camera _mainCamera;
    [SerializeField] private Image _healthBarImage;
                     private bool _isActiveBot = true;
                     private static bool _healthBarsVisible = true;
    private static List<HealthBarComponent> _allHealthComponents = new();

    public static IReadOnlyList<HealthBarComponent> AllHealthComponents => _allHealthComponents;


    public void UpdateHealth(float currentHealth, float maxHealth)
    {
        if (currentHealth <= 0)
        {
            _isActiveBot = false;
            _healthBarImage.fillAmount = 0;
            return;
        }
        _healthBarImage.fillAmount = currentHealth / maxHealth;
    }
  

    protected virtual void Awake()
    {

        _allHealthComponents.Add(this);
        UpdateHealthBarVisibility(_healthBarsVisible);
    } 
    
    public static void SetHealthBarsVisibility(bool visible)
    {
        _healthBarsVisible = visible;
        foreach (var healthComponent in _allHealthComponents)
        {
            healthComponent.UpdateHealthBarVisibility(visible);
        }
    }

    protected virtual void OnDestroy()
    {
        _allHealthComponents.Remove(this);
    }

    protected abstract void UpdateHealthBarVisibility(bool visible);

    private void Start()
    {
        _mainCamera = Camera.main;
      
    }

    private void LateUpdate()
    {
        if (_mainCamera != null && _isActiveBot)
        {

            transform.LookAt(transform.position + _mainCamera.transform.rotation * Vector3.forward,
                             _mainCamera.transform.rotation * Vector3.up);
        }
    }
}
