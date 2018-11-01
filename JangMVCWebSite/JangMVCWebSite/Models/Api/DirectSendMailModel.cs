namespace JangMVCWebSite.Models.Api
{
    public class DirectSendMailModel
    {
        #region 필수 데이터

        /// <summary>
        /// 제목
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// 본문
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// 발신 Email
        /// </summary>
        public string Sender { get; set; }

        /// <summary>
        /// 발신자 이름
        /// </summary>
        public string Sender_Name { get; set; }

        /// <summary>
        /// DirectSend ID
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 받는 이의 E-mail ','으로 구분
        /// </summary>
        public string Recipients { get; set; }

        /// <summary>
        /// [Api 연동 관리] 발급 받은 API Key
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// asp
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 즉시발송 / 예약 발송 구분
        /// NORMAL - 즉시발송 / ONETIME - 1회예약 / WEEKLY - 매주정기예약 / MONTHLY - 매월정기예약 / YEARLY - 매년정기예약
        /// </summary>
        public string Mail_type { get; set; }

        #endregion 필수 데이터

        /// <summary>
        /// 메일 내용을 텍스트로 보낼때 1(기본값은 HTML이고 따로 설정 안해도 됨)
        /// </summary>
        public int Bodytag { get; set; }

        /// <summary>
        /// 결과 값을 받을 도메인
        /// 실제 발송성공실패 여부를 받기 원하실 경우 주석을 해제하신 후 결과를 받을 URL을 입력해 주시기 바랍니다.
        /// </summary>
        public string Return_url { get; set; }

        /// <summary>
        /// 발송 측정결과 Open 값을 받을 경우 1
        /// </summary>
        public int Open { get; set; }

        /// <summary>
        /// 발송 측정결과 Click 값을 받을 경우 1
        /// </summary>
        public int Click { get; set; }

        /// <summary>
        /// 트래킹 기간을 설정 3,7,15,30일 기준)
        /// </summary>
        public int Check_period { get; set; }

        /// <summary>
        /// 위의 측정 결과를 받고 싶은 URL입력
        /// </summary>
        public string Option_return_url { get; set; }

        /// <summary>
        /// 예약시작시간
        /// </summary>
        public string Start_reserve_time { get; set; }

        /// <summary>
        /// 예약종료시간
        /// </summary>
        public string End_reserve_time { get; set; }

        /// <summary>
        /// 예약 기간동안 발송 횟수를 넣어준다.
        /// </summary>
        public int Remained_count { get; set; }

        /// <summary>
        /// 수신동의 문구를 넣어준다.
        /// </summary>
        public string Agreement_text { get; set; }

        /// <summary>
        /// 수신거부 문구를 넣어준다.
        /// </summary>
        public string Deny_text { get; set; }

        /// <summary>
        /// 발신자 정보 문구를 넣어준다.
        /// </summary>
        public string Sender_info_text { get; set; }

        /// <summary>
        /// Logo를 사용할 때 1/ 사용하지 않을 때 0
        /// </summary>
        public int Logo_state { get; set; }

        /// <summary>
        /// 로고 이미지 경로(Logo_state 1일 때 path가 없으면 DirectSend에서 등록된 이미지 사용
        /// </summary>
        public string Logo_path { get; set; }

        /// <summary>
        /// 첨부파일의 URL을 보내면 DirectSend에서 파일을 download 받아 발송처리를 진행함. 개당 10M이하, 파일 구분자는 '|(shift+\)'로 사용 5개까지 첨부 가능
        /// </summary>
        public string File_url { get; set; }

        /// <summary>
        /// 첨부파일 이름 지정. 첨부파일은 순차적, 지정하지 않을 경우 마지막 파일 이름으로 메일 보여짐
        /// </summary>
        public string File_name { get; set; }
    }
}