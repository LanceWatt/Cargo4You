import { Container, Grid } from "semantic-ui-react";
import { ParcelSpecification } from "../../../app/models/ParcelSpecification";
import "./../../../styles/QuotesDashboard.css";
import CompaniesList from "./CompaniesList";
import InValidQuoteReturn from "./InvalidQuoteReturn";
import QuoteForm from "./QuoteForm";
import ValidQuoteReturn from "./ValidQuoteReturn";

interface Props {
  parcelSpecs: ParcelSpecification;
  price?: number;
  companyName?: string;
  onSpecsChange: (event: React.ChangeEvent<HTMLInputElement>) => void;
  error?: string | null;
  handleSubmit: () => void;
  responseReceived: boolean;
  listOfCompanies: string[];
  volume?: number;
  weight?: number;
  companyFound: boolean;
}

export default function QuoteDashBoard(props: Props) {
  const { listOfCompanies } = props;

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
            <CompaniesList listOfCompanies={listOfCompanies} />
          </div>
        </Grid.Column>

        <Grid.Column className="form-container">
          <QuoteForm
            handleSubmit={props.handleSubmit}
            parcelSpecs={props.parcelSpecs}
            onSpecsChange={props.onSpecsChange}
          />
        </Grid.Column>

        <Grid.Column className="form-container">
          {props.responseReceived &&
            (props.companyFound ? (
              <ValidQuoteReturn
                price={props.price}
                companyName={props.companyName}
                volume={props.volume}
                weight={props.weight}
              />
            ) : (
              <InValidQuoteReturn
                price={props.price}
                companyName={props.companyName}
                volume={props.volume}
                weight={props.weight}
              />
            ))}
        </Grid.Column>
      </Grid>
    </Container>
  );
}
