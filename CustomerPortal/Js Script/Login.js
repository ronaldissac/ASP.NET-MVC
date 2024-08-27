function valid() {
    var customerId = document.getElementById('CustomerId').value.trim();
    var customerpass = document.getElementById('CustomerPassword').value;

    if (customerId.trim() === '' && customerpass === '') {
        alert('Enter CustomerID and Password');
        return false;
    }
    else if (customerId === '') {
        alert('Enter CustomerID');
        return false;
    }
    else if (customerpass === '') {
        alert('Enter Password');
        return false;
    }
    return true;
}
