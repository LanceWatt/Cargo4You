import { Container, List, Segment } from "semantic-ui-react";

interface Props {
  listOfCompanies: string[];
}

export default function CompaniesList(props: Props) {
  const { listOfCompanies } = props;

  return (
    <Container fluid>
      <Container style={{ marginTop: "7em" }}>
        <Segment raised style={{ padding: "2em" }}>
          <h3
            style={{ marginBottom: "1em", textAlign: "center", color: "black" }}
          >
            Our Shipping Partners:
          </h3>
          <List relaxed>
            {listOfCompanies.map((company, index) => (
              <List.Item key={index}>
                <List.Content style={{ textAlign: "center" }}>
                  <List.Header
                    style={{ fontSize: "1.2em", fontWeight: "bold" }}
                  >
                    {company}
                  </List.Header>
                </List.Content>
              </List.Item>
            ))}
          </List>
        </Segment>
      </Container>
    </Container>
  );
}
