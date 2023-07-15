using System;
using FluentValidator;

namespace EliteStay.Shared.Entities
{
  public abstract class Entity : Notifiable
  {
    public Entity()
    {
      Id = Guid.NewGuid();
    }

    public Guid Id { get; protected set; }
  }
}