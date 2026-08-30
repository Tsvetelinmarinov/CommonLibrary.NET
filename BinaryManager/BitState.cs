namespace CommonLibrary.NET.BinaryManager
{
    /// <summary>
    ///  Describes the two possible states of a bit - 0(turned off) and 1(turned on).
    ///  That enumeration specifies the bit state in the methods of <see cref="BitOperations"/> class.
    /// </summary>
    public enum BitState
    {
        /// <summary>
        ///  Specifies that the bit should be turned off.
        /// </summary>
        TurnOff = 0,
        
        /// <summary>
        ///  Specifies that the bit should be turned on.
        /// </summary>
        TurnOn = 1,

        /// <summary>
        ///  Specifies that the bit should be switched -> if is 1 to 0 and if is 0 to 1.
        /// </summary>
        Switch = 2
    }
}