$(function () {
    $("button[name='btn_DirectSend']").on("click", function () {
        if (confirm("정말 전송하시겠습니까?") == false) {
            return;
        }

        var id = $(this).data("id");
        var url = "";
        switch (id) {
            case 1:
                url = "/ExternalApi/MSXMLType";
                break;
            case 2:
                url = "/ExternalApi/HttpWebRequestType";
                break;
            case 3:
                url = "/ExternalApi/WebClientType";
                break;
            default:
                break;
        }

        $.getJSON(url, function (data) {
            alert(data.result);
        });
    });
});