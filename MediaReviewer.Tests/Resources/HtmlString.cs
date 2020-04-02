using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaReviewer.Tests.Resources
{
    public static class HtmlString
    {
        public const string HtmlLeadAndBody = @"
            <!DOCTYPE html>
            <html>
            <head>
                <meta charset='utf-8'>
                <meta http-equiv='X-UA-Compatible' content='IE=edge'>
                <title>Page Title</title>
                <meta name='viewport' content='width=device-width, initial-scale=1'>
                <link rel='stylesheet' type='text/css' media='screen' href='main.css'>
                <script src='main.js'></script>
            </head>
            <body>
                <div class=""news-lead"" >Text in news-lead class</div>
                <p>Here also some text..<p>
                <div class=""news-body bbtext"">Text in news-body class.<div class=""x-rwd-inl-c"">
                    <div 
                        class=""spolecznoscinet"" id=""spolecznosci-1304"">
                    </div>
                </div>

                
            </body>
            </html>";
        public const string HtmlArticlesLead = @"
            <!DOCTYPE html>
            <html>
            <head>
                <meta charset='utf-8'>
                <meta http-equiv='X-UA-Compatible' content='IE=edge'>
                <title>Page Title</title>
                <meta name='viewport' content='width=device-width, initial-scale=1'>
                <link rel='stylesheet' type='text/css' media='screen' href='main.css'>
                <script src='main.js'></script>
            </head>
            <body>
                <div class=""news-lead"" >Text in news-lead class</div>
                <p>Here also some text..<p>
            </body>
            </html>";
        public const string HtmlArticlesBody = @"
            <!DOCTYPE html>
            <html>
            <head>
                <meta charset='utf-8'>
                <meta http-equiv='X-UA-Compatible' content='IE=edge'>
                <title>Page Title</title>
                <meta name='viewport' content='width=device-width, initial-scale=1'>
                <link rel='stylesheet' type='text/css' media='screen' href='main.css'>
                <script src='main.js'></script>
            </head>
            <body>
                
                <p>Here also some text..<p>
                <div class=""news-body bbtext"">Text in news-body class.</div>

                
            </body>
            </html>";
        public const string HtmlNoLeadAndBody = @"
            <!DOCTYPE html>
            <html>
            <head>
                <meta charset='utf-8'>
                <meta http-equiv='X-UA-Compatible' content='IE=edge'>
                <title>Page Title</title>
                <meta name='viewport' content='width=device-width, initial-scale=1'>
                <link rel='stylesheet' type='text/css' media='screen' href='main.css'>
                <script src='main.js'></script>
            </head>
            <body>
                <p>Here also some text..<p>
            </body>
            </html>";

        public const string HtmlClassNewsLeadNoImg= @"
            <!DOCTYPE html>
            <html>
            <head>
                <meta charset='utf-8'>
                <meta http-equiv='X-UA-Compatible' content='IE=edge'>
                <title>Page Title</title>
                <meta name='viewport' content='width=device-width, initial-scale=1'>
                <link rel='stylesheet' type='text/css' media='screen' href='main.css'>
                <script src='main.js'></script>
            </head>
            <body>
                
                <p>Here also some text..<p>
                <div class=""news - lead no - img"">Text in news-body class.
                    <div class=""x-rwd-inl-c""><div class=""spolecznoscinet"" id=""spolecznosci-1304"">
                    </div>
                </div>

                
            </body>
            </html>";
    }
}
