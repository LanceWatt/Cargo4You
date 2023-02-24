import React, { ChangeEvent, useEffect, useState } from "react";
import "./App.css";
import axios from "axios";
import { ParcelSpecification } from "../models/ParcelSpecification";
import Navbar from "./Navbar";
import QuoteDashBoard from "../../features/quotes/dashboard/QuoteDashBoard";

function App() {
  const [parcelSpecs, setParcelSpecs] = useState<ParcelSpecification>({
    firstname: "",
    lastname: "",
    email: "",
    length: 0,
    width: 0,
    height: 0,
    weight: 0,
  });

  const [price, setPrice] = useState<number | undefined>();
  const [companyName, setCompanyName] = useState<string | undefined>();
  const [error, setError] = useState<string | undefined>();
  const [responseReceived, setResponseReceived] = useState(false);
  const [listOfCompanies, setListOfCompanies] = useState([]);

  const handleParcelSpecificationChange = (
    event: ChangeEvent<HTMLInputElement>
  ) => {
    setParcelSpecs({
      ...parcelSpecs,
      [event.target.name]: event.target.value,
    });
  };

  const handleSubmit = () => {
    axios
      .post("https://localhost:5000/api/ShippingRates", parcelSpecs)
      .then((response) => {
        const quoteResponseData = response.data;
        setCompanyName(quoteResponseData.companySupplier);
        setPrice(quoteResponseData.mostCompetitiveRate);
        setError(undefined);
        setResponseReceived(true);
      })
      .catch((error) => {
        setCompanyName(undefined);
        setPrice(undefined);
        setError(error.response?.data?.message || "Something went wrong");
        setResponseReceived(true);
      });
  };

  useEffect(() => {
    axios
      .get("https://localhost:5000/api/ShippingRates/")
      .then((response) => {
        const list = response.data;
        setListOfCompanies(list);
      })
      .catch((error) => {
        // handle error
      });
  }, []);

  return (
    <div>
      <div className="background-image"></div>
      <Navbar />
      <QuoteDashBoard
        parcelSpecs={parcelSpecs}
        companyName={companyName}
        price={price}
        onSpecsChange={handleParcelSpecificationChange}
        error={error}
        handleSubmit={handleSubmit}
        responseReceived={responseReceived}
        listOfCompanies={listOfCompanies}
      />
    </div>
  );
}

export default App;
