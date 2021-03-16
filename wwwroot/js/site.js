var idInput;
$('#modal').on('show.bs.modal', function (event) {    
    let formGroup = document.getElementById('exampleFormControlSelect1');
    let modalName = document.getElementById('modalName');
    let button = $(event.relatedTarget);
    let content = button.data('content');    
    formGroup.innerText = "";
    fetch('https://localhost:44380/popup/modalCode?idButton=' + content) //продумать название параметра
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
                    for (let i = 0; i < data.listPopupModel.length; i++) {
                        formGroup.innerHTML += `<option>${data.listPopupModel[i].popupItem}</option>`;
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
    var clearInput=0;
    $("input:text").each(function () {
        countInput++;
        if ($(this).val()=="") {
            clearInput++;  
        }
    });    
    if (clearInput == countInput) {        
        $('#btn-search').popover('show');
        return false;       
    }    
});

function addInModal() {
    // exampleFormControlSelect1 - id select    
    let selected = Array.from(exampleFormControlSelect1.options).filter(option => option.selected).map(option => option.value);    
    let output = document.getElementById('exampleFormControlSelect2');
    output.innerText += "";
    for (let i = 0; i < selected.length; i++) {
        output.innerHTML += `<option>${selected[i]}</option>`;
    }   
}

function clearOutput() {
    let output = document.getElementById('exampleFormControlSelect2');
    output.innerText = "";
}

function addToInput() {    
    let selected = Array.from(exampleFormControlSelect2.options).map(option => option.value);
    let inputForm = document.getElementById(idInput);
    inputForm.value = selected;
    $('.modal').modal('hide');
}

function close() {
    $('.modal').modal('hide');
}