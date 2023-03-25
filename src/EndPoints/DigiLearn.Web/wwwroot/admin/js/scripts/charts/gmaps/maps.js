/*=========================================================================================
    File Name: maps.js
    Description: google maps
==========================================================================================*/

// Gmaps Maps
// ------------------------------
$(window).on("load", function () {

	// Basic Map
	// ------------------------------
	var map = new GMaps({
		div: '#basic-map',
		lat: 9.0820,
		lng: 8.6753,
		zoom: 7
	});

	map.addMarker({
		lat: 9.0765,
		lng: 7.3986,
		title: 'نشانگر 1',
		draggable: true,
	});

	// Info Window
	// ------------------------------
	var mapInfo = new GMaps({
		div: '#info-window',
		lat: 47.4073,
		lng: 7.7526,
		zoom: 7
	});
	// marker added in map
	mapInfo.addMarker({
		lat: 47.4073,
		lng: 7.76,
		title: 'نشانگر 1',
		infoWindow: {
			content: '<p class="m-1 primary-font">نشانگر 1</p>'
		}
	});
	mapInfo.addMarker({
		lat: 47.3769,
		lng: 8.5417,
		title: 'نشانگر 2',
		infoWindow: {
			content: '<p class="m-1 primary-font">نشانگر 2</p>'
		}
	});
	mapInfo.addMarker({
		lat: 46.9480,
		lng: 7.4474,
		title: 'نشانگر 3',
		infoWindow: {
			content: '<p class="m-1 primary-font">نشانگر 3</p>'
		}
	});

	// Street View Markers
	// ------------------------------
	var mapStreet = GMaps.createPanorama({
		el: '#street-view',
		lat: 52.201272,
		lng: 0.118720,
	});

	// Random Value for street heading
	$(".street-heading").on("click", function () {
		mapStreet = GMaps.createPanorama({
			el: '#street-view',
			lat: 52.201272,
			lng: 0.118720,
			pov: {
				heading: Math.random() * 360,
				pitch: 5
			}
		});
	});

	// Random Value for street Pitch
	$(".street-pitch").on("click", function () {
		mapStreet = GMaps.createPanorama({
			el: '#street-view',
			lat: 52.201272,
			lng: 0.118720,
			pov: {
				heading: 20,
				pitch: Math.random() * 180 - 90
			}
		});
	});

	// Random Value for both street heading and street pitc
	$(".street-both").on("click", function () {
		map = GMaps.createPanorama({
			el: '#street-view',
			lat: 52.201272,
			lng: 0.118720,
			pov: {
				heading: Math.random() * 360,
				pitch: Math.random() * 180 - 90
			}
		});
	});

	// Bicycling layer map
	// ------------------------------
	var bicycleMapOptions = {
			zoom: 14,
			center: new google.maps.LatLng(42.3726399, -71.1096528)
		},
		bicycle_map = new google.maps.Map(document.getElementById("bicycle-map"), bicycleMapOptions),
		bikeLayer = new google.maps.BicyclingLayer();
	bikeLayer.setMap(bicycle_map);

	// Trafic layer map
	// ------------------------------
	var trafficMapOptions = {
			zoom: 13,
			center: new google.maps.LatLng(51.5, -0.11)
		},
		traffic_map = new google.maps.Map(document.getElementById("transit-map"), trafficMapOptions),
		trafficLayer = new google.maps.TrafficLayer();
	trafficLayer.setMap(traffic_map);
});