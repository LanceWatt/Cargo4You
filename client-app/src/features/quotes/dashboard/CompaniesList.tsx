import { Container, List, Segment } from "semantic-ui-react";
import { observer } from "mobx-react-lite";
import { useStore } from "../../../app/stores/store";

interface Props {}

export default observer(function CompaniesList(props: Props) {
  const { quoteStore } = useStore();

  return (
    <Container fluid>
      <Container style={{ marginTop: "7em" }}>
        <Segment raised style={{ padding: "2em" }}>
          <h3
            style={{ marginBottom: "1em", textAlign: "center", color: "black" }}
          >
            Our Shipping Partners:
          </h3>
          {quoteStore.listOfCompanies ? (
            <List relaxed>
              {quoteStore.listOfCompanies.map((company, index) => (
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
          ) : (
            <p>No companies found</p>
          )}
        </Segment>
      </Container>
    </Container>
  );
});
