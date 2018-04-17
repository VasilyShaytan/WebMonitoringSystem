// Write your JavaScript code.
var m_map = null,
    m_start_lat, m_start_lon = null;

m_start_lat = 60;
m_start_lon = 30;

var poly;

var gmap_div = document.getElementById('google_map');
function init_map(map_lang) { 
    google.maps.visualRefresh = true;
    if (!gmap_div) return;
    m_map = new google.maps.Map(gmap_div, {
        zoom: 10,
        center: new google.maps.LatLng(m_start_lat, m_start_lon),
        mapTypeId: google.maps.MapTypeId.ROADMAP
        //mapTypeId: t,
        //mapTypeControlOptions: { mapTypeIds: types, style: google.maps.MapTypeControlStyle.DROPDOWN_MENU },
    });
    
}
function setCoordinatePoint(lat, lng) {
    var myLatLng = { lat, lng };
    var marker = new google.maps.Marker({
        position: myLatLng,
        map: m_map,
        title: 'BMW E340'
    });
}

$(document).ready(function () {
    $('#carpark_administrator').on('click', function () {
        window.open('/Server/Index', '_blank', 'left=100,top=100,width=1200,height=800,toolbar=1,resizable=0');
    });
});
$(document).ready(function () {
    $('#carpark_registration_vehicle').on('click', function () {
        window.open('/CarPark/RegistrationVehicleIndex', '_blank', 'left=100,top=100,width=1200,height=800,toolbar=1,resizable=0');
    });
});

$(document).ready(function () {
    $('#carpark_vehicle_group_create').on('click', function () {
        window.open('/CarPark/VehicleGroupIndex', '_blank', 'left=100,top=100,width=1200,height=800,toolbar=1,resizable=0');
    });
});


function do_submit() {
    document.getElementById("all_units_list").value = calc_units(document.getElementById("all_units"));
    document.getElementById("group_units_list").value = calc_units(document.getElementById("group_units"));
    document.getElementById("form1").submit();
}

function calc_units(sel) {
    var ret = "";
    for (i = 0; i < sel.options.length; i++)
        ret += sel.options[i].value + ",";
    return ret;
}


function vehicleMove(from, to) {
    var f = document.getElementById(from);
    var t = document.getElementById(to);
    if (f.selectedIndex === -1 || f === null || t === null) return;
    var sel = f.options.item(f.selectedIndex);
    t.appendChild(sel);
    if (0) reload_parent();
}

function select_vehicle_group_in_list(vehicle_group_id) {
    var group_list = document.getElementById("VehicleGroupViewModelList");

    for (var i = 0; i < group_list.options.length; i++) {
        if (group_list.options[i].value == vehicle_group_id) {
            group_list.options[i].selected = true;
            break;
        }
    }

    //on_units_group_changed(false);
}


function route() {
    var locations = [
        ['Bondi Beach', 60.890542, 30.274856, 4],
        ['Coogee Beach', 60.923036, 30.259052, 5],
        ['Cronulla Beach', 60.028249, 30.157507, 3],
        ['Manly Beach', 60.80010128657071, 30.28747820854187, 2],
        ['Maroubra Beach', 60.950198, 30.259302, 1]
    ];
    var infowindow = new google.maps.InfoWindow();

    var marker, i;

    for (i = 0; i < locations.length; i++) {
        marker = new google.maps.Marker({
            position: new google.maps.LatLng(locations[i][1], locations[i][2]),
            map: m_map
        });

        google.maps.event.addListener(marker, 'click', (function (marker, i) {
            return function () {
                infowindow.setContent(locations[i][0]);
                infowindow.open(m_map, marker);
            }
        })(marker, i));
    }

}

function markerInfo() {
    var uluru = { lat: 60.363, lng: 31.044 };
    var contentString = '<div id="content">' +
        '<div id="siteNotice">' +
        '</div>' +
        '<h1 id="firstHeading" class="firstHeading">Uluru</h1>' +
        '<div id="bodyContent">' +
        '<p><b>Uluru</b>, also referred to as <b>Ayers Rock</b>, is a large ' +
        'sandstone rock formation in the southern part of the ' +
        'Northern Territory, central Australia. It lies 335&#160;km (208&#160;mi) ' +
        'south west of the nearest large town, Alice Springs; 450&#160;km ' +
        '(280&#160;mi) by road. Kata Tjuta and Uluru are the two major ' +
        'features of the Uluru - Kata Tjuta National Park. Uluru is ' +
        'sacred to the Pitjantjatjara and Yankunytjatjara, the ' +
        'Aboriginal people of the area. It has many springs, waterholes, ' +
        'rock caves and ancient paintings. Uluru is listed as a World ' +
        'Heritage Site.</p>' +
        '<p>Attribution: Uluru, <a href="https://en.wikipedia.org/w/index.php?title=Uluru&oldid=297882194">' +
        'https://en.wikipedia.org/w/index.php?title=Uluru</a> ' +
        '(last visited June 22, 2009).</p>' +
        '</div>' +
        '</div>';

    var infowindow = new google.maps.InfoWindow({
        content: contentString
    });

    var marker = new google.maps.Marker({
        position: uluru,
        map: m_map,
        title: 'Uluru (Ayers Rock)'
    });
    marker.addListener('click', function () {
        infowindow.open(m_map, marker);
    });
}

function proute() {

    poly = new google.maps.Polyline({
        strokeColor: '#111666',
        strokeOpacity: 1.0,
        strokeWeight: 3
    });
    poly.setMap(m_map);

    // Add a listener for the click event
    m_map.addListener('click', addLatLng);

    // Handles click events on a map, and adds a new point to the Polyline.
    
}

function addLatLng(event) {
    var path = poly.getPath();

    // Because path is an MVCArray, we can simply append a new coordinate
    // and it will automatically appear.
    path.push(event.latLng);

    // Add a new marker at the new plotted point on the polyline.
    var marker = new google.maps.Marker({
        position: event.latLng,
        title: '#' + path.getLength(),
        map: m_map
    });
}

/// Handle unit selection
function on_unit_changed() {
    route();
    markerInfo();
    proute();
    var fromSelect = document.getElementById('VehicleGroupViewModelList');
    var toSelect = document.getElementById('VehicleGroupTempList');
    toSelect.innerHTML = "";
    for (var i = 0; i < fromSelect.options.length; i++) {
        var option = fromSelect.options[i];
        toSelect.appendChild(option);
    }


    /*var vg = document.getElementById('VehicleGroupViewModelList');
    var options = vg.innerHTML;

    var vgt = document.getElementById('VehicleGroupTempList');
    var options = vgt.innerHTML + options;

    vgt.innerHTML = options;*/
        

    
    //var sel = vg.options.item(vg.item);
    //alert(JSON.stringify(sel, null, 4));
    //vgt.appendChild(sel);
}



/*var qwerty = "VVVAAASSS";

var pgp = require("pg-promise")(/*options*//*);
var db = pgp("postgres://vasily:222222@localhost:5432/dbmonitoringsystem");

db.one("SELECT $1 AS value", 123)
    .then(function (data) {
        console.log("DATA:", data.value);
    })
    .catch(function (error) {
        console.log("ERROR:", error);
    });

/*$(document).ready(function () {
    $('#testAlert').on('click', function () {
        alert("\nVASQQQ\n");
    });
});*/
