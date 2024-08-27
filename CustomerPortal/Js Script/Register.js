function valid() {
    var customerName = document.getElementById('CustomerName').value;
    var customerEmail = document.getElementById('CustomerEmail').value;
    var customerPhone = document.getElementById('CustomerPhone').value;
    var customerId = document.getElementById('CustomerId').value;
    var CustomerPass = document.getElementById('CustomerPassword').value;
    var Checkpass = document.getElementById('CheckPassword').value;
    if (customerName === '') {
        alert('Please Enter your Name')
        return false;
    }
    if (customerEmail === '') {
        alert('Please Enter valid email Id');
        return false;
    }
    if (customerPhone === '') {
        alert('Please Enter your Phone Number');
        return false;
    }
    if (customerId === '') {
        alert('`Please Enter CustomerID');
        return false;
    }
    if (CustomerPass === '') {
        alert('Please Enter Password');
        return false;
    }
    if (CustomerPass !== Checkpass) {
        alert('Password does not Match');
        return false;
    }
    if (!isValidEmail(customerEmail)) {
        alert('Please enter a vaild Mail ID');
        return false;
    }
    if (!isValidPhoneNumber(customerPhone)) {
        alert('Please enter a vaild Phone number');
        return false;
    }
    return true;
}
