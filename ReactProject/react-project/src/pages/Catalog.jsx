import React from "react";
import { useSelector, useDispatch } from "react-redux";
import {
  selectProducts,
  setSearchTerm,
  toggleCart,
  addToCart,
  removeFromCart,
  incrementQuantity,
  decrementQuantity,
  getTotalPrice,
} from "../store/productsSlice";
import "@fortawesome/fontawesome-free/css/all.min.css";

export default function Catalog() {
  const dispatch = useDispatch();
  const { searchTerm, filteredProducts, cartOpen, cartItems } =
    useSelector(selectProducts);

  const totalPrice = useSelector((state) => getTotalPrice(state)).toFixed(2);

  return (
    <div>
      <div className="flex justify-end p-4">
        <button
          onClick={() => dispatch(toggleCart())}
          className="text-gray-600 focus:outline-none hover:text-gray-800 transition ease-in-out duration-300 mr-5"
        >
          <i className="fas fa-clock text-2xl"></i>
        </button>
      </div>

      <div className="relative mt-6 max-w-lg mx-auto">
        <span className="absolute inset-y-0 left-0 pl-3 flex items-center">
          <svg
            className="h-5 w-5 text-gray-500"
            viewBox="0 0 24 24"
            fill="none"
          >
            <path
              d="M21 21L15 15M17 10C17 13.866 13.866 17 10 17C6.13401 17 3 13.866 3 10C3 6.13401 6.13401 3 10 3C13.866 3 17 6.13401 17 10Z"
              stroke="currentColor"
              strokeWidth="2"
              strokeLinecap="round"
              strokeLinejoin="round"
            />
          </svg>
        </span>
        <input
          className="w-full border rounded-md pl-10 pr-4 py-2 focus:border-gray-500 focus:outline-none focus:shadow-outline"
          type="text"
          placeholder="Поиск"
          value={searchTerm}
          onChange={(e) => dispatch(setSearchTerm(e.target.value))}
        />
      </div>

      <section className="mt-6 max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
        <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4 gap-6">
          {filteredProducts.map((product) => (
            <div
              key={product.id}
              className="bg-white rounded-lg shadow-md overflow-hidden"
            >
              <img
                className="w-full h-48 object-cover"
                src={product.image}
                alt={product.name}
              />
              <div className="p-4">
                <h3 className="text-lg font-semibold text-gray-900">
                  {product.name}
                </h3>
                <p className="mt-1 text-gray-600">{product.description}</p>
                <p className="mt-2 text-gray-900 font-bold">
                  ${product.price.toFixed(2)}
                </p>
                <button
                  onClick={() => dispatch(addToCart(product))}
                  className="mt-4 w-full py-2 px-4 bg-blue-600 text-white rounded-md hover:bg-blue-700 transition ease-in-out duration-300"
                >
                  Addd to Cart
                </button>
              </div>
            </div>
          ))}
        </div>
      </section>

      {cartOpen && (
        <section className="fixed right-0 top-0 w-80 h-full bg-white shadow-lg p-4">
          <h2 className="text-xl font-bold text-gray-900">Cart</h2>
          <ul className="mt-4">
            {cartItems.map((item) => (
              <li
                key={item.id}
                className="flex items-center justify-between mb-4"
              >
                <span className="text-gray-800">{item.name}</span>
                <div className="flex items-center">
                  <button
                    onClick={() => dispatch(decrementQuantity(item.id))}
                    className="px-2 py-1 bg-gray-200 rounded-l-md"
                  >
                    -
                  </button>
                  <span className="px-2">{item.quantity}</span>
                  <button
                    onClick={() => dispatch(incrementQuantity(item.id))}
                    className="px-2 py-1 bg-gray-200 rounded-r-md"
                  >
                    +
                  </button>
                </div>
                <span className="text-gray-900">
                  ${(item.price * item.quantity).toFixed(2)}
                </span>
                <button
                  onClick={() => dispatch(removeFromCart(item.id))}
                  className="text-red-500 hover:text-red-700 transition ease-in-out duration-300"
                >
                  <i className="fas fa-trash-alt"></i>
                </button>
              </li>
            ))}
          </ul>
          <div className="mt-4 flex justify-between">
            <span className="font-bold text-gray-900">Итого:</span>
            <span className="font-bold text-gray-900">${totalPrice}</span>
          </div>
        </section>
      )}
    </div>
  );
}
