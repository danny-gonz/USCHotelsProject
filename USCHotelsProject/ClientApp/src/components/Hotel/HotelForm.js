import React from "react";
import { ErrorMessage, Field, Formik, Form } from "formik";
import HotelFormSchema from "../../validationSchemas/hotelValidationSchema";

import { Button, Col, FormGroup, Label, Row } from "reactstrap";

import PropTypes from "prop-types";

function HotelForm({ searchHotelLocation }) {
  const hotelLocData = {
    city: "",
    currency: "USD",
    eapid: 1,
    locale: "en_US",
    siteId: 300000001,

    checkInDate: {
      day: "",
      month: "",
      year: "",
      fullDate: "",
    },
    checkOutDate: {
      day: "",
      month: "",
      year: "",
      fullDate: "",
    },
    rooms: [
      {
        adults: 2,
        children: [{ age: 5 }, { age: 7 }],
      },
    ],
    resultsStartingIndex: 0,
    resultsSize: 20,
    sort: "PRICE_LOW_TO_HIGH",
    filters: {
      price: { max: 150, min: 100 },
    },
  };

  const formatDate = fullDate => {
    const [year, month, day] = fullDate.split("-");
    return { year, month, day };
  };

  const onHandleSubmit = values => {
    const { checkInDate, checkOutDate } = values;

    const newValues = { ...values };

    newValues.checkInDate = formatDate(checkInDate.fullDate);
    newValues.checkOutDate = formatDate(checkOutDate.fullDate);

    searchHotelLocation(newValues);
  };

  return (
    <div>
      <Formik
        initialValues={hotelLocData}
        validationSchema={HotelFormSchema}
        onSubmit={onHandleSubmit}>
        <Form>
          <Row className='row-cols-lg-auto g-3 align-items-center'>
            <Col>
              <FormGroup>
                <Label for='city' style={{ display: "block" }}>
                  City
                </Label>
                <Field
                  type='text'
                  name='city'
                  id='city'
                  placeholder='Please enter a city name'
                />
                <ErrorMessage
                  name='city'
                  component='div'
                  style={{ color: "red" }}
                />
              </FormGroup>
            </Col>

            <Col>
              <FormGroup>
                <Label for='checkInDate' style={{ display: "block" }}>
                  Checkin Date
                </Label>
                <Field
                  type='date'
                  name='checkInDate.fullDate'
                  id='checkInDate'
                />
                <ErrorMessage
                  name='checkInDate.fullDate'
                  component='div'
                  style={{ color: "red" }}
                />
              </FormGroup>
            </Col>

            <Col>
              <FormGroup>
                <Label for='checkOutDate' style={{ display: "block" }}>
                  Checkout Date
                </Label>
                <Field
                  type='date'
                  name='checkOutDate.fullDate'
                  id='checkOutDate'
                />
                <ErrorMessage
                  name='checkOutDate.fullDate'
                  component='div'
                  style={{ color: "red" }}
                />
              </FormGroup>
            </Col>

            <Col>
              <Button type='submit'>Submit</Button>
            </Col>
          </Row>
        </Form>
      </Formik>
    </div>
  );
}

HotelForm.propTypes = {
  searchHotelLocation: PropTypes.func.isRequired,
};

export default HotelForm;
