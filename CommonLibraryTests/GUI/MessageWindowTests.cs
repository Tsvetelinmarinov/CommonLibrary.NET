namespace CommonLibraryTests.GUI;

using CommonLibrary.NET.GUI;
using static CommonLibrary.NET.GUI.MessageWindow;

/// <summary>
///  Provides tests that test the MessageWindow functionality.
/// </summary>
[TestFixture]
public class MessageWindowTests
{

    [Test]
    public void Test_ShowMessageShowsDefaultMessageWhenMessageParamIsNull()
        => Assert.DoesNotThrowAsync(async () => ShowMessage(null!));

    [Test]
    public void Test_AskQuestionShowDefaultMessageWhenMessageParamIsNull()
        => Assert.DoesNotThrowAsync(async () => AskQuestion(null!));

    [Test]
    public void Test_ShowShowsDefaultMessageWhenMessageParamIsNull()
        => Assert.DoesNotThrowAsync(async () => Show(null!, null, null));

    [Test]
    public void Test_ShowReturnsResultYesWhenPressingYesButton()
    {
        Assert.That(
            Show( //=> You should press button Yes
                "Are you agree?", 
                "Simple question",
                MessageWindowType.WithButtonsYesNoAndQuestionMark
            ), 
            Is.EqualTo(MessageWindowResult.ResultYes)
        );
    }
}
