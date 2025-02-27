using Todo.Core.Entities;

namespace Todo.Core.Models;


/// <summary>
/// Модель описывающая задания
/// </summary>
public class Challenge
{
    protected ChallengeEntity? _entity;

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

    public Challenge CreateFrom (ChallengeEntity challengeEntity)
    {
        var newTask = new Challenge()
        {
            Comment = challengeEntity.Comment,
            CreationDate = challengeEntity.CreationDate,
            isComplete = challengeEntity.isComplete
        };

        return newTask; 
    }

    public ChallengeEntity ToEntity()
    {
        if (_entity == null)
            _entity = new ChallengeEntity();
        
        _entity.Comment = Comment;
        _entity.CreationDate = CreationDate;
        _entity.isComplete = isComplete;

        return _entity;
    }
}