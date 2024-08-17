//Darkmode funct
let darkmode = localStorage.getItem('darkmode');
const themeSwitch = document.getElementById('theme-switch');

const enableDarkmode = () => {
    document.body.classList.add('darkmode');
    localStorage.setItem('darkmode', 'active')
}

const disableDarkmode = () => {
    document.body.classList.remove('darkmode');
    localStorage.setItem('darkmode', null);
}

if (darkmode === "active") {
    enableDarkmode();
}

themeSwitch.addEventListener("click", () => {
    darkmode = localStorage.getItem('darkmode');
    darkmode !== "active" ? enableDarkmode() : disableDarkmode();
});

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
    event.preventDefault(); // Prevent the default form submission

    var formData = new FormData(this);

    fetch('/Store/AddProduct', {
        method: 'POST',
        body: formData
    })
        .then(response => response.json())
        .then(data => {
            if (data.success) {
                alert('Product added successfully!');
                window.location.reload(); // Refresh the page to see the new product
            } else {
                alert('Failed to add product. ' + (data.message || ''));
            }
        })
        .catch(error => {
            console.error('Error:', error);
            alert('An error occurred.');
        });
});
