function ShowModal(modalId) {
    $('#' + modalId).modal('show');
}
function CloseModal(modalId) {
    $('#' + modalId).modal('hide');
}
function TestDataTablesAdd(table) {    
    alert(table);
}
$(document).ready(function () {
    console.log("ready!");
    //TestDataTablesAdd("#table")
});