using System.Collections.Generic;
using Adapter.DTO;

namespace Adapter
{
    public class Keyboard
    {
        private Dictionary<Key, KeyRecord> _records = new();
        public enum Key
        {
            MoveRight,
            MoveLeft,
            Drop,
            HardDrop,
            TurnRight,
            TurnLeft,
            Keep,
            Trash
        }
        
        public void Update(KeyDownData data)
        {
            foreach (var key in data.IsDownDict.Keys)
            {
                _records[key].Update(data.IsDownDict[key], data.DeltaTime);
            }
        }
        
        public delegate void KeyDownCallback();
        public void RegisterCallBack(Key key, KeyDownCallback callback, float duration = float.PositiveInfinity)
        {
            this._records[key] = new KeyRecord(key, callback, duration);
        }
    }
}