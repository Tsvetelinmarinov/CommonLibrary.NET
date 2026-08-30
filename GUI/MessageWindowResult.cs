namespace CommonLibrary.NET.GUI
{
    /// <summary>
    /// Specifies the returned result from the MessageBoxW() C function.
    /// </summary>
    public enum MessageWindowResult : int
    {
        ResultOK     =  1, // Button OK is pressed.
        ResultCancel =  2, // Button No is pressed.
        ResultAbort  =  3, // Exit window button is pressed.
        ResultRetry  =  4, // Retry operation.
        ResultIgnore =  5, // Ignore operation.
        ResultYes    =  6, // Button Yes is pressed.
        ResultNo     =  7, // Button No is pressed.
    }
}
