import React, { useEffect, useRef } from "react";
import { useDispatch, useSelector } from "react-redux";
import { Link, useLocation } from "react-router-dom";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faUserCircle } from "@fortawesome/free-solid-svg-icons";
import {
  toggleMenu,
  closeMenu,
  setActiveItem,
  selectNavbar,
} from "../store/navbarSlice";
import NavItems from "../Routes";

export default function Navbar() {
  const dispatch = useDispatch();
  const location = useLocation();

  const { menus, activeItem } = useSelector(selectNavbar);
  const moreMenuRef = useRef(null);

  const navItems = NavItems[0].children.filter((item) => item.path);

  useEffect(() => {
    const handleClickOutside = (event) => {
      if (moreMenuRef.current && !moreMenuRef.current.contains(event.target)) {
        if (menus.moreMenu) {
          dispatch(closeMenu("moreMenu"));
        }
      }
    };

    if (menus.moreMenu) {
      document.addEventListener("click", handleClickOutside);
    }

    return () => {
      document.removeEventListener("click", handleClickOutside);
    };
  }, [dispatch, menus.moreMenu]);

  useEffect(() => {
    const currentPath = location.pathname;
    const pathToActiveItem = currentPath.replace("/", "") || "home";

    if (activeItem !== pathToActiveItem) {
      dispatch(setActiveItem(pathToActiveItem));
    }
  }, [dispatch, location.pathname, activeItem]);

  return (
    <div className="fixed top-0 left-0 w-full z-50">
      <div className="bg-gray-800 shadow-md">
        <div className="w-full text-gray-200">
          <div className="flex flex-col max-w-screen-xl px-4 mx-auto md:items-center md:justify-between md:flex-row md:px-6 lg:px-8">
            <div className="flex flex-row items-center justify-between p-4">
              <span className="text-lg font-semibold tracking-widest text-yellow-400 uppercase rounded-lg focus:outline-none focus:shadow-outline">
                Watch Store
              </span>
              <button
                className="rounded-lg md:hidden focus:outline-none focus:shadow-outline"
                onClick={() => dispatch(toggleMenu("mobileMenu"))}
              >
                <svg
                  fill="currentColor"
                  viewBox="0 0 20 20"
                  className="w-6 h-6"
                >
                  <path
                    fillRule="evenodd"
                    d={
                      menus.mobileMenu
                        ? "M4.293 4.293a1 1 0 011.414 0L10 8.586l4.293-4.293a1 1 0 111.414 1.414L11.414 10l4.293 4.293a1 1 0 01-1.414 1.414L10 11.414l-4.293 4.293a1 1 0 01-1.414-1.414L8.586 10 4.293 5.707a1 1 0 010-1.414z"
                        : "M3 5a1 1 0 011-1h12a1 1 0 110 2H4a1 1 0 01-1-1zM3 10a1 1 0 011-1h12a1 1 0 110 2H4a1 1 0 01-1-1zM9 15a1 1 0 011-1h6a1 1 0 110 2h-6a1 1 0 01-1-1z"
                    }
                    clipRule="evenodd"
                  />
                </svg>
              </button>
            </div>
            <nav
              className={`flex-col flex-grow pb-4 md:pb-0 md:flex md:justify-end md:flex-row ${
                menus.mobileMenu ? "flex" : "hidden"
              }`}
            >
              {navItems.map((item, index) => (
                <Link to={`/${item.path.toLowerCase()}`} key={index}>
                  <button
                    style={{ textTransform: "capitalize" }}
                    className={`cursor-pointer px-4 py-2 mt-2 text-sm font-semibold rounded-lg md:mt-0 md:ml-4 focus:outline-none focus:shadow-outline 
                                        ${
                                          activeItem === item.path
                                            ? "bg-gray-700 text-yellow-400"
                                            : "bg-transparent text-gray-200 hover:text-gray-300 focus:text-gray-300 hover:bg-gray-700 focus:bg-gray-700"
                                        }`}
                    onClick={() => dispatch(setActiveItem(item.path))}
                  >
                    {item.name}
                  </button>
                </Link>
              ))}

              {menus.mobileMenu && (
                <div className="flex flex-row items-center justify-end mt-4 space-x-4">
                  <Link to={"/auth"}>
                    <button
                      onClick={() => dispatch(setActiveItem("auth"))}
                      className={`p-2 rounded-full text-xl ${
                        activeItem === "auth"
                          ? "bg-gray-700 text-yellow-400"
                          : "text-gray-200 hover:text-gray-300 focus:text-gray-300 hover:bg-gray-700 focus:bg-gray-700"
                      }`}
                    >
                      <FontAwesomeIcon icon={faUserCircle} />
                    </button>
                  </Link>
                </div>
              )}
            </nav>
            <div className="absolute right-0 mr-5 p-5 hidden md:flex space-x-4">
              <Link to={"/auth"}>
                <button
                  onClick={() => dispatch(setActiveItem("auth"))}
                  className={`p-2 rounded-full text-xl ${
                    activeItem === "auth"
                      ? "bg-gray-700 text-yellow-400"
                      : "text-gray-200 hover:text-gray-300 focus:text-gray-300 hover:bg-gray-700 focus:bg-gray-700"
                  }`}
                >
                  <FontAwesomeIcon icon={faUserCircle} />
                </button>
              </Link>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}
