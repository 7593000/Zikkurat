using UnityEngine.UIElements;

public interface IBotState
{/// <summary>
/// ����� ����������� ��� �������� � ��������� 
/// </summary>
    public void Enter(BotComponent bot);
    /// <summary>
    /// ����� ����������� ��� ���������� � ���������  
    /// </summary>
    /// <param name="bot"></param>
    public void Execute(BotComponent bot);
    /// <summary>
    /// ����������� ��� ������ �� ���������  
    /// </summary>
    public void Exit(BotComponent bot);

    /// <summary>
    /// �������� ��� ��������� 
    /// </summary>
    /// <returns></returns>
    public float GetWeight(BotComponent bot);

}
