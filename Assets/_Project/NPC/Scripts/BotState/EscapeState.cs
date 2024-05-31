using UnityEngine;

public class EscapeState : IBotState
{
   
    private float _escapeWeight = 0;
    private float _escapeFactor = 1f;

    private Vector3 _runawayTarget;




    public void Enter(BotComponent bot)
    {
        Debug.Log("Переход в состояние: " + BotState.ESCAPE);
        bot.GetStatusPanicMode = true;
        bot.GetMoveStatus = true;
      
    }

    public void Execute(BotComponent bot)
    {
        if (bot.GetTargetEnemy == null)
        {
             _runawayTarget = bot.GetTargetDefault.transform.position;
 
        }
        else
        {
            _runawayTarget = bot.GetTargetEnemy.transform.position;
        }

        var (distanceSquared, activeDistanceSquared, escTarget) = Escape(bot, _runawayTarget);


        if (distanceSquared > activeDistanceSquared)
        {
            bot.GetTarget = escTarget;
           
        }
        bot.GetStatusPanicMode = false;
        _escapeWeight = 0;

    }

    public void Exit(BotComponent bot)
    {
        _escapeWeight = 0;
        bot.GetTargetEnemy = null;
        bot.GetStatusPanicMode = false;
        Debug.Log("Выход из состояния: " + BotState.ESCAPE);
    }
     

    public float GetWeight(BotComponent bot)
    {
        if (bot.Activity == false) return 0f;


        #region CheckNUll
        if (bot.GetHealthComponent == null)
        {
            Debug.Log("GetHealthComponent is Null");

        }

        if (bot.GetHealthComponent.GetHealth == 0)
        {
            Debug.Log("bot.GetHealthComponent.GetHealth is Zero");

        }
        #endregion

        _escapeWeight = bot.GetHealthComponent.GetHealthFactor();
         
        //Если активный аптечек больше 0, то надежда есть
        if( bot.GetHealthManager.GetActiveAirKitCount() > 0)
        {
            _escapeWeight -= _escapeFactor;
        }
        else
        {
            _escapeWeight += _escapeFactor;
        }

        //Если аптечку не удалось найти, то надежда падает
        if (!bot.GetStatusAidkit)
        {
            _escapeWeight += _escapeFactor;
        }

        //если есть противник, то надежда стремительно падает
        if (bot.GetTargetEnemy)
        {
            _escapeWeight += _escapeFactor + Mathf.Abs(bot.GetHealthComponent.GetHealth - bot.GetTargetEnemy.GetHealthComponent.GetHealth);

        }
        else
        {
            _escapeWeight -= _escapeFactor;
        }


        bot.GetController.Escape = (int)_escapeWeight;
      
        return _escapeWeight;
 



    }

    private (float distanceSquared, float activeDistanceSquared, Vector3 escTarget) Escape(BotComponent bot, Vector3 target)
    {
        Vector3 escDirection = (bot.transform.position - target).normalized;
        Vector3 escTarget = bot.transform.position + escDirection * bot.GetConfig.EscapeDistance;

        float distanceSquared = (bot.transform.position - escTarget).sqrMagnitude;
        float activeDistanceSquared = bot.GetConfig.EscapeDistance  * bot.GetConfig.EscapeDistance;

        return (distanceSquared, activeDistanceSquared, escTarget);
    }





}
