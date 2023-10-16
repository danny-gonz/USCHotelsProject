import React from "react";
import PropTypes from "prop-types";
import {
  Button,
  Card,
  CardBody,
  CardImg,
  CardSubtitle,
  CardText,
  CardTitle,
} from "reactstrap";

function HotelCard({ hotel }) {
  return (
    <Card style={{ display: "flex", flexDirection: "column" }}>
      <CardImg
        alt='Card image cap'
        src={hotel.propertyImage.image.url}
        top
        width='100%'
        style={{ height: "200px", objectFit: "cover" }}
      />
      <CardBody style={{ height: "100px", overflow: "hidden", flex: 1 }}>
        <CardTitle tag='h5' style={{ height: "75px" }}>
          {hotel.name}
        </CardTitle>
        <CardSubtitle className='mb-2 text-muted' tag='h6'>
          {hotel.destinationInfo.distanceInfo || "No data available"}
        </CardSubtitle>
        <CardText style={{ height: "100px", overflow: "hidden" }}>
          Distinctio non error voluptatibus consequatur et vitae veniam libero.
        </CardText>
        <Button>Button</Button>
      </CardBody>
    </Card>
  );
}
HotelCard.propTypes = {
  hotel: PropTypes.shape({
    name: PropTypes.string,
    destinationInfo: PropTypes.shape({
      distanceInfo: PropTypes.string,
    }),
    propertyImage: PropTypes.shape({
      image: PropTypes.shape({ url: PropTypes.string.isRequired }),
    }),
  }).isRequired,
};

export default React.memo(HotelCard);
