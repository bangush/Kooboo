﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Kooboo.Model.Render.Vue
{
    public partial class LoadData
    {
        /// <summary>
        /// The model name which loaded data is assign to
        /// </summary>
        public string ModelName { get; set; }

        /// <summary>
        /// The api url load from
        /// </summary>
        public string Url { get; set; }
    }

    partial class LoadData
    {
        public const string Keyword_ApiGet = "api.get";
        public const string Keyword_ParameterBind = "ParameterBinder.bind";

        public class RootViewRenderer : IVueRenderer
        {
            public void Render(InnerJsBuilder builder, IEnumerable<object> items, VueJsBuilderOptions options)
            {
                builder.Created(b => RenderApiGets(b, items, options));
            }
        }

        public class SubViewRenderer : IVueRenderer
        {
            public const string Keyword_Show = "show";

            private Regex ParameterRegex = new Regex("\\{[^\\}]+\\}");

            public void Render(InnerJsBuilder builder, IEnumerable<object> items, VueJsBuilderOptions options)
            {
                builder.Methods(b =>
                {
                    var paraNames = items.Cast<LoadData>().SelectMany(o => o.Url.TrimStart('{').TrimEnd('}')).Distinct();
                    b.AppendLine($"{Keyword_Show}: function({String.Join(",", paraNames)})").Indent();

                    RenderApiGets(b, items, options);

                    b.AppendLine().Unindent().AppendLine("}");
                });
            }
        }

        public static void RenderApiGets(InnerJsBuilder builder, IEnumerable<object> items, VueJsBuilderOptions options)
        {
            builder.AppendLine("const vm = this");
            builder.AppendLine("var url = ''").AppendLine();
            int i = 0;
            foreach (LoadData item in items)
            {
                if (i > 0)
                {
                    builder.AppendLine().AppendLine();
                }

                builder.AppendLine($"url = {Keyword_ParameterBind}('{item.Url}')");
                builder.Append($"{Keyword_ApiGet}(url).then(function(d) {{ vm.{item.ModelName} = d }})");

                i++;
            }
        }
    }
}