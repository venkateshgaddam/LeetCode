#pragma checksum "C:\Users\vgaddam\source\repos\LeetCode\LeetCode\Pages\LeetCode.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f454f03a01f1fafd40c78b03d1de9aade49c2a19"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(LeetCode.Pages.Pages_LeetCode), @"mvc.1.0.razor-page", @"/Pages/LeetCode.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/LeetCode.cshtml", typeof(LeetCode.Pages.Pages_LeetCode), null)]
namespace LeetCode.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\vgaddam\source\repos\LeetCode\LeetCode\Pages\_ViewImports.cshtml"
using LeetCode;

#line default
#line hidden
#line 3 "C:\Users\vgaddam\source\repos\LeetCode\LeetCode\Pages\LeetCode.cshtml"
using Kendo.Mvc.UI;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f454f03a01f1fafd40c78b03d1de9aade49c2a19", @"/Pages/LeetCode.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"401d124e5b84280993741489730c3b4042dfab95", @"/Pages/_ViewImports.cshtml")]
    public class Pages_LeetCode : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/CustomStyle.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 5 "C:\Users\vgaddam\source\repos\LeetCode\LeetCode\Pages\LeetCode.cshtml"
  
    ViewData["Title"] = "LeetCode";
    Layout = "~/Pages/_Layout.cshtml";

#line default
#line hidden
            BeginContext(194, 1775, true);
            WriteLiteral(@"
<script>

    function CreateInstance() {

        var input = $(""#txtInput"").val();
        var integer = parseInt(input, 10);
        console.log(input);
        console.log(integer);

        if (integer <= 0) {
            $(""#lblError"").addClass(""lblError"");
            $(""#lblError"").text(""Please enter proper Inputs."");;
            $(""#spnText"").text(integer);
            return;
        }
        else if (input.length >= 5) {
            $(""#lblError"").addClass(""lblError"");
            $(""#lblError"").text(""Limited this to 4 Digits.Please excuse me"");
            $(""#spnText"").text("""");
            return
        }

        $.ajax(
            {
                url: ""api/EC2/LeetCode"",
                dataType: ""text"",
                crossdomain: true,
                contentType: ""application/json"",
                data: input,
                type: ""POST"",
                //define a contentType of your request
                secure: true,
                //headers:");
            WriteLiteral(@" {
                //    ""Access-Control-Allow-Origin"": ""*"",
                //    ""Access-Control-Allow-Headers"": ""*""
                //},
                success: function (data) {
                    //alert(""Success"");
                    var instanceID = JSON.parse(data);
                    $(""#spnText"").text(instanceID.message);
                },
                error: function (xhr, errorType, exception) {
                    var errorMessage = exception || xhr.statusText;
                    console.log(exception);
                    console.log(xhr);
                    alert(errorType + "";  "" + errorMessage + "" "" + exception + ""  Status:: "" + xhr.statusText);
                }
            });
    }
</script>

");
            EndContext();
            BeginContext(1969, 54, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "37de6aaafb38406f9fd401cd5e496440", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2023, 526, true);
            WriteLiteral(@"
<div style=""height:40px;"">
</div>

<div class=""container-fluid"">
    <div class=""row"">
        <div class=""col-md-10 col-sm-12 col-lg-10"">
            <div class=""row"">
                <div class=""well"" id=""CreateEC2"" style=""width:60%"">
                    <p>
                        <label id=""lblError"" style=""display:none""></label>
                    </p>
                    <p>
                        Please Enter your Inputs
                    </p>

                    <p>
                        ");
            EndContext();
            BeginContext(2550, 128, false);
#line 78 "C:\Users\vgaddam\source\repos\LeetCode\LeetCode\Pages\LeetCode.cshtml"
                   Write(Html.Kendo().TextBox().Name("InputText").HtmlAttributes(new { @class = "k-textbox", @style = "width: 100%;", @id = "txtInput" }));

#line default
#line hidden
            EndContext();
            BeginContext(2678, 77, true);
            WriteLiteral("\r\n                    </p>\r\n                    <p>\r\n                        ");
            EndContext();
            BeginContext(2757, 372, false);
#line 81 "C:\Users\vgaddam\source\repos\LeetCode\LeetCode\Pages\LeetCode.cshtml"
                    Write(Html.Kendo().Button().Name("TextButton")
                                                                       .Content("Submit")
                                                                       .HtmlAttributes(new { @class = "textButton k-primary" })
                                                                       .Events(e => e.Click("CreateInstance")));

#line default
#line hidden
            EndContext();
            BeginContext(3130, 257, true);
            WriteLiteral(@"
                    </p>

                    <p>
                        <label id=""lblOutput"">Output :- <span id=""spnText""></span></label>
                    </p>
                </div>

            </div>
        </div>
    </div>
</div>

");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Pages_LeetCode> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Pages_LeetCode> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Pages_LeetCode>)PageContext?.ViewData;
        public Pages_LeetCode Model => ViewData.Model;
    }
}
#pragma warning restore 1591
