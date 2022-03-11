window.addEventListener("DOMContentLoaded", (e) => {

    function getCookie(name) {
        var cookieArr = document.cookie.split(";");
        for (var i = 0; i < cookieArr.length; i++) {
            var cookiePair = cookieArr[i].split("=");
            if (name == cookiePair[0].trim()) {
                return decodeURIComponent(cookiePair[1]);
            }
        }
        return null;
    }
    

    function checkCookie() {
        var username = getCookie("username");
        //console.log("username:  " + username);
        console.log("username:  " + username);

        //username je v cookiju
        if (username != null) {
            var loginElement = document.getElementById("loginElement");
            var registrationElement = document.getElementById("registracijaElement");
            var odjavaElement = document.getElementById("odjavaElement");

            loginElement.style.display = "none";
            registrationElement.style.display = "none";
            odjavaElement.style.display = "block";

        }
        else {
            var loginElement = document.getElementById("loginElement");
            var registrationElement = document.getElementById("registracijaElement");
            var odjavaElement = document.getElementById("odjavaElement");

            loginElement.style.display = "block";
            registrationElement.style.display = "block";
            odjavaElement.style.display = "none";
        }
    }

    function clickOdjava() {
        var odjavaElement = document.getElementById("odjavaElement");
        odjavaElement.addEventListener("click", odjava)
    }

    function odjava() {
        document.cookie = "username= ; expires = Thu, 01 Jan 1970 00:00:00 GMT"
        document.cookie = "userGuid= ; expires = Thu, 01 Jan 1970 00:00:00 GMT"
        document.cookie = "userId= ; expires = Thu, 01 Jan 1970 00:00:00 GMT"
    }

    checkCookie();
    clickOdjava();

});