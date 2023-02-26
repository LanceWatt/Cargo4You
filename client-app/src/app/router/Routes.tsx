import { createBrowserRouter, RouteObject } from "react-router-dom";
import ContactPage from "../../features/contact/ContactPage";
import QuoteDashBoard from "../../features/quotes/dashboard/QuoteDashBoard";
import App from "../layout/App";

export const routes: RouteObject[] = [
  {
    path: "/",
    element: <App />,
    children: [
      { path: "/", element: <App /> },
      { path: "contact", element: <ContactPage /> },
      // { path: "quotes", element: <QuoteDashBoard /> },
    ],
  },
];

export const router = createBrowserRouter(routes);
