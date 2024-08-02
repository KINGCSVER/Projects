import Home from "./pages/Home";
import Catalog from "./pages/Catalog";
import AboutUs from "./pages/AboutUs";
import News from "./pages/News";
import Authentication from "./pages/Auth/Auth";
import { Outlet } from "react-router-dom";
import { faNewspaper } from "@fortawesome/free-solid-svg-icons";

const moreItems = [
  {
    path: "news",
    title: "News",
    description: "Stay updated with the latest news",
    icon: faNewspaper,
    element: <News />,
  },
];

const appRoutes = [
  {
    path: "/",
    element: <Home />,
  },
  {
    path: "home",
    element: <Home />,
  },
  {
    path: "catalog",
    element: <Catalog />,
  },
  {
    path: "aboutus",
    element: <AboutUs />,
  },
  {
    path: "more",
    element: <Outlet />,
    children: moreItems.map((item) => ({
      path: item.path,
      element: item.element,
    })),
  },
  {
    path: "auth",
    element: <Authentication />,
  },
];

export default appRoutes;
