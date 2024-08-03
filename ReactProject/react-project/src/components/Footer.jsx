import React from "react";

export default function Footer() {
  const Year = new Date().getFullYear();

  return (
    <footer className="relative bg-gray-800 text-white mt-5">
      <div className="relative">
        <svg
          data-name="Layer 1"
          xmlns="http://www.w3.org/2000/svg"
          viewBox="0 0 1200 120"
          preserveAspectRatio="none"
          className="relative w-full h-20"
        >
          <defs>
            <linearGradient id="gradient1" x1="0%" y1="0%" x2="100%" y2="0%">
              <stop offset="0%" style={{ stopColor: "#333", stopOpacity: 1 }} />
              <stop
                offset="100%"
                style={{ stopColor: "#555", stopOpacity: 1 }}
              />
            </linearGradient>
          </defs>
          <path
            d="M321.39,56.44c58-10.79,114.16-30.13,172-41.86,82.39-16.72,168.19-17.73,250.45-.39C823.78,31,906.67,72,985.66,92.83c70.05,18.48,146.53,26.09,214.34,3V0H0V27.35A600.21,600.21,0,0,0,321.39,56.44Z"
            fill="url(#gradient1)"
          />
        </svg>

        <div className="grid lg:grid-cols-4 gap-6 px-4 md:px-8">
          <div className="flex flex-col gap-3">
            <h2 className="text-xl text-yellow-400">About Us</h2>
            <p className="text-base">
              Discover a curated selection of premium watches. Our collection
              features luxury timepieces that blend timeless design with modern
              sophistication.
            </p>
          </div>

          <div>
            <h3 className="text-lg font-semibold text-yellow-400 py-1 uppercase">
              Customer Service
            </h3>
            <ul className="space-y-2 inline-block">
              <li className="block text-white hover:text-yellow-400 hover:scale-110 transition-transform duration-500 cursor-pointer">
                Shipping & Returns
              </li>
              <li className="block text-white hover:text-yellow-400 hover:scale-110 transition-transform duration-500 cursor-pointer">
                Order Tracking
              </li>
              <li className="block text-white hover:text-yellow-400 hover:scale-110 transition-transform duration-500 cursor-pointer">
                FAQ
              </li>
              <li className="block text-white hover:text-yellow-400 hover:scale-110 transition-transform duration-500 cursor-pointer">
                Contact Us
              </li>
            </ul>
          </div>

          <div>
            <h3 className="text-lg text-yellow-400 py-1 uppercase">
              Information
            </h3>
            <ul className="space-y-2 inline-block">
              <li className="text-white hover:text-yellow-400 hover:scale-110 transition-transform duration-500 cursor-pointer">
                Privacy Policy
              </li>
              <li className="text-white hover:text-yellow-400 hover:scale-110 transition-transform duration-500 cursor-pointer">
                Terms of Service
              </li>
              <li className="text-white hover:text-yellow-400 hover:scale-110 transition-transform duration-500 cursor-pointer">
                Site Map
              </li>
              <li className="text-white hover:text-yellow-400 hover:scale-110 transition-transform duration-500 cursor-pointer">
                Careers
              </li>
            </ul>
          </div>

          <div>
            <h3 className="text-lg font-semibold text-yellow-400 py-1 uppercase">
              Contact
            </h3>
            <p className="text-base my-2">Email: contact@watchstore.com</p>
            <p className="text-base my-2">Phone: +1 234 567 890</p>
            <div className="flex space-x-4 mt-2">
              <button className="text-white hover:text-yellow-400 transform hover:scale-150 transition-transform duration-500 ease-in-out">
                <i className="fab fa-facebook-f cursor-pointer" />
              </button>
              <button className="text-white hover:text-yellow-400 transform hover:scale-150 transition-transform duration-500 ease-in-out">
                <i className="fab fa-twitter cursor-pointer" />
              </button>
              <button className="text-white hover:text-yellow-400 transform hover:scale-150 transition-transform duration-500 ease-in-out">
                <i className="fab fa-instagram cursor-pointer" />
              </button>
              <button className="text-white hover:text-yellow-400 transform hover:scale-150 transition-transform duration-500 ease-in-out">
                <i className="fab fa-linkedin-in cursor-pointer" />
              </button>
            </div>
          </div>
        </div>

        <div className="mt-8">
          <div className="h-full flex items-center justify-center mb-4">
            <div className="w-80 relative">
              <input
                placeholder="Contact Us"
                className="w-full text-gray-800 p-3 h-8 rounded-full focus:outline-none focus:border border-yellow-500"
              />
              <button className="bg-yellow-400 px-6 py-1 rounded-full text-gray-800 absolute top-0 right-0">
                Send
              </button>
            </div>
          </div>
        </div>
        <h6 className="text-center text-sm">&copy; Watch Store {Year}</h6>
      </div>
    </footer>
  );
}
