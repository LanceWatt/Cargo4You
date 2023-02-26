import { Button, Card, Image } from "semantic-ui-react";
import { observer } from "mobx-react-lite";

export default observer(function InvalidQuoteReturn() {
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
});
