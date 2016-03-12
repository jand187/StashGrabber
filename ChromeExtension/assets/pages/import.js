$(function() {
	var tabsContainer = $("#tabs");
	var stash = GetStashTabs();



});


function GetStashTabs(tabsContainer) {
	$.ajax({
			url: "https://www.pathofexile.com/character-window/get-stash-items?accountName=PowerGNU&tabIndex=2&league=Standard&tabs=1",
			type: "GET",
			dataType: "json"
		})
		.done(function(json) {
			for (var i in json.tabs) {
				var tab = json.tabs[i];
				$("#tabs").append(CreateStashTabLine(tab));
			}
		})
		.fail(function() {
			console.log("error");
		})
		.always(function() {
			console.log("complete");
		});
}

function CreateStashTabLine(tab) {
	var elm = $(document.createElement("div"));
	elm.addClass("tabLine");
	elm.append('<span class="tabId">' + tab.i + '</span>');
	elm.append('<span class="tabTitle">' + tab.n + '</span>');

	var importButton = $(document.createElement("button"));
	importButton.text("Import");
	importButton.attr('data-id', tab.i);
	importButton.click(ImportTab);
	elm.append(importButton);

	return elm;
}

function ImportTab(elm, b, c) {
	var id = $(elm.target).attr('data-id');
	$.ajax({
			url: "https://www.pathofexile.com/character-window/get-stash-items?accountName=PowerGNU&tabIndex=" + id + "&league=Standard&tabs=0",
			type: "GET",
			dataType: "json"
		})
		.done(function(json) {
			PostTabToRepo(json);
		})
		.fail(function() {
			console.log("error");
		})
		.always(function() {
			console.log("complete");
		});



}

function PostTabToRepo(json) {
	$.ajax({
			url: 'http://localhost:56666/api/StashTab',
			type: 'POST',
			dataType: "json",
			contentType: "application/json",
//			data: json
			data: JSON.stringify(json)
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