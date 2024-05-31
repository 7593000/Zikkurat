using UnityEngine;

public class HealthBar : HealthBarComponent
{
    [SerializeField] private Canvas _healthBarCanvas;
   

    protected override void UpdateHealthBarVisibility(bool visible)
    {
        if (_healthBarCanvas != null)
        {
            _healthBarCanvas.enabled = visible;
        }
    }

 

}
