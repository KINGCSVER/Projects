import React from "react";

const images = [
  require("../assets/rolex-submariner.png"),
  require("../assets/patek-philippe-calatrava.png"),
  require("../assets/omega-seamaster.png"),
  require("../assets/tag-heuer-carrera.png"),
  require("../assets/audemars-piguet-royal-oak.png"),
  require("../assets/iwc-pilots-watch.png"),
];

export default function News() {
  const newsItems = [
    {
      id: 1,
      title: "Introducing Our Latest Luxury Watch Collection",
      date: "2024-01-15",
      description:
        "Explore our latest collection of luxury watches, designed to elevate your style and sophistication.",
      image: images[0],
    },
    {
      id: 2,
      title: "Exclusive Discounts on Top Brands",
      date: "2024-03-10",
      description:
        "Enjoy exclusive discounts on top watch brands. Shop now to get the best deals!",
      image: images[1],
    },
    {
      id: 3,
      title: "Trendy Watches for the Modern Man",
      date: "2024-04-05",
      description:
        "Discover the latest trends in watches for men. Find the perfect timepiece to match your style.",
      image: images[2],
    },
    {
      id: 4,
      title: "Limited Edition Watches Available Now",
      date: "2024-05-20",
      description:
        "Check out our limited edition watches, crafted for collectors and enthusiasts. Limited availability!",
      image: images[3],
    },
    {
      id: 5,
      title: "Smart Watches: The Future of Timekeeping",
      date: "2024-06-15",
      description:
        "Step into the future with our range of smart watches, combining advanced technology with luxury.",
      image: images[4],
    },
    {
      id: 6,
      title: "Elegant Watches for Women",
      date: "2024-07-01",
      description:
        "Find the perfect elegant watch for every occasion. Explore our collection of women’s watches.",
      image: images[5],
    },
  ];

  return (
    <div className="bg-gray-50">
      <h3 className="text-gray-800 text-5xl font-semibold text-center py-12">
        Latest News
      </h3>

      <div className="container mx-auto px-4 py-12 grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-8">
        {[...newsItems].reverse().map((news) => (
          <div
            key={news.id}
            className="bg-white border border-gray-200 rounded-lg shadow-md hover:shadow-lg transition-shadow duration-300"
          >
            <img
              src={news.image}
              alt={news.title}
              className="w-full h-48 object-cover rounded-t-lg"
            />
            <div className="p-6">
              <h2 className="text-2xl font-semibold text-gray-800">
                {news.title}
              </h2>
              <p className="text-sm text-gray-500">{news.date}</p>
              <p className="mt-4 text-gray-700">{news.description}</p>
            </div>
          </div>
        ))}
      </div>

      <section className="bg-gray-800 text-white py-16">
        <div className="container mx-auto px-4 text-center">
          <h1 className="text-4xl font-semibold">Stay Updated!</h1>
          <p className="mt-4 text-lg">
            Subscribe to our newsletter for the latest news and exclusive offers
            on luxury watches.
          </p>
          <div className="mt-8 flex justify-center">
            <input
              type="email"
              className="border border-gray-400 rounded-l-md py-2 px-4 text-gray-700 placeholder-gray-400 focus:outline-none focus:ring-2 focus:ring-gold-600"
              placeholder="Your Email"
            />
            <button className="bg-gold-600 text-white rounded-r-md py-2 px-6 hover:bg-gold-700 focus:outline-none focus:ring-2 focus:ring-gold-600">
              Subscribe
            </button>
          </div>
        </div>
      </section>
    </div>
  );
}
