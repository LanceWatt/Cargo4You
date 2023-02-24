import React from "react";
import { Container, Header, Icon, List } from "semantic-ui-react";

const ContactPage: React.FC = () => {
  return (
    <Container style={{ marginTop: "7em" }}>
      <Header as="h2" icon textAlign="center">
        <Icon name="envelope outline" circular />
        <Header.Content>Contact Us</Header.Content>
      </Header>
      <Container textAlign="center" style={{ marginTop: "2em" }}>
        <p>
          Thank you for your interest in our company. We'd love to hear from
          you!
        </p>
        <p>Please feel free to contact us by email or phone:</p>
        <List divided verticalAlign="middle" size="big">
          <List.Item>
            <List.Content floated="right">
              <a href="mailto:info@cargo4you.com">
                <Icon name="mail" />
                info@cargo4you.com
              </a>
            </List.Content>
            <List.Content>
              <Icon name="envelope" />
              Email
            </List.Content>
          </List.Item>
          <List.Item>
            <List.Content floated="right">
              <Icon name="phone" />
              +1 555-123-4567
            </List.Content>
            <List.Content>
              <Icon name="phone" />
              Phone
            </List.Content>
          </List.Item>
        </List>
      </Container>
    </Container>
  );
};

export default ContactPage;
