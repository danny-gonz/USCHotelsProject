import React, { useState } from "react";
import HotelCard from "./HotelCard";
import hotelService from "../../services/hotelService";
import { Col, Row } from "reactstrap";
import HotelForm from "./HotelForm";
import HotelImage from "../../assets/hotel.jpg";

function Hotel() {
  const [hotelLocData, setHotelLocData] = useState({
    orgHotelData: [],
    hotelComponents: [],
  });

  const searchLocation = hotelData => {
    console.log(hotelData, "data from form");
    hotelService
      .searchHotelLocation(hotelData)
      .then(onSearchHotelLocSuccess)
      .catch(onSearchHotelLocSuccessError);
  };

  const onSearchHotelLocSuccess = data => {
    console.log("properties", data);
    let hotels = data.data;

    setHotelLocData(prevState => {
      let newHotelObj = { ...prevState };
      newHotelObj.orgHotelData = hotels;
      newHotelObj.hotelComponents = hotels.map(HotelMapper);

      return newHotelObj;
    });
  };

  const onSearchHotelLocSuccessError = error => {
    //need to let user know of error
    console.log(error.message);
  };

  const HotelMapper = hotel => {
    return (
      <Col
        md='3'
        sm='6'
        xs='12'
        key={hotel.id}
        className='mb-4'
        style={{ marginBottom: "16px" }}>
        <HotelCard hotel={hotel} />
      </Col>
    );
  };

  return (
    <div className='container'>
      <HotelForm searchHotelLocation={searchLocation} />
      <hr />
      <h1>Hotel Finder</h1>
      <Row>
        {" "}
        {hotelLocData.hotelComponents.length ? (
          hotelLocData.hotelComponents
        ) : (
          <div>
            <img src={HotelImage} alt='No hotels found' />
            <p>No hotels found</p>
          </div>
        )}
      </Row>
    </div>
  );
}

export default Hotel;
