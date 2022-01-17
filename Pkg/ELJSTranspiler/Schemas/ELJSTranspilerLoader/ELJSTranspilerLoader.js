define(
	[
		"ELJSTranspilerConfig",
		"ELSchemaBuilderOverrider",
		"ELJSTranspilerPluginCreator"
	],
	function(
		config,
		builderOverrider,
		pluginCreator
	) {
		config = config || {};
		if (config.require) {
			requirejs.config(config.require);
		}
		var plugin = pluginCreator.create(config);
		var pluginConfig = config.plugin || {};
		if (pluginConfig.isEnabled && pluginConfig.isEnabledForSchemas) {
			builderOverrider.override(pluginConfig);
		}
		return plugin;
	}
);