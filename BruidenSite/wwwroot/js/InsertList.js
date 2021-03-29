$(document).on("click", ".upbtn", function () {
    var huidig = $(this).closest('li')
    var vorige = $(huidig).prev();
    if (vorige.length !== 0) {
        huidig.insertBefore(vorige);
    }
    return false;
});
$(document).on("click", ".downbtn", function () {
    var huidig = $(this).closest('li')
    var volgende = huidig.next('li');
    if (volgende.length !== 0){
        huidig.insertAfter(volgende);
    }
    return false;
});

$(document).on("click", ".deletebtn", function () {
    $(this).parent().remove();
});





