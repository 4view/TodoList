namespace Todo.Core.Entities;

/// <summary>
/// Описание сущности в базе данных
/// </summary>
public class ChallengeEntity
{
    /// <summary>
    /// Уникальный 
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Сообщение в задание
    /// </summary>
    public string? Comment { get; set; }

    /// <summary>
    /// Дата создания 
    /// </summary>
    public DateTimeOffset CreationDate { get; set; }

    /// <summary>
    /// Было ли выполнено задание
    /// </summary>
    public bool isComplete { get; set; }
}