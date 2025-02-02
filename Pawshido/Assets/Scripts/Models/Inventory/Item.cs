using UnityEngine;

namespace Inventories
{
    public sealed class Item
    {
        private static int _idGen;
        private readonly int _id;

        public string Name { get; }

        public Item(string name)
        {
            Name = name;
            _id = _idGen++;
        }

        public override bool Equals(object obj) => obj is Item other && _id == other._id;

        public override int GetHashCode() => _id;

        public override string ToString() => Name;
    }
}