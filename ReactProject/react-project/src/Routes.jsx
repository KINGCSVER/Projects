import Home from "./pages/Home";
import Catalog from "./pages/Catalog";
import AboutUs from "./pages/AboutUs";
import News from "./pages/News";
import Auth from "./pages/Auth/Auth";

import App from "./App";

const appRoutes = [
  {
    path: "/",
    element: <App />,
    children: [
      { path: "/", element: <Home /> },
      { path: "/catalog", element: <Catalog /> },
      { path: "/aboutUs", element: <AboutUs /> },
      { path: "/news", element: <News /> },
      { path: "/auth", element: <Auth /> },
    ],
  },
];

export default appRoutes;
