function focusElement(id) {
    const element = document.getElementById(id);
    element.focus();
};

$(document).on("keypress", "#vesselLength", function (e) {
    if (e.keyCode == 69 || e.keyCode == 101) {
        e.preventDefault();
    }
});
