using System;
using System.Linq;
using Xamarin.Forms;

namespace XamarinChallenge.Behaviors
{
    public class SearchEntryBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(entry);
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(entry);
        }

        void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            bool isValid = args.NewTextValue.All(x => char.IsDigit(x) || char.IsLetter(x) || char.IsWhiteSpace(x));
            ((Entry)sender).TextColor = isValid ? Color.Default : Color.Red;
        }
    }
}
