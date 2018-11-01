using JangMVCWebSite.Extension;
using JangMVCWebSite.Models.Api;
using MSXML2;
using System.IO;
using System.Net;
using System.Text;

namespace JangMVCWebSite.Libs.Service.Api
{
    public class DirectSendMailApiService
    {
        private const string ApiKey = "v6lqgjFOnazHoOy";

        public string SendServerXmlHttp()
        {
            ServerXMLHTTP srv = new ServerXMLHTTP();
            srv.open("POST", "https://directsend.co.kr/index.php/api/v2/mail/utf8", false);
            srv.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
            srv.send(SetMailInfo().GetQueryString());
            return srv.responseText;
        }

        public string SendHttpWebRequest()
        {
            var mailInfo = SetMailInfo().GetQueryString();
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://directsend.co.kr/index.php/api/v2/mail/utf8");
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = mailInfo.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(Encoding.UTF8.GetBytes(mailInfo), 0, mailInfo.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();
            return new StreamReader(response.GetResponseStream()).ReadToEnd();
        }

        public string SendWebClient()
        {
            var mailInfo = SetMailInfo().GetQueryString();
            using (var wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                return wc.UploadString("https://directsend.co.kr/index.php/api/v2/mail/utf8", "POST", mailInfo);
            }
        }

        private DirectSendMailModel SetMailInfo()
        {
            var info = new DirectSendMailModel()
            {
                Subject = "Direct 테스트 메일을 발송합니다.",
                Body = "TESTMAILE입니당",
                Sender = "test@DirectSend.co.kr",
                Sender_Name = "TEST",
                UserName = "dj6316",
                Recipients = "dj6316@naver.com",
                Mail_type = "NORMAL",
                //info.Start_reserve_time = "",
                //info.End_reserve_time = "",
                //info.Remained_count = 1,
                //Agreement_text = "觛蝁懫糬邵玫煮寪肥縶╪肢 欞肥恰扁垢邵垢恰姻垢疝穹狗社玥炊",
                //Deny_text = "메일 수신을 원치 않으시면 [$DENY_LINK]를 클릭하세요.",
                //Sender_info_text = "豇齱蒱齌儃区欬閞縶",
                //Logo_state = 1,
                //Logo_path = "http://logoimage.com/image.png",
                //info.Open = 1,
                //info.Click = 1,
                //Check_period = 3,
                //Option_return_url = "http://domain",
                //info.Return_url = "http://domain",
                //info.File_url = "http://domain/test.png|http://domain/test1.png",
                //info.File_name = "image.png|image2.png",
                //info.Bodytag = 1;
                Key = ApiKey,
                Type = "asp"
            };
            return info;
        }
    }
}