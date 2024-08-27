//JS Functions for EMAIL AND PHONE UPDATE

function renderCustomerDetails(data) {
    var detailsContainer = $('#customer-details');
    detailsContainer.empty();

    if (data.length > 0) {
        $.each(data, function (index, customer) {
            var html = '<tr>';
            html += '<td>' + customer.CustomerName + '</td>';
            html += '<td>' + customer.CustomerEmail + ' <a href="" data-toggle="modal" class="edit-Mail" data-target="#EditMail" data-whatever="@mail"><i class="fas fa-edit"></i></a></td>';
            html += '<td>' + customer.CustomerPhone + ' <a href="#" class="edit-Phone"><i class="fas fa-edit"></i></a></td>';
            html += '</tr>';
            detailsContainer.append(html);
        });
        $('#HidCustomerID').val(data[0].ID);
    } else {
        detailsContainer.html('No customer details found.');
    }
}
$(document).on('click', '.edit-Phone', function (e) {
    e.preventDefault();
    $('#EditPhone').modal('show');
    $('#EditMail').modal('hide');
});
$(document).on('click', '.edit-Mail', function (e) {
    e.preventDefault();
    $('#EditMail').modal('show');
    $('#EditPhone').modal('hide');
});
function closeModal(id) {
    var MailInput = $('#EditMail').find('#MailID');
    var PhoneInput = $('#EditPhone').find('#PhoneID');

    if (id === 1) {
        MailInput.val('');
        $('#msg').text('');
        $('#EditMail').modal('hide');

    } else if (id === 2) {
        PhoneInput.val('');
        $('#msg1').text('');
        $("#EditPhone").modal('hide');
    }
}

    function isValidEmail(email) {
        var emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        if (emailRegex.test(email))
            return true;
        else if (email.trim() === '' || email === null)
            return false;
        else
            return false;
    }

function isValidPhoneNumber(phoneNumber) {
    var phonePattern = /^\d{10}$/;
    if (phoneNumber === null || phoneNumber.trim() === '')
        return false;
    else if (phonePattern.test(phoneNumber))
        return true
    else
        return false
}

