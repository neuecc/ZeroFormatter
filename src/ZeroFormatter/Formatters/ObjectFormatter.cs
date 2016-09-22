using System;
using System.Reflection;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZeroFormatter.Internal;

namespace ZeroFormatter.Formatters
{
    internal delegate int PropertySerializer<T>(T self, ref byte[] bytes, int offset);
    internal delegate void PropertyDeserializer<T>(T self, ref byte[] bytes, int offset);

    // Layout: [index table...][t format...]

    // TODO:No, this is Serialize/Deserialize. not ZeroDeserialize!

    internal class ObjectFormatHelper<T>
        where T : class, new()
    {
        PropertySerializer<T>[] serializers;
        PropertyDeserializer<T>[] deserializers;
        int lastIndex;

        public ObjectFormatHelper()
        {
            var type = typeof(T);

            var zeroFormattable = type.GetCustomAttributes(typeof(ZeroFormattableAttribute), true).Any();

            var props = typeof(T).GetProperties();


            // TODO:Runtime Verify
            // TODO:Generate Serializer/Deserializer
        }


        public TProperty GetProperty<TProperty>(ref byte[] bytes, int offset, int index)
        {
            var startOffset = BinaryUtil.ReadInt32(ref bytes, offset + (index * 4));
            return Formatter<TProperty>.Default.Deserialize(ref bytes, startOffset);
        }

        // SetProperty?
        //public TProperty GetProperty<TProperty>(ref byte[] bytes, int offset, int index)
        //{
        //    var startOffset = BinaryUtil.ReadInt32(ref bytes, offset + (index * 4));
        //    return Formatter<TProperty>.Default.Deserialize(ref bytes, startOffset);
        //}


        /*
        public override int Serialize(ref byte[] bytes, int offset, T value)
        {
            var startOffset = offset + (lastIndex * 4);
            BinaryUtil.EnsureCapacity(ref bytes, offset, startOffset);

            int totalLength = 0;
            for (int i = 0; i < lastIndex; i++)
            {
                var length = serializers[i](value, ref bytes, startOffset); // write element
                BinaryUtil.WriteInt32(ref bytes, offset + (i * 4), length); // write header
                startOffset += length;
                totalLength += length;
            }

            return totalLength;
        }

        public override T Deserialize(ref byte[] bytes, int offset)
        {
            var self = new T();

            for (int i = 0; i < lastIndex; i++)
            {
                var readOffset = BinaryUtil.ReadInt32(ref bytes, offset + (i * 4));
                var deserializer = deserializers[i];
                deserializer(self, ref bytes, readOffset);
            }

            return self;
        }
        */
    }
}
