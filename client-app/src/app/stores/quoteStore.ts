import { action, makeAutoObservable } from "mobx";
import agent from "../api/agent";
import { ParcelSpecification } from "../models/ParcelSpecification";
import React, { ChangeEvent, useEffect, useState } from "react";

export default class QuoteStore {
  listOfCompanies: string[] = [];
  parcelSpecs = {
    firstname: "",
    lastname: "",
    emailaddress: "",
    lengthincm: 0,
    widthincm: 0,
    heightincm: 0,
    weightinkg: 0,
  };
  price: number | undefined;
  companyName: string | undefined;
  companyFound = false;
  volume: number | undefined;
  weight: number | undefined;
  error: string | undefined;
  responseReceived = false;

  constructor() {
    makeAutoObservable(this);
  }

    @action setParcelSpecs = (value: ParcelSpecification) => {
    this.parcelSpecs = value;
  };

  @action setPrice = (value: number | undefined) => {
    this.price = value;
  };

  @action setCompanyName = (value: string | undefined) => {
    this.companyName = value;
  };

  @action setCompanyFound = (value: boolean) => {
    this.companyFound = value;
  };

  @action setVolume = (value: number | undefined) => {
    this.volume = value;
  };

  @action setWeight = (value: number | undefined) => {
    this.weight = value;
  };

  @action setError = (value: string | undefined) => {
    this.error = value;
  };

  @action setResponseReceived = (value: boolean) => {
    this.responseReceived = value;
  };

  @action handleParcelSpecificationChange = (
    event: ChangeEvent<HTMLInputElement>
  ) => {
    this.parcelSpecs = {
      ...this.parcelSpecs,
      [event.target.name]: event.target.value,
    };
  };


   @action loadListOfCompanies = async () => {
    try {
        const companies = await agent.ShippingRates.list();
        console.log(companies)
        this.listOfCompanies = companies;
        console.log(this.listOfCompanies)
    } catch (error) {
      console.log(error);
    }
  };
}