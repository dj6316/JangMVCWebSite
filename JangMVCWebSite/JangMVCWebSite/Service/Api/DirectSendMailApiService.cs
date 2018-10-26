using JangMVCWebSite.Models.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using MSXML2;
using System.IO;
using System.Text;
using JangMVCWebSite.Extension;

namespace JangMVCWebSite.Service.Api
{
    public class DirectSendMailApiService
    {
        public const string ApiKey = "v6lqgjFOnazHoOy";

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

            Stream dataStream = request.GetRequestStream();
            dataStream.Write(Encoding.UTF8.GetBytes(mailInfo), 0, mailInfo.Length);
            dataStream.Close();

            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            response.Close();

            return responseFromServer;
        }

        public void SendRequestHttpWebRequest_Basic2()
        {
            var mailInfo = SetMailInfo().GetQueryString();
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://directsend.co.kr/index.php/api/v2/mail/utf8");
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = mailInfo.Length;

            using(var stream = request.GetRequestStream())
            {
                stream.Write(Encoding.UTF8.GetBytes(mailInfo), 0, mailInfo.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
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


        public DirectSendMailModel SetMailInfo()
        {
            var info = new DirectSendMailModel();
            info.Subject = "Direct 테스트 메일을 발송합니다.";
            info.Body = "";
            info.Sender = "test@DirectSend.co.kr";
            info.Sender_Name = "dj6316";
            info.Recipients = "dj6316@naver.com";
            info.Key = ApiKey;
            //실제 발송성공실패 여부를 받기 원하실 경우 주석을 해제하신 후 결과를 받을 URL을 입력해 주시기 바랍니다.
            info.Return_url = "http://domain";
            //NORMAL - 즉시발송 / ONETIME - 1회예약 / WEEKLY - 매주정기예약 / MONTHLY - 매월정기예약 / YEARLY - 매년정기예약
            info.Mail_type = "NOMAL";
            info.Start_reserve_time = "";
            info.End_reserve_time = "";
            info.Remained_count = 1;
            info.Agreement_text = "觛蝁懫糬邵玫煮寪肥縶╪肢 欞肥恰扁垢邵垢恰姻垢疝穹狗社玥炊";
            info.Deny_text = "URL";
            info.Sender_info_text = "豇齱蒱齌儃区欬閞縶";
            info.Logo_state = 1;
            info.Logo_path = "http://logoimage.com/image.png";
            info.Open = 1;
            info.Click = 1;
            info.Check_period = 3;
            info.Option_return_url = "http://domain";
            info.File_url = "http://domain/test.png|http://domain/test1.png";
            info.File_name = "image.png|image2.png";
            info.Bodytag = 1;
            return info;
        }
    }
}