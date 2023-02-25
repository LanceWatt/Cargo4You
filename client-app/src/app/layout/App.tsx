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
    emailaddress: "",
    lengthincm: 0,
    widthincm: 0,
    heightincm: 0,
    weightinkg: 0,
  });
  const [price, setPrice] = useState<number | undefined>();
  const [companyName, setCompanyName] = useState<string | undefined>();
  const [companyFound, setCompanyFound] = useState(false);
  const [volume, setVolume] = useState<number | undefined>();
  const [weight, setWeight] = useState<number | undefined>();
  const [error, setError] = useState<string | undefined>();
  const [responseReceived, setResponseReceived] = useState(false);
  const [listOfCompanies, setListOfCompanies] = useState<string[]>([]);

  const handleParcelSpecificationChange = (
    event: ChangeEvent<HTMLInputElement>
  ) => {
    setParcelSpecs({
      ...parcelSpecs,
      [event.target.name]: event.target.value,
    });
  };

  useEffect(() => {
    console.log("companyName:", companyName);
  }, [companyName]);

  const handleSubmit = () => {
    axios
      .post("http://localhost:5000/api/ShippingRates", parcelSpecs)
      .then((response) => {
        const quoteResponseData = response.data;
        console.log("quoteResponseData:", quoteResponseData);
        setCompanyFound(quoteResponseData.found);
        setVolume(quoteResponseData.volume);
        setWeight(quoteResponseData.weight);
        setCompanyName(quoteResponseData.companySupplier);
        setPrice(quoteResponseData.mostCompetitiveRate);
        setError(undefined);
        setResponseReceived(true);
      })
      .catch((error) => {
        console.log("API error:", error);
        setError(error.message);
      });
  };

  useEffect(() => {
    axios
      .get("http://localhost:5000/api/ShippingRates")
      .then((response) => {
        const list = response.data;
        setListOfCompanies(list);
      })
      .catch((error) => {});
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
        volume={volume}
        weight={weight}
        companyFound={companyFound}
      />
    </div>
  );
}

export default App;
