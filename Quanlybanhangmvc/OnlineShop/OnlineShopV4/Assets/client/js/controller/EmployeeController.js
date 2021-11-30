var user = {
    init: function () {
        user.registerEvent();
        user.activeStatus();
        user.activeStatus2();
        user.activeStatus3();
    },
    registerEvent: function () {
        for (var i = 0; i < $('.btn-active').length; i++) {
            const element = $('.btn-active')[i];
            $(element).off('click').on('click', function (e) {
                e.preventDefault();
                var btn = $(this);
                var id = btn.data('id');
                console.log(btn);
                $.ajax({
                    url: "/Employee/Account/changeStatus",
                    data: { id: id },
                    dataType: "json",
                    type: "POST",
                    success: function (reponse) {
                        console.log(element, reponse)

                        if (reponse.stutus == true) {
                            $(element).text("Active");
                        }
                        else {
                            $(element).text("Block");
                        }
                    }
                })
            });

        }

    },
    activeStatus: function () {
        console.log("abc")
        for (var i = 0; i < $('.btn-active-1').length; i++) {
            const element = $('.btn-active-1')[i];
            console.log("abc")
            $(element).off('click').on('click', function (e) {
                e.preventDefault();
                var btn = $(this);
                var id = btn.data('id');
                console.log(btn);
                $.ajax({
                    url: "/Employee/SupplierProduct/changeStatus",
                    data: { id: id },
                    dataType: "json",
                    type: "POST",
                    success: function (reponse) {
                        console.log(element, reponse)

                        if (reponse.stutus == true) {
                            $(element).text("Còn hàng");
                        }
                        else {
                            $(element).text("Hết hàng");
                        }
                    }
                })
            });

        }

    },
    activeStatus2: function () {
        for (var i = 0; i < $('.btn-active-2').length; i++) {
            const element = $('.btn-active-2')[i];
            console.log("abc")
            $(element).off('click').on('click', function (e) {
                e.preventDefault();
                var btn = $(this);
                var id = btn.data('id');
                console.log(btn);
                $.ajax({
                    url: "/Employee/ProductBill/changeStatus",
                    data: { id: id },
                    dataType: "json",
                    type: "POST",
                    success: function (reponse) {
                        console.log(element, reponse)

                        if (reponse.stutus == true) {
                            $(element).text("Đã giao");
                        }
                        else {
                            $(element).text("Chưa giao");
                        }
                    }
                })
            });

        }

    },
    activeStatus3: function () {
        for (var i = 0; i < $('.btn-active-3').length; i++) {
            const element = $('.btn-active-3')[i];
            console.log("abc")
            $(element).off('click').on('click', function (e) {
                e.preventDefault();
                var btn = $(this);
                var id = btn.data('id');
                console.log(btn);
                $.ajax({
                    url: "/Employee/Product/changeStatus",
                    data: { id: id },
                    dataType: "json",
                    type: "POST",
                    success: function (reponse) {
                        console.log(element, reponse)

                        if (reponse.stutus == true) {
                            $(element).text("Còn hàng");
                        }
                        else {
                            $(element).text("Hết hàng");
                        }
                    }
                })
            });

        }

    }

}

user.init();

//var supplierproduct = {
//    init: function () {
//        user.registerEvent();
//    },
//    registerEvent: function () {
//        console.log("abc")
//        for (var i = 0; i < $('.btn-active-1').length; i++) {
//            const element = $('.btn-active-1')[i];
//            console.log("abc")
//            $(element).off('click').on('click', function (e) {
//                e.preventDefault();
//                var btn = $(this);
//                var id = btn.data('id');
//                console.log(btn);
//                $.ajax({
//                    url: "/Admin/SupplierProduct/changeStatus",
//                    data: { id: id },
//                    dataType: "json",
//                    type: "POST",
//                    success: function (reponse) {
//                        console.log(element, reponse)

//                        if (reponse.stutus == true) {
//                            $(element).text("Còn hàng");
//                        }
//                        else {
//                            $(element).text("Hết hàng");
//                        }
//                    }
//                })
//            });

//        }

//    }
//}

//supplierproduct.init();