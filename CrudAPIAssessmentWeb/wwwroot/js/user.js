function signUp() {
    var signupForm = $("#signUpForm");
    if ($('#terms').is(':checked')) {
        var form = new FormData();
        if ($(signupForm).parsley().validate()) {
            debugger;
            console.log($.trim(signupForm.find('[name="User.OtherNationality"]').val()));
            //var intlNumber = $("#Phone").intlTelInput("getNumber");
            var intlNumber = $.trim(signupForm.find('[name="User.Phone"]').val());
            var countryData = $("#Phone").intlTelInput("getSelectedCountryData");
            var countryIso = countryData.iso2;
            var newNo = intlNumber;

            $.blockUI();
            var PassportPath = $.trim(signupForm.find('[name="User.PassportPath"]').val());
            var ProfilePath = $.trim(signupForm.find('[name="User.ProfilePath"]').val());
            var SelfiePath = $.trim(signupForm.find('[name="User.SelfiePath"]').val());
            var UtilityBillPath = $.trim(signupForm.find('[name="User.UtilityBillPath"]').val());

            form.append('PassportPath', PassportPath);
            form.append('ProfilePath', ProfilePath);
            form.append('SelfiePath', SelfiePath);
            form.append('UtilityBillPath', UtilityBillPath);

            form.append('ImgUrl1', signupForm.find("[name='passport']")[0].files[0]);
            form.append('ImgUrl2', signupForm.find("[name='profile']")[0].files[0]);
            form.append('ImgUrl3', signupForm.find("[name='selfie']")[0].files[0]);
            form.append('ImgUrl4', signupForm.find("[name='utility']")[0].files[0]);

            var user = {

                'Id': $("#userId").val(),
                'FullName': $.trim(signupForm.find('[name="User.FullName"]').val()),
                'MidleName': $.trim(signupForm.find('[name="User.MidleName"]').val()),
                'Country': $.trim(signupForm.find('[name="User.Country"]').val()),
                'LocationOfElection': $.trim(signupForm.find('[name="User.LocationOfElection"]').val()),
                'Email': $.trim(signupForm.find('[name="User.Email"]').val()),
                'Phone': newNo,
                'CountryIso': countryIso,
                'Birthday': $.trim(signupForm.find('[name="User.Birthday"]').val()),
                'OtherNationality': $.trim(signupForm.find('[name="User.OtherNationality"]').val()),
                'Address1': $.trim(signupForm.find('[name="User.Address1"]').val()),
                'Address2': $.trim(signupForm.find('[name="User.Address2"]').val()),
                'FacebookSocialLink': $.trim(signupForm.find('[name="User.FacebookSocialLink"]').val()),
                'InstaSocialLink': $.trim(signupForm.find('[name="User.InstaSocialLink"]').val()),
                'LinkedInSocialLink': $.trim(signupForm.find('[name="User.LinkedInSocialLink"]').val()),
                'TweeterSocialLink': $.trim(signupForm.find('[name="User.TweeterSocialLink"]').val()),
                'YoutubeSocialLink': $.trim(signupForm.find('[name="User.YoutubeSocialLink"]').val()),
            };
            var dto = {
                'User': user
            }
            console.log(dto)
            form.append('User', JSON.stringify(user));
            form.append('CreateOrUpdateUser', JSON.stringify(dto));
            $.blockUI();
            $.ajax({
                url: "/User/SignUp",
                dataType: 'json',
                method: "POST",
                data: form,
                processData: false,
                contentType: false,
                cache: false,
                success: function (result) {
                    $.unblockUI();
                    if (result == "SuccessFully Added" || result == "SuccessFully Updated") {
                        location.href = "/Home/Index";
                        $.unblockUI();
                        swal("Good job!", "Record saved successfully", "success")

                    } else {
                        $.toast({
                            heading: 'Error!',
                            text: result,
                            position: 'top-right',
                            loaderBg: '#fd683e',
                            icon: 'error',
                            hideAfter: 3500,
                            stack: 6
                        });
                        $.unblockUI();
                    }
                },
                error: function (request, status, error) {
                    $.unblockUI();
                    console.log(request.responseText)
                    //alert()
                }
            });
        } 
    } else {
        $.toast({
            heading: 'Error!',
            text: "Please accept the terms if you agree",
            position: 'top-right',
            loaderBg: '#fd683e',
            icon: 'error',
            hideAfter: 3500,
            stack: 6
        });
    }
    
}

function deleteUser(id) {
    swal({
        title: "Are you sure?",
        text: "You will not be able to recover this information!",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Yes, delete it!",
        closeOnConfirm: false
    }, function () {
        $.blockUI();
        $.ajax({
            type: "POST",
            url: "/User/DeleteUser",
            data: { Id: id },
            dataType: 'json',
            success: function () {
                location.reload();
                swal("Deleted!", "Your information has been deleted.", "success");
                $.unblockUI();
            },
            error: function (result) {
                console.log(result);
                $.unblockUI();
            }
        });
        //swal("Deleted!", "Your imaginary file has been deleted.", "success");
    });
}