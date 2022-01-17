define({
	/**
	 * Checks whether the schema needs to be converted by transpiler
	 * @param {string} schemaName
	 * @returns {boolean}
	 */
	getIsTranspilationNeeded: function(schemaName) {
		var result = false,
			i = 0,
			allowedSchemaNameParts = ["page", "detail", "section", "v2"],
			count = allowedSchemaNameParts.length,
			endsWith = function(source, value) {return source.substr(-value.length) === value;};
		for (i; i < count; i++) {
			if (endsWith(schemaName.toLowerCase(), allowedSchemaNameParts[i].toLowerCase())) {
				result = true;
				break;
			}
		}
		return result && !!requirejs.s.contexts._.config.paths[schemaName];
	}
});