import { configureStore } from "@reduxjs/toolkit";
import authReducer from "./authSlice";
import navbarReducer from "./navbarSlice";
import catalogReducer from "./productsSlice";

const store = configureStore({
  reducer: {
    auth: authReducer,
    navbar: navbarReducer,
    catalog: catalogReducer,
  },
});

export default store;
