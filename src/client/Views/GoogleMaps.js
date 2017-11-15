export default function (mapElement) {
    if (!mapElement) { return; }
    // For more options see: https://developers.google.com/maps/documentation/javascript/reference#MapOptions
    var mapOptions = {
        zoom: 14,
        center: new google.maps.LatLng(-36.784924, 175.03),
        styles: [
            {
                "featureType": "all",
                "elementType": "geometry.fill",
                "stylers": [
                    {
                        "weight": "2.00"
                    }
                ]
            },
            {
                "featureType": "all",
                "elementType": "geometry.stroke",
                "stylers": [
                    {
                        "color": "#9c9c9c"
                    }
                ]
            },
            {
                "featureType": "all",
                "elementType": "labels.text",
                "stylers": [
                    {
                        "visibility": "on"
                    }
                ]
            },
            {
                "featureType": "landscape",
                "elementType": "all",
                "stylers": [
                    {
                        "color": "#f2f2f2"
                    }
                ]
            },
            {
                "featureType": "landscape",
                "elementType": "geometry.fill",
                "stylers": [
                    {
                        "color": "#ffffff"
                    }
                ]
            },
            {
                "featureType": "landscape.man_made",
                "elementType": "geometry.fill",
                "stylers": [
                    {
                        "color": "#ffffff"
                    }
                ]
            },
            {
                "featureType": "poi",
                "elementType": "all",
                "stylers": [
                    {
                        "visibility": "off"
                    }
                ]
            },
            {
                "featureType": "road",
                "elementType": "all",
                "stylers": [
                    {
                        "saturation": -100
                    },
                    {
                        "lightness": 45
                    }
                ]
            },
            {
                "featureType": "road",
                "elementType": "geometry.fill",
                "stylers": [
                    {
                        "color": "#eeeeee"
                    }
                ]
            },
            {
                "featureType": "road",
                "elementType": "labels.text.fill",
                "stylers": [
                    {
                        "color": "#7b7b7b"
                    }
                ]
            },
            {
                "featureType": "road",
                "elementType": "labels.text.stroke",
                "stylers": [
                    {
                        "color": "#ffffff"
                    }
                ]
            },
            {
                "featureType": "road.highway",
                "elementType": "all",
                "stylers": [
                    {
                        "visibility": "simplified"
                    }
                ]
            },
            {
                "featureType": "road.arterial",
                "elementType": "labels.icon",
                "stylers": [
                    {
                        "visibility": "off"
                    }
                ]
            },
            {
                "featureType": "transit",
                "elementType": "all",
                "stylers": [
                    {
                        "visibility": "off"
                    }
                ]
            },
            {
                "featureType": "water",
                "elementType": "all",
                "stylers": [
                    {
                        "color": "#6c8099"
                    },
                    {
                        "visibility": "on"
                    }
                ]
            },
            {
                "featureType": "water",
                "elementType": "geometry.fill",
                "stylers": [
                    {
                        "color": "#6c8099"
                    }
                ]
            },
            {
                "featureType": "water",
                "elementType": "labels.text.fill",
                "stylers": [
                    {
                        "color": "#070707"
                    }
                ]
            },
            {
                "featureType": "water",
                "elementType": "labels.text.stroke",
                "stylers": [
                    {
                        "color": "#ffffff"
                    }
                ]
            }
        ]
    };

    var map = new google.maps.Map(mapElement, mapOptions);

    new google.maps.Marker({
        position: new google.maps.LatLng(-36.7805102,174.9915019),
        map: map,
        icon: { url: './PassengerFerry.svg' },
        title: 'Passenger Ferry'
    });

    new google.maps.Marker({
        position: new google.maps.LatLng(-36.809152, 175.026569),
        map: map,
        icon: { url: './CarFerry.svg' },
        title: 'Car Ferry'
    });

    new google.maps.Marker({
        position: new google.maps.LatLng(-36.779348, 175.021618),
        map: map,
        icon: { url: './Rings.svg' },
        title: 'Ceremony'
    });
    
    new google.maps.Marker({
        position: new google.maps.LatLng(-36.789135, 175.067011),
        map: map,
        icon: { url: './Wine.svg' },
        title: 'Reception at Casita Miro'
    });

    new google.maps.Marker({
        position: new google.maps.LatLng(-36.787051, 175.077597),
        map: map,
        icon: { url: './Rest.svg' },
        title: 'Rest'
    });
}

//https://www.google.co.nz/maps/place/Fullers+Ferry+Waiheke+Island/
//@,16.75z/data=!4m5!3m4!1s0x6d72cb97197f0779:0x787cd3e8f8a1fec2!8m2!3d-36.7804506!4d174.9920341