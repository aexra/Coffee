import { Link } from "react-router-dom";
import logo from "./oggetto-logo.png";

const Header = () => {
  return (
    <header>
      <div className="logo-container">
        <Link to="/home" className="logo-button">
          <img src={logo} alt="Logo" className="logo" />
        </Link>
      </div>
      <div className="right-buttons-container">
        <button className="transparent-button">О сервисе</button>
        <button className="transparent-button">Статистика</button>
        <Link to="/profile" className="transparent-button">
          Мой профиль
        </Link>
      </div>
    </header>
  );
};

export default Header;
