﻿

using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chatbot.Common.Helper
{
    public class HtmlHelper
    {
        public static string ConvertHtmlToImage(string source)
        {
            //source = @"  
            //    <!DOCTYPE html>  
            //        <html>  
            //            <head>  
            //                <style>  
            //                    table {  
            //                      font-family: arial, sans-serif;  
            //                      border-collapse: collapse;  
            //                      width: 100%;  
            //                    }  

            //                    td, th {  
            //                      border: 1px solid #dddddd;  
            //                      text-align: left;  
            //                      padding: 8px;  
            //                    }  

            //                    tr:nth-child(even) {  
            //                      background-color: #dddddd;  
            //                    }  
            //              </style>  
            //             </head>  
            //        <body>  

            //            <h2>HTML Table</h2>  

            //            <table>  
            //              <tr>  
            //                <th>Trần Văn Quang</th>  
            //                <th>AHIHI</th>  
            //              </tr>  
            //              <tr>  
            //                <td>Kaushik</td>  
            //                <td>India</td>  
            //              </tr>  
            //              <tr>  
            //                <td>Bhavdip</td>  
            //                <td>America</td>  
            //              </tr>  
            //              <tr>  
            //                <td>Faisal</td>  
            //                <td>Australia</td>  
            //              </tr>  
            //            </table>  
            //         </body>  
            //        </html> ";
            StartBrowser(source);
            return "test";
        }
        private static void StartBrowser(string source)
        {
            var th = new Thread(() =>
            {
                var webBrowser = new WebBrowser();
                webBrowser.ScrollBarsEnabled = false;
                webBrowser.IsWebBrowserContextMenuEnabled = true;
                webBrowser.AllowNavigation = true;

                webBrowser.DocumentCompleted += webBrowser_DocumentCompleted;
                webBrowser.DocumentText = source;

                Application.Run();
            });
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        static void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            var webBrowser = (WebBrowser)sender;
            using (Bitmap bitmap = new Bitmap(1000, 1000, PixelFormat.Format16bppRgb555))
            {
                webBrowser.DrawToBitmap(bitmap, new Rectangle(0, 0, 1000, 1000));
                bitmap.Save(@"covid-vn2.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            }

        }

        public static string ConvertHtmlToImageVersion2(string source, ref string fileName)
        {
            Image image = TheArtOfDev.HtmlRenderer.WinForms.HtmlRender.RenderToImage(source);
            image.Save(fileName + ".png", ImageFormat.Png);
            return fileName;
        }


    }
}
