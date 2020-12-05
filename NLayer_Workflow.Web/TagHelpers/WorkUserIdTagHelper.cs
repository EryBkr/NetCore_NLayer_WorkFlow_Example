using Microsoft.AspNetCore.Razor.TagHelpers;
using NLayer_Workflow.Bussiness.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayer_Workflow.Web.TagHelpers
{
    [HtmlTargetElement("getWorksAppUserId")]
    public class WorkUserIdTagHelper:TagHelper
    {

        private readonly IWorkService workService;

        public WorkUserIdTagHelper(IWorkService workService)
        {
            this.workService = workService;
        }

        public int UserId { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var works = workService.GetWithUser(UserId);
            var endedWorksCount=works.Where(i => i.Status).Count();
            var countiuedWorksCount= works.Where(i => !i.Status).Count();

            string htmlString = $"<strong>Tamamladığı görev sayısı: {endedWorksCount}</strong><br><strong>Devam eden görev sayısı: {countiuedWorksCount}</strong>";
            output.Content.SetHtmlContent(htmlString);
        }
    }
}
