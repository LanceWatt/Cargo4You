import { createContext, useContext } from "react";
import QuoteStore from "./quoteStore";

interface Store{
    quoteStore: QuoteStore
}

export const store: Store = {
    quoteStore: new QuoteStore()
}

export const StoreContext = createContext(store);

export function useStore() {
    return useContext(StoreContext);
}