import axios, { AxiosResponse } from 'axios';

axios.defaults.baseURL = 'http://localhost:5000/api';

const responseBody = (response: AxiosResponse) => response.data;

const requests = {
    get: (url: string) => axios.get(url).then(responseBody),
    post: (url: string, body: {}) => axios.post(url, body).then(responseBody),
}

const ShippingRates = {
    list: () => requests.get('/ShippingRates'),
    quoteResponse: (parcelSpecs: {}) => requests.post('/ShippingRates', parcelSpecs),
}

const agent = {  
    ShippingRates
}

export default agent;