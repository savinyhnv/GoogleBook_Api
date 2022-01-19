define("ELBook3c6f0817Section", [], function() {
	return {
		entitySchemaName: "ELBook",
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "AddBooksButton",
				"parentName": "ActionButtonsContainer",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.BUTTON,
					"style": Terrasoft.controls.ButtonEnums.style.GREEN,
					"caption": { "bindTo": "Resources.Strings.DownloadGoogleBooks" }
				}
			}
		]/**SCHEMA_DIFF*/,
		methods: {}
	};
});
