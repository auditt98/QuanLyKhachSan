$(document).ready(function () {
	$(".btnAdd").off('click').on('click', function (e) {
		e.preventDefault();
		var btnplus = $(this);
		var id = btnplus.data('id');
		$.ajax({
			data: { id: $(this).data('id') },
			url: '/Home/ADD',
			dataType: 'json',
			type: 'POST',
			success: function (res) {
				if (res.status == true) {

				}
			}
		})
	})

})