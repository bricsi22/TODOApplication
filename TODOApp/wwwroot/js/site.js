// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
	$("#userPhotoWindow").kendoWindow({
		width: "600px",
		title: "User Photo",
		modal: true,
		visible: false,
		actions: [
			"Pin",
			"Minimize",
			"Maximize",
			"Close"
		]
	});

	$("#userTodoItemsWindow").kendoWindow({
		width: "600px",
		title: "User Photo",
		modal: true,
		visible: false,
		actions: [
			"Pin",
			"Minimize",
			"Maximize",
			"Close"
		]
	})

	$("#btnUploadPhoto").click(function () 
	{
		$("#userPhotoWindow").data("kendoWindow").refresh($("#btnUploadPhoto").data("url"));

		$("#userPhotoWindow").data("kendoWindow").open();
		$("#userPhotoWindow").data("kendoWindow").center();
	});
});

function GetUserTodoItems(userId) {
	var userTodoItemsWindow = $("#UserTodoItemsWindow").data("kendoWindow");
	if (!userTodoItemsWindow) {
		userTodoItemsWindow = $("#UserTodoItemsWindow").kendoWindow({
			width: "600px",
			height: "620px",
			title: "User Todo List",
			modal: true,
			visible: false,
			actions: [
				"Pin",
				"Minimize",
				"Maximize",
				"Close"
			]
		}).data("kendoWindow");
	}
	var refreshUrl = $("#UserTodoItemsUrl").val();
	refreshUrl = refreshUrl.replace("/0", "/" + userId)
	userTodoItemsWindow.refresh(refreshUrl);
	userTodoItemsWindow.center();
	userTodoItemsWindow.open();
}

function getTodoGridAdditionaData() {
	return {
		userId: $("#Id").val()
	}
}