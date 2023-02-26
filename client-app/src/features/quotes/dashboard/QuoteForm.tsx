import { Button, Form } from "semantic-ui-react";
import { observer } from "mobx-react-lite";
import { useStore } from "../../../app/stores/store";
import agent from "../../../app/api/agent";

export default observer(function QuoteForm() {
  const { quoteStore } = useStore();

  const handleCalculateRate = async () => {
    try {
      quoteStore.listOfCompanies = [];
      await quoteStore.loadListOfCompanies();
    } catch (error) {
      console.log(error);
    }
  };

  const handleSubmit = () => {
    agent.ShippingRates.quoteResponse(quoteStore.parcelSpecs)
      .then((quoteResponseData) => {
        console.log("quoteResponseData:", quoteResponseData);
        quoteStore.setCompanyFound(quoteResponseData.found);
        quoteStore.setVolume(quoteResponseData.volume);
        quoteStore.setWeight(quoteResponseData.weight);
        quoteStore.setCompanyName(quoteResponseData.companySupplier);
        quoteStore.setPrice(quoteResponseData.mostCompetitiveRate);
        quoteStore.setError(undefined);
        quoteStore.setResponseReceived(true);
      })
      .catch((error) => {
        console.log("API error:", error);
        quoteStore.setError(error.message);
      });
  };

  return (
    <Form className="form" onSubmit={handleSubmit} autoComplete="off">
      <div className="two column row">
        <div className="column">
          <h3 style={{ marginTop: "20px", marginBottom: "10px" }}>
            Your Details:
          </h3>
          <Form.Field>
            <label>First Name</label>
            <input
              type="text"
              placeholder="First Name"
              value={quoteStore.parcelSpecs.firstname}
              name="firstname"
              onChange={quoteStore.handleParcelSpecificationChange}
            />
          </Form.Field>
          <Form.Field>
            <label>Last Name</label>
            <input
              type="text"
              placeholder="Last Name"
              value={quoteStore.parcelSpecs.lastname}
              name="lastname"
              onChange={quoteStore.handleParcelSpecificationChange}
            />
          </Form.Field>
          <Form.Field>
            <label>Email</label>
            <input
              type="text"
              placeholder="Email"
              value={quoteStore.parcelSpecs.emailaddress}
              name="emailaddress"
              onChange={quoteStore.handleParcelSpecificationChange}
            />
          </Form.Field>
        </div>
        <div className="column">
          <h3 style={{ marginTop: "20px", marginBottom: "10px" }}>
            Package Parameters:
          </h3>
          <Form.Field>
            <label>Weight (kg)</label>
            <input
              type="number"
              placeholder="Weight"
              value={quoteStore.parcelSpecs.weightinkg}
              name="weightinkg"
              onChange={quoteStore.handleParcelSpecificationChange}
            />
          </Form.Field>
          <Form.Field>
            <label>Length (cm)</label>
            <input
              type="number"
              placeholder="Length"
              value={quoteStore.parcelSpecs.lengthincm}
              name="lengthincm"
              onChange={quoteStore.handleParcelSpecificationChange}
            />
          </Form.Field>
          <Form.Field>
            <label>Width (cm)</label>
            <input
              type="number"
              placeholder="Width"
              value={quoteStore.parcelSpecs.widthincm}
              name="widthincm"
              onChange={quoteStore.handleParcelSpecificationChange}
            />
          </Form.Field>
          <Form.Field>
            <label>Height (cm)</label>
            <input
              type="number"
              placeholder="Height"
              value={quoteStore.parcelSpecs.heightincm}
              name="heightincm"
              onChange={quoteStore.handleParcelSpecificationChange}
            />
          </Form.Field>
          <Button
            color="blue"
            type="submit"
            className="btn"
            onClick={handleCalculateRate}
          >
            Calculate Rate
          </Button>
        </div>
      </div>
    </Form>
  );
});
