
var request;
var service;
const apikey = 'AIzaSyDDIANXZR7wMkoTZfgwe8bHqrUKbbrkdDg';
const details = 'https://maps.googleapis.com/maps/api/place/details/json?placeid=';
const styles = [{ "featureType": "landscape", "stylers": [{ "saturation": -100 }, { "lightness": 65 }, { "visibility": "on" }] }, { "featureType": "poi", "stylers": [{ "saturation": -100 }, { "lightness": 51 }, { "visibility": "simplified" }] }, { "featureType": "road.highway", "stylers": [{ "saturation": -100 }, { "visibility": "simplified" }] }, { "featureType": "road.arterial", "stylers": [{ "saturation": -100 }, { "lightness": 30 }, { "visibility": "on" }] }, { "featureType": "road.local", "stylers": [{ "saturation": -100 }, { "lightness": 40 }, { "visibility": "on" }] }, { "featureType": "transit", "stylers": [{ "saturation": -100 }, { "visibility": "simplified" }] }, { "featureType": "administrative.province", "stylers": [{ "visibility": "off" }] }, { "featureType": "water", "elementType": "labels", "stylers": [{ "visibility": "on" }, { "lightness": -25 }, { "saturation": -100 }] }, { "featureType": "water", "elementType": "geometry", "stylers": [{ "hue": "#ffff00" }, { "lightness": -25 }, { "saturation": -97 }] }];
let btn = document.createElement("BUTTON");
btn.classList.add("btn")
btn.classList.add("btn-primary")
btn.classList.add("mt-2")
btn.innerHTML = "Review";
btn.setAttribute("id", "review")

function addReview(googleId) {
    $.ajax({
        method: "PUT",
        async: false,
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
function addPlace(request) {
    let name = $("#review").siblings().children('.title').html()
    $.ajax({
        method: "PUT",
        async: false,
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

        if (!document.getElementsByClassName('poi-info-window gm-style')[0].contains(document.getElementById('review'))) {
            document.getElementsByClassName('poi-info-window gm-style')[0].appendChild(btn);
            btn.onclick = function () {
                addPlace(request);
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
            loadMarkers(response)
        },
        error: function (response) {
            console.log("error")
        }
    });
}
function loadMarkers(response) {
    for (let place of response) {
        let service = new google.maps.places.PlacesService(map);
        service.getDetails({
            placeId: place.GoogleId
        }, function (result, status) {
            if (status == google.maps.places.PlacesServiceStatus.OK) {
                let marker = new google.maps.Marker({
                    animation: google.maps.Animation.DROP,
                    position: result.geometry.location,
                    label: {
                        text: place.Rating,
                        color: "#fff",
                        fontWeight: "bold"
                    },

                    map: map
                });

                let infowindow = new google.maps.InfoWindow({
                    content: `<h3 id="title">${place.Name}</h3>
                                    <p class="small">${result.formatted_address}</p>
                                    <h6>${place.Rating} / 5</h6>
                                    <div class="progress progress-sm">
                                        <div class="progress-bar progress-bar-animated" role="progressbar" aria-valuemin="0" aria-valuemax="100" aria-valuenow="${(place.Rating / 5 * 100)}" style="width: ${(place.Rating / 5 * 100)}%"></div>
                                    </div>
                                    <button id="review_${place.GoogleId}" class="btn btn-primary mt-2" onclick="addReview('${place.GoogleId }')">Review</button>`
                })

                marker.addListener('click', function () {
                    infowindow.open(map, marker);
                    //$(`#review_${place.GoogleId}`).click(function () { alert('Hello')})
                })
            }
        });
    }
}
function initialize() {
    let mapOptions = {
        zoom: 14,
        center: new google.maps.LatLng(37.975533, 23.735101),
        mapTypeId: google.maps.MapTypeId.ROADMAP,
    }
    let currentPositionIW = new google.maps.InfoWindow;

    map = new google.maps.Map(document.getElementById('map'), mapOptions);
    map.set('styles', styles);
    navigator.geolocation.getCurrentPosition(function (position) {
        var point = { lat: position.coords.latitude, lng: position.coords.longitude }
        currentPositionIW.setPosition(point)
        currentPositionIW.setContent('<h6 class="p-2 m-2 bg-light rounded">You are here</h6>')
        currentPositionIW.open(map);
        map.setCenter(point)
    })
    geocoder = new google.maps.Geocoder;

    getRatings();
    google.maps.event.addListener(map, 'click', function (e) { addReviewButton(e) });
}

google.maps.event.addDomListener(window, 'load', initialize);
