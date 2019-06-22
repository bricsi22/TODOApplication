﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
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
	})

	$("#btnUploadPhoto").click(function () 
	{
		$("#userPhotoWindow").data("kendoWindow").refresh($("#btnUploadPhoto").data("url"));

		$("#userPhotoWindow").data("kendoWindow").open();
		$("#userPhotoWindow").data("kendoWindow").center();
	});
});
