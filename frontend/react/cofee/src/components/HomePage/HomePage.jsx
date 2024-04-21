import React from "react";
import Header from "./Header";
import CallsOverlay from "./CallsOverlay";
import CalendarOverlay from "./CalendarOverlay";
import PhotosOverlay from "./PhotosOverlay";
import logo from "./ogetto_logo.png";
export default function HomePage() {
  return (
    <>
      <Header />
      <CallsOverlay />
      <CalendarOverlay />
      <h1 className="overlay-title">Совместные фотографии</h1>
      <PhotosOverlay />
      <img src={logo} className="bottom-right-image" alt="Description" />
    </>
  );
}
