using Enums;
using UnityEngine;

namespace Models
{
    public class Entity : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public GameRoles GameRole { get; set; }
        public Vector3 Position { get; set; }
        
    }
}