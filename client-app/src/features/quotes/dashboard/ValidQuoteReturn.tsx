import { Button, Card, Image } from "semantic-ui-react";
import { useStore } from "../../../app/stores/store";
import { observer } from "mobx-react-lite";

export default observer(function ValidQuoteReturn() {
  const { quoteStore } = useStore();

  return (
    <Card>
      <Image
        src="https://react.semantic-ui.com/images/avatar/large/matthew.png"
        wrapped
        ui={false}
      />
      <Card.Content>
        <Card.Header>
          Order Now from {quoteStore.companyName} and Get the Best Shipping
          Rate!
        </Card.Header>
        <Card.Meta>
          <span className="date">Joined in 2015</span>
        </Card.Meta>
        <Card.Description>
          The best offer we can provide is with {quoteStore.companyName}!
          <br />
          The shipping rate is EUR {quoteStore.price}, for a Package of{" "}
          {quoteStore.weight}Kg & with a volume of {quoteStore.volume} cubic
          meters;
        </Card.Description>
      </Card.Content>
      <Card.Content extra>
        <Button color="green" size="large">
          Order Now from {quoteStore.companyName}
        </Button>
        <br />
        <p style={{ marginTop: "1em", color: "#808080", fontSize: "1.2em" }}>
          Click the button above to place your order and get the best deal!
        </p>
      </Card.Content>
    </Card>
  );
});
