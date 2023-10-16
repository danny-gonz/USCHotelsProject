import * as Yup from "yup";

const HotelFormSchema = Yup.object().shape({
  city: Yup.string().required("City is required"),
  checkInDate: Yup.object().shape({
    fullDate: Yup.date().required("Check-in date is required"),
  }),
  checkOutDate: Yup.object().shape({
    fullDate: Yup.date().required("Check-out date is required"),
  }),
});

export default HotelFormSchema;
