using UnityEngine;

namespace Systems
{
    public interface IMoveSystem
    {
        void Move(Vector3 direction, float speed);
        void Rotate(Quaternion rotation);
    }
}