    function ValidateBooking() {

        // Validate Shipper Name
        if ($('#txt_customer').val().trim() === '') {
            alert('Please enter Shipper Name.');
            $('#txt_customer').focus();
            return false
        }

        // Validate Place of Booking
        if ($('#dropdown_POB').val() === '0') {
            alert('Please select Place of Booking.');
            $('#dropdown_POB').focus();
            return false
        }

        // Validate Consignee
        if ($('#txt_consignee').val().trim() === '') {
            alert('Please enter Consignee.');
            $('#txt_consignee').focus();
            return false
        }

        // Validate Date of Stacking
        if ($('#txt_Dos').val().trim() === '') {
            alert('Please enter Date of Stacking.');
            $('#txt_Dos').focus();
            return false
        }

        // Validate Place of Rec
        if ($('#dropdown_POR').val() === '0') {
            alert('Please select Place of Rec.');
            $('#dropdown_POR').focus();
            return false
        }

        // Validate POD
        if ($('#dropdown_POD').val() === '0') {
            alert('Please select POD.');
            $('#dropdown_POD').focus();
            return false
        }

        // Validate Voyage
        if ($('#dropdown_voyage').val() === '0') {
            alert('Please select Voyage.');
            $('#dropdown_voyage').focus();
            return false
        }

        // Validate Vessel
        if ($('#dropdown_vessel').val() === '0') {
            alert('Please select Vessel.');
            $('#dropdown_vessel').focus();
            return false
        }

        // Validate Vessel Operator
        if ($('#dropdown_VesselOp').val() === '0') {
            alert('Please select Vessel Operator.');
            $('#dropdown_VesselOp').focus();
            return false
        }

        // Validate Pre Carriage
        if ($('#dropdown_Pre').val() === '0') {
            alert('Please select Pre Carriage.');
            $('#dropdown_Pre').focus();
            return false
        }

        // Validate Dest Carriage
        if ($('#dropdown_Dest').val() === '0') {
            alert('Please select Dest Carriage.');
            $('#dropdown_Dest').focus();
            return false
        }

        // Validate Type of Cargo
        if ($('#dropdown_CargoTypes').val() === '0') {
            alert('Please select Type of Cargo.');
            $('#dropdown_CargoTypes').focus();
            return false
        }

        // Validate Container
        if ($('#dropdown_CargoType').val() === '0') {
            alert('Please select Container.');
            $('#dropdown_CargoType').focus();
            return false
        }

        // Validate Qty
        if ($('#Cargo_Qty').val().trim() === '') {
            alert('Please enter Qty.');
            $('#Cargo_Qty').focus();
            return false
        }

        // Validate Commodity
        if ($('#dropdown_Commodity').val() === '0') {
            alert('Please select Commodity.');
            $('#dropdown_Commodity').focus();
            return false
        }

        // Validate Gr.Wt(KG)
        if ($('#Gr_wt').val().trim() === '') {
            alert('Please enter Gr.Wt(KG).');
            $('#Gr_wt').focus();
            return false
        }
        return true;
    }

    function getBookingData() {
        var formattedDate = new Date();
        var bookingData = {
            ShipperName: $('#txt_customer').val().trim(),
            PlaceOfBooking: $('#dropdown_POB').val(),
            Consignee: $('#txt_consignee').val().trim(),
            DateOfStacking: $('#txt_Dos').val().trim(),
            PlaceOfRec: $('#dropdown_POR').val(),
            POD: $('#dropdown_POD').val(),
            Voyage: $('#dropdown_voyage').val(),
            Vessel: $('#dropdown_vessel').val(),
            VesselOperator: $('#dropdown_VesselOp').val(),
            PreCarriage: $('#dropdown_Pre').val(),
            DestCarriage: $('#dropdown_Dest').val(),
            TypeOfCargo: $('#dropdown_CargoTypes').val(),
            Container: $('#dropdown_CargoType').val(),
            Qty: $('#Cargo_Qty').val().trim(),
            Commodity: $('#dropdown_Commodity').val(),
            GrWt: $('#Gr_wt').val().trim(),
            DateOfBooking: formattedDate.toLocaleDateString('en-GB'),
            BkgID: $('#bkgID').val(),
            BookingRefNo: sessionStorage.getItem('Bkgref')
        };
        return bookingData;
    }

    function setBookingData(data) {
        bookingData = JSON.parse(data);
        $('#txt_customer').val(bookingData[0].ShipperName);
        $('#dropdown_POB').val(bookingData[0].PlaceOfBooking);
        $('#txt_consignee').val(bookingData[0].Consignee);
        $('#txt_Dos').val(bookingData[0].DateOfStacking);
        $('#dropdown_POR').val(bookingData[0].PlaceOfRec);
        $('#dropdown_POD').val(bookingData[0].POD);
        $('#dropdown_voyage').val(bookingData[0].Voyage);
        $('#dropdown_vessel').val(bookingData[0].Vessel);
        $('#dropdown_VesselOp').val(bookingData[0].VesselOperator);
        $('#dropdown_Pre').val(bookingData[0].PreCarriage);
        $('#dropdown_Dest').val(bookingData[0].DestCarriage);
        $('#dropdown_CargoTypes').val(bookingData[0].TypeOfCargo);
        $('#dropdown_CargoType').val(bookingData[0].Container);
        $('#Cargo_Qty').val(bookingData[0].Qty);
        $('#dropdown_Commodity').val(bookingData[0].Commodity);
        $('#Gr_wt').val(bookingData[0].GrWt);
        $('#bkgID').val(bookingData[0].BkgID);
        sessionStorage.setItem('Bkgref', bookingData[0].BookingRefNo);
        console.log($('#bkgID').val());
    }

    function clearBookingData() {
        $('#bkgform').find('input[type="text"]:not(:disabled), input[type="number"]:not(:disabled), input[type="date"]:not(:disabled), input[type="hidden"]').val('');
        $('#bkgform').find('select').prop('selectedIndex', 0);
    }

        function SaveBkg() {
            if (ValidateBooking()) {
                var bookingData = getBookingData();
                $.ajax({
                    url: '/Export/InsertBooking',
                    type: 'POST',
                    contentType: 'application/json',
                    data: JSON.stringify(bookingData),
                    success: function (data) {
                        if (data) {
                            alert('Booking saved');
                            setBookingData(data);
                            $('#btn_save').attr('hidden', true);
                            $('#btn_upd').removeAttr('hidden');
                            var bkgref = sessionStorage.getItem('Bkgref');
                            $('#lbl').text(bkgref + ' booking Details');

                        } else {
                            clearBookingData();
                            $('#btn_save').removeAttr('hidden');
                            $('#btn_upd').attr('hidden', true);
                            $('#lbl').text('Enter the Booking Details');
                            alert('Booking Not found');
                        }
                    },
                    error: function (error) {
                        // Handle error
                        console.error('AJAX request error', error);
                    }
                });
            }
        }

        function GetBkg() {
            if ($('#bkgref').val().trim() != '') {
                $.ajax({
                    url: '/Export/GetBooking',
                    type: 'GET',
                    contentType: 'application/json',
                    data: { bkgref: $('#bkgref').val() },
                    success: function (data) {
                        if (data) {
                            setBookingData(data);
                            $('#btn_save').attr('hidden', true);
                            $('#btn_cancel').attr('hidden', true);
                            $('#btn_upd').removeAttr('hidden');
                            $('#btn_delete').removeAttr('hidden');
                            var bkgref = sessionStorage.getItem('Bkgref');
                            $('#lbl').text(bkgref + ' booking Details');

                        } else {
                            clearBookingData();
                            $('#btn_save').removeAttr('hidden');
                            $('#btn_upd').attr('hidden', true);
                            $('#lbl').text('Enter the Booking Details');
                            alert('Booking Not found');
                        }
                    },
                    error: function (error) {
                        console.error('Error fetching booking data', error);
                        alert('Failed to fetch booking data');
                    }
                });
            } else {
                clearBookingData();
                $('#btn_save').removeAttr('hidden');
                $('#btn_upd').attr('hidden', true);
                $('#lbl').text('Enter the Booking Details');
                alert('Enter Booking Ref');
            }
        }


    function UpdateBkg() {

        var confirm = window.confirm('Do you want to Update ' + sessionStorage.getItem('Bkgref'));

        if ($('#bkgID').val() != 0 && ValidateBooking() && confirm) {
                var UpdateBkg = getBookingData();
                $.ajax({
                    url: '/Export/UpdateBooking',
                    type: 'POST',
                    contentType: 'application/json',
                    data: JSON.stringify(UpdateBkg),
                    success: function (data) {
                        if (data.success)
                            alert('Booking updated.');
                        else
                            alert('Failed');
                        console.log('AJAX request successful', data);
                    },
                    error: function (error) {
                        // Handle error
                        alert('Update Failed');
                        console.error('AJAX request error', error);
                    }
                });
            }
        }


    function DeleteBkg() {

        var confirm = window.confirm('Do you want to Delete ' + sessionStorage.getItem('Bkgref'));
        var Bkgid = $('#bkgID').val();

        if (confirm && Bkgid != 0) {
            $.ajax({
                url: '/Export/DeleteBooking',
                type: 'GET',
                contentType: 'application/json',
                data: { BkgID: Bkgid },
                success: function (data) {
                    if (data.success) {
                        alert('Booking deleted.');
                        clearBookingData();
                    }
                    else
                        alert('Failed');
                    //console.log('AJAX request successful', data);
                },
                error: function (error) {
                    // Handle error
                    console.error('AJAX request error', error);
                }
            });
        }
        else {
            alert('Unable to delete');
        }
    }
    function loadPartialView(viewId) {
        $.ajax({
            url: '/Export/LoadPartial',
            type: 'GET',
            data: { ViewId: viewId },
            success: function (data) {
                $('#Partialdiv').empty();
                $('#Partialdiv').html(data);
            },
            error: function (xhr, status, error) {
                console.error('Error loading partial view:', status, error);
                alert('server error');
            }
        });
    }

    $('#btn_clear').on('click', function(){

        clearBookingData();

    })

