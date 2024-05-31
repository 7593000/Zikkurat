public enum SpriteType : byte
{
    CRIT,
    DOUBLE,
    GHOST
}


/// <summary>
/// Перечисление состояния бота
/// </summary>
public enum BotState : byte
{
    /// <summary>
    /// Ожидание нового состояния
    /// </summary>
    NONE = 0,
    /// <summary>
    /// Состояние:  ожидания 
    /// </summary>
    IDLE = 1,
    /// <summary>
    /// Состояние:  патрулирования местности
    /// </summary>
    PATROL = 2,
    /// <summary>
    /// Состояние:  движение на позицию 
    /// </summary>
    MOVE = 3,
    /// <summary>
    /// Состояние: Поиск врага и движение к последней его позиции
    /// </summary>
    SEARCH = 4,
    /// <summary>
    /// Состояние: Атака врага
    /// </summary>
    ATTACKING= 5,
    /// <summary>
    /// Состояние: Поиск аптечки
    /// </summary>
    SEEKHEALTH = 6,
    /// <summary>
    /// Состояние: бегство  
    /// </summary>
    ESCAPE = 7,
    /// <summary>
    /// Бот мертвый
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
/// Цвета фракций 
/// </summary>
public enum ColorFraction:byte
{
    RED,
    GREEN,
    BLUE
}




