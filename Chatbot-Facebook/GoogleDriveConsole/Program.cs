using Google.Apis.Drive.v3;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Download;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace GoogleDriveConsole
{


    class Program
    {
        static void Main(string[] args)
        {
            // Thiết lập phạm vi truy xuất dữ liệu Scope = DriveReadonly để upload file
            string[] Scopes = { DriveService.Scope.DriveReadonly };
            string ApplicationName = "Google Drive API .NET - Download File hoctoantap.com";
            UserCredential credential;
            using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                // Thông tin về quyền truy xuất dữ liệu của người dùng được lưu ở thư mục token.json
                string credPath = "token.json";

                // Yêu cầu người dùng xác thực lần đầu và thông tin sẽ được lưu vào thư mục token.json
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,  // Quyền truy xuất dữ liệu của người dùng
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;

                Console.WriteLine("Credential file saved to: " + credPath);
            }
            // Tạo ra 1 dịch vụ Drive API - Create Drive API service với thông tin xác thực và ApplicationName
            var driveService = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
            // ID File lấy tài khoản Google Drive của bạn 
            var fileId = "1jZOmG9JN26ZwHFMwNznUD67db1Ih7D6v";
            var request = driveService.Files.Get(fileId);
            // Khai báo 1 MemoryStream để nhận kết quả tải về
            var streamDownload = new System.IO.MemoryStream();
            // Đăng ký phương thức thực hiện sự kiện ProgressChanged
            request.MediaDownloader.ProgressChanged +=
                    (IDownloadProgress progress) =>
                    {
                        switch (progress.Status)
                        {
                            case DownloadStatus.Downloading:
                                {
                                    Console.WriteLine(progress.BytesDownloaded);
                                    break;
                                }
                            case DownloadStatus.Completed:
                                {
                                    Console.WriteLine("Download complete.");

                                    // Hoàn thành việc tải file xuống MemoryStream thì thực hiện việc chuyển MemoryStream ra FileStream thực tế
                                    using (FileStream fs = new FileStream("File From Google Drive.jpg", FileMode.OpenOrCreate))
                                    {
                                        streamDownload.WriteTo(fs);
                                        fs.Flush();
                                    }
                                    break;
                                }
                            case DownloadStatus.Failed:
                                {
                                    Console.WriteLine("Download failed.");
                                    break;
                                }
                        }
                    };
            // File được tải xuống dưới dạng MemoryStream lưu trong Ram
            request.Download(streamDownload);
            Console.ReadLine();
        }
    }
}
