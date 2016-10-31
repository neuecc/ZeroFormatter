#if !UNITY

using ZeroFormatter;

namespace UnityEngine
{
    [ZeroFormattable]
    public struct Vector2
    {
        [Index(0)]
        public float x { get; private set; }
        [Index(1)]
        public float y { get; private set; }

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
    }
}


#endif