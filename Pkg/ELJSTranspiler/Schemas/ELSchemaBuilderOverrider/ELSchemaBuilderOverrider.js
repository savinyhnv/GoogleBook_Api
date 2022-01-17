define(["ELJSTranspileModuleFilter"], function(transpilerSchemaFilter) {
		return {
			/**
			 * Overrides Terrasoft.configuration.SchemaBuilder class
			 * @param {Object} transpilerPluginConfig
			 * @param {string} transpilerPluginConfig.prefix - RequireJs plugin name for js files. Will be applied
			 * only if file is considered to be loaded by plugin
			 */
			override: function(transpilerPluginConfig) {
				/** @class Terrasoft.configuration.EdenLab.overrides.SchemaBuilderV2
				 * Overrides SchemaBuilder to load modules throw RequireJS transpiler plugin
				 */
				Ext.define("Terrasoft.configuration.EdenLab.overrides.SchemaBuilderV2", {

					override: "Terrasoft.configuration.SchemaBuilder",

					/**
					 * Loads schema by plguin if it is needed
					 * @inheritDoc SchemaBuilderV2.NUI#getSchema
					 * @override
					 */
					getSchema: function(schemaName, callback, scope) {
						if (transpilerSchemaFilter.getIsTranspilationNeeded(schemaName)) {
							schemaName = transpilerPluginConfig.prefix + "!" + schemaName;
						}
						this.callParent([schemaName, callback, scope]);
					}
				});
			}
		};
	}
);