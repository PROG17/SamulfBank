$(document).ready(function () {


    $(document).on('click', '#depositBtn', function () {

        var data = {
            model: {
                Amount: $('#amountInput').val(),
                AccountNumber: $('#accountSelect').val()
            }
        };

        $.post('/DepositWithdraw/Deposit', data, function (result) {
        });
    });

    $(document).on('click', '#withdrawBtn', function () {
        var data = {
            model: {
                Amount: $('#amountInput').val(),
                AccountNumber: $('#accountSelect').val()
            }
        };

        $.post('/DepositWithdraw/Withdraw', data, function (result) {
        });
    });


});



