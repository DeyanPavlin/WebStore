//Admin Mode
function toggleAdminMode() {
    var adminSection = document.getElementById("adminSection");
    if (adminSection.style.display === "none") {
        adminSection.style.display = "block";
    } else {
        adminSection.style.display = "none";
    }
}

document.getElementById('addProductForm').addEventListener('submit', function (event) {
    event.preventDefault();

    var formData = new FormData(this);

    fetch('/Store/AddProduct', {
        method: 'POST',
        body: formData
    })
        .then(response => response.json())
        .then(data => {
            if (data.success) {
                alert('Product added successfully!');
                window.location.reload();
            } else {
                alert('Failed to add product. ' + (data.message || ''));
            }
        })
        .catch(error => {
            console.error('Error:', error);
            alert('An error occurred.');
        });
});