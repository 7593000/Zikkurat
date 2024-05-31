using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// Состояние бота: Атака
/// </summary>
public class AttackingState : IBotState
{
    private AttackComponent _strongAttack;
    private AttackComponent _fastAttack;
    private float _ratioStrongAndFast;
    private bool _canAttack;
    private bool _doubleBlow = false;
    private bool _critActive = false;
    public AttackingState(BotComponent bot)
    {
        _strongAttack = new(
            bot.GetConfig.DamageStrongAttack,
            bot.GetConfig.MissAttack,
            bot.GetConfig.ChanceCrit,
            bot.GetConfig.CritRatio,
            bot.GetConfig.DoubleBlow
        );

        _fastAttack = new(
            bot.GetConfig.DamageFastAttack,
            bot.GetConfig.MissAttack,
            bot.GetConfig.ChanceCrit,
            bot.GetConfig.CritRatio,
            bot.GetConfig.DoubleBlow
        );

        _ratioStrongAndFast = bot.GetConfig.WeakStrongAttackRatio;
        _canAttack = true;
    }

    public async void TryAttack(IAttack attack, string clip, float timer, BotComponent bot)
    {
        if (_canAttack)
        {
            if (_doubleBlow)
            {
                bot.ShowSpriteAnimation(SpriteType.DOUBLE);
                timer = 0;

            }
            if (_critActive) bot.ShowSpriteAnimation(SpriteType.CRIT);
          
            _doubleBlow = false;
            _critActive = false;
            _canAttack = false;
            
            Attack(attack, clip, bot);
            await AttackCooldown(timer);
             
            _canAttack = true;
        }
    }

    private async Task AttackCooldown(float attackSpeed)
    {
        await Task.Delay((int)(attackSpeed * 1000));
    }

    public void Enter(BotComponent bot)
    {
        Debug.Log("Переход в состояние: " + BotState.ATTACKING);
        bot.GetMoveStatus = false;
       
    }

    public void Execute(BotComponent bot)
    {
        if (bot.GetTargetEnemy != null && !bot.GetStatusPanicMode)
        {
            float distance = bot.CheckDisctance();

            if (float.IsNaN(distance))
            {
                ResetAttackTriggers(bot);
                return;
            }

            if (distance < bot.GetConfig.ActiveDistance)
            {
                bot.GetMoveStatus = false;
                float randomValue = Random.Range(0f, 1f);
                IAttack attack;
                string clip;
                float speedAttack;

                if (randomValue < _ratioStrongAndFast)
                {
                    attack = _strongAttack;
                    clip = "Strong";
                    speedAttack = bot.GetConfig.SpeedStrongAttack;
                }
                else
                {
                    attack = _fastAttack;
                    clip = "Fast";
                    speedAttack = bot.GetConfig.SpeedFastAttack;
                }
                if (_doubleBlow)
                {
                    bot.ShowSpriteAnimation(SpriteType.DOUBLE);
                    speedAttack = 0;
                     
                }
                if (_critActive) bot.ShowSpriteAnimation(SpriteType.CRIT);
                TryAttack(attack, clip, speedAttack, bot);
            }
            else
            {
                ResetAttackTriggers(bot);
                bot.GetMoveStatus = true;
            }
        }
     
    }

    public void Exit(BotComponent bot)
    {
        Debug.Log("Выход из состояния: " + BotState.ATTACKING);
        
       
    }

    public float GetWeight(BotComponent bot)
    {
        if (!bot.Activity) return 0f;

        float weight = 0;

        float healthFactor = bot.GetHealthComponent.GetHealth / bot.GetConfig.Health;

        if (bot.GetTargetEnemy != null && !bot.GetStatusPanicMode && bot.GetTargetEnemy.Activity)
        {
            weight = 50;
            float distance = bot.CheckDisctance();

            if (!float.IsNaN(distance) && distance < bot.GetConfig.ActiveDistance)
            {
                weight += (bot.GetHealthComponent.GetHealth - bot.GetTargetEnemy.GetHealthComponent.GetHealth) * healthFactor;
            }
            else
            {
                weight -= (bot.GetHealthComponent.GetHealth - bot.GetTargetEnemy.GetHealthComponent.GetHealth) * healthFactor;
                weight -= distance;
            }
        }
        else
        {
            bot.GetTargetEnemy = null;
            weight = 0;
        }

        weight = Mathf.Clamp(weight, 0f, 100f);
        bot.GetController.Attack = (int)weight;
        return weight;
    }





    private void Attack(IAttack attack, string clip, BotComponent bot)
    {
        bot.GetAnimator.SetTrigger(clip);

        (float damage, bool doubleBlow,bool crit)  = attack.Attack();

        _doubleBlow = doubleBlow;
        _critActive = crit;
        if (damage > 0 && bot.GetTargetEnemy != null)
        {
            bot.GetTargetEnemy.GetAnimator.SetTrigger("Impact");
            bot.GetTargetEnemy.GetMoveStatus = false;
            bot.GetTargetEnemy.GetHealthComponent.TakeDamage(damage);
            bot.GetTargetEnemy.GetMoveStatus = true;
        }
    }


    private void ResetAttackTriggers(BotComponent bot)
    {
        bot.GetAnimator.ResetTrigger("Strong");
        bot.GetAnimator.ResetTrigger("Fast");
    }
}
