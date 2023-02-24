import { Input, Menu } from "semantic-ui-react";
import Button from "semantic-ui-react/dist/commonjs/elements/Button";

export default function Navbar() {
  return (
    <Menu inverted fixed="top">
      <Menu.Item header>
        <img
          src="/assets/logo.jpg"
          alt="logo"
          style={{ marginRight: "12px" }}
        />
        Cargo4You
      </Menu.Item>
      <Menu.Item name="pricing">Pricing</Menu.Item>

      <Menu.Item name="contact">Contact</Menu.Item>
      <Menu.Item name="quotes">
        <Button positive content="Get Instant Quote"></Button>
      </Menu.Item>
      <Menu.Item>
        <Input icon="search" placeholder="Search..." />
      </Menu.Item>
    </Menu>
  );
}
