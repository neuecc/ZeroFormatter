using System;
using ZeroFormatter.Internal;

namespace ZeroFormatter.Formatters
{
    internal class DateTimeOffsetFormatter<TTypeResolver> : Formatter<TTypeResolver, DateTimeOffset>
        where TTypeResolver : ITypeResolver, new()
    {
        public override bool NoUseDirtyTracker
        {
            get
            {
                return true;
            }
        }

        public override int? GetLength()
        {
            return 14;
        }

        public override int Serialize(ref byte[] bytes, int offset, DateTimeOffset value)
        {
            BinaryUtil.WriteDateTime(ref bytes, offset, new DateTime(value.Ticks, DateTimeKind.Utc)); // current ticks as is.
            BinaryUtil.WriteInt16(ref bytes, offset + 12, (short)value.Offset.TotalMinutes);
            return 14;
        }

        public override DateTimeOffset Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 14;
            var dateTime = BinaryUtil.ReadDateTime(ref bytes, offset);
            var dateOffsetMinutes = BinaryUtil.ReadInt16(ref bytes, offset + 12);
            return new DateTimeOffset(dateTime.Ticks, TimeSpan.FromMinutes(dateOffsetMinutes));
        }
    }

    internal class NullableDateTimeOffsetFormatter<TTypeResolver> : Formatter<TTypeResolver, DateTimeOffset?>
        where TTypeResolver : ITypeResolver, new()
    {
        public override bool NoUseDirtyTracker
        {
            get
            {
                return true;
            }
        }

        public override int? GetLength()
        {
            return 15;
        }

        public override int Serialize(ref byte[] bytes, int offset, DateTimeOffset? value)
        {
            BinaryUtil.EnsureCapacity(ref bytes, offset, 13);
            if (value.HasValue)
            {
                BinaryUtil.WriteBooleanTrueUnsafe(ref bytes, offset);
                BinaryUtil.WriteDateTime(ref bytes, offset + 1, new DateTime(value.Value.Ticks, DateTimeKind.Utc)); // current ticks as is.
                BinaryUtil.WriteInt16(ref bytes, offset + 13, (short)value.Value.Offset.TotalMinutes);
            }
            else
            {
                BinaryUtil.WriteBooleanFalseUnsafe(ref bytes, offset);
            }

            return 15;
        }

        public override DateTimeOffset? Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 15;

            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return default(DateTimeOffset?);

            var dateTime = BinaryUtil.ReadDateTime(ref bytes, offset + 1);
            var dateOffsetMinutes = BinaryUtil.ReadInt16(ref bytes, offset + 13);
            return new DateTimeOffset(dateTime.Ticks, TimeSpan.FromMinutes(dateOffsetMinutes));
        }
    }
}
