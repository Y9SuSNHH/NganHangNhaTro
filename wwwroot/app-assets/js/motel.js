//$(document).ready(function () {
//    loginSuccess();
//})

document.addEventListener("DOMContentLoaded", function () {
    loginSuccess();
});

// Biến
var btnEditSave = document.getElementById('btn-edit-save');
var btnTest = document.getElementById('btn-test');

// Lớp MotelJS
class MotelJS {
    constructor() {
        this.initEvents();
    }

    // Hàm xử lý sự kiện cho các nút
    initEvents() {
        // Sự kiện nhấn nút tìm kiếm
        var btnSearch = document.getElementById('btn-search');
        btnSearch.addEventListener('click', function () {
            // Lấy giá trị từ input tìm kiếm
            var searchTerm = document.getElementById("motel-search").value;
            motelJS.SearchMotelByString(searchTerm);
        });
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
                    // Chuyển đổi JSON response thành đối tượng JavaScript
                    var jsonResponse = JSON.parse(xhr.responseText);
                    if (jsonResponse.length > 0) {
                        var resultDiv = document.getElementById("wishlist");
                        resultDiv.innerHTML = "";
                        // Duyệt qua từng phần tử trong danh sách kết quả tìm kiếm
                        for (var motel of jsonResponse) {
                            // Hiển thị thông tin từng đối tượng motel lên view
                            resultDiv.innerHTML += `
                            <div class="card ecommerce-card">
                                <div class="item-img text-center">
                                    <a asp-controller="Motel" asp-action="Detail" asp-route-id="${motel.id}" class="motel-link">
                                        <img src="${motel.image}" class="img-fluid motel-img" alt="img-placeholder">
                                    </a>
                                </div>
                                <div class="card-body">
                                    <div class="item-wrapper">
                                        <div class="item-rating">
                                            <ul class="unstyled-list list-inline"></ul>
                                        </div>
                                        <div class="item-cost">
                                            <h6 class="item-price">${motel.price} đ</h6>
                                        </div>
                                    </div>
                                    <div class="item-name">
                                        <a href="app-ecommerce-details.html">${motel.title}</a>
                                    </div>
                                    <p class="card-text item-description">
                                        Địa chỉ: ${motel.address}
                                    </p>
                                </div>
                            </div>`;
                        }
                    } else {
                        alert("Không tìm thấy kết quả");
                    }
                }
                else {
                    // Xử lý lỗi nếu có
                    console.log("Lỗi khi gửi yêu cầu tìm kiếm. Mã lỗi: " + xhr.status);
                }
            }
        }

        // Gửi yêu cầu
        xhr.send();
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

// Đọc file ảnh và hiển thị ảnh
function readURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            var elementImg = document.getElementById('img-edit');
            elementImg.src = e.target.result;
            //$('#img-edit').attr('src', e.target.result).width(150).height(200);
        };
        reader.readAsDataURL(input.files[0]);
    }
}


