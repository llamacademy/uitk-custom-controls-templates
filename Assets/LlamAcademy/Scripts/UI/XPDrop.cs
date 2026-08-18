using UnityEngine;
using UnityEngine.UIElements;

namespace LlamAcademy.UI
{
    [UxmlElement]
    public partial class XPDrop : VisualElement
    {
        private VisualElement Icon;
        private Label Label;

        public XPDrop()
        {
            VisualTreeAsset template = Resources.Load<VisualTreeAsset>("UI/Components/XPDrop");
            template.CloneTree(this);

            Icon = this.Q("icon");
            Label = this.Q<Label>();
            schedule.Execute(RemoveFromHierarchy).ExecuteLater(2_500);
        }

        public void SetAmount(int amount)
        {
            Label.SetText(amount.ToString("N0"));
        }
    }
}