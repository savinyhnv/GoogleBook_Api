define(function() {
	var prefix = "es+";
	var pluginModule = "ELJSTranspilerLoader";

	var babelConfig = {
		sourceMaps: "inline",
		presets: [["react", {development: false}]],
		plugins: [
			"proposal-async-generator-functions",
			"proposal-class-properties",
			["proposal-decorators", {decoratorsBeforeExport: true}],
			"proposal-do-expressions",
			"proposal-function-bind",
			"proposal-nullish-coalescing-operator",
			"proposal-object-rest-spread",
			"proposal-optional-catch-binding",
			"proposal-optional-chaining",
			["proposal-pipeline-operator", {proposal: "smart"}],
			"transform-async-to-generator",
			"transform-arrow-functions",
			"transform-block-scoped-functions",
			"transform-block-scoping",
			"transform-classes",
			"transform-computed-properties",
			"transform-destructuring",
			"transform-for-of",
			"transform-instanceof",
			"transform-member-expression-literals",
			"transform-object-super",
			"transform-parameters",
			"transform-property-literals",
			"transform-property-mutators",
			"transform-regenerator",
			"transform-reserved-words",
			"transform-shorthand-properties",
			"transform-spread",
			"transform-template-literals",
			"transform-typeof-symbol"
		]
	};

	var pluginConfig = {
		isEnabled: true,
		isEnabledForSchemas: true,
		prefix: prefix,
		moduleName: pluginModule
	};

	var requireConfig = {map: {"*": {}}};
	requireConfig.map["*"][prefix] = pluginModule;

	return {
		babel: babelConfig,
		plugin: pluginConfig,
		require: requireConfig
	};
});