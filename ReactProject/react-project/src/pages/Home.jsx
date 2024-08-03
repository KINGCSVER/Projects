import React from "react";
import Carousel from "../components/Carousel/Carousel";

export default function Home() {
  const img = require("../assets/1920x1080-px-luxury-watches-watch-1291761-wallhere.com.jpg");
  return (
    <div>
      <div className="relative">
        <div className="">
          <img src={img} alt="title-img" />
        </div>
        <div className="absolute top-0 flex flex-col justify-center w-full">
          <div className="px-4 mx-auto max-w-7xl sm:px-6 lg:px-8 relative z-20 bg-black/30 backdrop-blur-none mt-5 rounded">
            <div className="max-w-xl mx-auto text-center py-12">
              <h1 className="text-4xl font-bold sm:text-6xl">
                <span className="text-white bg-clip-text bg-gradient-to-r from-gold-500 to-silver-600">
                  Discover the Finest Timepieces for Every Occasion
                </span>
              </h1>
              <p className="mt-5 text-base text-white sm:text-xl">
                Explore our exquisite collection of watches. From classic to
                contemporary, find the perfect timepiece that suits your style.
              </p>

              <div
                title="Shop Now"
                className="inline-flex items-center px-6 py-4 mt-8 font-semibold text-white transition-all duration-200 bg-gold-600 rounded-lg hover:bg-gold-700 focus:bg-gold-700"
                role="button"
              >
                Shop Now
                <svg
                  className="w-6 h-6 ml-4"
                  xmlns="http://www.w3.org/2000/svg"
                  fill="none"
                  viewBox="0 0 24 24"
                  stroke="currentColor"
                >
                  <path
                    strokeLinecap="round"
                    strokeLinejoin="round"
                    strokeWidth="1.5"
                    d="M13 9l3 3m0 0l-3 3m3-3H8m13 0a9 9 0 11-18 0 9 9 0 0118 0z"
                  />
                </svg>
              </div>
            </div>
          </div>

          <div className="py-12">
            <div className="grid grid-cols-1 px-4 sm:px-6 md:px-12 lg:px-24 gap-x-12 gap-y-8 sm:grid-cols-3">
              <div className="cursor-pointer flex items-center p-4 border border-gold-600 rounded-lg shadow-md transition-transform duration-500 transform hover:scale-105 hover:bg-gold-200">
                <svg
                  className="flex-shrink-0 w-8 h-8 text-gold-600"
                  xmlns="http://www.w3.org/2000/svg"
                  fill="none"
                  viewBox="0 0 31 25"
                >
                  <path
                    d="M25.1667 14.187H20.3333C17.6637 14.187 15.5 16.3507 15.5 19.0203V19.8258C15.5 19.8258 18.0174 20.6314 22.75 20.6314C27.4826 20.6314 30 19.8258 30 19.8258V19.0203C30 16.3507 27.8363 14.187 25.1667 14.187Z"
                    stroke="#FFD700"
                    strokeWidth="1.5"
                    strokeMiterlimit="10"
                    strokeLinecap="round"
                    strokeLinejoin="round"
                  />
                  <path
                    d="M18.7227 6.9369C18.7227 4.71276 20.5263 2.90912 22.7504 2.90912C24.9746 2.90912 26.7782 4.71276 26.7782 6.9369C26.7782 9.16104 24.9746 11.7702 22.7504 11.7702C20.5263 11.7702 18.7227 9.16104 18.7227 6.9369Z"
                    stroke="#FFD700"
                    strokeWidth="1.5"
                    strokeMiterlimit="10"
                    strokeLinecap="round"
                    strokeLinejoin="round"
                  />
                  <path
                    d="M13.2231 15.8512H7.11157C3.73595 15.8512 1 18.5871 1 21.9628V22.9814C1 22.9814 4.18311 24 10.1674 24C16.1516 24 19.3347 22.9814 19.3347 22.9814V21.9628C19.3347 18.5871 16.5988 15.8512 13.2231 15.8512Z"
                    fill="#0B1715"
                    stroke="white"
                    strokeWidth="1.5"
                    strokeMiterlimit="10"
                    strokeLinecap="round"
                    strokeLinejoin="round"
                  />
                  <path
                    d="M5.07422 6.68386C5.07422 3.87152 7.35485 1.59088 10.1672 1.59088C12.9795 1.59088 15.2602 3.87152 15.2602 6.68386C15.2602 9.4962 12.9795 12.7954 10.1672 12.7954C7.35485 12.7954 5.07422 9.4962 5.07422 6.68386Z"
                    fill="#0B1715"
                    stroke="white"
                    strokeWidth="1.5"
                    strokeMiterlimit="10"
                    strokeLinecap="round"
                    strokeLinejoin="round"
                  />
                </svg>
                <p className="ml-3 text-sm text-white">
                  Exclusive luxury timepieces
                </p>
              </div>

              <div className="cursor-pointer flex items-center p-4 border border-gold-600 rounded-lg shadow-md transition-transform duration-500 transform hover:scale-105 hover:bg-gold-200">
                <svg
                  className="flex-shrink-0 w-8 h-8 text-gold-600"
                  xmlns="http://www.w3.org/2000/svg"
                  fill="none"
                  viewBox="0 0 23 23"
                >
                  <path
                    d="M19.8335 21.9166H3.16683C2.6143 21.9166 2.08439 21.6972 1.69369 21.3065C1.30299 20.9158 1.0835 20.3858 1.0835 19.8333V3.16665C1.0835 2.61411 1.30299 2.08421 1.69369 1.69351C2.08439 1.30281 2.6143 1.08331 3.16683 1.08331H19.8335C20.386 1.08331 20.9159 1.30281 21.3066 1.69351C21.6973 2.08421 21.9168 2.61411 21.9168 3.16665V19.8333C21.9168 20.3858 21.6973 20.9158 21.3066 21.3065C20.9159 21.6972 20.386 21.9166 19.8335 21.9166Z"
                    stroke="white"
                    strokeWidth="1.5"
                    strokeMiterlimit="10"
                    strokeLinecap="round"
                    strokeLinejoin="round"
                  />
                  <path
                    d="M7 12.6667L9.25 15L16 8"
                    stroke="#FFD700"
                    strokeWidth="1.5"
                    strokeMiterlimit="10"
                    strokeLinecap="round"
                    strokeLinejoin="round"
                  />
                </svg>
                <p className="ml-3 text-sm text-white">
                  Timeless elegance and precision
                </p>
              </div>

              <div className="cursor-pointer flex items-center p-4 border border-gold-600 rounded-lg shadow-md transition-transform duration-500 transform hover:scale-105 hover:bg-gold-200">
                <svg
                  className="flex-shrink-0 w-8 h-8 text-gold-600"
                  xmlns="http://www.w3.org/2000/svg"
                  fill="none"
                  viewBox="0 0 24 24"
                >
                  <path
                    d="M12 2C6.477 2 2 6.477 2 12s4.477 10 10 10 10-4.477 10-10S17.523 2 12 2zM12 19.5a1.5 1.5 0 110-3 1.5 1.5 0 010 3zm1.5-4.5H10.5v-6h3v6z"
                    fill="#FFD700"
                  />
                </svg>
                <p className="ml-3 text-sm text-white">
                  Wide range of watch collections
                </p>
              </div>
            </div>
          </div>
        </div>
      </div>

      <Carousel />
    </div>
  );
}
