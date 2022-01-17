define("ELSchemaHierarchyUtils", [], function() {
	var structurePrefix = "Structure";

	/**
	 * @class EdenLab.utils.schemaHierarchy
	 * Class with utility methods for reflecting schemas with hierarchy
	 */
	Ext.define("EdenLab.utils.schemaHierarchy", {

		alternateClassName: "EL.utils.schemaHierarchy",

		singleton: true,

		getLastChildSchemaStructure: function(schemaName, callback, scope) {
			require([schemaName + structurePrefix], callback.bind(scope));
		},

		getLastChildSchemaUId: function(schemaName, callback, scope) {
			this.getLastChildSchemaStructure(
				schemaName,
				function(lastChildStructure) {
					callback.call(scope, (lastChildStructure || {}).schemaUId);
				},
				scope
			);
		},

		getHierarchy: function(schemaName, callback, scope) {
			(function loadParents(schemaName, parents) {
				require([schemaName + structurePrefix], function(s) {
					if (s.parentSchemaName) {
						loadParents(s.parentSchemaName, parents.concat([s.parentSchemaName]));
					} else {
						callback.call(scope, parents.reverse());
					}
				});
			})(schemaName, []);
		}
	});

	return EdenLab.utils.schemaHierarchy;
});