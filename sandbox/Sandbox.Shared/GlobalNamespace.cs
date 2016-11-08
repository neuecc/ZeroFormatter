using ZeroFormatter;

[ZeroFormattable]
public class DataRoot
{
    public enum DataTypeVersion
    {
        MonsterDataV1,
        MonsterDataV2,
    }

    [Index(0)]
    public virtual DataTypeVersion DataType { get; set; }

    [Index(1)]
    public virtual byte[] Data { get; set; }

    [Index(2)]
    public virtual MyGlobal GB { get; set; }
}

public enum MyGlobal
{
    A, B, C
}