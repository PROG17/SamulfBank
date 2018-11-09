$(document).ready(function () {


    $(document).on('click', '#depositBtn', function () {

        var data = {
            model: {
                Amount: $('#amountInput').val(),
                AccountNumber: $('#accountInput').val()
            }
        };

        $.post('/DepositWithdraw/Deposit', data, function (result) {

            if (result.success) {
                alert(result.message);
                clearInputs();
            }
            else {
                alert(result.message);
            }

        });
    });

    $(document).on('click', '#withdrawBtn', function () {
        var data = {
            model: {
                Amount: $('#amountInput').val(),
                AccountNumber: $('#accountInput').val()
            }
        };

        $.post('/DepositWithdraw/Withdraw', data, function (result) {

            if (result.success) {
                alert(result.message);
                clearInputs();
            }
            else {
                alert(result.message);
            }
        });
    });

    $(document).on('change', '#accountSelect', function () {

        $('#accountInput').val($('#accountSelect').val());
    });

    $(document).on('keyup', '#accountInput', function () {
        $('#accountSelect').val($('#accountInput').val());
    });

});

function clearInputs() {
    $('#amountInput').val('');
    $('#accountInput').val('');
    $('#accountSelect').val('');

}



