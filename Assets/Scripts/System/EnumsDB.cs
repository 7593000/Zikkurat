public enum SpriteType : byte
{
    CRIT,
    DOUBLE,
    GHOST
}


/// <summary>
/// ������������ ��������� ����
/// </summary>
public enum BotState : byte
{
    /// <summary>
    /// �������� ������ ���������
    /// </summary>
    NONE = 0,
    /// <summary>
    /// ���������:  �������� 
    /// </summary>
    IDLE = 1,
    /// <summary>
    /// ���������:  �������������� ���������
    /// </summary>
    PATROL = 2,
    /// <summary>
    /// ���������:  �������� �� ������� 
    /// </summary>
    MOVE = 3,
    /// <summary>
    /// ���������: ����� ����� � �������� � ��������� ��� �������
    /// </summary>
    SEARCH = 4,
    /// <summary>
    /// ���������: ����� �����
    /// </summary>
    ATTACKING= 5,
    /// <summary>
    /// ���������: ����� �������
    /// </summary>
    SEEKHEALTH = 6,
    /// <summary>
    /// ���������: �������  
    /// </summary>
    ESCAPE = 7,
    /// <summary>
    /// ��� �������
    /// </summary>
    DIE = 8
}

 
public enum IgnoreAxisType : byte
{
    None = 0,
    X = 1,
    Y = 2,
    Z = 4
}

/// <summary>
/// ����� ������� 
/// </summary>
public enum ColorFraction:byte
{
    RED,
    GREEN,
    BLUE
}




