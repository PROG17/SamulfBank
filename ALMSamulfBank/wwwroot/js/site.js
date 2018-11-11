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

        var acc = $('#accountSelect').val();
        if (acc !== null) {
            ShowDetails(acc);
        }
        else {
            HideDetails();
        }
    });

    $(document).on('keyup', '#accountInput', function () {
        $('#accountSelect').val($('#accountInput').val());
        var acc = $('#accountSelect').val();

        if (acc !== null) {
            ShowDetails(acc);
        }
        else {
            HideDetails();
        }
    });

});

function ShowDetails(acc) {

    var data = {
        accNo: acc
    };
    $.post('/DepositWithdraw/ShowDetails', data, function (result) {

        var ChosenAccount = result.accounts.filter(function (account) {
            var rightAccount = account.accountNumber.toString() === acc;
            if (rightAccount) {
                return account;
            }
        })[0];

        $('#detailsHead').text('Owner: ' + result.name);
        $('#detailsAccount').text('Account: ' + ChosenAccount.accountNumber.toString() + ' (balance: ' + ChosenAccount.balance.toString() + 'kr)');

    });
}

function HideDetails() {
    $('#detailsHead').text('');
    $('#detailsAccount').text('');
}

function clearInputs() {
    $('#amountInput').val('');
    $('#accountInput').val('');
    $('#accountSelect').val('');
    HideDetails();

}



