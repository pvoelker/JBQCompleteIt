using System.Text;

namespace JBQCompleteIt
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void CompleteIt_Clicked(object sender, EventArgs e)
        {
            var context = BindingContext as ViewModel.MainPage;

            if (context != null)
            {
                var errors = context.GetErrors();

                if (errors.Any())
                {
                    await DisplayAlert("Cannot Start Quizzing", string.Join(Environment.NewLine, errors.DistinctBy(x => x.ErrorMessage).Select(x => $"• {x.ErrorMessage}")), "OK");
                }
                else
                {
                    await Navigation.PushAsync(new QuizPage(context.StartQuestionNumber, context.EndQuestionNumber, context.Difficulty, context.EnableHints));
                }
            }
            else
            {
                throw new NullReferenceException("Context cannot be null");
            }
        }

        private async void InfoButton_Clicked(object sender, EventArgs e)
        {
            var context = BindingContext as JBQCompleteIt.ViewModel.MainPage;

            if (context != null)
            {
                var builder = new StringBuilder();
                builder.AppendLine("JBQ Complete It!");
                if (context.Copyright != null)
                {
                    builder.AppendLine(context.Copyright);
                }
                builder.AppendLine("MIT License");
                if (context.Version != null)
                {
                    builder.AppendLine($"Version: {context.Version}");
                }

                builder.AppendLine(string.Empty);
                builder.AppendLine("• Questions are based on 20 point questions from the NLT (2021) Bible Fact-Pak™ (https://biblefactpak.com/)");
                builder.AppendLine("• Questions are sourced from the New Living Translation (NLT) version of the Bible");
                builder.AppendLine("• Designed and developed by Paul Voelker of Faith Chapel - Overland Park");

                // PEV - 8/25/2023 - Limiting the amount of text due to an issue in MacOS (Catalyst): https://github.com/dotnet/maui/issues/11766
                if (DeviceInfo.Current.Platform != DevicePlatform.MacCatalyst)
                {
                    builder.AppendLine("• Given to the glory of God");
                }

                await DisplayAlert("About Game", builder.ToString(), "OK");
            }
            else
            {
                throw new NullReferenceException("Context cannot be null");
            }
        }
    }
}