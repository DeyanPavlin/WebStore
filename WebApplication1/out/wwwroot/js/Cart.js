// Add to cart
function addToCart(productName, quantity) {
    const data = {
        Product: { Name: productName },
        Quantity: quantity
    };

    console.log("Sending data to server:", data);

    fetch('/Cart/AddToCart', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    })
        .then(response => response.json())
        .then(result => {
            if (result.success) {
                alert('Product added to cart!');
            } else {
                alert('Failed to add product to cart.');
            }
        })
        .catch(error => {
            console.error('Error adding to cart:', error);
            alert('An error occurred while adding the product to the cart.');
        });
}
//Remove cart
function removeFromCart(productName) {
    fetch('/Cart/RemoveFromCart', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(productName)
    })
        .then(response => response.json())
        .then(result => {
            if (result.success) {
                //alert('Product removed from cart!');
                location.reload();
            } else {
                alert('Failed to remove product from cart.');
            }
        })
        .catch(error => {
            console.error('Error removing from cart:', error);
            alert('An error occurred while removing the product from the cart.');
        });
}