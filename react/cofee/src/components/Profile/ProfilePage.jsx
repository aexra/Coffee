import Header from "../HomePage/Header";
import "./Profile.css";
import youtube from "./Vector.png";

export default function ProfilePage() {
  return (
    <>
      <Header />
      <div className="topper">
        <div className="user-foto" />
        <div className="main-info">
          <div className="topper-text">Алексей Алексеев</div>
          <div className="social">
            <img src={youtube} alt="yt" />
          </div>
        </div>
      </div>
      <h1 className="info1">Информация</h1>
      <div className="info">
        <div className="substatick">
          <h2>Должность</h2>
          <div className="prof">Веб-дизайнер</div>
          <h3>Дата поступления на работу</h3>
          <div className="datep">14.88.1488</div>
        </div>
        <div className="subunstat">
          <h4>Хобби</h4>
          <div className="hobby">
            <span>
              Путешествия
              <br />
            </span>
            <span>Конный спорт</span>
          </div>
          <h5>Любимый кофе</h5>
          <div className="coffee">Любимый кофе</div>
        </div>
      </div>
      <div className="photo-grid">
        <div className="photo"></div>
        <div className="photo"></div>
        <div className="photo"></div>
        <div className="photo"></div>
        <div className="photo"></div>
        <div className="photo"></div>
      </div>
    </>
  );
}
