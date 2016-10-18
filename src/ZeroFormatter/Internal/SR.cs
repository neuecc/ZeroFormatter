namespace ZeroFormatter.Internal
{
    internal static class SR
    {
        public const string InvalidOperation_EnumFailedVersion = "InvalidOperation_EnumFailedVersion";
        public const string InvalidOperation_EnumOpCantHappen = "InvalidOperation_EnumOpCantHappen";
        public const string ArgumentOutOfRange_Index = "ArgumentOutOfRange_Index";
        public const string Argument_InvalidArrayType = "Argument_InvalidArrayType";
        public const string NotSupported_ValueCollectionSet = "NotSupported_ValueCollectionSet";
        public const string Arg_RankMultiDimNotSupported = "Arg_RankMultiDimNotSupported";
        public const string Arg_ArrayPlusOffTooSmall = "Arg_ArrayPlusOffTooSmall";
        public const string Arg_NonZeroLowerBound = "Arg_NonZeroLowerBound";
        public const string NotSupported_KeyCollectionSet = "NotSupported_KeyCollectionSet";
        public const string Arg_WrongType = "Arg_WrongType";
        public const string ArgumentOutOfRange_NeedNonNegNum = "ArgumentOutOfRange_NeedNonNegNum";
        public const string Arg_HTCapacityOverflow = "Arg_HTCapacityOverflow";
        public const string Argument_AddingDuplicate = "Argument_AddingDuplicate";

        public static string Format(string f, params object[] args)
        {
            return string.Format(f, args);
        }
    }
}