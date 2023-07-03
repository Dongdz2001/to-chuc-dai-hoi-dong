<template>
    <div class="footer-hus">
            <div class="row">
                <div class="col-12 col-md-2 ml-14">
                    <div class="footer-single-widget">
                        <a href="javascript:void(0);">
                            <img style="padding-bottom: 20px;"
                                src="https://hus.vnu.edu.vn/static//HUS/img/core-img/logofooter.png"
                                alt="Đại học khoa học tự nhiên - Đại học QGHN"></a> <br>
                        <a href="https://www.google.com/maps/place/VNU+University+of+Science/@20.9959394,105.8057838,17z/data=!3m1!4b1!4m5!3m4!1s0x3135acbf0df2c0e5:0xd740a66998e1a0ed!8m2!3d20.9959344!4d105.8079725"
                            target="_blank" title="Bản đồ chỉ đường">
                            <img src="https://hus.vnu.edu.vn/static//HUS/img/core-img/iconmap.png"
                                alt="Bản đồ chỉ đường" style="padding-bottom: 2vh;"></a>
                    </div>
                </div>
                <div class="col-12 col-md-4 section-padding-1">
                    <h4>TRƯỜNG ĐẠI HỌC <br> KHOA HỌC TỰ NHIÊN</h4>
                    <p class="p-daihoc"><strong>ĐỊA CHỈ</strong>: 334 Nguyễn Trãi - Thanh Xuân - Hà Nội</p>
                    <p class="p-daihoc"><strong>Điện thoại</strong>: (84) 0243-8584615 / 8581419</p>
                    <p class="p-daihoc"><strong>Fax</strong>: (84) 0243-8583061</p>
                    <p class="p-daihoc"><strong>Email</strong>: hus@vnu.edu.vn hoặc admin@hus.edu.vn</p>
                </div>
                <div class="col-12 col-md-3">
                    <h4>THÔNG TIN HỮU ÍCH</h4>
                    <div class="footer-single-widget">
                        <ul class="footer-menu d-flex flex-column">
                            <li><a href="http://vnu.edu.vn/home/" target="_blank">Website VNU</a> --- <a href="/tai-lieu-bieu-mau.html">Tài liệu biểu mẫu</a> </li>
                            
                            <li><a href="http://mail.vnu.edu.vn/" target="_blank">Thư điện tử VNU</a> --- <a href="http://data.hus.vnu.edu.vn/" target="_blank">Tài nguyên số</a></li>
                        
                            <li><a href="http://mail.hus.edu.vn/" target="_blank">Thư điện tử HUS</a> --- <a href="javascript:void(0);">Liên kết Website</a></li>
                            
                        </ul>
                    </div>
                </div>


                <div class="col-12 col-md-2 ">
        <h4>Mạng xã hội</h4>
        <p class="social">
            <a href="https://www.facebook.com/HusFanpage/" target="_blank">
                <i class="fab fa-facebook"></i>Fanpage Trường ĐHKHTN
            </a>
        </p>
        <p class="social">
            <a href="https://www.facebook.com/VNUHUSFanpage/" target="_blank"> 
                <i class="fab fa-facebook"></i>Fanpage Tư vấn tuyển sinh
            </a>
        </p>
    </div>  
            </div>

        <div class="copywrite" style="width: 100%; text-align: left; padding-left: 10vh;" >
  
                <div class="row" >
                    <div class="col-md-5 pt-3">
                        <h5>
                            Bản quyền © {{ currentYear }} Trường ĐHKHTN-ĐHQGHN
                        </h5>
                    </div>
                </div>
            </div>
        </div>

</template>

<script>
export default {
    data() {
        return {
            currentYear: new Date().getFullYear(),
        };
    },
};
</script>
<style scoped>
.footer-hus {
    background-color: #1662B3;
    color: white;
    padding-top: 20px;
    width: 100%;
}

.footer-single-widget a,
.footer-menu a,
.social a {
    color: white;
    font-size: 14px; /* Điều chỉnh kích cỡ chữ của các liên kết */
}

.footer-single-widget a:hover,
.footer-menu a:hover,
.social a:hover {
    color: #ffd700;
}

.footer-menu {
    list-style: none; /* Loại bỏ các dấu gạch đầu dòng mặc định */
    padding: 0; /* Loại bỏ padding mặc định */
}

.footer-menu li {
    margin-bottom: 10px; /* Thêm khoảng cách giữa các mục trong danh sách */
}

.copywrite {
    background-color: #006666;
    color: white;
    padding: 10px 0;
    text-align: center; /* Đặt nội dung copywrite ở chế độ căn giữa */
}

.copywrite p {
    color: white;
    font-size: 14px; /* Điều chỉnh kích cỡ chữ của phần copywrite */
}

.social i {
    padding-right: 5px;
    font-size: 20px; /* Điều chỉnh kích cỡ chữ của biểu tượng mạng xã hội */
}

.footer-single-widget img:hover {
    transform: scale(1.1);
}

.fab.fa-facebook-f {
    color: red;
}

.p-daihoc{
    text-align: left;
    margin-left: 5vh;
}

</style>
    