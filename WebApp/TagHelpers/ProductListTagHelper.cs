using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Routing;
using System;
using System.Text;
using WebApp.Models;
using WebApp.Models.ViewModels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebApp.Taghelpers
{
    public class ProductListTagHelper : TagHelper
    {

        public List<ProductViewModel> Products { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var htmlStringBuilder = new StringBuilder();
            var tableHtml = string.Empty;
            output.TagName = "div"; //<div></div>
            htmlStringBuilder.Append(@$"<table class='table table-striped'>
            <thead>
                    <tr>
                        <th>Id</th>
                        <th>İsim</th>
                        <th>Fiyat</th>
                        <th>Renk</th>
                        <th>Yayın durumu</th>
                        <th>Kategori</th>
                        <th></th>
                    </tr>
            </thead>
            <tbody>");

            foreach (var item in Products)
            {

                var row = $@"<tr>
                                <td>{item.Id}</td>
                                <td>{item.Name}</td>
                                <td>{item.Price}</td>
                                <td>{item.Color}</td>
                                <td>{item.IsPublish}</td>
                                <td>{item.Category?.Name}</td>
                            </tr>";
                htmlStringBuilder.Append(row);
            }
            htmlStringBuilder.Append("</tbody></table>");
            output.Content.SetHtmlContent(htmlStringBuilder.ToString());

        }
    }
}