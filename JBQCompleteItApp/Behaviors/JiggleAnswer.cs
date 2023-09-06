using CommunityToolkit.Mvvm.Input;
using System;

namespace JBQCompleteIt.Behaviors
{
    public class JiggleAnswer : Behavior<BalloonButton>
    {
        protected override void OnAttachedTo(BalloonButton control)
        {
            control.BindingContextChanged += Control_BindingContextChanged;

            base.OnAttachedTo(control);
        }

        protected override void OnDetachingFrom(BalloonButton control)
        {
            control.BindingContextChanged -= Control_BindingContextChanged;

            base.OnDetachingFrom(control);
        }

        private void Control_BindingContextChanged(object sender, EventArgs e)
        {
            var control = sender as BalloonButton;

            if (control != null)
            {
                var context = control.BindingContext as ViewModel.AnswerSegment;

                if (context != null)
                {
                    context.ShowHint = new AsyncRelayCommand(async () =>
                    {
                        await control.ScaleTo(1.1, 50);
                        for (int i = 0; i < 4; i++)
                        {
                            await control.RotateTo(5, 50);
                            await control.RotateTo(-5, 50);
                        }
                        await control.RotateTo(0);
                        await control.ScaleTo(1, 50);
                    });
                }
            }
        }
    }
}
