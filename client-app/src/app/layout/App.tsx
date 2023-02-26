import React, { useEffect, useState } from "react";
import "./App.css";
import { ParcelSpecification } from "../models/ParcelSpecification";
import Navbar from "./Navbar";
import QuoteDashBoard from "../../features/quotes/dashboard/QuoteDashBoard";
import { useStore } from "../stores/store";
import { observer } from "mobx-react-lite";

function App() {
  const { quoteStore } = useStore();

  const [parcelSpecs, setParcelSpecs] = useState<ParcelSpecification>({
    firstname: "",
    lastname: "",
    emailaddress: "",
    lengthincm: 0,
    widthincm: 0,
    heightincm: 0,
    weightinkg: 0,
  });

  // Dynamically receive the list of suppliers
  useEffect(() => {
    quoteStore.loadListOfCompanies();
  }, [quoteStore]);

  return (
    <div>
      <div className="background-image"></div>
      <Navbar />
      <QuoteDashBoard />
    </div>
  );
}

export default observer(App);
