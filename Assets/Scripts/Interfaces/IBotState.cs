using UnityEngine.UIElements;

public interface IBotState
{/// <summary>
/// метод выполняется при переходе в состояние 
/// </summary>
    public void Enter(BotComponent bot);
    /// <summary>
    /// метод выполняемый при нахождении в состоянии  
    /// </summary>
    /// <param name="bot"></param>
    public void Execute(BotComponent bot);
    /// <summary>
    /// выполняемый при выходе из состояния  
    /// </summary>
    public void Exit(BotComponent bot);

    /// <summary>
    /// Получить вес состояния 
    /// </summary>
    /// <returns></returns>
    public float GetWeight(BotComponent bot);

}
