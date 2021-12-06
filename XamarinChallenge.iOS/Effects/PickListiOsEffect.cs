using System;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamarinChallenge.Controls;

[assembly: ResolutionGroupName("CharterCommunications")]  
[assembly: ExportEffect(typeof(XamarinChallenge.iOS.Effects.PickListiOsEffect), nameof(PickListEffect))]  
namespace XamarinChallenge.iOS.Effects
{
    public class PickListiOsEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            if (this.Control != null)
            {
                var textField = (UITextField)this.Control;
                textField.BorderStyle = UITextBorderStyle.None;
            }
        }

        protected override void OnDetached()
        {
            throw new NotImplementedException();
        }
    }
}
