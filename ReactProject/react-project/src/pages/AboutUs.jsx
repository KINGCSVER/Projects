import React from "react";

export default function AboutUs() {
  return (
    <section className="py-12 bg-gradient-to-r from-[#f9f9f9] to-[#e0e0e0] sm:py-16 lg:py-20">
      <div className="px-4 mx-auto max-w-7xl sm:px-6 lg:px-8">
        <div className="text-center">
          <h2 className="text-3xl font-bold leading-tight text-gray-900 sm:text-4xl xl:text-5xl font-serif">
            About Us
          </h2>
          <p className="mt-4 text-base leading-7 text-gray-600 sm:mt-8 font-serif">
            We strive to offer the best watches and exceptional service to our
            customers.
          </p>
        </div>

        <div className="grid grid-cols-1 mt-10 text-center sm:mt-16 sm:grid-cols-2 sm:gap-x-12 gap-y-12 md:grid-cols-3 md:gap-0 xl:mt-24">
          {[
            {
              title: "Support",
              description:
                "Our support team is ready to help you with any questions or concerns. We care about your satisfaction.",
              svgPaths: [
                "M23 2C17.48 2 13 6.48 13 12C13 17.52 17.48 22 23 22C28.52 22 33 17.52 33 12C33 6.48 28.52 2 23 2Z",
                "M1 19H3C3 12.27 7.72 7.58 14 7.58C20.28 7.58 25 12.27 25 19H27",
              ],
            },
            {
              title: "Sale",
              description:
                "Our sales team is ready to help you choose the perfect watch for you. Contact us for personalized help.",
              svgPaths: [
                "M12 6V18M6 12H18",
                "M18 3V9H21.15C22.1 9 23.09 9.52 23.76 10.34L26.11 13.46C26.56 13.96 27 14.5 27 15.03V17H15.03V15.03C15.5 14.5 15.96 13.96 16.46 13.46L18.11 11.81",
              ],
            },
            {
              title: "Introduction",
              description:
                "Our introduction process provides you with the best experience from the very beginning. We accompany you at every stage.",
              svgPaths: [
                "M2 2H22V22H2V2Z",
                "M8 5H14V11H8V5Z",
                "M8 13H14V19H8V13Z",
              ],
            },
            {
              title: "Quality control",
              description:
                "Our QA team ensures the highest standards for our watches, ensuring reliability and durability.",
              svgPaths: [
                "M12 2C6.48 2 2 6.48 2 12C2 17.52 6.48 22 12 22C17.52 22 22 17.52 22 12C22 6.48 17.52 2 12 2Z",
                "M8 8H16V16H8V8Z",
              ],
            },
            {
              title: "Innovations",
              description:
                "We strive to innovate to stay one step ahead in the industry by constantly improving our watches and services.",
              svgPaths: [
                "M6 18L18 6M18 18L6 6",
                "M12 4C14.21 4 16 5.79 16 8C16 10.21 14.21 12 12 12C9.79 12 8 10.21 8 8C8 5.79 9.79 4 12 4Z",
              ],
            },
            {
              title: "Stability",
              description:
                "We are committed to sustainable practices, ensuring that our operations have minimal environmental impact.",
              svgPaths: ["M5 5H19V19H5V5Z", "M10 10H14V14H10V10Z"],
            },
          ].map((item, index) => (
            <div
              key={index}
              className="cursor-pointer md:p-8 lg:p-14 md:border-l md:border-gray-200 hover:bg-gray-200 hover:scale-105 transition-all duration-300 ease-in-out"
            >
              <svg
                className="mx-auto"
                width={index === 1 ? "46" : "42"}
                height={index === 1 ? "46" : "42"}
                viewBox="0 0 46 46"
                fill="none"
                xmlns="http://www.w3.org/2000/svg"
              >
                {item.svgPaths.map((path, i) => (
                  <path
                    key={i}
                    d={path}
                    fill={i === 0 ? "#D4D4D8" : "none"}
                    stroke="#000"
                    strokeWidth="2"
                    strokeMiterlimit="10"
                    strokeLinecap="round"
                    strokeLinejoin="round"
                  />
                ))}
              </svg>
              <h3 className="mt-12 text-xl font-bold text-gray-900 font-serif">
                {item.title}
              </h3>
              <p className="mt-5 text-base text-gray-600 font-serif">
                {item.description}
              </p>
            </div>
          ))}
        </div>
      </div>
    </section>
  );
}
