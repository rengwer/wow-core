using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.TagHelpers
{
    [HtmlTargetElement(BattleNetIconElementName, Attributes = "icon-name, icon-size")]
    public class BattleNetIcon : TagHelper
    {
        private const string BattleNetIconElementName = "bn-icon";
        private const string BattleNetIconNameAttributeName = "icon-name";
        private const string BattleNetIconSizeAttributeName = "icon-size";
        private static readonly List<int> ValidIconSizes = new List<int>{ 18, 36, 56 };

        [HtmlAttributeName(BattleNetIconNameAttributeName)]
        public string IconName { get; set; }

        [HtmlAttributeName(BattleNetIconSizeAttributeName)]
        public int IconSize { get; set; } = 18;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (!ValidIconSizes.Contains(IconSize))
                throw new Exception(
                    $"{BattleNetIconSizeAttributeName} is not valid. Options include {String.Join(", ", ValidIconSizes)}");

            var url = $"https://us.media.blizzard.com/wow/icons/{IconSize}/{IconName}.jpg";
            output.Content.SetHtmlContent($"<img src='{url}' asp-append-version='true'></img>");

            base.Process(context, output);
        }
    }
}
