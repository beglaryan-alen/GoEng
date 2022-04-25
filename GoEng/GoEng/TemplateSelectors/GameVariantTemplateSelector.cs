using GoEng.ViewModels.Home.GameVariantDetails;
using Xamarin.Forms;

namespace GoEng.TemplateSelectors
{
    public class GameVariantTemplateSelector : DataTemplateSelector
    {
        public DataTemplate AnimalTemplate { get; set; }
        public DataTemplate QuestionTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container) =>
            item switch
            {
                AnimalTabViewModel => AnimalTemplate,
                QuestionTabViewModel => QuestionTemplate,
                _ => throw new System.NotImplementedException(),
            };
    }
}
