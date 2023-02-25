import { Button, Card, Image } from "semantic-ui-react";
interface Props {
  price?: number;
  companyName?: string;
  volume?: number;
  weight?: number;
}

export default function QuoteReturn(props: Props) {
  const { companyName, price, volume, weight } = props;

  return (
    <Card>
      <Image
        src="https://react.semantic-ui.com/images/avatar/large/matthew.png"
        wrapped
        ui={false}
      />
      <Card.Content>
        <Card.Header>
          Order Now from {companyName} and Get the Best Shipping Rate!
        </Card.Header>
        <Card.Meta>
          <span className="date">Joined in 2015</span>
        </Card.Meta>
        <Card.Description>
          The best offer we can provide is with {companyName}!
          <br />
          The shipping rate is EUR {price}.00, for a Package of {weight}Kg &
          with a volume of {volume}m3;
        </Card.Description>
      </Card.Content>
      <Card.Content extra>
        <Button color="green" size="large">
          Order Now from {companyName}
        </Button>
        <br />
        <p style={{ marginTop: "1em", color: "#808080", fontSize: "1.2em" }}>
          Click the button above to place your order and get the best deal!
        </p>
      </Card.Content>
    </Card>
  );
}
