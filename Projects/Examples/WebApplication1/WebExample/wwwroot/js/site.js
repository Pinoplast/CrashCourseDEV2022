// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function getWeatherForecast() {
	
	document.querySelector(".weather-block").appendChild(document.createElement("hr"));
	return $.ajax({
		url: "https://localhost:7081/WeatherForecast",
		success: (data) => {
			let weatherParentElement = document.querySelector(".weather-block");
			let weatherBlock = document.createElement("div");
			for (var i in data) {
				let infoDate, infoSummary, infoTempC, infoTempF;
				let oneRow = document.createElement("p");
				
				oneRow.innerHTML = "day " + new Date(data[i].date).getDay()
					+ "<br>summary = " + data[i].summary
					+ "<br>temperature celcium = " + data[i].temperatureC
					+ "<br>temperature farinheit = " + data[i].temperatureF;
				
				weatherBlock.appendChild(oneRow);
			}

			weatherParentElement.appendChild(weatherBlock);
			console.log(data);
		}
	});
}
