using GoEng.ViewModels.SignInDetails;
using System;
using Xamarin.Forms;

namespace GoEng.TemplateSelectors
{
    public class SignInDetailTemplateSelector : DataTemplateSelector
    {
        public DataTemplate LogInTemplate { get; set; }

        public DataTemplate RegisterTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container) =>
            item switch
            {
                LoginTabViewModel => LogInTemplate,
                RegisterTabViewModel => RegisterTemplate,
                _ => throw new Exception()
            };
    }
}
