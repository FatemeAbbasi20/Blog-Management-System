using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CodeYad_Blog_CoreLayer.Utilities
{
    public static class TextHelper
    {
        public static string ToSlug(this string Value)
        {
            return Value.Trim().ToLower()
                .Replace("~", "")
                .Replace("@", "")
                .Replace("#", "")
                .Replace("$", "")
                .Replace("%", "")
                 .Replace("^", "")
                  .Replace("&", "")
                   .Replace("*", "")
                    .Replace("(", "")
                     .Replace(")", "")
                      .Replace(" ", "-")
                       .Replace("_", "")
                        .Replace(">", "")
                         .Replace("<", "")
                          .Replace("/", "")
                           .Replace(@"\", "")
                            .Replace("+", "");




        }

        public static string ConvertHtmlToText(this string text)
        {
            return Regex.Replace(text, "<.*?>", " ")
                .Replace(":&nbsp;", " ");
        }


    }
}
