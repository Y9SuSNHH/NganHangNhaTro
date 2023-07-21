//$(document).ready(function () {
//    loginSuccess();
//})

document.addEventListener("DOMContentLoaded", function () {
    loginSuccess();
});

// Biến
var btnEditSave = document.getElementById('btn-edit-save');
var btnSearch = document.getElementById('btn-search');
var btnTest = document.getElementById('btn-test');

// Lớp MotelJS
class MotelJS {
    constructor() {
        this.initEvents();
    }

    // Hàm xử lý sự kiện cho các nút
    initEvents() {
        // Sự kiện nhấn nút tìm kiếm
        btnSearch.addEventListener('click', function () {
            // Lấy giá trị từ input tìm kiếm
            var searchTerm = document.getElementById("motel-search").value;
            //alert('thanh cong');
            console.log(123);
            motelJS.SearchMotelByString(searchTerm);
        });
        //
        //btnTest.onclick = function () {
        //    alert('thanh cong');
        //    console.log(123);
        //}
    }

    // ============ Hàm thao tác với dữ liệu ============
    // Hàm tìm kiếm thông tin nhà trọ
    SearchMotelByString(searchTerm) {
        // Tạo XmlHttpRequest
        var xhr = new XMLHttpRequest();
        // Xác định phương thức gửi và url
        xhr.open("GET", `/Motel/SearchMotelByString?searchTerm=${encodeURIComponent(searchTerm)}`, true);

        // Định nghĩa hàm xử lý khi nhận phản hồi từ máy chủ
        xhr.onreadystatechange = function () {
            if (xhr.readyState === XMLHttpRequest.DONE) {
                if (xhr.status === 200) {
                    // Xử lý kết quả tìm kiếm ở đây
                    // Ví dụ: hiển thị kết quả lên trang web
                    var resultDiv = document.getElementById("searchResult");
                    resultDiv.innerHTML = xhr.responseText;
                }
                else {
                    // Xử lý lỗi nếu có
                    console.error("Lỗi khi gửi yêu cầu tìm kiếm. Mã lỗi: " + xhr.status);
                }
            }
        }

        // Gửi yêu cầu
        xhr.send();
    }
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

// ============ Các hàm bổ trợ ============
function loginSuccess() {
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
        }
        else {
            console.log('Yêu cầu không thành công. Mã lỗi:', xhr.status);
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

