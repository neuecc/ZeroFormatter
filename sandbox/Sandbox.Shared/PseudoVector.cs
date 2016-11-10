#if INCLUDE_ONLY_CODE_GENERATION
// include generator target but does not includes compile.

using ZeroFormatter;

namespace UnityEngine
{
    [ZeroFormattable]
    public struct Vector2
    {
        [Index(0)]
        public float x;
        [Index(1)]
        public float y;

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
    }

  [ZeroFormattable]
public struct Vector3
{
    [Index(0)]
    public float x;
    [Index(1)]
    public float y;
    [Index(2)]
    public float z;

    public Vector2(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
}
}

#endif