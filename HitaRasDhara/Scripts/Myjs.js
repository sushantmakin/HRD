var showPopup = function (code) {
    switch (code) {
        case 0:
            swal('Duplicate Mobile Number!',
                'A registration is already made with this mobile number. Kindly use a unique number.',
                'error');
            break;
        case 1:
            swal('Registration already exists !',
                'A registration is already made with this mobile number. Kindly use a unique number.',
                'error');
            break;
        case 3:
            swal('Technical Error !', 'An error has occured, please try again.', 'error');
            break;
        case 5:
            swal('Success !', 'You have successfully registered for the event. \n Your registration pass has been successfully downloaded to your system as well as mailed to the provided email address. \n \n Kindly show this pass along with a valid government-issued ID card to gain entry into the discourse.', 'success');
            break;
        case 7:
            swal('Error !',
                'Either no registeration is made with the provided mobile number or it has been already cancelled by you. Kindly verify the number once and try again.',
                'error');
            break;
        case 9:
            swal('Success !', 'Your registration pass has been regenerated. \n It has been downloaded to your system as well as resent to your registered email address successfully. \n \n Kindly show this pass along with a valid government-issued ID card to gain entry into the discourse.', 'success');
            break;
        case 11:
            swal('Error !', 'No registration exists with the provided mobile number.', 'error');
            break;
        case 12:
            swal('Registration Cancelled !', 'This registration was cancelled in the past.', 'error');
            break;
        case 13:
            swal('Success !', 'Registration has been cancelled Successfully.', 'success');
            break;
        case 14:
            swal('Success !', 'Your Feedback has been successfully captured.', 'success');
            break;
        case 15:
            swal('Error !', 'You have already provided your Feedback.', 'error');
            break;
            //16 at last
        case 17:
            swal('Already entered!', 'This listener has already been allowed entry into the auditorium.', 'error');
            break;
        case 18:
            swal('Success!', 'Listener has been allowed entry into the auditorium.', 'success').then(() => {
                window.location.reload();
            });
            break;
        case 16:
            swal('Success !', 'Your Query has been successfully submitted. We will get back to you soon.', 'success').then(() => {
                window.location.href = 'http://www.hitaambrish.com';
            });
            break;
        case 19:
            swal('Success !', 'You have successfully replied to the query.', 'success').then(() => {
                window.history.back();
            });
            break;
        case 20:
            swal('Success !', 'You have successfully cancelled the query.', 'success').then(() => {
                window.location.reload();
            });
            break;
        case 21:
            swal('Error !', 'Query is already cancelled.', 'error');
            break;
        case 22:
            swal('Error !', 'Query is already Important.', 'error');
            break;
        case 23:
            swal('Success !', 'You have successfully marked the query as important.', 'success').then(() => {
                window.location.reload();
            });
            break;
        case 24:
            swal('Error !', 'Query is already Replied.', 'error');
            break;
        case 25:
            swal('Success !', 'You have successfully removed the query from important.', 'success').then(() => {
                window.location.reload();
            });
            break;
        case 26:
            swal('Success !', 'You have successfully added New Katha record..', 'success').then(() => {
                window.location.href = 'http://www.hitaambrish.com/admin/KathaManagement';
            });
            break;
        case 27:
            swal('Success !', 'You have successfully edited the Katha record..', 'success').then(() => {
                window.location.href = 'http://www.hitaambrish.com/admin/KathaManagement';
            });
            break;
    }
}

function is_touch_device() {
    try {
        document.createEvent("TouchEvent");
        return true;
    } catch (e) {
        return false;
    }
}


