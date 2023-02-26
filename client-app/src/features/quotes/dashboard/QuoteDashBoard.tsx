import { Container, Grid } from "semantic-ui-react";
import { observer } from "mobx-react-lite";
import "./../../../styles/QuotesDashboard.css";
import CompaniesList from "./CompaniesList";
import { useStore } from "../../../app/stores/store";
import InValidQuoteReturn from "./InvalidQuoteReturn";
import ValidQuoteReturn from "./ValidQuoteReturn";
import QuoteForm from "./QuoteForm";

export default observer(function QuoteDashboard() {
  const { quoteStore } = useStore();

  return (
    <Container fluid>
      <Grid columns={3} className="quote-form-container">
        <Grid.Column className="quote-message-container">
          <div className="quote-message">
            <h2>Get the best shipping rates instantly!</h2>
            <p>
              Enter your parcel's dimensions and weight and we'll provide you
              with the best quotes from us and our partners.
            </p>

            <CompaniesList />
          </div>
        </Grid.Column>

        <Grid.Column className="form-container">
          <QuoteForm />
        </Grid.Column>

        <Grid.Column className="form-container">
          {quoteStore.responseReceived &&
            (quoteStore.companyFound ? (
              <ValidQuoteReturn />
            ) : (
              <InValidQuoteReturn />
            ))}
        </Grid.Column>
      </Grid>
    </Container>
  );
});
