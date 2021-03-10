function getModal(id) {
    let formGroup = document.getElementById('exampleFormControlSelect1');
    let modalName = document.getElementById('modalName');
    $(document).on('show.bs.modal', '.modal', function () {
        //debugger;
        formGroup.innerHTML += "";
        fetch('https://localhost:44380/popup/modalCode?idButton=' + id)
            .then(
                function (response) {
                    if (response.status !== 200) {
                        console.log('Looks like there was a problem. Status Code: ' +
                            response.status);
                        return;
                    }
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
        $('.modal').modal('show');    
}

function addInModal() {
    // exampleFormControlSelect1 - id select
    let selected = Array.from(exampleFormControlSelect1.options).filter(option => option.selected).map(option => option.value);
    console.log(selected);
    let output = document.getElementById('exampleFormControlSelect2');    
    for (let i = 0; i < selected.length; i++) {
        output.innerHTML += `<option>${selected[i]}</option>`;
    }   
}

function clearOutput() {
    let output = document.getElementById('exampleFormControlSelect2');
    output.innerText += "";
}

function addToInput() {    
    let selected = Array.from(exampleFormControlSelect2.options).map(option => option.value);
    let inputForm = document.getElementById('1');
    inputForm.value = selected;
    $('.modal').modal('hide');
}


