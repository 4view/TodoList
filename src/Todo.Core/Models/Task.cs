namespace Todo.Core.Models;


/// <summary>
/// Модель описывающая задания
/// </summary>
public class Task
{
    /// <summary>
    /// Id задания
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
    /// Выполнено ли задание
    /// </summary>
    public bool isComplete { get; set; }
}