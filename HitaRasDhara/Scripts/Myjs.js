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
            //case 2:
            //    swal('Technical Error !', 'An error has occured, please try again.', 'error');
            //    break;
        case 3:
            swal('Technical Error !', 'An error has occured, please try again.', 'error');
            break;
            //case 4:
            //    swal('Error !', 'Applicant doesnot exist. Kindly add applicant entry via Add data page.', 'error');
            //    break;
        case 5:
            swal('Success !', 'You have successfully registered for the event and your registration pass has been successfully downloaded to your system. Kindly take a printout of the same and bring it to the event.', 'success');
            break;
            //case 6:
            //    swal('Success !', 'You have successfully registered for the event, but due to a technical issue your pass could not be generated. Kindly try reprinting the pass using Reprint Pass option on homepage.', 'information');
            //    break;
        case 7:
            swal('Error !',
                'Either no registeration is made with the provided mobile number or it has been already cancelled by you. Kindly verify the number once and try again.',
                'error');
            break;
            //case 8:
            //    swal('Success !', 'Deeksha Dashboard Data is exported Successfully.', 'success');
            //    break;
        case 9:
            swal('Success !', 'Your registration pass has been regenerated and downloaded to your system successfully. Kindly take a printout of the same.', 'success');
            break;
            //case 10:
            //    swal('Success !', 'Deeksha Dashboard Data is exported Successfully.', 'success');
            //    break;
        case 11:
            swal('Error !', 'No registration exists with the provided mobile number.', 'error');
            break;
        case 12:
            swal('Already Cancelled !', 'This registration has already been cancelled in the past.', 'error');
            break;
        case 13:
            swal('Success !', 'Registration has been cancelled Successfully.', 'success');
            break;
    }
}


