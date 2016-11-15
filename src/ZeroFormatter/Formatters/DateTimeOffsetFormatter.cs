using System;
using ZeroFormatter.Internal;
using ZeroFormatter.Segments;

namespace ZeroFormatter.Formatters
{
    internal class DateTimeOffsetFormatter : Formatter<DateTimeOffset>
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
            return 24;
        }

        public override int Serialize(ref byte[] bytes, int offset, DateTimeOffset value)
        {
            BinaryUtil.WriteDateTime(ref bytes, offset, new DateTime(value.Ticks, DateTimeKind.Utc)); // current ticks as is.
            BinaryUtil.WriteTimeSpan(ref bytes, offset + 12, value.Offset);
            return 24;
        }

        public override DateTimeOffset Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 24;
            var dateTime = BinaryUtil.ReadDateTime(ref bytes, offset);
            var dateOffset = BinaryUtil.ReadTimeSpan(ref bytes, offset + 12);
            return new DateTimeOffset(dateTime.Ticks, dateOffset);
        }
    }

    internal class NullableDateTimeOffsetFormatter : Formatter<DateTimeOffset?>
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
            return 25;
        }

        public override int Serialize(ref byte[] bytes, int offset, DateTimeOffset? value)
        {
            BinaryUtil.EnsureCapacity(ref bytes, offset, 13);
            if (value.HasValue)
            {
                BinaryUtil.WriteBooleanTrueUnsafe(ref bytes, offset);
                BinaryUtil.WriteDateTime(ref bytes, offset + 1, new DateTime(value.Value.Ticks, DateTimeKind.Utc)); // current ticks as is.
                BinaryUtil.WriteTimeSpan(ref bytes, offset + 13, value.Value.Offset);
            }
            else
            {
                BinaryUtil.WriteBooleanFalseUnsafe(ref bytes, offset);
            }

            return 25;
        }

        public override DateTimeOffset? Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 25;

            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return default(DateTimeOffset?);

            var dateTime = BinaryUtil.ReadDateTime(ref bytes, offset + 1);
            var dateOffset = BinaryUtil.ReadTimeSpan(ref bytes, offset + 13);
            return new DateTimeOffset(dateTime.Ticks, dateOffset);
        }
    }
}
