namespace Domain.BaseEntity;
public abstract class Entity
{
    public Guid Id { get; protected set; }
    public DateTime CreatedAt { get; protected set; }
    public DateTime? UpdatedAt { get; protected set; }
    public DateTime? DeletedAt { get; protected set; }
    public bool IsDeleted { get; protected set; }
    public string CreatedBy { get; protected set; } = string.Empty;
    public string UpdatedBy { get; protected set; } = string.Empty;

    protected Entity()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
        IsDeleted = false;
    }

    public virtual void MarkAsUpdated(string? updatedBy)
    {
        if (string.IsNullOrWhiteSpace(updatedBy))
        {
            return;
        }

        UpdatedAt = DateTime.Now;
        UpdatedBy = updatedBy;
    }

    public virtual void MarkAsDeleted(string? deletedBy)
    {
        if (string.IsNullOrWhiteSpace(deletedBy))
        {
            return;
        }

        DeletedAt = DateTime.Now;
        IsDeleted = true;
        UpdatedBy = deletedBy;
    }

}
