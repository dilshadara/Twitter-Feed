$.getJSON("http://api.openweathermap.org/data/2.5/weather?q=sydney&units=imperial&appid=d2587ae982a5fb39c16a0d15f805c3fc", function (data) {

    console.log(data);
    var icon = "https://openweathermap.org/img/w/" + data.weather[0].icon + ".png";

    var temp = Math.floor(data.main.temp);
    var weather = data.weather[0].main;
    //console.log(icon);
    $('.icon').attr('src', icon);
    $('.temp').append(temp);
    $('.weather').append(weather);

});

$(function () {
    var flickrApiUrl = "https://api.flickr.com/services/feeds/photos_public.gne?jsoncallback=?";
    $.getJSON(flickrApiUrl, {
        //options
        tags: "sunrise,sunset,river,forest",
        tagmode: "any",
        format:"json"
    }).done(function (data) {
        //success
        console.log(data);
        $.each(data.items, function (index, item) {
            console.log(item);
            $("<img>").attr('src', item.media.m).appendTo("#flickr");

            if (index == 15) {
                return false;
            }
               
        });
        }).fail(function () {
            //failure
            alert("Ajax call failed.");
        })
});

//$.getJSON("https://api.twitter.com/1.1/statuses/user_timeline.json?screen_name=@ResonateAU&cout=2", function (data) {
//    console.log(data);

//});


// <div class="col-md-7">

//    <p id="flickrHeading">My Flickr Gallery</p>
//    <div id="flickr"></div>
//</div> 

//<div class="weather-container" style="width:88%">
//    <img class="icon" />
//    <p class="weather"></p>
//    <p class="temp"></p>
//</div>