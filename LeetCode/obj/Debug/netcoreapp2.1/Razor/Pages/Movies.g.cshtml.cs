#pragma checksum "C:\Users\vgaddam\source\repos\LeetCode\LeetCode\Pages\Movies.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "45db8c695d87d954791fb4ddb5ab661008623dbc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(LeetCode.Pages.Pages_Movies), @"mvc.1.0.razor-page", @"/Pages/Movies.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/Movies.cshtml", typeof(LeetCode.Pages.Pages_Movies), null)]
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
#line 4 "C:\Users\vgaddam\source\repos\LeetCode\LeetCode\Pages\Movies.cshtml"
using Kendo.Mvc.UI;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"45db8c695d87d954791fb4ddb5ab661008623dbc", @"/Pages/Movies.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"401d124e5b84280993741489730c3b4042dfab95", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Movies : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "text", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("txtMovieName"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("placeholder", new global::Microsoft.AspNetCore.Html.HtmlString("Producer"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "Producer", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("txtProducer"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 6 "C:\Users\vgaddam\source\repos\LeetCode\LeetCode\Pages\Movies.cshtml"
  
    ViewData["Title"] = "Movies";
    Layout = "~/Pages/_Layout.cshtml";

#line default
#line hidden
            BeginContext(232, 100, true);
            WriteLiteral("\r\n<!--<script src=\"https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js\"></script>-->\r\n");
            EndContext();
            BeginContext(494, 12110, true);
            WriteLiteral(@"
<script type=""text/javascript"">
    var userData = null;
    var oldMovieName = """";
    var actorData = [];
    $(document).ready(function myfunction() {

        $.ajax({
            url: ""api/Movies/GetMovies"",
            dataType: ""json"",
            crossdomain: true,
            contentType: ""application/json"",
            type: ""GET"",
            //define a contentType of your request
            secure: true,
            //headers: {
            //    ""Access-Control-Allow-Origin"": ""*"",
            //    ""Access-Control-Allow-Headers"": ""*""
            //},
            success: function (data) {
                tblData = data
                $.each(data, function (i, data) {
                    var actorsData = data.table[i].actors;
                    var actorsNames = actorNames(actorsData);
                    userData = data;
                    var Update = ""<a name=LoginButton data-toggle= modal  data-target= #exampleModal onclick=updateMovie('"" + this.itemArray[1] + ""')");
            WriteLiteral(@"  value=Update href=# id=btnUpdate>Update</a>"";
                    var Delete = ""<a name=LoginBut onclick=DeleteRecord('"" + this.itemArray[1] + ""') href=# id="" + data.table[i].movieName + "">Delete</a>"";
                    var body = ""<tr>"";
                    body += ""<td id="" + data.table[i].movieName + "">"" + data.table[i].movieName + ""</td > "";
                    body += ""<td>"" + data.table[i].dateOfRelease + ""</td>"";
                    body += ""<td>"" + data.table[i].producer + ""</td>"";
                    body += ""<td>"" + actorsNames.replace(/,\s*$/, """") + ""</td>"";
                    body += ""<td>"" + Update + ""  ||  "" + Delete + ""</td>"";
                    body += ""</tr>"";
                    $(body).appendTo($("".tblData""));
                });
                $('#tblMovies').DataTable(
                    //{
                    //""scrollX"": true
                    //}
                );
            },
            error: function (xhr, errorType, exception) {
                var ");
            WriteLiteral(@"errorMessage = exception || xhr.statusText;
                console.log(exception);
                console.log(xhr);
                alert(errorType + "";  "" + errorMessage + "" "" + exception + ""  Status:: "" + xhr.statusText);
            }
        });


    });

    function actorNames(data) {
        var names = """";
        for (var i = 0; i < data.length; i++) {
            names = names + data[i].actorName + "","";
        }
        return names;
    }

    function updateMovie(movieName) {
        console.log(movieName);
        getActorsData();
        oldMovieName = movieName;
        var body = """";
        $(body).appendTo($(""#slctActors""));
        $('#txtMovieName').prop('disabled', true);

        $.ajax({
            url: ""http://localhost:51502/api/Movies/"" + movieName + """",

            dataType: ""json"",
            crossdomain: true,
            contentType: ""application/json"",
            type: ""GET"",
            //define a contentType of your request
           ");
            WriteLiteral(@" secure: true,
            headers: {
                ""Access-Control-Allow-Origin"": ""*"",
                ""Access-Control-Allow-Headers"": ""*""
            },
            success: function (data) {
                console.log(data);
                tblData = data[0].table[0];
                $('#txtMovieName').val(movieName);
                $('#txtProducer').val(tblData.producer);

                $(""#txtReleaseDate"").val(tblData.dateOfRelease);

                $('#selectedFilters').children().remove();
                var dataarray = [];
                //    { name: ""ActorName0"", value: ""value1"" },
                //    { name: ""ActorName1"", value: ""value2"" },
                //    { name: ""name3"", value: ""value3"" },
                //    { name: ""name4"", value: ""value4"" },
                //    { name: ""name5"", value: ""value5"" },
                //    { name: ""name6"", value: ""value6"" }

                //body += ""<input id='selectedFilters'>"";
                //$(body).appendTo($(""#l");
            WriteLiteral(@"blActors""));
                for (var i = 0; i <= actorData.length - 1; i++) {
                    var obj = {
                        name: ""ActorName"" + i.toString(),
                        value: actorData[i].actorName
                    }
                    dataarray.push(obj);
                }
                console.log(dataarray);
                var multiselect = $('#selectedFilters').kendoMultiSelect({
                    //autoBind: false,
                    dataSource: dataarray,
                    dataTextField: 'value',
                    dataValueField: 'name',
                    filter: 'contains',
                    placeholder: ""Select Actor...."",
                    delay: 0,
                    minLength: 2,
                    highlightFirst: true,
                    ignoreCase: true,
                    change: function (event) {
                        console.log(""change"");
                    }
                }).data(""kendoMultiSelect"");

           ");
            WriteLiteral(@"     arrActors = [];

                for (var j = 0; j < tblData.actors.length; j++) {
                    for (var i = 0; i < dataarray.length; i++) {

                        if (tblData.actors[j].actorName.includes(dataarray[i].value)) {
                            arrActors.push(dataarray[i].value)
                        }
                    }
                }
                console.log(""Actors Array :-"" + arrActors);
                multiselect.value(arrActors);
            },
            error: function (xhr, errorType, exception) {
                var errorMessage = exception || xhr.statusText;
                console.log(exception);
                console.log(xhr);
                alert(errorType + "";  "" + errorMessage + "" "" + exception + ""  Status:: "" + xhr.statusText);
            }
        });

        $(""#exampleModal"").modal('show');

        $('#exampleModal').on('hidden.bs.modal', function () {
            location.reload();
        })

    }

    function get");
            WriteLiteral(@"ActorsData() {
        $.ajax({
            url: ""api/Movies/GetActors"",
            dataType: ""json"",
            //crossdomain: true,
            //contentType: ""application/json"",
            type: ""GET"",
            //define a contentType of your request
            secure: true,
            success: function (resultdata) {
                console.log(resultdata);
                actorData = resultdata;
                return resultdata;
            },
            error: function () {
                return ""Hello"";
            }
        });
        console.log(""Enter2"");
    }


    function DeleteRecord(movieName) {
        console.log(document.getElementsByName(""LoginBut""));
        // var $row = $(this).closest(""tr"");    // Find the row
        //var $text = $row.find(""#tmp"").text(); // Find the text
        $.ajax({
            url: ""api/Movies/"" + movieName,
            crossdomain: true,
            contentType: ""application/json"",
            type: ""DELETE"",
        ");
            WriteLiteral(@"    success: function (result) {
                console.log(""success"");
                window.location.reload();
            },
            error: function (xhr, errorType, exception) {
                var errorMessage = exception || xhr.statusText;
                console.log(exception);
                console.log(xhr);
                alert(errorType + "";  "" + exception + ""  Status:: "" + xhr.statusText);
            }
        });
    }


    function Savechanges() {
        var moviename = $(""#txtMovieName"").val();
        var frmdata = $(""#frmUpdate"").serialize();
        var producername = $(""#txtProducer"").val();
        var releasedate = $(""#txtReleaseDate"").val();
        var actorNames = """";

        $(""#slctActors > option"").each(function () {
            //alert(this.text + ' ' + this.value);
            actorNames = actorNames + this.value + "","";
        });

        var DataObject =
        {
            ""Movies"": [
                {
                    ""MovieName""");
            WriteLiteral(@": moviename,
                    ""Producer"": producername,
                    ""DateOfRelease"": releasedate,
                    ""actor"": [
                        {
                            ""ActorName"": ""Test2""
                        }
                    ]
                }
            ]
        }

        var dt = {
            ""MovieName"": moviename,
            ""Producer"": producername,
            ""DateOfRelease"": releasedate,
            ""Actor"": actorNames.substring(0, actorNames.length - 2)
        }

        $.ajax({
            url: ""http://localhost:51502/api/Movies/"" + oldMovieName + """",
            data: JSON.stringify(dt),
            dataType: ""json"",
            crossdomain: true,
            contentType: ""application/json; charset=utf-8"",
            type: ""PUT"",
            //define a contentType of your request
            secure: true,
            headers: {
                ""Access-Control-Allow-Origin"": ""*"",
                ""Access-Control-Allow-Headers""");
            WriteLiteral(@": ""*""
            },
            success: function (data) {
                tblData = data
                console.log(data);
                $('#modal').modal('toggle');
                window.location.reload(function myfunction() {
                    $('#loading').hide();
                });
                //$.each(data, function (i, data) {
                //    var actorsData = data.Table[i].Actors;
                //    window.sessionStorage.setItem('data', data.Table[i]);
                //    userData = data;
                //    $('#txtMovieName').val(movieName);
                //    $('#txtProducer').val(data.Table[i].Producer);
                //    $(""#txtReleaseDate"").val(data.Table[i].DateOfRelease);
                //    var body = """";
                //    for (var i = 0; i <= actorsData.length - 1; i++) {
                //        body += ""<option id="" + i + "">"" + actorsData[i].ActorName + ""</option > "";
                //        $(body).appendTo($(""#slctActors""));
    ");
            WriteLiteral(@"            //    }

                //});
            },
            error: function (xhr, errorType, exception) {
                var errorMessage = exception || xhr.statusText;
                console.log(exception);
                console.log(xhr);
                alert(errorType + "";  "" + errorMessage + "" "" + exception + ""  Status:: "" + xhr.statusText);
            }
        });

        console.log(data + "","" + producername + "","" + releasedate);
    }

</script>

<div style=""height:80px;"">

</div>

<div class=""container"">
    <div class=""spinner-grow text-primary"" role=""status"" id=""loading"">
        <span class=""sr-only"">Loading...</span>
    </div>

    <table class=""table"" id=""tblMovies"" style=""width:100%"">
        <thead>
            <tr>
                <th>MovieName</th>
                <th>DateOfRelease</th>
                <th>Producer</th>
                <th>Actors</th>
                <th>Options</th>
            </tr>
        </thead>
        <tbody class=");
            WriteLiteral(@"""tblData""></tbody>
    </table>


    <div class=""modal fade"" id=""exampleModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
        <div class=""modal-dialog modal-lg"" role=""document"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h5 class=""modal-title"" id=""exampleModalLabel"">Update Movie</h5>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>
                </div>
                <div class=""modal-body"">
                    <div class=""form-row"">
                        <div class=""form-group col-md-6"">
                            <label>MovieName</label>
                            ");
            EndContext();
            BeginContext(12604, 126, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "90d1367bddc74653b95298f350d3f355", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#line 333 "C:\Users\vgaddam\source\repos\LeetCode\LeetCode\Pages\Movies.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.movies.MovieName);

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Name = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(12730, 174, true);
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"form-group col-md-6\">\r\n                            <label>Producer</label>\r\n                            ");
            EndContext();
            BeginContext(12904, 124, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "d26f64949a5d4ca1880e0add40edee7c", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#line 337 "C:\Users\vgaddam\source\repos\LeetCode\LeetCode\Pages\Movies.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.movies.Producer);

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Name = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(13028, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(13162, 270, true);
            WriteLiteral(@"                        </div>
                    </div>
                    <div class=""form-row"">
                        <div class=""form-group col-md-6"">
                            <label for=""txtReleaseDate"">DateOfRelease</label>
                            ");
            EndContext();
            BeginContext(13433, 160, false);
#line 344 "C:\Users\vgaddam\source\repos\LeetCode\LeetCode\Pages\Movies.cshtml"
                       Write(Html.Kendo().DatePicker().Name("datepicker").HtmlAttributes(new { @class = "form-control", @style = "width: 95%;", id = "txtreleaseDate" }).Format("MM/DD/YYYY"));

#line default
#line hidden
            EndContext();
            BeginContext(13593, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(13759, 179, true);
            WriteLiteral("                        </div>\r\n                        <div class=\"form-group col-md-6\">\r\n                            <label for=\"selectedFilters\" id=\"lblActors\">Actors</label>\r\n");
            EndContext();
            BeginContext(14152, 486, true);
            WriteLiteral(@"                            <input id='selectedFilters'>
                        </div>
                    </div>
                </div>
                <div class=""modal-footer"">
                    <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Close</button>
                    <button type=""button"" class=""btn btn-primary"" onclick=""Savechanges()"">Save changes</button>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ServerlessApp.Pages.MoviesModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ServerlessApp.Pages.MoviesModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ServerlessApp.Pages.MoviesModel>)PageContext?.ViewData;
        public ServerlessApp.Pages.MoviesModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
