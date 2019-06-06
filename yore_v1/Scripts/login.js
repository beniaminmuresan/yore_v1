$(document).ready(function() {
  // Elements
  var input = $('input.text');
  var button = $('.submit');
  var menu = $('.menu');
  
  // Variables
  var canLoad = true;
  var showPass = false;
  var tabCount = 0;
  
  // If all input fields are not empty, remove disabled from the button
  $(input).on('keyup', function() {
    if(input.eq(0).val() != "" && input.eq(1).val().length >= 4) {
      button.removeAttr('disabled');
    } else {
      button.attr('disabled','disabled');
    }
    
    if(input.eq(1).val().length >= 6) {
      $('.fa-eye').fadeIn('fast');
    } else {
      $('.fa-eye').fadeOut('fast');
    }
  });
  
  // When 'bluring' the input, it checks if it is not empty. If it is not, add a class named active to it
  //$(input).on('focusout',function() {
    //var val = input.val();
    //if(val === "") {
     // $(this).siblings('label').removeClass('active');
    //} else {
      //$(this).siblings('label').addClass('active');
    //}
  //});
  
  // When clicking the login button, it will run some animations and get the datas of the input fields
  button.on('click', function() {
    if (canLoad === true) {
       var name = input.eq(0).val();
       $(this).text('').addClass('loading');
       setTimeout(function(){ 
         if(name != "") {
           canLoad = false;
           $('.loading').removeClass('loading');
           $('body').addClass('logged');
           $('meta[name="theme-color"]').attr('content','#5dd662');
           button.attr('title','You are already Logged In!').css('cursor','default').html('<i class="fa fa-check" aria-hidden="true"></i>').find('.fa-check').fadeIn('fast');
           $('.login').find('input,button').attr('disabled','disabled');
           setTimeout(function() {
               menu.find('.loggedin').addClass('active').find('h2').text(name + '!');
               setTimeout(function() {
                 canLoad = true;
                 $('.content').addClass('active').children().addClass('active');
                 $('meta[name="theme-color"]').attr('content','#9C27B0');
                 $('body').removeClass('logged');
                 button.attr('title','Log In').css('cursor','pointer').find('.fa-check').fadeOut('fast', function() {
                   button.html('GO')
                 });
                 input.val('').siblings('label').removeClass('active').siblings('.fa-eye').fadeOut('fast');
                 $('.rmbr').find('input[type="checkbox"]:checked').prop('checked',false);
                 $('.login').find('input,button').removeAttr('disabled').parent().find(button).attr('disabled','disabled');
               },300);
           }, 500);
         }
       }, 2000);
    }
  });
  
  // Shows password when clicking the eye
  $('.fa-eye').on('click', function() {
    $(this).toggleClass('active');
    if(showPass === false) {
      showPass = true;
      input.eq(1).attr('type','text');
    } else {
      showPass = false;
      input.eq(1).attr('type','password');
    }
  });
  
  /* Closes the logged in menu */
  $('.fa-times').on('click', function() {
    menu.find('.content').removeClass('active').children().removeClass('active');
    setTimeout(function() {
        menu.find('.loggedin').removeClass('active');
        $('meta[name="theme-color"]').attr('content','#E91E63');
    }, 300);
  });
});