import { createSlice } from "@reduxjs/toolkit";

const productsSlice = createSlice({
  name: "products",
  initialState: {
    searchTerm: "",
    products: [
      {
        id: 1,
        name: "Rolex Submariner",
        price: 8000,
        imageUrl: require("../assets/rolex-submariner.png"),
      },
      {
        id: 2,
        name: "Omega Seamaster",
        price: 5000,
        imageUrl: require("../assets/omega-seamaster.png"),
      },
      {
        id: 3,
        name: "Tag Heuer Carrera",
        price: 3500,
        imageUrl: require("../assets/tag-heuer-carrera.png"),
      },
      {
        id: 4,
        name: "Patek Philippe Calatrava",
        price: 12000,
        imageUrl: require("../assets/patek-philippe-calatrava.png"),
      },
      {
        id: 5,
        name: "Audemars Piguet Royal Oak",
        price: 15000,
        imageUrl: require("../assets/audemars-piguet-royal-oak.png"),
      },
      {
        id: 6,
        name: "IWC Pilot's Watch",
        price: 4500,
        imageUrl: require("../assets/iwc-pilots-watch.png"),
      },
    ],
    filteredProducts: [],
    cartOpen: false,
    cartItems: [],
  },
  reducers: {
    setSearchTerm: (state, action) => {
      state.searchTerm = action.payload;
      state.filteredProducts = filterProducts(state.products, state.searchTerm);
    },
    toggleCart: (state) => {
      state.cartOpen = !state.cartOpen;
    },
    addToCart: (state, action) => {
      const product = action.payload;
      const existingItem = state.cartItems.find(
        (item) => item.id === product.id
      );

      if (existingItem) {
        existingItem.quantity += 1;
      } else {
        state.cartItems.push({ ...product, quantity: 1 });
      }
    },
    removeFromCart: (state, action) => {
      const productId = action.payload;
      state.cartItems = state.cartItems.filter((item) => item.id !== productId);
    },
    incrementQuantity: (state, action) => {
      const productId = action.payload;
      const item = state.cartItems.find((item) => item.id === productId);
      if (item) {
        item.quantity += 1;
      }
    },
    decrementQuantity: (state, action) => {
      const productId = action.payload;
      const item = state.cartItems.find((item) => item.id === productId);
      if (item) {
        item.quantity = item.quantity > 1 ? item.quantity - 1 : 1;
      }
    },
  },
  extraReducers: (builder) => {
    builder.addDefaultCase((state) => {
      state.filteredProducts = filterProducts(state.products, state.searchTerm);
    });
  },
});

function filterProducts(products, searchTerm) {
  return products.filter((product) =>
    product.name.toLowerCase().includes(searchTerm.toLowerCase())
  );
}

export const getTotalPrice = (state) =>
  state.products.cartItems.reduce(
    (total, item) => total + item.price * item.quantity,
    0
  );

export const {
  setSearchTerm,
  toggleCart,
  addToCart,
  removeFromCart,
  incrementQuantity,
  decrementQuantity,
} = productsSlice.actions;

export const selectProducts = (state) => state.products;

export default productsSlice.reducer;
