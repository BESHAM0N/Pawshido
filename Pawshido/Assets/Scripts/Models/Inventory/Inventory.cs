using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventories
{
    public sealed class Inventory : IEnumerable<Item>
    {
        public event Action<Item, Vector2Int> OnAdded;
        public event Action<Item, Vector2Int> OnRemoved;
        public event Action OnCleared;

        private readonly Item[,] _grid;
        private readonly Dictionary<Item, Vector2Int> _items = new();

        public int Width { get; }
        public int Height { get; }
        public int Count => _items.Count;

        public Inventory(int width, int height)
        {
            if (width <= 0 || height <= 0)
                throw new ArgumentException("Width and height must be greater than zero");

            Width = width;
            Height = height;
            _grid = new Item[width, height];
        }

        public bool CanAddItem(Vector2Int position) => 
            IsPositionWithinBounds(position) && _grid[position.x, position.y] == null;

        public bool AddItem(Item item, Vector2Int position)
        {
            if (item == null || _items.ContainsKey(item) || !CanAddItem(position))
                return false;

            _grid[position.x, position.y] = item;
            _items[item] = position;
            OnAdded?.Invoke(item, position);
            return true;
        }

        public bool RemoveItem(Item item)
        {
            if (!_items.TryGetValue(item, out var position))
                return false;

            _grid[position.x, position.y] = null;
            _items.Remove(item);
            OnRemoved?.Invoke(item, position);
            return true;
        }

        public bool Contains(Item item) => _items.ContainsKey(item);

        public Item GetItem(Vector2Int position) => _grid[position.x, position.y];

        public void Clear()
        {
            Array.Clear(_grid, 0, _grid.Length);
            _items.Clear();
            OnCleared?.Invoke();
        }

        private bool IsPositionWithinBounds(Vector2Int position) =>
            position.x >= 0 && position.x < Width && position.y >= 0 && position.y < Height;

        public IEnumerator<Item> GetEnumerator() => _items.Keys.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
