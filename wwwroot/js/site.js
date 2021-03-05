function getModal(id) {
    let formGroup = document.getElementById('exampleFormControlSelect2');
    let modalName = document.getElementById('modalName');
    $(document).on('show.bs.modal', '.modal', function () {
        debugger;
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
    function show() {
        $('.modal').modal('show');
    }
    show();
    setTimeout(show, 6000);
}


