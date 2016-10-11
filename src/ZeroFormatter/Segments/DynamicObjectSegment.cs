using System;
using System.Reflection;
using System.Reflection.Emit;
using ZeroFormatter.Internal;

namespace ZeroFormatter.Segments
{
    // ObjectSegment is inherit to target class directly or generate.

    // Layout: [int byteSize][indexOffset:int...][t format...]

    public static class ObjectSegmentHelper
    {
        public static int GetByteSize(ArraySegment<byte> originalBytes)
        {
            var array = originalBytes.Array;
            return BinaryUtil.ReadInt32(ref array, originalBytes.Offset);
        }

        public static int GetOffset(ArraySegment<byte> originalBytes, int index)
        {
            var array = originalBytes.Array;
            return BinaryUtil.ReadInt32(ref array, originalBytes.Offset + 4 + 4 * index);
        }

        public static int SerializeFixedLength<T>(ref byte[] targetBytes, int offset, ArraySegment<byte> originalBytes, int index)
        {
            var formatter = global::ZeroFormatter.Formatters.Formatter<T>.Default;
            var len = formatter.GetLength();
            BinaryUtil.EnsureCapacity(ref targetBytes, offset, len.Value);
            Buffer.BlockCopy(originalBytes.Array, GetOffset(originalBytes, index), targetBytes, offset, len.Value);
            return len.Value;
        }

        public static int SerializeSegment<T>(ref byte[] targetBytes, int offset, IZeroFormatterSegment segment)
        {
            return segment.Serialize(ref targetBytes, offset);
        }
    }

    public static class DynamicObjectSegmentBuilder<T>
    {
        const string ModuleName = "ZeroFormatter.Segments.DynamicObjectSegment";

        public static Type Build()
        {
            // TODO:Verify
            // VerifyInterface(typeof(T));

            var assemblyName = new AssemblyName(ModuleName);
            var assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
            var moduleBuilder = assemblyBuilder.DefineDynamicModule(ModuleName);
            var generatedType = GenerateObjectSegmentImplementation(moduleBuilder);

            return generatedType;
        }

        static Type GenerateObjectSegmentImplementation(ModuleBuilder moduleBuilder)
        {
            // public class DynamicObjectSegment.MyClass : MyClass, IZeroFormatterSegment
            var type = moduleBuilder.DefineType(
                ModuleName + "." + typeof(T).Name,
                TypeAttributes.Public,
                typeof(T));
            // TODO:Impl Interface
            //new[] { typeof(IZeroFormatterSegment) });

            var originalBytes = type.DefineField("<>_originalBytes", typeof(ArraySegment<byte>), FieldAttributes.Private | FieldAttributes.InitOnly);
            var tracker = type.DefineField("<>_tracker", typeof(DirtyTracker), FieldAttributes.Private | FieldAttributes.InitOnly);

            // TODO:XxxSegment...

            BuildConstructor(type, originalBytes, tracker);

            // BuildProperties
            // BuildZeroFormatterSegmentMethods

            //foreach (var method in GetAllInterfaceMethods(typeof(T)))
            //{
            //    BuildMethod(type, method, contextField, targetPeerField);
            //}

            return type.CreateType();
        }

        static readonly MethodInfo ArraySegmentArrayGet = typeof(ArraySegment<byte>).GetProperty("Array").GetGetMethod();
        static readonly MethodInfo CreateChild = typeof(DirtyTracker).GetMethod("CreateChild");

        static void BuildConstructor(TypeBuilder type, FieldInfo originalBytesField, FieldInfo trackerField)
        {
            var method = type.DefineMethod(".ctor", System.Reflection.MethodAttributes.Public | System.Reflection.MethodAttributes.HideBySig);

            var baseCtor = typeof(T).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic,
                null, new Type[] { }, null);

            method.SetReturnType(typeof(void));
            method.SetParameters(typeof(DirtyTracker), typeof(ArraySegment<byte>));

            var generator = method.GetILGenerator();

            generator.DeclareLocal(typeof(byte[]));

            // ctor
            generator.Emit(OpCodes.Ldarg_0);
            generator.Emit(OpCodes.Call, baseCtor);

            // Local Var( var __array = originalBytes.Array; )
            generator.Emit(OpCodes.Ldarga_S, (byte)2);
            generator.Emit(OpCodes.Call, ArraySegmentArrayGet);
            generator.Emit(OpCodes.Stloc_0);

            // Assign Field Common
            generator.Emit(OpCodes.Ldarg_0);
            generator.Emit(OpCodes.Ldarg_2);
            generator.Emit(OpCodes.Stfld, originalBytesField);
            generator.Emit(OpCodes.Ldarg_0);
            generator.Emit(OpCodes.Ldarg_1);
            generator.Emit(OpCodes.Callvirt, CreateChild);
            generator.Emit(OpCodes.Dup);
            generator.Emit(OpCodes.Starg_S, (byte)1);
            generator.Emit(OpCodes.Stfld, trackerField);

            // Assign Field MutableSegments
            // TODO:...

            generator.Emit(OpCodes.Ret);
        }

        //static void BuildMethod(TypeBuilder type, MethodInfo interfaceMethodInfo, FieldInfo contextField, FieldInfo targetPeerField)
        //{
        //    MethodAttributes methodAttributes =
        //          MethodAttributes.Public
        //        | MethodAttributes.Virtual
        //        | MethodAttributes.Final
        //        | MethodAttributes.HideBySig
        //        | MethodAttributes.NewSlot;

        //    ParameterInfo[] parameters = interfaceMethodInfo.GetParameters();
        //    Type[] paramTypes = parameters.Select(param => param.ParameterType).ToArray();

        //    MethodBuilder methodBuilder = type.DefineMethod(interfaceMethodInfo.Name, methodAttributes);

        //    // void BroadcastEvent(IEnumerable<IPhotonWirePeer> targetPeers, byte eventCode, params object[] args);
        //    MethodInfo invokeMethod = typeof(HubContext).GetMethod(
        //        "BroadcastEvent", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null,
        //        new Type[] { typeof(IEnumerable<IPhotonWirePeer>), typeof(byte), typeof(object[]) }, null);

        //    methodBuilder.SetReturnType(interfaceMethodInfo.ReturnType);
        //    methodBuilder.SetParameters(paramTypes);

        //    ILGenerator generator = methodBuilder.GetILGenerator();

        //    generator.DeclareLocal(typeof(object[]));

        //    // Get Context and peer
        //    generator.Emit(OpCodes.Ldarg_0);
        //    generator.Emit(OpCodes.Ldfld, contextField); // context
        //    generator.Emit(OpCodes.Ldarg_0);
        //    generator.Emit(OpCodes.Ldfld, targetPeerField); // peer

        //    // OpCode
        //    var opCode = interfaceMethodInfo.GetCustomAttribute<OperationAttribute>().OperationCode;
        //    generator.Emit(OpCodes.Ldc_I4, (int)opCode);

        //    // new[]{ }
        //    generator.Emit(OpCodes.Ldc_I4, parameters.Length);
        //    generator.Emit(OpCodes.Newarr, typeof(object));
        //    generator.Emit(OpCodes.Stloc_0);

        //    // object[]
        //    for (int i = 0; i < paramTypes.Length; i++)
        //    {
        //        generator.Emit(OpCodes.Ldloc_0);
        //        generator.Emit(OpCodes.Ldc_I4, i);
        //        generator.Emit(OpCodes.Ldarg, i + 1);
        //        generator.Emit(OpCodes.Box, paramTypes[i]);
        //        generator.Emit(OpCodes.Stelem_Ref);
        //    }

        //    // Call BroadcastEvent
        //    generator.Emit(OpCodes.Ldloc_0);
        //    generator.Emit(OpCodes.Callvirt, invokeMethod);

        //    generator.Emit(OpCodes.Ret);
        //}

        //// Verify

        //// TODO:No Interface
        //static void VerifyInterface(Type interfaceType)
        //{
        //    if (!interfaceType.IsInterface)
        //    {
        //        throw new InvalidOperationException($"Hub<T>'s T must be interface : {interfaceType.Name}");
        //    }

        //    if (interfaceType.GetProperties().Length != 0)
        //    {
        //        throw new InvalidOperationException($"Client proxy type must not contains properties : {interfaceType.Name}");
        //    }

        //    if (interfaceType.GetEvents().Length != 0)
        //    {
        //        throw new InvalidOperationException($"Client proxy type must not contains events : {interfaceType.Name}");
        //    }

        //    foreach (var method in interfaceType.GetMethods())
        //    {
        //        VerifyMethod(interfaceType, method);
        //    }

        //    foreach (var parent in interfaceType.GetInterfaces())
        //    {
        //        VerifyInterface(parent);
        //    }
        //}

        //static void VerifyMethod(Type interfaceType, MethodInfo interfaceMethod)
        //{
        //    if (interfaceMethod.ReturnType != typeof(void))
        //    {
        //        throw new InvalidOperationException($"Client proxy's method must return void : {interfaceType.Name}.{interfaceMethod.Name}");
        //    }

        //    if (interfaceMethod.GetCustomAttributes<OperationAttribute>().FirstOrDefault() == null)
        //    {
        //        throw new InvalidOperationException($"Client proxy's method must put OperationAttribute : {interfaceType.Name}.{interfaceMethod.Name}");
        //    }

        //    foreach (var parameter in interfaceMethod.GetParameters())
        //    {
        //        VerifyParameter(interfaceType, interfaceMethod, parameter);
        //    }
        //}

        //static void VerifyParameter(Type interfaceType, MethodInfo interfaceMethod, ParameterInfo parameter)
        //{
        //    if (parameter.IsOut)
        //    {
        //        throw new InvalidOperationException($"Client proxy's method must not take out parameter : {interfaceType.Name}.{interfaceMethod.Name}({parameter.Name})");
        //    }

        //    if (parameter.ParameterType.IsByRef)
        //    {
        //        throw new InvalidOperationException($"Client proxy's method must not take ref parameter : {interfaceType.Name}.{interfaceMethod.Name}({parameter.Name})");
        //    }
        //}
    }
}

