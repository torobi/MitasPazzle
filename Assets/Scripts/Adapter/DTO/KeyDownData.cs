using System.Collections.Generic;

namespace Adapter.DTO
{
    public struct KeyDownData
    {
        public readonly float DeltaTime;
        public readonly Dictionary<Keyboard.Key, bool> IsDownDict;

        public KeyDownData(float deltaTime, Dictionary<Keyboard.Key, bool> isDownDict)
        {
            this.DeltaTime = deltaTime;
            this.IsDownDict = isDownDict;
        }
    }
}