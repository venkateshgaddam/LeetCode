function checkUser() {
    var userName = $("#txtUserName").val();
    var password = $("#txtPassword").val();
    var userData = $("#frmLogin").serialize();

    $.ajax({
        url: "http://localhost:53768/api/login/check/dhoni/dhoni",

        dataType: "text",
        //data: {'username': userName, 'password': password },
        crossdomain: true,
        contentType: "text/plain",
        type: "GET",
        //define a contentType of your request
        secure: true,
        //jsonpCallback: "jsonpcallback",
        headers: {
            "Access-Control-Allow-Origin": "*",
            "Access-Control-Allow-Headers": "*"
        },
        success: function (username) {
            console.log("Success")
            console.log(username);
            $('#exampleModal').modal('hide');
            window.sessionStorage.setItem("User", username);
        },
        error: function (xhr, errorType, exception) {
            var errorMessage = exception || xhr.statusText;
            console.log(exception);
            console.log(xhr);
            alert(errorType + ";  " + exception + "  Status:: " + xhr.statusText);
        }
    });
}
function addCookie() {
    var button = document.querySelector("#cookieConsent button[data-cookie-string]");
    button.addEventListener("click", function (event) {
        document.cookie = button.dataset.cookieString;
    }, false);
    document.getElementById("bannerPrivacyPolicy").style.display = 'none';
}


//function checkUser() {
        //    var userName = $("#txtUserName").val();
        //    var password = $("#txtPassword").val();
        //    var userData = $("#frmLogin").serialize();

        //    $.ajax({
        //        url: "http://localhost:53768/api/login/check/dhoni/dhoni",

        //        dataType: "text",
        //        //data: { 'username': userName, 'password': password },
        //        crossdomain: true,
        //        contentType: "text/plain",
        //        type: "GET",
        //        //define a contentType of your request
        //        secure: true,
        //        //jsonpCallback: "jsonpcallback",
        //        headers: {
        //            "Access-Control-Allow-Origin": "*",
        //            "Access-Control-Allow-Headers": "*"
        //        },
        //        success: function (response) {
        //            console.log("Success")
        //            // myfunc(data);
        //            console.log(response);
        //            alert(response);
        //            //alert(errorType + JSON.stringify(eData));
        //        },
        //        error: function (xhr, errorType, exception) {
        //            var errorMessage = exception || xhr.statusText;
        //            console.log(exception);
        //            console.log(xhr);
        //            alert(errorType + ";  " + exception + "  Status:: " + xhr.statusText);
        //        }
        //    });
        //}
        //function addCookie() {
        //    var button = document.querySelector("#cookieConsent button[data-cookie-string]");
        //    button.addEventListener("click", function (event) {
        //        document.cookie = button.dataset.cookieString;
        //    }, false);
        //    document.getElementById("bannerPrivacyPolicy").style.display = 'none';
        //}
