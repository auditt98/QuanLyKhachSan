

var dataClient

var UserController = {
    init: function () {
        //UserController.loadDataServer();
        UserController.registerEven();
    },
    registerEven: function () {
        $(".btnAdd").off('click').on('click', function (e) {
            e.preventDefault();
            var btnplus = $(this);
            var id = btnplus.data('id');
            $.ajax({
                data: { id: $(this).data('id'), check_in: $('#txtCheck_in').val(), check_out: $('#txtCheck_out').val()},
                url: '/Home/ADD',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {

                    }
                }
            })
        })
    },
    loadDataServer: function () {
        $.ajax({
            url: 'ListCart',
            type: 'GET',           
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    var data = response.data;

                }
            }
        })
    },

}
UserController.init();
