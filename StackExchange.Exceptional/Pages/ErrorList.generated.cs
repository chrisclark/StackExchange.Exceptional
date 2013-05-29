﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18047
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StackExchange.Exceptional.Pages
{
    using System;
    
    #line 2 "..\..\Pages\ErrorList.cshtml"
    using System.Collections.Generic;
    
    #line default
    #line hidden
    
    #line 3 "..\..\Pages\ErrorList.cshtml"
    using System.Linq;
    
    #line default
    #line hidden
    using System.Text;
    
    #line 4 "..\..\Pages\ErrorList.cshtml"
    using StackExchange.Exceptional;
    
    #line default
    #line hidden
    
    #line 6 "..\..\Pages\ErrorList.cshtml"
    using StackExchange.Exceptional.Extensions;
    
    #line default
    #line hidden
    
    #line 5 "..\..\Pages\ErrorList.cshtml"
    using StackExchange.Exceptional.Pages;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "1.5.4.0")]
    internal partial class ErrorList : RazorPageBase
    {
#line hidden

        #line 27 "..\..\Pages\ErrorList.cshtml"

    public string Url(string path)
    {
        return BasePageName.EndsWith("/") ? BasePageName + path : BasePageName + "/" + path;
    }

        #line default
        #line hidden

        public override void Execute()
        {


WriteLiteral("\n");








            
            #line 8 "..\..\Pages\ErrorList.cshtml"
  
    var log = ErrorStore.Default;
    var errors = new List<Error>();
    var total = log.GetAll(errors);
    var typefilter = Request.Params["typefilter"];
    errors = errors.OrderByDescending(e => e.CreationDate).ToList();
    var suppressedCount = 0;
    if (!string.IsNullOrEmpty(typefilter))
    {
        var unfilteredCount = errors.Count;
        errors.RemoveAll(e => e.Type.ToShortException().ToLowerInvariant().Contains(typefilter.ToLowerInvariant()));
        total = errors.Count;
        suppressedCount = unfilteredCount - total;
        
    }
    
    Layout = new Master { PageTitle = "Error Log" };


            
            #line default
            #line hidden

WriteLiteral("\n");


            
            #line 33 "..\..\Pages\ErrorList.cshtml"
 if (log.InFailureMode)
{
    var le = ErrorStore.LastRetryException;

            
            #line default
            #line hidden
WriteLiteral("    <div class=\"failure-mode\">Error log is in failure mode, ");


            
            #line 36 "..\..\Pages\ErrorList.cshtml"
                                                       Write(ErrorStore.WriteQueue.Count);

            
            #line default
            #line hidden
WriteLiteral(" ");


            
            #line 36 "..\..\Pages\ErrorList.cshtml"
                                                                                     Write(ErrorStore.WriteQueue.Count == 1 ? "entry" : "entries");

            
            #line default
            #line hidden

            
            #line 36 "..\..\Pages\ErrorList.cshtml"
                                                                                                                                                  WriteLiteral(" queued to log.");

            
            #line default
            #line hidden
            
            #line 36 "..\..\Pages\ErrorList.cshtml"
                                                                                                                                                                  if(le != null){
            
            #line default
            #line hidden
WriteLiteral("<br />Last Logging Exception: ");


            
            #line 36 "..\..\Pages\ErrorList.cshtml"
                                                                                                                                                                                                                Write(le.Message);

            
            #line default
            #line hidden

            
            #line 36 "..\..\Pages\ErrorList.cshtml"
                                                                                                                                                                                                                                       }
            
            #line default
            #line hidden
WriteLiteral("</div>\n");



WriteLiteral("    <!-- Exception Details:\n");


            
            #line 38 "..\..\Pages\ErrorList.cshtml"
     if(ErrorStore.LastRetryException != null)
    {
        
            
            #line default
            #line hidden
            
            #line 40 "..\..\Pages\ErrorList.cshtml"
   Write(ErrorStore.LastRetryException.Message);

            
            #line default
            #line hidden
            
            #line 40 "..\..\Pages\ErrorList.cshtml"
                                              
        
            
            #line default
            #line hidden
            
            #line 41 "..\..\Pages\ErrorList.cshtml"
   Write(ErrorStore.LastRetryException.StackTrace);

            
            #line default
            #line hidden
            
            #line 41 "..\..\Pages\ErrorList.cshtml"
                                                 
    }

            
            #line default
            #line hidden
WriteLiteral("     -->\n");


            
            #line 44 "..\..\Pages\ErrorList.cshtml"
}

            
            #line default
            #line hidden

            
            #line 45 "..\..\Pages\ErrorList.cshtml"
 if (!errors.Any())
{

            
            #line default
            #line hidden
WriteLiteral("    <h1>No errors yet, yay!</h1>\n");


            
            #line 48 "..\..\Pages\ErrorList.cshtml"
}
else
{
    var last = errors.FirstOrDefault(); // oh the irony

            
            #line default
            #line hidden
WriteLiteral("    <h1 id=\"errorcount\">");


            
            #line 52 "..\..\Pages\ErrorList.cshtml"
                   Write(ErrorStore.ApplicationName);

            
            #line default
            #line hidden
WriteLiteral(" - ");


            
            #line 52 "..\..\Pages\ErrorList.cshtml"
                                                 Write(total);

            
            #line default
            #line hidden
WriteLiteral(" Errors; last ");


            
            #line 52 "..\..\Pages\ErrorList.cshtml"
                                                                     Write(last.CreationDate.ToRelativeTime());

            
            #line default
            #line hidden
WriteLiteral("</h1>\n");



WriteLiteral("    <div><label for=\"tyepfilter\">Filter out types containing:</label><input type=" +
"\"text\" id=\"typefilter\" value=\"");


            
            #line 53 "..\..\Pages\ErrorList.cshtml"
                                                                                                          Write(typefilter);

            
            #line default
            #line hidden
WriteLiteral("\"/><button id=\"dofilter\">Filter</button>\r\n");


            
            #line 54 "..\..\Pages\ErrorList.cshtml"
         if (!string.IsNullOrEmpty(typefilter))
        {

            
            #line default
            #line hidden
WriteLiteral("            <span>(");


            
            #line 56 "..\..\Pages\ErrorList.cshtml"
              Write(suppressedCount);

            
            #line default
            #line hidden
WriteLiteral(" exceptions currently suppressed)</span>\r\n");


            
            #line 57 "..\..\Pages\ErrorList.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("    </div>\n");



WriteLiteral(@"    <table id=""ErrorLog"" class=""alt-rows"">
        <thead>
            <tr>
                <th class=""type-col"">&nbsp;</th>
                <th class=""type-col"">Type</th>
                <th>Error</th>
                <th>Url</th>
                <th>Remote IP</th>
                <th>Time</th>
                <th>Site</th>
                <th>Server</th>
            </tr>
        </thead>
        <tbody>
");


            
            #line 73 "..\..\Pages\ErrorList.cshtml"
         foreach (var e in errors)
        {
            var fullUrl = "http://" + e.Host + e.Url;

            
            #line default
            #line hidden
WriteLiteral("            <tr data-id=\"");


            
            #line 76 "..\..\Pages\ErrorList.cshtml"
                    Write(e.GUID);

            
            #line default
            #line hidden
WriteLiteral("\" class=\"error");


            
            #line 76 "..\..\Pages\ErrorList.cshtml"
                                          Write(e.IsProtected ? " protected" : "");

            
            #line default
            #line hidden
WriteLiteral("\">\n                <td>\n                    <a href=\"");


            
            #line 78 "..\..\Pages\ErrorList.cshtml"
                        Write(Url("delete"));

            
            #line default
            #line hidden
WriteLiteral("\" class=\"delete-link\" title=\"Delete this error\">&nbsp;X&nbsp;</a>\n");


            
            #line 79 "..\..\Pages\ErrorList.cshtml"
                     if (!e.IsProtected)
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <a href=\"");


            
            #line 81 "..\..\Pages\ErrorList.cshtml"
                            Write(Url("protect"));

            
            #line default
            #line hidden
WriteLiteral("\" class=\"protect-link\" title=\"Protect this error\">&nbsp;P&nbsp;</a>\n");


            
            #line 82 "..\..\Pages\ErrorList.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                </td>\n                <td class=\"type-col\" title=\"");


            
            #line 84 "..\..\Pages\ErrorList.cshtml"
                                       Write(e.Type);

            
            #line default
            #line hidden
WriteLiteral("\">");


            
            #line 84 "..\..\Pages\ErrorList.cshtml"
                                                Write(e.Type.ToShortException());

            
            #line default
            #line hidden
WriteLiteral("</td>\n                <td class=\"error-col\"><a href=\"");


            
            #line 85 "..\..\Pages\ErrorList.cshtml"
                                          Write(Url("info?guid="+@e.GUID));

            
            #line default
            #line hidden
WriteLiteral("\" class=\"info-link\">");


            
            #line 85 "..\..\Pages\ErrorList.cshtml"
                                                                                        Write(e.Message);

            
            #line default
            #line hidden
WriteLiteral("</a> \n");


            
            #line 86 "..\..\Pages\ErrorList.cshtml"
                     if(e.DuplicateCount > 1)
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <span class=\"duplicate-count\" title=\"number of similar er" +
"rors occurring close to this error\">(");


            
            #line 88 "..\..\Pages\ErrorList.cshtml"
                                                                                                                 Write(e.DuplicateCount);

            
            #line default
            #line hidden
WriteLiteral(")</span>\n");


            
            #line 89 "..\..\Pages\ErrorList.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                </td>\n                <td>\n");


            
            #line 92 "..\..\Pages\ErrorList.cshtml"
                     if (e.HTTPMethod == "GET" && e.Url.HasValue())
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <a href=\"");


            
            #line 94 "..\..\Pages\ErrorList.cshtml"
                            Write(fullUrl);

            
            #line default
            #line hidden
WriteLiteral("\" title=\"");


            
            #line 94 "..\..\Pages\ErrorList.cshtml"
                                             Write(fullUrl);

            
            #line default
            #line hidden
WriteLiteral("\" class=\"url-link\">");


            
            #line 94 "..\..\Pages\ErrorList.cshtml"
                                                                        Write(e.Url.TruncateWithEllipsis(40));

            
            #line default
            #line hidden
WriteLiteral("</a>\n");


            
            #line 95 "..\..\Pages\ErrorList.cshtml"
                    }
                    else if (e.Url.HasValue())
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <span title=\"");


            
            #line 98 "..\..\Pages\ErrorList.cshtml"
                                Write(fullUrl);

            
            #line default
            #line hidden
WriteLiteral("\">");


            
            #line 98 "..\..\Pages\ErrorList.cshtml"
                                          Write(e.Url.TruncateWithEllipsis(40));

            
            #line default
            #line hidden
WriteLiteral("</span>\n");


            
            #line 99 "..\..\Pages\ErrorList.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                </td>\n                <td>");


            
            #line 101 "..\..\Pages\ErrorList.cshtml"
               Write(e.IPAddress);

            
            #line default
            #line hidden
WriteLiteral("</td>\n                <td><span title=\"");


            
            #line 102 "..\..\Pages\ErrorList.cshtml"
                             Write(string.Format("{0:G} -- {1:u}", e.CreationDate, e.CreationDate.ToUniversalTime()));

            
            #line default
            #line hidden
WriteLiteral("\">");


            
            #line 102 "..\..\Pages\ErrorList.cshtml"
                                                                                                                  Write(e.CreationDate.ToRelativeTime());

            
            #line default
            #line hidden
WriteLiteral("</span></td>\n                <td>");


            
            #line 103 "..\..\Pages\ErrorList.cshtml"
               Write(e.Host);

            
            #line default
            #line hidden
WriteLiteral("</td>\n                <td>");


            
            #line 104 "..\..\Pages\ErrorList.cshtml"
               Write(e.MachineName);

            
            #line default
            #line hidden
WriteLiteral("</td>\n            </tr>\n");


            
            #line 106 "..\..\Pages\ErrorList.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("        </tbody>\n    </table>\n");


            
            #line 109 "..\..\Pages\ErrorList.cshtml"
    if (errors.Any(e => !e.IsProtected))
    {

            
            #line default
            #line hidden
WriteLiteral("    <div class=\"clear-all-div\">\n        <a class=\"delete-link clear-all-link\" hre" +
"f=\"");


            
            #line 112 "..\..\Pages\ErrorList.cshtml"
                                               Write(Url("delete-all"));

            
            #line default
            #line hidden
WriteLiteral("\">&nbsp;X&nbsp;- Clear all non-protected errors</a>\n    </div>\n");


            
            #line 114 "..\..\Pages\ErrorList.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral(@"    <script type=""text/javascript"">
        doFilter = function() {
            window.location.href = 'exceptions?typefilter=' + $('#typefilter').val();
        };
        $(document).ready(function() {
            $(""#dofilter"").click(doFilter);
            $(""#typefilter"").keypress(function(e) {
                if (e.which == 13) {
                    doFilter();
                }
            });
        });
    </script>
");


            
            #line 128 "..\..\Pages\ErrorList.cshtml"
}
            
            #line default
            #line hidden

        }
    }
}
#pragma warning restore 1591
