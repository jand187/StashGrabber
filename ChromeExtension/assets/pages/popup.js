$(function() {

	GetStashTabs();

});



function GetStashTabs() {
	$.ajax({
			url: "https://www.pathofexile.com/character-window/get-stash-items?accountName=PowerGNU&tabIndex=2&league=Standard&tabs=0",
			type: "GET",
			dataType: "json"
		})
		.done(function() {
			console.log("success");
		})
		.fail(function() {
			console.log("error");
		})
		.always(function() {
			console.log("complete");
		});

}