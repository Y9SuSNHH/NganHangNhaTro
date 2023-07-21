$(document).ready(function () {
    loginSusess();
})

// Biến
var btnEditSave = document.getElementById('btn-edit-save');

// Lớp Filter - đối tượng điều kiện lọc
class Filter {
    //constructor(filterType, value, fieldName) {
    //    this.FilterType = filterType;
    //    this.FilterValue = value;
    //    this.FieldName = fieldName;
    //}
}

// Lớp MotelJS
class MotelJS {
    constructor() {
        this.initEvents();
    }
    // Hàm xử lý sự kiện cho các nút
    initEvents() {

        // Sự kiện nhấn nút Sửa
        //btnEditSave.onclick = function () {
        //    motelJS.RedirectToEditMotel();
        //};
    }

    // ============ Hàm thao tác với dữ liệu ============
    RedirectToEditMotel() {
        var xhttp = new XMLHttpRequest(); // Create an XMLHttpRequest object
        // Define a callback function
        xhttp.onload = function () {
            // Here you can use the Data
            // Xử lý dữ liệu nhận được (nếu cần)
            var newContent = xhttp.responseText; // Nội dung của view mới
        }
        // Send a request
        xhttp.open("GET", "Edit.cshtml");
        xhttp.send();
    }

}

var motelJS = new MotelJS();

// Các hàm bổ trợ
function loginSusess() {
    // Tạo XMLHttpRequest object
    var xhr = new XMLHttpRequest();

    // Xác định phương thức và URL endpoint
    xhr.open('GET', '/Auth/GetUserNameFromSession', true);

    // Xử lý sự kiện khi yêu cầu hoàn tất
    xhr.onload = function () {
        if (xhr.status === 200) {
            var data = xhr.responseText;
            if (data != "") {
                document.getElementById('nav-btn-login-register').style.display = "none";
                document.getElementById('nav-user').style.display = "block";
            } else {
                document.getElementById('nav-btn-login-register').style.display = "block";
                document.getElementById('nav-user').style.display = "none";
            }
            console.log(data); // Hiển thị tên người dùng trong Session
        } else {
            console.error('Yêu cầu không thành công. Mã lỗi:', xhr.status);
        }
    };

    // Xử lý sự kiện khi có lỗi
    xhr.onerror = function () {
        console.error('Đã xảy ra lỗi trong quá trình gửi yêu cầu.');
    };
    // Gửi yêu cầu
    xhr.send();

}

//
function directionLogin() {
    var form = document.querySelector('.auth-login-form');
    var formData = new FormData(form);
    var xmlHttp = new XMLHttpRequest();
    xmlHttp.onreadystatechange = function () {
        if (xmlHttp.readyState == 4) {
            if (xmlHttp.status == 200) {
                console.log(xmlHttp.response);
                console.log(xmlHttp.responseText);
            } else {
                console.error('Error: ' + xmlHttp.statusText);
            }
        }
    }

    xmlHttp.open('POST', form.action, true);
    xml.send(formData);
}

