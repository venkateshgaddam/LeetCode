#pragma checksum "C:\Users\vgaddam\source\repos\LeetCode\LeetCode\Pages\FactoryPattern.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "02928527f42571a8425c8f8c06a4e2c4e57a4456"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(LeetCode.Pages.Pages_FactoryPattern), @"mvc.1.0.razor-page", @"/Pages/FactoryPattern.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/FactoryPattern.cshtml", typeof(LeetCode.Pages.Pages_FactoryPattern), null)]
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
#line 3 "C:\Users\vgaddam\source\repos\LeetCode\LeetCode\Pages\FactoryPattern.cshtml"
using Kendo.Mvc.UI;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"02928527f42571a8425c8f8c06a4e2c4e57a4456", @"/Pages/FactoryPattern.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"401d124e5b84280993741489730c3b4042dfab95", @"/Pages/_ViewImports.cshtml")]
    public class Pages_FactoryPattern : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
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
#line 6 "C:\Users\vgaddam\source\repos\LeetCode\LeetCode\Pages\FactoryPattern.cshtml"
  
    ViewData["Title"] = "FactoryPattern";
    Layout = "~/Pages/_Layout.cshtml";

#line default
#line hidden
            BeginContext(233, 3260, true);
            WriteLiteral(@"
<script>

    $(document).ready(function myfunction() {
        $('#prDynamic').text('This Section makes use of the Factory Design Pattern')
    });

    function GetCelebrityData() {

        var file = document.querySelector('input[type=file]').files[0];
        var rekognitionType = """";

        if (!file) {
            $("".k-header"").css({ 'border-color': 'red' });
            return
        } else {
            $("".k-header"").css({ 'border-color': 'white' });

            rekognitionType = $(""#rCUpload"").prop('checked') ? ""celebrity"" : ""image"";

            var reader = new FileReader();
            reader.addEventListener(""load"", function () { }, false);

            reader.readAsDataURL(file);

            console.log(reader.result.split(',')[1]);
            var apiInput = reader.result.split(',')[1];
        }

        $.ajax(
            {
                url: ""api/Rekognition/GetCelebrity"",
                dataType: ""text"",
                crossdomain: true,
     ");
            WriteLiteral(@"           contentType: ""application/json"",
                data: JSON.stringify({
                    'base64Data': apiInput,
                    'fileName': file.name,
                    'fileSize': file.size,
                    'RekognitionType':rekognitionType
                }),
                type: ""POST"",
                //define a contentType of your request
                secure: true,
                headers: {
                    ""Access-Control-Allow-Origin"": ""*"",
                    ""Access-Control-Allow-Headers"": ""*""
                },
                success: function (data) {
                    PopualtePopUpModal(data);
                    var upload = $(""#fUpload"").data(""kendoUpload"");
                    upload.clearAllFiles();
                    $('#dvImg').css({ 'display': 'block' });
                    $('#imgUpload').attr('src', reader.result);
                },
                error: function (xhr, errorType, exception) {
                    var errorMessag");
            WriteLiteral(@"e = exception || xhr.statusText;
                    console.log(exception);
                    console.log(xhr);
                    alert(errorType + "";  "" + errorMessage + "" "" + exception + ""  Status:: "" + xhr.statusText);
                }
            });


        function PopualtePopUpModal(data) {

            if (data == """") {
                data = ""Your Image does not have any celebrity.Please try a new Image"";
            }
            var arrData = data.split(',');

            $.each(arrData, function (i, arrData) {
                var lstBody = ""<li id='lstgrp' class=list-group-item list-group-item-light>"";

                lstBody += arrData + ""</li>"";
                $(lstBody).appendTo($("".list-group""));
                console.log(arrData);
            })
            //$('#lstgrp').addClass(""list-group-item"");
            //$('#lstgrp').addClass(""list-group-item-light"");
            //list-group-item-light
            $(""#txtCelebrityData"").text(data);
            ");
            WriteLiteral("//var body = \"<li class=\"\"list-group-item list-group-item-light\"\">\";\r\n\r\n            //$(\"#rekognitionModal\").modal(\'show\');\r\n            console.log(data);\r\n        }\r\n    }\r\n</script>\r\n\r\n");
            EndContext();
            BeginContext(3493, 54, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "b96d4fa72d30450ea467805a38cb5b14", async() => {
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
            BeginContext(3547, 535, true);
            WriteLiteral(@"

<div class=""label"">
    <p id=""prDynamic"" class=""lead text-center"" style=""margin-top:10px""></p>
</div>


<div class=""container-fluid placeholder"">

    <div class=""row"">
        <div class=""col-md-8"">
            <div class=""row"">
                <div class=""col-md-4"">
                    <div class=""well"" id=""rdCelebRekognition"" style=""font-family:cursive"">
                        <input type=""radio"" id=""rCUpload"" class=""radio"" name=""Rekognition"" /><label style=""font-family:cursive"">CelebrityRekognition</label>
");
            EndContext();
            BeginContext(4266, 338, true);
            WriteLiteral(@"                    </div>
                </div>
                <div class=""col-md-4"">
                    <div class=""well"" id=""rdImageRekognition"" style=""font-family:cursive"">
                        <input type=""radio"" id=""rIUpload"" class=""radio"" name=""Rekognition"" /><label style=""font-family:cursive"">ImageRekognition</label>
");
            EndContext();
            BeginContext(4800, 402, true);
            WriteLiteral(@"                    </div>
                </div>
            </div>
            <div class=""row"">
                <div class=""col-md-8"">
                    <div class=""well"" id=""celebrityRekognition"">
                        <p style=""font-family:cursive"">
                            Image Rekognition
                        </p>

                        <p>
                            ");
            EndContext();
            BeginContext(5203, 104, false);
#line 133 "C:\Users\vgaddam\source\repos\LeetCode\LeetCode\Pages\FactoryPattern.cshtml"
                       Write(Html.Kendo().Upload().Name("UploadFile").HtmlAttributes(new { @style = "width: 60%;", @id = "fUpload" }));

#line default
#line hidden
            EndContext();
            BeginContext(5307, 89, true);
            WriteLiteral("\r\n                        </p>\r\n                        <p>\r\n                            ");
            EndContext();
            BeginContext(5398, 179, false);
#line 136 "C:\Users\vgaddam\source\repos\LeetCode\LeetCode\Pages\FactoryPattern.cshtml"
                        Write(Html.Kendo().Button().Name("TextButton").Content("GetImageData").HtmlAttributes(new { @class = "textButton k-primary", @type = "submit" }).Events(e => e.Click("GetCelebrityData")));

#line default
#line hidden
            EndContext();
            BeginContext(5578, 88, true);
            WriteLiteral("\r\n                        </p>\r\n\r\n                    </div>\r\n                </div>\r\n\r\n");
            EndContext();
            BeginContext(6471, 1747, true);
            WriteLiteral(@"            </div>

            <div class=""container-fluid"" id=""dvImg"" style=""display:none"">
                <picture>
                    <img class=""img-fluid img-thumbnail"" src=""./"" id=""imgUpload"" alt=""Test"" style=""padding:5rem;"" />
                </picture>
            </div>

        </div>

        <div class=""col-md-4"">
            <div class=""column"">
                <div class=""content-section"">
                    <h3 style=""font-family:cursive"">Rekognition Data</h3>
                    <p class='text-muted'>
                        <ul class=""list-group""></ul>
                    </p>
                </div>
            </div>
        </div>
    </div>

</div>


<div class=""modal fade"" id=""rekognitionModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog modal-lg modal-dialog-centered"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""mo");
            WriteLiteral(@"dal-title"" id=""exampleModalLabel"">Success</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">

                <div class=""form-row"">
                    <div class=""isa_success"">
                        <i class=""fa fa-check""></i>
                        Rekognition Data - <span id=""txtCelebrityData""></span>
                    </div>
                </div>
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Close</button>
");
            EndContext();
            BeginContext(8331, 58, true);
            WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LeetCode.Models.ImageData> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<LeetCode.Models.ImageData> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<LeetCode.Models.ImageData>)PageContext?.ViewData;
        public LeetCode.Models.ImageData Model => ViewData.Model;
    }
}
#pragma warning restore 1591
