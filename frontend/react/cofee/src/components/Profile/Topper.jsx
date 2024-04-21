import youtube from "./Vector.png";

export default function Topper() {
  return (
    <>
      <div className="topper">
        <div className="user-foto" />
        <div className="main-info">
          <div className="topper-text">Алексей Алексеев</div>
          <div className="social">
            <img src={youtube} alt="yt" />
          </div>
        </div>
      </div>
      ;
    </>
  );
}
