﻿
var request;
var service;
let btn;
var labels = []
var labelIndex = 0;
let markers = [];
var apikey = 'AIzaSyDDIANXZR7wMkoTZfgwe8bHqrUKbbrkdDg';
var details = 'https://maps.googleapis.com/maps/api/place/details/json?placeid=';
var styles = [{ "featureType": "landscape", "stylers": [{ "saturation": -100 }, { "lightness": 65 }, { "visibility": "on" }] }, { "featureType": "poi", "stylers": [{ "saturation": -100 }, { "lightness": 51 }, { "visibility": "simplified" }] }, { "featureType": "road.highway", "stylers": [{ "saturation": -100 }, { "visibility": "simplified" }] }, { "featureType": "road.arterial", "stylers": [{ "saturation": -100 }, { "lightness": 30 }, { "visibility": "on" }] }, { "featureType": "road.local", "stylers": [{ "saturation": -100 }, { "lightness": 40 }, { "visibility": "on" }] }, { "featureType": "transit", "stylers": [{ "saturation": -100 }, { "visibility": "simplified" }] }, { "featureType": "administrative.province", "stylers": [{ "visibility": "off" }] }, { "featureType": "water", "elementType": "labels", "stylers": [{ "visibility": "on" }, { "lightness": -25 }, { "saturation": -100 }] }, { "featureType": "water", "elementType": "geometry", "stylers": [{ "hue": "#ffff00" }, { "lightness": -25 }, { "saturation": -97 }] }];

function initialize() {
    let mapOptions = {
        zoom: 14,
        center: new google.maps.LatLng(37.975533, 23.735101),
        mapTypeId: google.maps.MapTypeId.ROADMAP,
    }
    function addPlace(request) {
        let name = $("#review").siblings().children('.title').html()
        $.ajax({
            method: "PUT",
            url: "/Rest/Place",
            data: {
                Address: request.address,
                Name: name,
                GoogleId: request.place_id
            },
            success: function (response) {
                console.log("success-place");
            }
        })
    }
    function addReview(googleId) {
        $.ajax({
            method: "PUT",
            url: "/Rest/Review",
            data: { googleId: googleId },
            success: function (response) {
                window.location.assign("/Reviews/Edit/" + response);
                console.log("success-review");
            },
            error: function (response) {
                console.log('error-adding-review')
            }
        })
    }
    function addReviewButton(e) {
        geocoder.geocode({ 'location': e.latLng }, function (results, status) {
            if (status === google.maps.GeocoderStatus.OK) {
                if (results[0]) {
                    request = {
                        //position: results[0].geometry.location,
                        location: e.latLng,
                        place_id: results[0].place_id,
                        address: results[0].formatted_address
                    };
                } else {
                    console.log('No results found');
                }
            } else {
                console.log('Geocoder failed due to: ' + status);
            }
            btn = document.createElement("BUTTON");
            if (!document.getElementsByClassName('poi-info-window gm-style')[0].contains(document.getElementById('review'))) {
                document.getElementsByClassName('poi-info-window gm-style')[0].appendChild(btn);
                btn.innerHTML = "Review";
                btn.setAttribute("id", "review")
                btn.onclick = function () {
                    addPlace(request);
                    console.log(request.place_id)
                    addReview(request.place_id);
                }
            }
        });
    }
    function getRatings() {
        $.ajax({
            method: "GET",
            url: "Rest/Ratings",
            success: function (response) {
                console.log("Success")
                console.log("response " + response)
                loadMarkers(response)
            },
            error: function (response) {
                console.log(response)
                console.log("error")
            }
        });
    }
    function loadMarkers(response) {
        for (let place of response) {
            var service = new google.maps.places.PlacesService(map);
            service.getDetails({
                placeId: place.GoogleId
            }, function (result, status) {
                console.log(result)
                if (status == google.maps.places.PlacesServiceStatus.OK) {
                    var marker = new google.maps.Marker({
                        animation: google.maps.Animation.DROP,
                        position: result.geometry.location,
                        label: {
                            text: place.Rating,
                            color: "#fff",
                            fontWeight: "bold"
                        },

                        map: map
                    });
                    var infowindow = new google.maps.InfoWindow({
                        content: `<div id="title">${result.name}</div>
    <h3>${place.Rating}</h3>
    <p>${result.formatted_address}</p>`

                    })
                    marker.addListener('click', function () { infowindow.open(map, marker); })

                }
            });
        }
    }

    map = new google.maps.Map(document.getElementById('map'), mapOptions);
    map.set('styles', styles);
    geocoder = new google.maps.Geocoder;

    getRatings();
    google.maps.event.addListener(map, 'click', function (e) { addReviewButton(e) });
}
google.maps.event.addDomListener(window, 'load', initialize);