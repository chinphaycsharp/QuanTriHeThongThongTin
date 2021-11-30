var user = {
    init: function () {
        user.loadProvice();
        user.registerEvent1();
    },
    registerEvent1: function () {
        $("#ddlProvince").off("change").on("change", function () {
            var id = $(this).val();
            if (id != '') {
                user.loadDistrict(parseInt(id));
            }
            else {
                $('ddlDistrict').html('');
            }
        })
    },
    loadProvice: function () {
        $.ajax({
            url: "/User/LoadProvince",
            type: "POST",
            dataType: "json",
            success: function (response) {
                if (response.status == true) {
                    var html = '<option value="" >--Chọn tỉnh thành--</option>';
                    var data = response.data;
                    $.each(data, function (i, item) {
                        html += '<option value="' + item.ID + '">' + item.Name + '</option>';
                    });
                    $('#ddlProvince').html(html);
                }
            }
        })
    },
    loadDistrict: function (id) {
        $.ajax({
            url: "/User/LoadDistrict",
            type: "POST",
            data: { ProvinceID:id},
            dataType: "json",
            success: function (response) {
                if (response.status == true) {
                    var html = '<option value="" >--Chọn quận huyện--</option>';
                    var data = response.data;
                    $.each(data, function (i, item) {
                        html += '<option value="' + item.ID + '">' + item.Name + '</option>';
                    });
                    $('#ddlDistrict').html(html);
                }
            }
        })
    },
}
user.init();