import { Button, Item, Form } from "semantic-ui-react";
import { ParcelSpecification } from "../../../app/models/ParcelSpecification";

interface Props {
  parcelSpecs: ParcelSpecification;
  handleSubmit: () => void;
  onSpecsChange: (event: React.ChangeEvent<HTMLInputElement>) => void;
  
}

export default function QuoteForm(props: Props) {
  return (
    <Form className="form" onSubmit={props.handleSubmit} autoComplete="off">
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
              value={props.parcelSpecs.firstname}
              name="firstname"
              onChange={props.onSpecsChange}
            />
          </Form.Field>
          <Form.Field>
            <label>Last Name</label>
            <input
              type="text"
              placeholder="Last Name"
              value={props.parcelSpecs.lastname}
              name="lastname"
              onChange={props.onSpecsChange}
            />
          </Form.Field>
          <Form.Field>
            <label>Email</label>
            <input
              type="text"
              placeholder="Email"
              value={props.parcelSpecs.emailaddress}
              name="emailaddress"
              onChange={props.onSpecsChange}
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
              value={props.parcelSpecs.weightinkg}
              name="weightinkg"
              onChange={props.onSpecsChange}
            />
          </Form.Field>
          <Form.Field>
            <label>Length (cm)</label>
            <input
              type="number"
              placeholder="Length"
              value={props.parcelSpecs.lengthincm}
              name="lengthincm"
              onChange={props.onSpecsChange}
            />
          </Form.Field>
          <Form.Field>
            <label>Width (cm)</label>
            <input
              type="number"
              placeholder="Width"
              value={props.parcelSpecs.widthincm}
              name="widthincm"
              onChange={props.onSpecsChange}
            />
          </Form.Field>
          <Form.Field>
            <label>Height (cm)</label>
            <input
              type="number"
              placeholder="Height"
              value={props.parcelSpecs.heightincm}
              name="heightincm"
              onChange={props.onSpecsChange}
            />
          </Form.Field>
          <Button color="blue" type="submit" className="btn">
            Calculate Rate
          </Button>
        </div>
      </div>
    </Form>
  );
}
