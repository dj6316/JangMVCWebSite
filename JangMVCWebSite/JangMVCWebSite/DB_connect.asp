<%@ language="vbscript" codepage="65001" %>
<% Response.CharSet = "utf-8" %>
<%
Dim conn, rs

Set conn = Server.CreateObject("ADODB.Connection")
conn.Open "Provider=SQLOLEDB;Initial Catalog=bbs;Data Source=(local);User ID=userid;Password=password;"  'DB 설정문 

'*********************************************************
'  필수 입력 항목
'  $user_id : DirectSend 로그인 아이디
'  $key_code : DirectSend 발급된 인증코드
'*********************************************************
key_code = "key_code"
'user_id = "test"

code = key_code

mode = request.getParameter("mode")

If key_code = code Then
    If mode = "list" Then
		'****************************************************************
		'  - DB에 맞게 쿼리를 수정하시고, DB에 연결하여 리스트를 가져옵니다.
		'  - email정보를 가지고 있는 필드가 가장 먼저 표현되어야 합니다.
		'  - 필드와 필드 사이는 ','로 구분하며, 라인은 ‘\n’로 구분합니다.
		'  - note1 필드는 비고 항목으로 선택사항입니다.
		'***************************************************************
	   
		query = "SELECT `email` AS `email`, `name` AS `name`, `mobile` AS `mobile`, `note1` as `note1` FROM `user`"
		Set rs = conn.Execute(query)
		
		Response.Write "email,name,mobile,note1\r\n"
		
		'위 쿼리에서 불러온 정보들을 출력합니다. 
		Do While Not (rs.EOF Or rs.BOF)
			Response.Write rs("email") & "," & rs("name") & "," & rs("mobile") & "," & rs("note1") & "\r\n"
			rs.MoveNext
		Loop

    ElseIf mode = "count" Then
		
		'********************************************************************
		'  - DB에 연결하여 리스트 수를 가져옵니다.
  		'  - 이때는 고객사의 비즈니스 로직에 맞게 데이터를 단일 테이블에 정리 후 본 페이지를 통해서는 해당 단일 테이블에서 값을 가져올 수 있어야 합니다.
  		'  - directsend 측의 응답 대기 시간은 15초 입니다.
		'********************************************************************
		query = "SELECT COUNT(email) FROM `user`"
		Set rs = conn.Execute(query)
		rs.MoveNext
		Response.Write rs("count")

    Else
		Response.Write "[Error] No Parameter!"
    End If
Else 
    Response.Write "[Error] Match thd key_code!"
End If

rs.Close
rs = Nothing
conn.Close
Set conn = Nothing

%>