using UnityEngine;
using UnityEngine.UIElements;

public class DetectedTrigger : MonoBehaviour
{
    [SerializeField]
    private BotComponent _bot;

#if UNITY_EDITOR

    [SerializeField]
    private float _detectionRadius = 10f;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _detectionRadius);
    }
#endif


    private void OnTriggerEnter( Collider other )
    {
        if (_bot.GetTargetEnemy != null || !_bot.Activity || _bot.GetStatusPanicMode)
        {
            return;
        }
 
        if ( other.TryGetComponent<BotComponent>(out var botComponent))
        {
            ColorFraction botEnemy = botComponent.GetColorBot;
            ColorFraction botTrigger = _bot.GetColorBot;

            if ( botTrigger != botEnemy )
            {
               
                _bot.GetTargetEnemy = botComponent;

                _bot.GetTarget = botComponent.transform.position;
               
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        
        if (other.TryGetComponent<BotComponent>(out var botComponent))
        {
          
            if (_bot.GetTargetEnemy == botComponent && !_bot.GetStatusPanicMode)
            {
                Debug.Log("Противник убежал");
              
                _bot.GetTargetEnemy = null;
                _bot.GetTarget = botComponent.transform.position;  
            }
        }
    }


}
