using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace WikiHero.Helpers
{
    public class TraslationTriggerAction : TriggerAction<VisualElement>
    {
        public int XFrom { set; get; }
        public int YFrom { set; get; }
        public int ZFrom { set; get; }
        protected async  override void Invoke(VisualElement sender)
        {
            await sender.TranslateTo(XFrom, YFrom, 500, Easing.SpringOut);
            await sender.TranslateTo(-XFrom, YFrom, 500, Easing.SpringOut);
            await sender.TranslateTo(0, 0);
        }
    }
}
