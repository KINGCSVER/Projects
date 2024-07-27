document.addEventListener("DOMContentLoaded", function () {
  const products = [
    {
      name: "Product 1",
      description: "Description 1",
      price: "100$",
      image: "path/to/image1.png",
    },
    {
      name: "Product 2",
      description: "Description 2",
      price: "200$",
      image: "path/to/image2.png",
    },
    {
      name: "Product 3",
      description: "Description 3",
      price: "300$",
      image: "path/to/image3.png",
    },
  ];

  const productGrid = document.querySelector(".product-grid");
  products.forEach((product) => {
    const productElement = document.createElement("div");
    productElement.className = "product";
    productElement.innerHTML = `
            <img src="${product.image}" alt="${product.name}" style="width: 100%;">
            <h3>${product.name}</h3>
            <p>${product.description}</p>
            <p>Price: ${product.price}</p>
        `;
    productGrid.appendChild(productElement);
  });
});
