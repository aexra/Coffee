import Header from "../HomePage/Header";
import Info from "./Info";
import "./Profile.css";
import Topper from "./Topper";
import PhotoGrid from "./PhotoGrid";

export default function ProfilePage() {
  return (
    <>
      <Header />
      <Topper />
      <h1 className="info1">Информация</h1>
      <Info />
      <PhotoGrid />
    </>
  );
}
