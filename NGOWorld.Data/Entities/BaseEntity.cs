using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NGOWorld.Data.Entities
{
    public abstract partial class BaseEntity
    {

    }

    public interface IEntity<T>
    {
        T Id { get; set; }
    }

    public abstract class Entity<T> : BaseEntity, IEntity<T>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public T Id { get; set; }
    }
}
