<%@  Language="VBScript" CodePage="65001" %>

<% Option Explicit %>
<% session.CodePage = "65001" %>
<% Response.CharSet = "UTF-8" %>
<% Response.buffer=true %>
<% Response.Expires = 0 %>

<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
</head>
<%		

	Dim data, httpRequest, postResponse

	Dim subject, body, sender, sender_name, username, recipients, names, key, file, img, bfile, bData, json
	
	'/* 
   	'* subject  : 받을 메일 제목
   	'* body  : 받을 메일 내용
   	'* sender : 발송자 메일주소
    '* sender_name : 발송자 이름
   	'* username : DirectSend 발급 ID
	'* recipients : 발송 할 고객 이메일 , 로 구분함. ex) aaa@naver.com,bbb@nate.com (',' 사이에 공백이 없게 해주세요!!)
   	'* key : DirectSend 발급 api key
   	'* 각 번호가 유효하지 않을 경우에는 발송이 되지 않습니다.
   	'*/ 	

	' 여기서부터 수정해주시기 바랍니다.

	subject = "[회원가입] 고객님 환영합니다."
	body = "고객님 환영합니다.."
	sender = "test@directsend.co.kr"
	sender_name = "DirectSend"
	username = "DirectSend id"
	recipients = "test1@directsend.co.kr,test2@directsend.co.kr"
	key = "DirectSend 발급 api key"

	' 실제 발송성공실패 여부를 받기 원하실 경우 주석을 해제하신 후 결과를 받을 URL을 입력해 주시기 바랍니다.
	Dim return_url
	return_url = "http://domain"

	' 예약발송 파라미터 추가
	Dim mail_type, start_reserve_time, end_reserve_time, remained_count
	mail_type = "NORMAL" 'NORMAL - 즉시발송 / ONETIME - 1회예약 / WEEKLY - 매주정기예약 / MONTHLY - 매월정기예약 / YEARLY - 매년정기예약
	start_reserve_time = "2017-05-17 10:00:00" ' 발송하고자 하는 시간
	end_reserve_time = "2017-05-17 10:19:10" ' 발송이 끝나는 시간 1회 예약일 경우 $start_reserve_time = $end_reserve_time
	' WEEKLY | MONTHLY | YEARLY 일 경우에 시작 시간부터 끝나는 시간까지 발송되는 횟수 Ex) type = WEEKLY, start_reserve_time = '2017-05-17 13:00:00', end_reserve_time = '2017-05-24 13:00:00' 이면 remained_count = 2 로 되어야 합니다.
	remained_count = 1

	' 필수 문구 파라미터 추가
	Dim agreement_text, deny_text, sender_info_text, logo_state, logo_path
	agreement_text = "본메일은 [$NOW_DATE] 기준, 회원님의 수신동의 여부를 확인한 결과 회원님께서 수신동의를 하셨기에 발송되었습니다."
	deny_text = "메일 수신을 원치 않으시면 [$DENY_LINK]를 클릭하세요.\nIf you don't want this type of information or e-mail, please click the [$EN_DENY_LINK]"
	sender_info_text = "사업자 등록번호:-- 소재지:ㅇㅇ시(도) ㅇㅇ구(군) ㅇㅇ동 ㅇㅇㅇ번지 TEL:--\nEmail: <a href='mailto:test@directsend.co.kr'>test@directsend.co.kr</a>"
	logo_state = 1	' logo 사용시 1 / 사용안할 시 0
	logo_path = "http://logoimage.com/image.png"

	Dim open, click, check_period, option_return_url
	open = 1    ' open 결과를 받으려면 주석을 해제 해주시기 바랍니다.
	click = 1   ' click 결과를 받으려면 주석을 해제 해주시기 바랍니다.
	check_period = 3    ' 트래킹 기간을 지정하며 3 / 7 / 15 / 30 일을 기준으로 지정하여 발송해 주시기 바랍니다. (단, 지정을 하지 않을 경우 결과를 받을 수 없습니다.)
	' 아래와 같이 http://domain 일 경우 http://domain?type=[click | open | reject]&mail_id=[MailID]&email=[Email] 과 같은 형식으로 request를 보내드립니다.
	option_return_url = "http://domrain/"

	' 첨부파일의 URL을 보내면 DirectSend에서 파일을 download 받아 발송처리를 진행합니다. 파일은 개당5MB 이하로 발송을 해야 하며, 파일의 구분자는 '|(shift+\)'로 사용하며 5개까지만 첨부가 가능합니다.
	Dim file_url, file_name
	file_url = "http://domain/test.png|http://domain/test1.png"
	' 첨부파일의 이름을 지정할 수 있도록 합니다. 첨부파일의 이름은 순차적(http://domain/test.png - image.png, http://domain/test1.png - image2.png) 와 같이 적용이 되며, file_name을 지정하지 않은 경우 마지막의 파일의 이름이로 메일에 보여집니다.
	file_name = "image.png|image2.png"

    Dim bodytag
    bodytag = 1  'HTML이 기본값 입니다. 메일 내용을 텍스트로 보내실 경우 주석을 해제 해주시기 바랍니다.

	'여기까지 수정해주시기 바랍니다.		

	data = "subject=" & Server.URLEncode(subject)
	data = data & "&body=" & Server.URLEncode(body)
	data = data & "&sender=" & Server.URLEncode(sender)
	data = data & "&sender_name=" & Server.URLEncode(sender_name)
	data = data & "&username=" & Server.URLEncode(username)
	data = data & "&recipients=" & Server.URLEncode(recipients)

	' 예약 관련 파라미터
	data = data & "&mail_type=" & Server.URLEncode(mail_type)
	data = data & "&start_reserve_time=" & Server.URLEncode(start_reserve_time)
	data = data & "&end_reserve_time=" & Server.URLEncode(end_reserve_time)
	data = data & "&remained_count=" & Server.URLEncode(remained_count)

	' 필수 안내문구
	data = data & "&agreement_text=" & Server.URLEncode(agreement_text)
	data = data & "&deny_text=" & Server.URLEncode(deny_text)
	data = data & "&sender_info_text=" & Server.URLEncode(sender_info_text)
	data = data & "&logo_state=" & Server.URLEncode(logo_state)
	data = data & "&logo_path=" & Server.URLEncode(logo_path)

	' 발송 결과 측정 항목
	'data = data & "&open=" & Server.URLEncode(open)
	'data = data & "&click=" & Server.URLEncode(click)
	data = data & "&check_period=" & Server.URLEncode(check_period)
	data = data & "&option_return_url=" & Server.URLEncode(option_return_url)

	'data = data & "&return_url=" & Server.URLEncode(return_url)

	'data = data & "&file_url=" & Server.URLEncode(file_url)
	'data = data & "&file_name=" & Server.URLEncode(file_name)

    '메일 내용 텍스트로 보내실 경우 주석 해제
	'data = data & "&bodytag=" & Server.URLEncode(bodytag)

	data = data & "&key=" & Server.URLEncode(key)
	data = data & "&type=" & Server.URLEncode("asp")

	Set httpRequest = Server.CreateObject("MSXML2.ServerXMLHTTP")
	' return_url이 없는 경우 사용하는 URL
	httpRequest.Open "POST", "https://directsend.co.kr/index.php/api/v2/mail/utf8", False
	' return_url이 있을 경우 사용하는 URL
	'httpRequest.Open "POST", "https://directsend.co.kr/index.php/api/result_v2/mail/utf8", False
	httpRequest.SetRequestHeader "Content-Type", "application/x-www-form-urlencoded"
	httpRequest.Send data

	postResponse = httpRequest.ResponseText

	Response.Write postResponse

	'/*
		'* response의 실패
   		'*  {"status":101}
  	'*/    

  	'/*    
    	'* response 성공
    	'* {"status":0}
    	'* 발송된 sms Id, 잔여 포인트, 성공 코드번호.
  	'*/    

    '** status code
    '0   : 정상발송
    '100 : POST validation 실패
    '101 : 회원정보가 일치하지 않음
    '102 : subject, message 정보가 없습니다.
    '103 : sender 이메일이 유효하지 않습니다.
    '104 : recipient 이메일이 유효하지 않습니다.
    '105 : 본문에 포함하면 안되는 확장자가 있습니다.
    '106 : body validation 실패
    '107 : 받는 사람이 없습니다.
    '109 : return_url이 없습니다.
    '110 : 첨부파일이 없습니다.
    '111 : 첨부파일의 개수가 5개를 초과합니다.
    '112 : 첨부파일의 Size가 5MB를 초과합니다.
    '113 : 첨부파일이 다운로드 되지 않았습니다.
    '205 : 잔액부족
    '999 : Internal Error.
    '**

Function Encode(Str)
'Use ADODB.Stream to write Ansi string to Unicode stream
Dim objstream, temp, bArray, objXML, objNode, Stream
Set objStream = CreateObject("ADODB.Stream")
objStream.Type = 2
objStream.Open
objStream.Charset = "unicode"
objStream.WriteText Str
objstream.Flush

'Read the stream back as a byte array
objStream.Position = 0
objStream.Type = 1
temp = objstream.read(2) 'read two bytes of the stream to discard the byte order mark
bArray = objStream.Read
objStream.Close
'Convert byte array to Base64
set objXML = createobject("MSXML2.DOMDocument.3.0")
Set objNode = objXML.createElement("b64")
objNode.dataType = "bin.base64"
objNode.nodeTypedValue = bArray
Encode = objNode.Text
Set Stream = Nothing
set objNode = nothing
set objXML = nothing
End Function
%>
