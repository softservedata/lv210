using ArtOfTest.WebAii.Controls.HtmlControls;
using ArtOfTest.WebAii.ObjectModel;

namespace Wow.ModalWindow
{
    interface IModalWindow
    {
        Element ModalTitle { get; set; }
        Element ModalBodyMessage { get; set; }
        HtmlButton Button { get; set; }

        string GetModalTitle();

        string GetModalBodyMessage();

        void ClickModalButton(string buttonText);
    }
}
