namespace CommonLibrary.GUI
{
    /// <summary>
    ///  Specifies the type of the <see cref="MessageWindow"/>.
    /// </summary>
    public enum MessageWindowType : uint
    {
        // Buttons
        WithButtonsYesNoCancel =  0x00000003U,
        WithButtonsYesNo       =  0x00000004U,
        WithButtonOK           =  0x00000000U,

        // Icons
        WithQuestionMark =  0x00000020U,
        WithWarningIcon  =  0x00000030U,
        WithErrorIcon    =  0x00000010U,
        WithInfoIcon     =  0x00000040U,

        // Combined complete interface variants ==>

//=> CA1069: Enums values should not be duplicated.
//=> ? Why ? I want them to be like that, so ...
#pragma warning disable CA1069

        // Button OK with four different icons.
        WithButtonOKAndQuestionMark = WithButtonOK  | WithQuestionMark,    // Question mark
        WithButtonOKAndWarningIcon  = WithButtonOK  |  WithWarningIcon,   // Warning icon
        WithButtonOKAndErrorIcon    = WithButtonOK  |    WithErrorIcon, // Error icon
        WithButtonOKAndInfoIcon     = WithButtonOK  |    WithInfoIcon, // Information icon
#pragma warning restore CA1069

        // Buttons Yes and No with four different icons.
        WithButtonsYesNoAndQuestionMark = WithButtonsYesNo  | WithQuestionMark,
        WithButtonsYesNoAndWarningIcon  = WithButtonsYesNo  |  WithWarningIcon,
        WithButtonsYesNoAndErrorIcon    = WithButtonsYesNo  |    WithErrorIcon,
        WithButtonsYesNoAndInfoIcon     = WithButtonsYesNo  |     WithInfoIcon,

        // Buttons Yes, No and Cancel with four different icons.
        WithButtonsYesNoCancelAndInfoIcon     = WithButtonsYesNoCancel  |     WithInfoIcon,
        WithButtonsYesNoCancelAndWarningIcon  = WithButtonsYesNoCancel  |  WithWarningIcon,
        WithButtonsYesNoCancelAndQuestionMark = WithButtonsYesNoCancel  | WithQuestionMark,
        WithButtonsYesNoCancelAndErrorIcon    = WithButtonsYesNoCancel  |    WithErrorIcon,
    }
}