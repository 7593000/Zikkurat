using UnityEngine;

/// <summary>
/// Состояние бота: Патрулирование
/// </summary>
public class PatrolState : IBotState
{

    public void Enter(BotComponent bot)
    {
        Debug.Log("Переход в состояние: " + BotState.PATROL);
        bot.GetBotState = BotState.MOVE;


        if (bot == null)
        {
            Debug.LogError("BotComponent  = null");
            return;
        }

        if (bot.GetTargetDefault == null)
        {
            Debug.LogError("GetTargetDefault  = null");
            return;
        }

        Transform targetTransform = bot.GetTargetDefault.transform;

        if (targetTransform == null)
        {
            Debug.LogError("GetTargetDefault  transform = null");
            return;
        }

        Vector3 targetPosition = targetTransform.position;
        bot.GetTarget = SetNewRandomTargetPosition(targetPosition);
        bot.GetBotState = BotState.PATROL;

        // Дополнительная проверка после назначения GetTarget
        if (bot.GetTargetDefault == null)
        {
            Debug.LogError("GetTargetDefault is null after assignment");
        }



    }

    public void Execute(BotComponent bot)
    {
        float distanceSquared = (bot.transform.position - bot.GetTarget).sqrMagnitude;
        float activeDistanceSquared = bot.GetConfig.ActiveDistance * bot.GetConfig.ActiveDistance;

        if (distanceSquared < activeDistanceSquared)
        {
            if (bot.GetMoveStatus)
            {

                bot.GetMoveStatus = false;

            }
        }

        if (bot.GetMoveStatus == false)
        {
            bot.GetTarget = SetNewRandomTargetPosition(bot.GetTarget);
            bot.GetMoveStatus = true;
        }

    }

    public void Exit(BotComponent bot)
    {

        bot.GetMoveStatus = false;
        Debug.Log("Выход из состояния: " + BotState.PATROL);


    }
    public float GetWeight(BotComponent bot)
    {
        if (bot.Activity == false) return 0f;
        float weight = 0f;

        if (bot.GetTargetEnemy == null)
        {
            weight += 50;
        }
        else
        {
            weight -= 50;
        }



        float healthFactor = bot.GetHealthComponent.GetHealth / bot.GetConfig.Health;

        weight *= healthFactor;


        if (bot.GetStatusPanicMode)
        {
            weight = 0;
        }


        weight = Mathf.Clamp(weight, 0f, 100f);


        bot.GetController.Patrol = (int)weight;

        return weight;
    }


    /// <summary>
    /// выбрать рандомную точку возле текущей 
    /// </summary> 
    private Vector3 SetNewRandomTargetPosition(Vector3 target)
    {
        var xRandom = Random.Range(-10f, 10f);
        var zRandom = Random.Range(-10f, 10f);

        return new Vector3(
               target.x + xRandom,
               target.y,
               target.z + zRandom
           );
    }






}
