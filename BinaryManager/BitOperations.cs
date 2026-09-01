using System.Numerics;
using System.Runtime.CompilerServices;

namespace CommonLibrary.BinaryManager
{
    /// <summary>
    ///  Provides set of static methods for manipulating the bits of an number.
    /// </summary>
    public static class BitOperations
    {
        /// <summary>
        ///  Changes the bit at the specified position in the specified number with 
        ///  the specified value(0 or 1).
        /// </summary>
        /// <typeparam name="TNumber">
        ///   The data type of the number. Must be integer type.
        /// </typeparam>
        /// <param name="number">
        ///  The number.
        /// </param>
        /// <param name="position">
        ///  The position of the bit to change.
        /// </param>
        /// <param name="bitState">
        ///  The state of the bit. 
        ///  Flag <see cref="BitState.TunrOn"/> of the enumeration
        ///  <see cref="BitState"/> specifies that the bit should receive value 1.
        ///  Flag <see cref="BitState.TunrOff"/> of the enumeration
        ///  <see cref="BitState"/> specifies that the bit should receive value 0.
        ///  Flag <see cref="BitState.Switch"/> of the enumeration
        ///  <see cref="BitState"/> specifies that the bit should switch his value.
        /// </param>
        /// <returns>
        ///  The new number after the bit manipulating.
        /// </returns>
        [MethodImpl(MethodImplOptions.PreserveSig)]
        public static TNumber ChangeBitAt<TNumber>(TNumber number, uint position, BitState bitState)
            where TNumber :
               IBitwiseOperators<TNumber, int, TNumber>,
               INumber<TNumber>
        {
            /* 
            * |----------------------------- Bit manipulation example -----------------------------|
            * 
            * Changing a bit at specified position is possible when we make mask(number) with 1 at that position
            * where we want to change the bit in the other number. All other bits of the mask are 0.
            * 
            * The tree different bitwise operations works as follows:
            *  Bitwise OR(|)  - Used to turn a bit on.
            *  Bitwise AND(&) - Used to turn a bit off.
            *  Bitwise XOR(^) - Used to switch the state of a bit.
            *  
            * Complete explanation bellow -->
            * 
            * Changing bit N to 1:
            *  N = 2
            *  00001001 ==> Changing the third bit(current is 0) to 1:
            *      00001001 
            *              | -> Bitwise OR operation.
            *      00000100  -> (1 << N(2)) - That will change the third bit to 1(if its zero) and will left
            *                   others not changed, because the operation is OR(|).
            *                              
            *      00001101 -> In the result the third bit now is 1, because OR(|) operation will return true(1 here)
            *                  only if one of both bits(of the number and the mask) are with value 1 or 0 or both are 1.
            *                  
            * Changing bit N to 0:
            *  N = 3
            *      00001001 => Changing the fourth bit to 0(current is 1).
            *          00001001
            *                  & -> Bitwise AND operation.
            *          11110111  -> ~(1 << N(3)) - Inverted mask, so all the bits will remain same
            *                       except that one that is at that place when is the 0
            *                       in the mask. That bit will accept value 0, because operation
            *                       AND(&) returns true(1 here) only if both 
            *                       bits(of the number and of the mask) are with value 1.
            *                                      
            *          00000001  -> The bit of position 3(right - left) is now 0(previously was 1).
            *          
            * Switching bit N - if 0 -> 1 and if 1 -> 0:
            *  N = 1
            *      00000101 => Switching the second bit(current is 0).
            *          00000101
            *                  ^ -> Bitwise XOR operation.
            *          00000010  -> (1 << N(1)) - That with switch the state of the second bit, because
            *                       operation XOR(^) return true only if both bits(of the number and the mask)
            *                       are with different values(0 or 1). If they both are 0 or 1 will return false(0 here).
            *          00000111  -> The second bit now is 1.
            *      
            *          00000111 => Switching again the second bit to turn it back to 0.
            *                  ^
            *          00000010
            *          00000101  -> The second bit again is 0.
            */
            if (bitState is BitState.TurnOn)
            {
                return number | (1 << (int)position);
            }
            else if (bitState is BitState.TurnOff)
            {
                return number & ~(1 << (int)position);
            }
            else //=> Only BitState.Switch left so ...
            {
                return number ^ (1 << (int)position);
            }
        }

        /// <summary>
        ///  Check if the bit at the specified position in the number is active.
        /// </summary>
        /// <typeparam name="TNumber">
        ///  The data type of the number.
        /// </typeparam>
        /// <param name="number">
        ///  The number.
        /// </param>
        /// <param name="position">
        ///  The position of the bit to change.
        /// <returns>
        ///  True if the bit is 1, otherwise False.
        /// </returns>
        [MethodImpl(MethodImplOptions.PreserveSig)]
        public static bool IsActiveBit<TNumber>(TNumber number, uint position)
            where TNumber : 
               IBitwiseOperators<TNumber, int, TNumber>,
               INumber<TNumber>
        {
            // The AND(&) operation will return true(1 here) only if
            // both bits(of the number and the mask) are with value 1.
            // If the bit at that position in the number where is 1 in the mask is 0,
            // AND(&) returns false.
            // So if the bit at the specified position is 1 then the result will be some value 1 - 255.
            // If the bit at the specified position is 0 then the result will be 0, because the mask has 1 only at
            // the specified position and will make all the other bits go 0 too,
            // so the result will be eight zeros -> 00000000 = 0.
            return (number & (1 << (int)position)) is not 0;                                                 
        }
    }
}