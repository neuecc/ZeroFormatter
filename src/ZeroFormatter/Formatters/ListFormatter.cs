using System.Collections.Generic;
using System.Linq;
using ZeroFormatter.Internal;
using ZeroFormatter.Segments;

namespace ZeroFormatter.Formatters
{
    // Layout: FixedSize -> [count:int][t format...] -> if count = -1 is null
    // Layout: VariableSize -> [int byteSize][count:int][elementOffset:int...][t format...] -> if byteSize = -1 is null
    [Preserve(AllMembers = true)]
    internal class ListFormatter<TTypeResolver, T> : Formatter<TTypeResolver, IList<T>>
        where TTypeResolver : ITypeResolver, new()
    {
        readonly Formatter<TTypeResolver, T> formatter;

        [Preserve]
        public ListFormatter()
        {
            this.formatter = Formatter<TTypeResolver, T>.Default;
        }

        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, IList<T> value)
        {
            if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }

            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }

            var length = formatter.GetLength();
            if (length != null)
            {
                // FixedSize Array
                var writeSize = value.Count * length.Value + 4;
                if (bytes == null)
                {
                    bytes = new byte[writeSize];
                }

                offset += BinaryUtil.WriteInt32(ref bytes, offset, value.Count);

                // Optimize iteration
                var array = value as T[];
                if (array != null)
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        offset += formatter.Serialize(ref bytes, offset, array[i]);
                    }
                }
                else
                {
                    var list = value as List<T>;
                    if (list != null)
                    {
                        for (int i = 0; i < list.Count; i++)
                        {
                            offset += formatter.Serialize(ref bytes, offset, list[i]);
                        }
                    }
                    else
                    {
                        foreach (var item in value)
                        {
                            offset += formatter.Serialize(ref bytes, offset, item);
                        }
                    }
                }

                return writeSize;
            }
            else
            {
                var startoffset = offset;
                var indexStartOffset = startoffset + 8;
                offset = (startoffset + 8) + (value.Count * 4);

                // Optimize iteration
                var array = value as T[];
                if (array != null)
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        var size = formatter.Serialize(ref bytes, offset, array[i]);
                        BinaryUtil.WriteInt32Unsafe(ref bytes, indexStartOffset + i * 4, offset - startoffset);
                        offset += size;
                    }
                }
                else
                {
                    var list = value as List<T>;
                    if (list != null)
                    {
                        for (int i = 0; i < list.Count; i++)
                        {
                            var size = formatter.Serialize(ref bytes, offset, list[i]);
                            BinaryUtil.WriteInt32Unsafe(ref bytes, indexStartOffset + i * 4, offset - startoffset);
                            offset += size;
                        }
                    }
                    else
                    {
                        var count = 0;
                        foreach (var item in value)
                        {
                            var size = formatter.Serialize(ref bytes, offset, item);
                            BinaryUtil.WriteInt32Unsafe(ref bytes, indexStartOffset + count * 4, offset - startoffset);
                            offset += size;
                            count++;
                        }
                    }
                }

                BinaryUtil.WriteInt32(ref bytes, startoffset + 4, value.Count);

                var totalBytes = offset - startoffset;
                BinaryUtil.WriteInt32Unsafe(ref bytes, startoffset, totalBytes);

                return totalBytes;
            }
        }

        public override IList<T> Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            var length = formatter.GetLength();
            if (length != null)
            {
                return FixedListSegment<TTypeResolver, T>.Create(tracker, bytes, offset, out byteSize);
            }
            else
            {
                return VariableListSegment<TTypeResolver, T>.Create(tracker, bytes, offset, out byteSize);
            }
        }
    }

#if !UNITY

    [Preserve(AllMembers = true)]
    internal class ReadOnlyListFormatter<TTypeResolver, T> : Formatter<TTypeResolver, IReadOnlyList<T>>
        where TTypeResolver : ITypeResolver, new()
    {
        readonly Formatter<TTypeResolver, T> formatter;

        [Preserve]
        public ReadOnlyListFormatter()
        {
            this.formatter = Formatter<TTypeResolver, T>.Default;
        }

        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, IReadOnlyList<T> value)
        {
            if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }

            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }

            var length = formatter.GetLength();
            if (length != null)
            {
                // FixedSize Array
                var writeSize = value.Count * length.Value + 4;
                if (bytes == null)
                {
                    bytes = new byte[writeSize];
                }

                offset += BinaryUtil.WriteInt32(ref bytes, offset, value.Count);

                // Optimize iteration
                var array = value as T[];
                if (array != null)
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        offset += formatter.Serialize(ref bytes, offset, array[i]);
                    }
                }
                else
                {
                    var list = value as List<T>;
                    if (list != null)
                    {
                        for (int i = 0; i < list.Count; i++)
                        {
                            offset += formatter.Serialize(ref bytes, offset, list[i]);
                        }
                    }
                    else
                    {
                        foreach (var item in value)
                        {
                            offset += formatter.Serialize(ref bytes, offset, item);
                        }
                    }
                }

                return writeSize;
            }
            else
            {
                var startoffset = offset;
                var indexStartOffset = startoffset + 8;
                offset = (startoffset + 8) + (value.Count * 4);

                // Optimize iteration
                var array = value as T[];
                if (array != null)
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        var size = formatter.Serialize(ref bytes, offset, array[i]);
                        BinaryUtil.WriteInt32Unsafe(ref bytes, indexStartOffset + i * 4, offset - startoffset);
                        offset += size;
                    }
                }
                else
                {
                    var list = value as List<T>;
                    if (list != null)
                    {
                        for (int i = 0; i < list.Count; i++)
                        {
                            var size = formatter.Serialize(ref bytes, offset, list[i]);
                            BinaryUtil.WriteInt32Unsafe(ref bytes, indexStartOffset + i * 4, offset - startoffset);
                            offset += size;
                        }
                    }
                    else
                    {
                        var count = 0;
                        foreach (var item in value)
                        {
                            var size = formatter.Serialize(ref bytes, offset, item);
                            BinaryUtil.WriteInt32Unsafe(ref bytes, indexStartOffset + count * 4, offset - startoffset);
                            offset += size;
                            count++;
                        }
                    }
                }

                BinaryUtil.WriteInt32(ref bytes, startoffset + 4, value.Count);

                var totalBytes = offset - startoffset;
                BinaryUtil.WriteInt32Unsafe(ref bytes, startoffset, totalBytes);

                return totalBytes;
            }
        }

        public override IReadOnlyList<T> Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            var length = formatter.GetLength();
            if (length != null)
            {
                return FixedListSegment<TTypeResolver, T>.Create(tracker, bytes, offset, out byteSize);
            }
            else
            {
                return VariableListSegment<TTypeResolver, T>.Create(tracker, bytes, offset, out byteSize);
            }
        }
    }

#endif
}
