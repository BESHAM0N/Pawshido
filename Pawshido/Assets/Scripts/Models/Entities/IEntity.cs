using Enums;
using UnityEngine;

namespace Models
{
    public interface IEntity
    {
        int Id { get; set; }
        string Name { get; set; }
        GameRoles GameRole { get; set; }
        Vector3 Position { get; set; }
    }
}