import { Button, Card, Image } from "semantic-ui-react";
interface Props {
  price?: number;
  companyName?: string;
  volume?: number;
  weight?: number;
}

export default function InValidQuoteReturn(props: Props) {
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
          I'm sorry, we don't know any supplier that can handle a package that
          large!
        </Card.Header>

        <Card.Description>Erm, maybe you could try NASA?</Card.Description>
      </Card.Content>
    </Card>
  );
}
