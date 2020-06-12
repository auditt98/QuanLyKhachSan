
var UserController = {
    init: function () {
        //UserController.loadDataServer();
        UserController.registerEven();
        UserController.loadDataServer();
    },
    registerEven: function () {
        $(".btnAdd").off('click').on('click', function (e) {
            e.preventDefault();
            var btnplus = $(this);
            var id = btnplus.data('id');
            var check_in = $('#txtCheck_in').val();
            var check_out = $('#txtCheck_out').val();
            var adults = $('#txtadults').html();
            var children = $('#txtchildren').html();
            $.ajax({
                data: { id, check_in, check_out, adults, children},
                url: '/Home/ADD',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        UserController.output(res.data);
                    }
                }
            })
        })
    },
    output: function (data) {
        if (data == null) {
            $('.reservation__empty').show();
            $('.btncheckuot').hide();
        }
        else {
            var table = $('.thongTinDatPhong');
            table.html('');
            $('.reservation__empty').hide();
            var tongTien = 0;
            $.each(data, function (i, item) {
                var ngayDen = new Date(item.ngaydukienden);            
                var ngayDi = new Date(item.ngaydukiendi);
                table.append("<div class=\"reservation__section reservation__section--dates\"><div class=\"reservation-dates\" ><div class=\"reservation-date reservation-date--checkin\"><span class=\"reservation-date__title\">Ngày đến</span><div class=\"reservation-date__date\"><span class=\"reservation-date__day\" data-date-format=\"d\">" + ngayDen.getDate() + "</span><span class=\"reservation-date__week\" data-date-format=\"l\">Thứ " + ngayDen.getDay() + "</span><span class=\"reservation-date__year\" data-date-format=\"M Y\">Th" + ngayDen.getMonth() + " " + ngayDen.getFullYear() + "</span></div></div><div class=\"reservation-date__arrow\" ><i class=\"aficon aficon-arrow-forward\"></i></div ><div class=\"reservation-date reservation-date--checkout\"><span class=\"reservation-date__title\">Ngày đi</span><div class=\"reservation-date__date\"><span class=\"reservation-date__day\" data-date-format=\"d\">" + ngayDi.getDate() + "</span><span class=\"reservation-date__week\" data-date-format=\"l\">Thứ " + ngayDi.getDay() + "</span><span class=\"reservation-date__year\" data-date-format=\"M Y\">Th" + ngayDi.getMonth() + " " + ngayDi.getFullYear() + "</span></div></div></div ></div>")
                table.append(function () {
                    tongTien += item.gia * item.songay;
                    var str = "<div class=\"reservation__section reservation__section--room\"><div class=\"roomdetails-room\"><dl class=\"roomdetails-room__list\"><dt>Phòng</dt><dd>" + item.tenloaiphong + "</dd><dt>Ở lại</dt><dd>" + item.songay + " ngày, <span class=\"gembooking_guest__adults\"> " + item.nguoilon + ". người lớn</span> , <span class=\"gembooking_guest__children\">" + item.trecon + " trẻ em</span></dd></dl><dl class=\"roomdetails-room__list--price\"><dt>Giá			<small>(" + item.songay + " đêm x " + item.gia + " đ)</small></dt><dd><span class=\"gembooking-price \"><span class=\"gembooking-price__amount\">" + item.gia * item.songay + "</span>&nbsp;<span class=\"gembooking-price__symbol\">&#8363;</span></span></dd></dl> <div class=\"roomdetails-room__actions\"><a href=\"\" class=\"remove-selected-room\">Xóa</a></div></div></div >";
                    return str;

                });
            });
            table.append("<div class=\"reservation__section reservation__section--totals\" ><dl><dt><strong>Tổng</strong></dt><dd><span class=\"gembooking-price \"><span class=\"gembooking-price__amount\">" + tongTien + "</span>&nbsp;<span class=\"gembooking-price__symbol\">&#8363;</span></span></dd></dl></div >");
            $('.btncheckuot').show();
        }
    },
    loadDataServer: function () {
        $.ajax({
            url: '/Home/ListCart',
            type: 'POST',           
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    UserController.output(response.data);
                }
            }
        })
    },

}
UserController.init();
