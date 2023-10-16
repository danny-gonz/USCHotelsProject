import axios from "axios";

const API_HOST_PREFIX = `${process.env.REACT_APP_API_HOST_PREFIX}/api/hotel`;

const searchHotelLocation = cityHotelData => {
  const config = {
    method: "POST",
    data: cityHotelData,
    url: `${API_HOST_PREFIX}?city=${cityHotelData.city}`,
    headers: { "Content-Type": "application/json" },
    crossdomain: true,
  };
  return axios(config);
};

const hotelService = { searchHotelLocation };
export default hotelService;
