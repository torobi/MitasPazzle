using UnityEngine;

namespace Adapter
{
    public class KeyRecord
    {
        public readonly Keyboard.Key Key;
        private readonly Keyboard.KeyDownCallback _callback;
        private readonly float _duration;
        private float _holdTime = 0;

        public KeyRecord(Keyboard.Key key, Keyboard.KeyDownCallback callback, float duration)
        {
            Key = key;
            _callback = callback;
            _duration = duration;
        }

        public void Update(bool isDown, float dt)
        {
            if (!isDown)
            {
                _holdTime = 0;
            }
            else if (_holdTime >= _duration)
            {
                _callback();
                _holdTime = 0.001f;
            }
            else if (_holdTime == 0)
            {
                _callback();
                _holdTime += dt;
            }
            else
            {
                _holdTime += dt;
            }
        }
    }
}