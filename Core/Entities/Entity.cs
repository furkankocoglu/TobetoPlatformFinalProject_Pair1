﻿namespace Core.Entities
{
    public class Entity<TId> : IEntityTimestamps
    {
        public TId Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public Entity() //eğer parametre girilmezse default değer
        {
            Id = default; 
        }
        public Entity(TId id) 
        {
            Id = id; 
        }
    }
}
