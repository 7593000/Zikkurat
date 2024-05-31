using System.Collections.Generic;
using UnityEngine;

public class BotManager : MonoBehaviour, IUpdateComponent
{
    [SerializeField] private CreateBotsPool _botsPool;
    
    private IReadOnlyList<BotComponent> _bots = new List<BotComponent>();

    private void OnEnable()
    {
        MenuComponent.OnDeadAll += KillAllUnits;    
    }

    private void OnDisable()
    {
        MenuComponent.OnDeadAll -= KillAllUnits;
    }

    private void Start()
    {
        _bots = _botsPool.GetBotList;
    }
     
    public void UpdateComponent()
    {
        foreach (BotComponent bot in _botsPool.GetBotList)
        {
            if (!bot.IsDie && bot.gameObject.activeSelf ) { 
            bot.GetController.GetWeights();
            bot.UpdateBot();
            }
        }
    }

    private void KillAllUnits()
    {
        Debug.Log("KILL");
        for(int i = 0; i< _bots.Count; i++)
        {
            if(_bots[i].Activity )
            {
              
                _bots[i].Activity = false;
                Debug.Log(_bots[i].Activity);
            }
        }
    }

    private void Update()
    {
        for (int i = 0; i < _bots.Count; i++)
        {


            if (_bots[i].Activity && _bots[i].GetMoveStatus)
            {
                _bots[i].GetAnimator.SetFloat("Movement", 1);
                MoveBot(_bots[i]);

            }
            else
            {
                _bots[i].GetAnimator.SetFloat("Movement", 0);

            }


        }
    }

    private void MoveBot(BotComponent bot)
    {
        if (bot.GetTarget == null)
        {
            bot.GetMoveStatus = false;
            return;
        }

        Vector3 direction = (bot.GetTarget - bot.transform.position).normalized;

        // Проверка на нулевой вектор
        if (direction == Vector3.zero)
        {
            bot.GetMoveStatus = false;
            Debug.Log("Бот уже на цели");
            return;
        }

        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));


        //Чем меньше жизней- тем медленее идет
        float movemotionCorrection = bot.GetHealthComponent.GetHealth / bot.GetConfig.Health;
        movemotionCorrection = Mathf.Clamp(movemotionCorrection, 0.6f, 1);

        bot.transform.SetPositionAndRotation(
            Vector3.MoveTowards(bot.transform.position, bot.GetTarget, bot.GetConfig.SpeedMoving * movemotionCorrection * Time.deltaTime),
            Quaternion.Slerp(bot.transform.rotation, lookRotation, Time.deltaTime * bot.GetConfig.RotationSpeed)
        );

        float distanceSquared = (bot.transform.position - bot.GetTarget).sqrMagnitude;
        float activeDistanceSquared = bot.GetConfig.ActiveDistance * bot.GetConfig.ActiveDistance;

       


        if (distanceSquared < activeDistanceSquared)
        {
            if (bot.GetMoveStatus)
            {
                 
                    Debug.Log("Бот достиг цели");
                   // bot.GetMoveStatus = false;
                
            }
        }
        else
        {
            bot.GetMoveStatus = true;
        }
    }

}





