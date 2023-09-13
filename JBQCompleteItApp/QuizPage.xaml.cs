using JBQCompleteIt.ViewModel;

namespace JBQCompleteIt;

public partial class QuizPage : ContentPage
{
	public QuizPage(int? startQuestionNumber, int? endQuestionNumber, DifficultyEnum difficulty, bool enableHints)
	{
		InitializeComponent();

        var context = BindingContext as ViewModel.QuizPage;

        if (context != null)
        {
            context.StartQuestionNumber = startQuestionNumber;
            context.EndQuestionNumber = endQuestionNumber;
            context.Difficulty = difficulty;
            context.EnableHints = enableHints;

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            context.InitializeAsync();
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
        }
        else
        {
            throw new NullReferenceException("Context cannot be null");
        }
    }

    // PEV - 9/4/2023 - At this time I can't get 'EventToCommandBehavior' to work, so I am using this to convert the event to a command
    private void SKLottieView_AnimationCompleted(object sender, EventArgs e)
    {
        var context = BindingContext as JBQCompleteIt.ViewModel.QuizPage;

        if (context != null)
        {
            if (context.AnimationComplete != null)
            {
                context.AnimationComplete.Execute(this);
            }
        }
        else
        {
            throw new NullReferenceException("Context cannot be null");
        }
    }
}