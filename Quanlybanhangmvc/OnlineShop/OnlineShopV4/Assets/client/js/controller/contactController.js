var contact = {
    init: function () {
        contact.registerEvents();

    },
    registerEvents: function () {
        $("#btnSend").off('click');
        $("#btnSend").on('click', function () {
            var name = $('#txtName').val();
            var phone = $('#txtPhone').val();
            var address = $('#txtAddress').val();
            var email = $('#txtEmail').val();
            var content = $('#txtContent').val();
            console.log('abc');
            $.ajax({
                url: '/Contact/Send',
                type: 'POST',
                dataType: 'json',
                data: {
                    name: name,
                    phone: phone,
                    address: address,
                    email: email,
                    content: content
                },
                success: function (res) {
                    if (res.status == true) {
                        window.alert("Gửi thành công ");
                        contact.resetForm();
                    }
                }
            });
        });
    },
    resetForm: function () {
        $('#txtName').val("");
        $('#txtPhone').val("");
        $('#txtAddress').val("");
        $('#txtEmail').val("");
        $('#txtContent').val("");
    }
}

contact.init();