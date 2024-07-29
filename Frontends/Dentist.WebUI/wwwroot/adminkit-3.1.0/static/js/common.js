// Silme işlemi için SweetAlert kullanımı
function setupDeleteConfirmation(className, urlPrefix) {
    const deleteButtons = document.querySelectorAll(className);

    deleteButtons.forEach(button => {
        button.addEventListener('click', function (event) {
            const itemId = this.getAttribute('data-id');

            Swal.fire({
                title: 'Emin misiniz?',
                text: "Bu öğeyi silmek istediğinizden emin misiniz?",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Evet, Sil!',
                cancelButtonText: 'İptal'
            }).then((result) => {
                if (result.isConfirmed) {
                    window.location.href = urlPrefix + itemId;
                }
            });
        });
    });
}


// Ekleme Güncelleme işlemleri için SweetAlert kullanımı
function setupFormSubmitWithAlert(formId, successMessage, submitDelay) {
    const form = document.getElementById(formId);

    if (!form) {
        console.error(`Form with id ${formId} not found.`);
        return;
    }

    form.addEventListener('submit', function (event) {
        event.preventDefault();

        Swal.fire({
            icon: 'success',
            title: successMessage,
            position: 'center',
            showConfirmButton: false,
            timer: submitDelay
        });

        setTimeout(function () {
            form.submit();
        }, submitDelay);
    });
}

