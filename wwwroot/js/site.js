$(document).ready(function () {
    $("input:text").each(function () {
        $(this).attr("autocomplete", "off");
    })
}); 
var idInput;    
$('#modal').on('show.bs.modal', function (event) {
    $('.loading').removeClass("hidden");
    $('.form-group').addClass("hidden");
    $('.form-group2').addClass("hidden");
    let formGroup = document.getElementById('exampleFormControlSelect1');
    let modalName = document.getElementById('modalName');    
    modalName.innerText = "";
    formGroup.innerText = "";
    let button = $(event.relatedTarget);
    let content = button.data('content');   
    fetch('/popup/modalCode?idButton=' + content) //продумать название параметра
        .then(
            function (response) {
                if (response.status !== 200) {
                    console.log('Looks like there was a problem. Status Code: ' +
                        response.status);
                    return;
                }
                idInput = content;
                response.json().then(function (data) {
                    modalName.innerHTML = data.popupName;
                    $('.loading').addClass("hidden");
                    $('.form-group').removeClass("hidden");
                    $('.form-group2').removeClass("hidden");
                    for (let i = 0; i < data.listPopupModel.length; i++) {
                        if (data.listPopupModel[i].itemId != null) {
                            formGroup.innerHTML += `<option data-id="${data.listPopupModel[i].itemId}">${data.listPopupModel[i].popupItem}</option>`;
                        } else {
                            formGroup.innerHTML += `<option>${data.listPopupModel[i].popupItem}</option>`;
                        }
                    }
                });                    
            }            
        )
        .catch(function (err) {
            console.log('Fetch Error :-S', err);
        });
});

$('#btn-search').on('click', function () {        
    var countInput=0;
    var clearInput = 0;

    $("input:text").each(function () {
        countInput++;
        if ($(this).val()=="") {
            clearInput++;            
        }        
        var attr = $(this).data('id');
        $(this).hide();
        if (typeof attr != typeof undefined && attr != false) {
            $(this).val(attr);
        }
    });    
    if (clearInput == countInput) {        
        $('#btn-search').popover('show');
        return false;       
    }    
});

$('#btn-delete').on('click', function () {
    $("input:text").each(function () {
        $(this).val("");
    });
});


function addInModal() {
    // exampleFormControlSelect1 - id select    
    let selected = Array.from(exampleFormControlSelect1.options).filter(option => option.selected).map(option => ({ value: option.value, id: option.dataset.id }));    
    let output = document.getElementById('exampleFormControlSelect2');
    output.innerText += "";
    for (let i = 0; i < selected.length; i++) {        
        if (selected[i].id == null) {
            output.innerHTML += `<option>${selected[i].value}</option>`;
        }
        else {
            output.innerHTML += `<option data-id="${selected[i].id}">${selected[i].value}</option>`;
        }
    }   
}

function clearOutput() {
    let output = document.getElementById('exampleFormControlSelect2');
    output.innerText = "";
}

function addToInput() {    
    let selectedValue = Array.from(exampleFormControlSelect2.options).map( option => option.value );
    let selectedId = Array.from(exampleFormControlSelect2.options).filter(option => option.dataset.id != null).map(option => option.dataset.id);
    let inputForm = document.getElementById(idInput);       
    inputForm.value = selectedValue.join(", ");
    if (selectedId != null) {
        inputForm.dataset.id = selectedId.join(", ");
    }
    $('.modal').modal('hide');
}

function close() {
    $('.modal').modal('hide');
}